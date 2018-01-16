using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CheetahEvents.Core;

namespace CheetahEvents.Tests.Contexts
{
    public class EntityContext<TEntity> where TEntity : EntityBase
    {
        public IEntityService<TEntity> EntityService{get;set;}
        public TEntity Entity{get;set;}
        public IList<Event> Events { get; } = new List<Event>();

        public class Subscriber : ISubscriber
        {
            private readonly Action<Event> _action;

            public Subscriber(Action<Event> action)
            {
                _action = action;
            }
            public Task RaiseEvent()
            {
                _action(new Event());
                return Task.CompletedTask;
            }
        }
    }
}