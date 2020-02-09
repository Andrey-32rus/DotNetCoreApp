using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WeatherService.Warmup
{
    [Serializable]
    public class WarmupException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public WarmupException()
        {
        }

        public WarmupException(string message) : base(message)
        {
        }

        public WarmupException(string message, Exception inner) : base(message, inner)
        {
        }

        protected WarmupException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
