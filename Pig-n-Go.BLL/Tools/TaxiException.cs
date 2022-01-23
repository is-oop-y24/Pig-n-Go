using System;

namespace Pig_n_Go.BLL.Tools
{
    public class TaxiException : Exception
    {
        public TaxiException() { }

        public TaxiException(string message)
            : base(message) { }

        public TaxiException(string message, Exception inner)
            : base(message, inner) { }
    }
}