using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;

namespace ProtobufTestConsole.Protobuf
{
    [ProtoContract]
    public class Model1
    {
        [ProtoMember(1)]
        public string Str { get; set; }
        [ProtoMember(2)]
        public int Int { get; set; }
    }
}
