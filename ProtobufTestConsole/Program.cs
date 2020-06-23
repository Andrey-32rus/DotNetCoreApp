using System;
using System.IO;
using System.Text;
using ProtoBuf;
using ProtobufTestConsole.Protobuf;

namespace ProtobufTestConsole
{
    class Program
    {
        private static byte[] SerializeProtobuf<T>(T src)
        {
            using MemoryStream protobuf = new MemoryStream();
            Serializer.Serialize(protobuf, src);
            return protobuf.ToArray();
        }

        private static T DeserializeProtobuf<T>(byte[] bytes)
        {
            using MemoryStream protobuf = new MemoryStream(bytes);
            return Serializer.Deserialize<T>(protobuf);
        }


        static void Main(string[] args)
        {
            Model1 model = new Model1
            {
                Str = "string",
                Int = 1,
            };

            var protobuf = SerializeProtobuf(model);
            string strProtobuf = Encoding.UTF8.GetString(protobuf);
            Model1 deserializedModel = DeserializeProtobuf<Model1>(protobuf);
        }
    }
}
