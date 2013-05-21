using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Contracts;

namespace Callbacks
{
    public class PalindromCheckerEventArgs : GeneralTaskEventArgs
    {
        public readonly Boolean Result;
        private SingleOperandInput _input;

        public PalindromCheckerEventArgs(Int32 sourceThreadId, SingleOperandInput input, Boolean result)
        {
            _input = input;
            SourceThreadId = sourceThreadId;
            Result = result;
        }
        public override string ToString()
        {
            return String.Format("{0} {1}", _input.Operand, Result == true ? "is a palindrome" : "is not a palindrome");
        }
    }

    public class PalindromCheckerResult : ResultBase
    {
        private SingleOperandInput _input;

        public PalindromCheckerResult(SingleOperandInput input)
        {
            _input = input;
        }
        public override void NotifyResult(object result)
        {
            PalindromCheckerEventArgs args = new PalindromCheckerEventArgs(Int32.Parse(Thread.CurrentThread.Name), _input, (Boolean)result);
            OnChanged(args);
        }
    }
}