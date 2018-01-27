using System;
using System.Linq;
using System.Threading.Tasks;
using CheetahEvents.Core;
using CheetahEvents.Tests.Contexts;
using CheetahTesting;
using Xunit;

namespace CheetahEvents.Tests.Steps
{
    public static class EntitySteps
    {
        public static void EntityService<T>(this IGiven<EntityContext<T>> given)
        where T : EntityBase, new()
        {
            var subscriber = new EntityContext<T>.Subscriber(e => given.Context.Events.Add(e));
            given.Context.EntityService = new EntityService<T>(subscriber);
        }
        public static void CreateTheEntity<T>(this IWhen<EntityContext<T>> when)
        where T : EntityBase
        {
            when.Context.Entity = when.Context.EntityService.NewEntity();
        }

        public static void VersionIs<T>(this IThen<EntityContext<T>> then, int version)
        where T : EntityBase
        {
            Assert.Equal(version, then.Context.Entity.Version);
        }

        public static void IdIsGenerated<T>(this IThen<EntityContext<T>> then)
        where T : EntityBase
        {
            Assert.True(then.Context.Entity.Id != Guid.Empty);
        }

        public static void EventIsRaised<T>(this IThen<EntityContext<T>> then, string eventType)
            where T : EntityBase
        {
            Assert.NotEmpty(then.Context.Events);
            Assert.True(then.Context.Events.Count() > then.Context.EventsChecked);
            var e = then.Context.Events.Skip(then.Context.EventsChecked).First();
            Assert.NotNull(e);
            Assert.Equal(eventType, e.MessageType);
            Assert.Equal(then.Context.EventsChecked + 1, e.Version);
            then.Context.EventsChecked++;
        }

        public static async Task MethodIsCalledAsync<T>(this IWhen<EntityContext<T>> when, Func<T, Task> action)
        where T : EntityBase
        {
            await action(when.Context.Entity);
        }
    }
}