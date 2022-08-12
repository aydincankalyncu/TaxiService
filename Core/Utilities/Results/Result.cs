using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result: IResult
    {
        public Result(bool success, string message) : this(success) // this(success) bu parametrelerle ctor çağrılırsa tek parametreli success ctor'una gider me success set edilir.
        {
            Message = message;
        }
        public Result(bool success)
        {
            Success = success;
        }
        public bool Success { get; }

        public string Message { get; }
    }
}
