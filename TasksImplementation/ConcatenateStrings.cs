using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contracts;

namespace Tasks
{
    public class ConcatenateStrings  : ITask
    {
        public ResultBase ResultAction { get; set; }
        private TwoOperandsInput _input;

        public ConcatenateStrings(Object op1, Object op2, Object resultAction)
        {
            ResultAction = resultAction as ResultBase;
            _input = new TwoOperandsInput() { Operand1 = op1, Operand2 = op2 };
        }

        public void Run()
        {
            String concat = String.Format("{0}{1}", _input.Operand1 as String, _input.Operand2 as String);
            ResultAction.NotifyResult(concat);
        }
    }
}