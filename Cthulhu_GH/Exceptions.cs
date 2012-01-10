using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cthulhu_GH
{
    public class UnsetParam : ApplicationException
    {
        public UnsetParam() { }
        public UnsetParam(string message) : base(message) { }
        public UnsetParam(string message, System.Exception inner)
            : base(message, inner)
        {
        }

        // Constructor needed for serialization 
        // when exception propagates from a remoting server to the client.
        protected UnsetParam(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) { }
    }

    public class Cthulhu_InvalidLicense : ApplicationException
    {
        public Cthulhu_InvalidLicense()
            : base("This version of Cthulhu has expired, please find an updated version at www.slateshinglestudio.com")
        { }

        // Constructor needed for serialization 
        // when exception propagates from a remoting server to the client.
        protected Cthulhu_InvalidLicense(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) { }
    }
}
