using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proxies
{
    public class ServiceAnswer<T>
    {
        public T Data
        {
            get;
            set;
        }
        public CallResult CallResult
        {
            get;
            set;
        }
        public string ErrorType
        {
            get;
            set;
        }
        public string ErrorText
        {
            get;
            set;
        }
    }
}
