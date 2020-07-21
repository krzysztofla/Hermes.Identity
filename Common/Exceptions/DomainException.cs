using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Hermes.Identity.Common
{
    public class DomainException : Exception
    {
        public virtual string Code { get; }

        protected DomainException(string message) : base(message)
        {
        }
    }
}
