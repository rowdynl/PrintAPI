using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rowdy.API.PrintAPI
{
    class PrintAPIException : Exception
    {
        public PrintAPIException()
        {
        }

        public PrintAPIException(string message)
            : base(message)
        {
        }

        public PrintAPIException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
