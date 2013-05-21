using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Contracts;

namespace Callbacks
{
    public class ConcatenateStringsEventArgs : GeneralTaskEventArgs
    {
        public readonly String Result;
        public ConcatenateStringsEventArgs(Int32 sourceThreadId, String result)
        {
            SourceThreadId = sourceThreadId;
            Result = result;
        }
        public override string ToString()
        {
            return String.Format("Concatenation gives {0}", Result);
        }
    }

    public class ConcatenateStringsResult : ResultBase
    {
        public override void NotifyResult(object result)
        {
            ConcatenateStringsEventArgs args = new ConcatenateStringsEventArgs(Int32.Parse(Thread.CurrentThread.Name), (String)result);
            OnChanged(args);
        }
    }
}