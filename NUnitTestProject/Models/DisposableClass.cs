using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTestProject.Models
{
    public class DisposableClass : IAsyncDisposable
    {
        public async ValueTask DisposeAsync()
        {
            await new ValueTask(Task.CompletedTask);
        }
    }
}
