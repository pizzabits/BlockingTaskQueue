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
using Task;
using System.Configuration;
using System.Reflection;

namespace BlockingTaskQueue
{
    public partial class MainForm : Form
    {
        // Maps task name to its qualified type name in the tasks assembly.
        private Dictionary<String, String> _taskNameToType;

        //// TODO: extend to many assemblies in the configuration.
        private String _tasksAssemblyName;

        private Assembly _tasksAssembly;

        // TODO: add a number-of-operands for each task to the configuration.
        private Boolean _isOneOperand = false;

        public MainForm()
        {
            InitializeComponent();

            // TODO: sanity checks
            _tasksAssemblyName = ConfigurationManager.AppSettings["TasksAssembly"];
            _tasksAssembly = Assembly.LoadFrom(_tasksAssemblyName);

            // TODO: implement a prefix for each task name, don't use Count!
            _taskNameToType = new Dictionary<String, String>(ConfigurationManager.AppSettings.Count);

            foreach (var key in ConfigurationManager.AppSettings.AllKeys)
            {
                // TODO: The following part SHOULD be done using an injection mechanism
                // (IoC, such as Unity/spring.net)
                // to determine which class that implements ITask is needed.
                // String --> class : ITask
                // Using this mechanism, I wouldn't have to define those classes in this assembly.

                if (key != "TasksAssembly")
                {
                    _taskNameToType.Add(key, ConfigurationManager.AppSettings[key]);
                    tasksComboBox.Items.Add(key);
                }
            }
        }

        private Thread[] _queuingThreads;

        private void startDequeueButton_Click(object sender, EventArgs e)
        {
            //TaskQueue.TaskQueue.
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

            // Create the task exactly once.
            Object task;
            Type taskConcreteType = _tasksAssembly.GetType(_taskNameToType[tasksComboBox.Text]);
            
            if (_isOneOperand)
            {
                task = Activator.CreateInstance(taskConcreteType, new Object[] { operand1TextBox.Text } );
            }
            else
            {
                task = Activator.CreateInstance(taskConcreteType, new Object[] { operand1TextBox.Text, operand2TextBox.Text });
            }

            // Enqueue it many times, in multiple threads
            EnqueueConcurrent(queueingThreads, tasksPerThread, task);
        }

        private void EnqueueConcurrent(Int32 queueingThreads, Int32 tasksPerThread, Object task)
        {
            _queuingThreads = new Thread[queueingThreads];

            for (Int32 i = 0; i < queueingThreads; i++)
            {
                _queuingThreads[i] = new Thread(new ParameterizedThreadStart(EnqueueTasksThreadFunc));

                EnqueingObject enqueueObj = new EnqueingObject() { Task = task, TasksToEnqueue = tasksPerThread };
                _queuingThreads[i].Start(enqueueObj);
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
                TaskQueue.TaskQueue.Enqueue((ITask)enqueueObj.Task);
            }
        }
    }
}
