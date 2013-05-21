using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Concurrent;
using System.Threading;
using Interfaces;

namespace BlockingTaskQueue
{
    public static class TaskQueue
    {
        private static Int32 _threadCount = 0;
        private static ConcurrentQueue<ITask> _queue = new ConcurrentQueue<ITask>();
        private static List<Thread> _dequeueThreads = new List<Thread>(100);

        public static void Enqueue(ITask task)
        {
            if (task == null)
            {
                throw new ArgumentNullException("task is null.");
            }

            _queue.Enqueue(task);
        }


        public static void Dequeue(Int32 workers)
        {
            for (Int32 i = 0; i < workers; i++)
            {
                Thread worker = new Thread(new ThreadStart(DequeueThreadFunc));
                 // Worker threads will not keep an application running after all foreground threads have exited.
                worker.IsBackground = true;
                worker.Name = Interlocked.Increment(ref _threadCount).ToString();
                _dequeueThreads.Add(worker);
                worker.Start();
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
                    task.Run();
                }
            }
        }
    }
}