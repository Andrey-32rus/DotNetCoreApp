using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProject
{
    public class TaskTests
    {
        [Fact]
        public async Task WhenAll()
        {
            int maxSec = 5;
            List<Task> tasks = new List<Task>(maxSec);
            for (int i = 0; i < maxSec; i++)
            {
                var task = Task.Delay(TimeSpan.FromSeconds(i + 1));
                tasks.Add(task);
            }

            await Task.WhenAll(tasks);
        }
    }
}
