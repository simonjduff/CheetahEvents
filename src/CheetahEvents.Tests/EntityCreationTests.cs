using CheetahTesting;
using CheetahEvents.Tests.Steps;
using Xunit;
using CheetahEvents.Tests.Contexts;
using System.Threading.Tasks;
using CheetahEvents.Core;

namespace CheetahEvents.Tests
{
    public class EntityCreationTests
    {
        [Fact]
        public async Task EntityCreatesWithIdAndVersion()
        {
            await CTest<EntityContext<EntityClass>>
                .Given(a => a.EntityService())
                .When(i => i.CreateTheEntity())
                .Then(t => t.VersionIs(1))
                .And(t => t.IdIsGenerated())
                .And(t => t.EventIsRaised())
                .ExecuteAsync();
        }

        public class EntityClass : EntityBase
        {
            public EntityClass()
            {
                RaiseEvent("EntityClassCreated").Wait();
            }
        }
    }
}
