using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task;

namespace BlockingTaskQueue
{
    public class AddIntegersResult : IResult
    {
    }

    public class AddIntegers : ITask
    {
        private TwoOperandsInput _input;

        public AddIntegers()
        {

        }

        public AddIntegers(Int32 op1, Int32 op2)
        {
            _input = new TwoOperandsInput() { Operand1 = op1, Operand2 = op2 };
        }

        public IResult Run()
        {
            IResult result = new AddIntegersResult();
            result.Description = "Add Numbers Result";

            Int32 sum = (Int32)_input.Operand1 + (Int32)_input.Operand2;
            result.Actual = String.Format("Sum is {0}", sum);

            return result;
        }
    }
}
