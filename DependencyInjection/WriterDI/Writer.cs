using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection.WriterDI
{
    public class Writer : IWriter
    {
        public void Write()
        {
            Console.WriteLine("Writer");
        }
    }
}
