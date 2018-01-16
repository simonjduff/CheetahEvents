using System;
using System.Linq;
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

        public static void EventIsRaised<T>(this IThen<EntityContext<T>> then)
            where T : EntityBase
        {
            var e = then.Context.Events.Single();
            Assert.NotNull(e);
        }
    }
}