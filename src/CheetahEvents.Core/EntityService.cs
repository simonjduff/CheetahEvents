using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CheetahEvents.Core
{
    public class EntityService<T> : IEntityService<T>
        where T : EntityBase, new()
    {
        private readonly ISubscriber _subscriber;

        public EntityService(ISubscriber subscriber)
        {
            _subscriber = subscriber;
        }

        public async Task<T> NewEntity()
        {
            var entity = new T{
                Version = 1,
                Id = Guid.NewGuid(),
                Subscriber = _subscriber
            };

            await _subscriber.RaiseEvent(new Event(
                $"{typeof(T).Name}_Created", 
                entity));

            return entity;
        }
    }
}