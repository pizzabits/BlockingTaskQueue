using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Interfaces;

namespace BlockingTaskQueue
{
    public class AddIntegersEventArgs : GeneralTaskEventArgs
    {
        public readonly Int32 Result;
        public AddIntegersEventArgs(Int32 sourceThreadId, Int32 result)
        {
            SourceThreadId = sourceThreadId;
            Result = result;
        }
        public override string ToString()
        {
            return String.Format("Sum is {0}", Result);
        }
    }

    public class AddIntegersResult : ResultBase
    {
        public override void NotifyResult(object result)
        {
            AddIntegersEventArgs args = new AddIntegersEventArgs(Int32.Parse(Thread.CurrentThread.Name), (Int32)result);
            OnChanged(args);
        }
    }
}