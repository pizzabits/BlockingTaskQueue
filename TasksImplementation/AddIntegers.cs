using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contracts;

namespace Tasks
{
    public class AddIntegers : ITask
    {
        public ResultBase ResultAction { get; set; }
        private TwoOperandsInput _input;

        public AddIntegers(Object op1, Object op2, Object resultAction)
        {
            ResultAction = resultAction as ResultBase;
            _input = new TwoOperandsInput() { Operand1 = op1, Operand2 = op2 };
        }

        public void Run()
        {
            Int32 sum = Int32.Parse(_input.Operand1 as String) + Int32.Parse(_input.Operand2 as String);
            ResultAction.NotifyResult(sum);
        }
    }
}