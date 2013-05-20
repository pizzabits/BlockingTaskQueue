using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task
{
    public class IResult
    {
        public String Description;
        public String Actual;
    }

    public class SingleOperandInput 
    {
        public Object Operand;
    }

    public class TwoOperandsInput 
    {
        public Object Operand1;
        public Object Operand2;
    }

    public interface ITask
    {
        IResult Run();
    }
}