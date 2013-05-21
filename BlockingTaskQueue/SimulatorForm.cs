using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Concurrent;
using Interfaces;
using System.Configuration;
using System.Reflection;
using System.IO;

namespace BlockingTaskQueue
{
    public partial class MainForm : Form
    {
        public delegate void NewResultDelegate(GeneralTaskEventArgs args);
        public NewResultDelegate _resultDelegate;

        // Maps task descriptions to their concrete class from the tasks assembly.
        private Dictionary<String, TaskObject> _taskDescriptionToObject;

        private Dictionary<Type, String> _concreteEventArgsToTaskDescription;
        
        //// TODO: extend to many assemblies in the configuration.
        private String _tasksAssemblyName;
        private Assembly _tasksAssembly;
        private Assembly _thisAssembly;

        public MainForm()
        {
            InitializeComponent();

            // TODO: sanity checks
            _tasksAssemblyName = ConfigurationManager.AppSettings["TasksAssembly"];
            _tasksAssembly = Assembly.LoadFrom(_tasksAssemblyName);
            _thisAssembly = Assembly.GetAssembly(this.GetType());

            // TODO: implement a prefix for each task name, don't use Count!
            _taskDescriptionToObject = new Dictionary<string, TaskObject>(ConfigurationManager.AppSettings.Count);
            _concreteEventArgsToTaskDescription = new Dictionary<Type, string>(ConfigurationManager.AppSettings.Count);

            foreach (var key in ConfigurationManager.AppSettings.AllKeys)
            {
                if (key != "TasksAssembly")
                {
                    String[] concreteTypeNamesAndOperandsRequired = ConfigurationManager.AppSettings[key].Split(',');
                    Type taskConcreteType = _tasksAssembly.GetType(concreteTypeNamesAndOperandsRequired[0]);
                    Type taskResultType = _thisAssembly.GetType(concreteTypeNamesAndOperandsRequired[1]);
                    Type taskConcreteEventArgsType = _thisAssembly.GetType(concreteTypeNamesAndOperandsRequired[2]);

                    _taskDescriptionToObject.Add(key, new TaskObject(taskConcreteType, taskResultType, Int32.Parse(concreteTypeNamesAndOperandsRequired[3]), "true" == concreteTypeNamesAndOperandsRequired[4]));
                    _concreteEventArgsToTaskDescription.Add(taskConcreteEventArgsType, key);
                    tasksComboBox.Items.Add(key);
                }
            }

            _resultDelegate = new NewResultDelegate(AddResultToList);
        }

        private void startDequeueButton_Click(object sender, EventArgs e)
        {
            Int32 dequeueThreads;

            // Sanity checks.
            if (!Int32.TryParse(dequeueThreadsTextBox.Text, out dequeueThreads))
            {
                throw new ArgumentException("Expected a number as number of de-queuing worker threads.");
            }

            if (dequeueThreads < 1)
            {
                throw new ArgumentException("Expected at least 1 de-queuing worker threads.");
            }

            BlockingTaskQueue.TaskQueue.Dequeue(dequeueThreads);
        }

