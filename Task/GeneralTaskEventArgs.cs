using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    public abstract class GeneralTaskEventArgs : EventArgs
    {
        public Int32 SourceThreadId;
        public Object Operand1;
        public Object Operand2;
    }
}
