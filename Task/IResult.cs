using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contracts
{
    public interface IResult
    {
        void NotifyResult(Object result);
    }
}