        private void queueButton_Click(object sender, EventArgs e)
        {
            Int32 queueingThreads;
            Int32 tasksPerThread;

            // Sanity checks.
            if (!Int32.TryParse(queueThreadsTextBox.Text, out queueingThreads))
            {
                throw new ArgumentException("Expected a number as number of queuing worker threads.");
            }
            if (queueingThreads < 1)
            {
                throw new ArgumentException("Expected at least 1 queuing worker threads.");
            }
            if (!Int32.TryParse(tasksPerThreadTextBox.Text, out tasksPerThread))
            {
                throw new ArgumentException("Expected a number as the number of tasks each queuing thread will enqueue.");
            }
            if (tasksPerThread < 1)
            {
                throw new ArgumentException("Expected at least 1 tasks to be enqueued by each thread.");
            }

            // Create instances of the task and the result-action.
            Object taskInstance = null;
            Object resultInstance = null;

            TaskObject taskObj = _taskDescriptionToObject[tasksComboBox.Text];

            // Instantiate the concrete result class
            if (!taskObj.RequiresInput)
            {
                resultInstance = Activator.CreateInstance(taskObj.ConcreteActionAndResult.Value);
            }
            
            if (taskObj.OperandsRequired == 1)
            {
                if (taskObj.RequiresInput)
                {
                    SingleOperandInput soi = new SingleOperandInput() { Operand = operand1TextBox.Text };
                    resultInstance = Activator.CreateInstance(taskObj.ConcreteActionAndResult.Value, new Object[] { soi });
                }
                taskInstance = Activator.CreateInstance(taskObj.ConcreteActionAndResult.Key, new Object[] { operand1TextBox.Text, resultInstance });
            }
            else if (taskObj.OperandsRequired == 2)
            {
                if (taskObj.RequiresInput)
                {
                    TwoOperandsInput toi = new TwoOperandsInput() { Operand1 = operand1TextBox.Text, Operand2 = operand2TextBox.Text };
                    resultInstance = Activator.CreateInstance(taskObj.ConcreteActionAndResult.Value, new Object[] { operand1TextBox.Text, operand2TextBox.Text });
                }
                taskInstance = Activator.CreateInstance(taskObj.ConcreteActionAndResult.Key, new Object[] { operand1TextBox.Text, operand2TextBox.Text, resultInstance });
            }
            else
            {
                throw new NotImplementedException("Not supporting more than 2 operands.");
            }

            ((ITask)taskInstance).ResultAction.Changed += NewResult;
            // Enqueue the task the amount of times specified, using the amount of threads specified.
            EnqueueConcurrent(queueingThreads, tasksPerThread, taskInstance);
        }

        private void NewResult(object state, GeneralTaskEventArgs args)
        {
            if (InvokeRequired)
            {
                Invoke(_resultDelegate, new object[] { args });
            }
            else
            {
                _resultDelegate(args);
            }
        }

        private void AddResultToList(GeneralTaskEventArgs args)
        {
            outputListBox.Items.Add(String.Format("{0} Result (Worker thread #{1})", _concreteEventArgsToTaskDescription[args.GetType()], args.SourceThreadId));
            outputListBox.Items.Add(args.ToString());
        }

        private void EnqueueConcurrent(Int32 queueingThreads, Int32 tasksPerThread, Object task)
        {
            for (Int32 i = 0; i < queueingThreads; i++)
            {
                Thread queueingThread = new Thread(new ParameterizedThreadStart(EnqueueTasksThreadFunc));
                EnqueingObject enqueueObj = new EnqueingObject() { Task = task, TasksToEnqueue = tasksPerThread };
                queueingThread.Start(enqueueObj);
            }
        }

        public static void EnqueueTasksThreadFunc(Object state)
        {
            EnqueingObject enqueueObj = state as EnqueingObject;
            if (enqueueObj == null)
            {
                throw new ArgumentNullException();
            }

            for (Int32 i = 0; i < enqueueObj.TasksToEnqueue; i++)
            {
                // If this isn't a real ITask, a run-time exception will be thrown.
                BlockingTaskQueue.TaskQueue.Enqueue((ITask)enqueueObj.Task);
            }
        }

        private void tasksComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 operandsRequired = _taskDescriptionToObject[tasksComboBox.Text].OperandsRequired;
            if (operandsRequired == 1)
            {
                if (operand2Label.Visible)
                {
                    operand2Label.Visible = false;
                    operand2TextBox.Visible = false;
                }
            }
            else if (operandsRequired == 2)
            {
                if (!operand2Label.Visible)
                {
                    operand2Label.Visible = true;
                    operand2TextBox.Visible = true;
                }
            }
        }
    }
}