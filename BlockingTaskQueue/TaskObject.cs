using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlockingTaskQueue
{
    public struct TaskObject
    {
        public readonly KeyValuePair<Type, Type> ConcreteActionAndResult;
        public readonly Int32 OperandsRequired;
        public readonly Boolean RequiresInput;

        public TaskObject(Type concreteActionClass, Type concreteResultClass, Int32 numberOfOperands, Boolean requiresInput)
        {
            ConcreteActionAndResult = new KeyValuePair<Type, Type>(concreteActionClass, concreteResultClass);
            OperandsRequired = numberOfOperands;
            RequiresInput = requiresInput;
        }
    }
}