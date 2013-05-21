using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
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
        ResultBase ResultAction { get; set; }
        void Run();
    }
}