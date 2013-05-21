using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contracts
{
    public abstract class ResultBase : IResult
    {
        // A delegate type for hooking up change notifications.
        public delegate void ResultEventHandler(object sender, GeneralTaskEventArgs e);

        // An event that clients can use to be notified whenever
        // there's a result.
        public event ResultEventHandler Changed;
        public abstract void NotifyResult(object result);

        // Invoke the Changed event
        protected virtual void OnChanged(GeneralTaskEventArgs e)
        {
            if (Changed != null)
            {
                Changed(this, e);
            }
        }
    }
}
