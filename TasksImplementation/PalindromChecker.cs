using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;

namespace TasksImplementation
{
    public class PalindromChecker  : ITask
    {
        public ResultBase ResultAction { get; set; }
        private SingleOperandInput _input;

        public PalindromChecker(Object operand, Object resultAction)
        {
            ResultAction = resultAction as ResultBase;
            _input = new SingleOperandInput() { Operand = operand };
        }

        public void Run()
        {
            String candidate = _input.Operand as String;
            if (candidate == null)
            {
                throw new ArgumentNullException();
            }

            Boolean isPalindrom = true;

            for (int i = 0; i < candidate.Length / 2; i++)
            {
                if (candidate[i] != candidate[candidate.Length - 1 - i])
                {
                    isPalindrom = false;
                    break;
                }
            }

            ResultAction.NotifyResult(isPalindrom);
        }
    }
}
