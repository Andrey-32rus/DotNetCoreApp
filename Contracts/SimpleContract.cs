﻿using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Contracts
{
    [DataContract]
    public class SimpleContract
    {
        [DataMember]
        public string Field1 { get; set; }
        [DataMember]
        public string Field2 { get; set; }
    }
}
