using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Se7enQ.Common.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public ValidationException(string message) : base(message)
        {

        }
    }
}
