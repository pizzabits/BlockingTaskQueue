using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Concurrent;
using System.Threading;
using Task;

namespace TaskQueue
{
    public static class TaskQueue
    {
        private static int _totalQueued = 0;
        private static ConcurrentQueue<ITask> _queue = new ConcurrentQueue<ITask>();
        private static List<Thread> _dequeueThreads = new List<Thread>(100);

        public static void Enqueue(ITask task)
        {
            if (task == null)
            {
                throw new ArgumentNullException("task is null.");
            }

            _queue.Enqueue(task);
            Interlocked.Increment(ref _totalQueued);
        }


        public static void Dequeue(Int32 workers)
        {
            for (Int32 i = 0; i < workers; i++)
            {
                //Timer timer = new Timer(new TimerCallback(DequeueThreadFunc), null, 0, 
                Thread worker = new Thread(new ThreadStart(DequeueThreadFunc));
                worker.Start();
                _dequeueThreads.Add(worker);
            }
        }

        public static void DequeueThreadFunc()
        {
            ITask task;

            while (true)
            {
                if (_queue.IsEmpty)
                { // Wait indefinitely until there is something to de-queue.
                    Thread.Sleep(100);
                }
                else if (_queue.TryDequeue(out task))
                {
                    IResult result = task.Run();

                    // now update the GUI!
                }
            }
        }
    }
}