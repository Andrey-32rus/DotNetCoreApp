using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Xunit;
using XUnitTestProject.Models;

namespace XUnitTestProject
{
    public class Serialization
    {
        private int iterations = 100000;

        [Fact]
        public void BinaryFormatterTest()
        {
            RefModel obj = new RefModel();
            RefModel obj2;
            BinaryFormatter formatter = new BinaryFormatter();

            for (int i = 0; i < iterations; i++)
            {
                using (var memoryStream = new MemoryStream())
                {
                    formatter.Serialize(memoryStream, obj);
                    memoryStream.Position = 0;
                    obj2 = (RefModel)formatter.Deserialize(memoryStream);
                }
            }
        }

        [Fact]
        public void SystemTextJsonTest()
        {
            RefModel obj = new RefModel();
            RefModel obj2;

            for (int i = 0; i < iterations; i++)
            {
                var serialized = System.Text.Json.JsonSerializer.Serialize(obj);
                obj2 = System.Text.Json.JsonSerializer.Deserialize<RefModel>(serialized);
            }
        }

        [Fact]
        public void NewtonsoftJsonTest()
        {
            RefModel obj = new RefModel();
            RefModel obj2;

            for (int i = 0; i < iterations; i++)
            {
                var serialized = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                obj2 = Newtonsoft.Json.JsonConvert.DeserializeObject<RefModel>(serialized);
            }
        }
    }
}
