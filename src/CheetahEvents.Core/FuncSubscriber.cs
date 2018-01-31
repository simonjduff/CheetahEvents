using System;
using System.Threading.Tasks;

namespace CheetahEvents.Core
{
    public class FuncSubscriber : ISubscriber
    {
        private readonly Func<Event, Task> func;

        public FuncSubscriber(Func<Event, Task> func)
        {
            this.func = func;
        }
        public async Task RaiseEvent(Event e)
        {
            await func(e);
        }
    }
}