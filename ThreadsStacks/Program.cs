using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Diagnostics.Runtime;

namespace ThreadsStacks
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                int number = i;
                Task.Run(() =>
                {
                    while (true)
                    {
                        Console.WriteLine($"Thread: {number + 1}");
                        Thread.Sleep(TimeSpan.FromSeconds(1));
                    }
                });
            }

            Thread.Sleep(TimeSpan.FromSeconds(3));

            Task.Run(() =>
            {
                while (true)
                {
                    var result = new Dictionary<int, string[]>();
                    var pid = Process.GetCurrentProcess().Id;
                    using (var dataTarget = DataTarget.AttachToProcess(pid, 5000, AttachFlag.Passive))
                    {
                        ClrInfo runtimeInfo = dataTarget.ClrVersions[0];
                        var runtime = runtimeInfo.CreateRuntime();

                        foreach (var t in runtime.Threads)
                        {
                            result.Add(
                                t.ManagedThreadId,
                                t.StackTrace.Select(f =>
                                {
                                    if (f.Method != null)
                                    {
                                        return f.Method.Type.Name + "." + f.Method.Name;
                                    }

                                    return null;
                                }).ToArray()
                            );
                        }
                    }

                    Thread.Sleep(TimeSpan.FromSeconds(1));
                }
            });
           

            Console.ReadLine();
        }
    }
}
