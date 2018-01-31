using System;
using System.Threading.Tasks;

namespace CheetahEvents.Core
{
    public abstract class EntityBase : IEntity
    {
        public ISubscriber Subscriber { get; set; }
        public Guid Id { get; set; }
        public int Version { get; set; }

        protected async Task RaiseEvent(string eventName)
        {
            if (Subscriber == null)
            {
                return;
            }

            Version++;

            await Subscriber.RaiseEvent(new Event(
                $"{GetType().Name}_{eventName}", 
                this));
        }
    }
}