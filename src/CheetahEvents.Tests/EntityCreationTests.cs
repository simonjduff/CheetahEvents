using CheetahTesting;
using CheetahEvents.Tests.Steps;
using Xunit;
using CheetahEvents.Tests.Contexts;
using System.Threading.Tasks;
using static CheetahEvents.Tests.Entities.EntityCreationTests;

namespace CheetahEvents.Tests
{
    public partial class EntityCreationTests
    {
        [Fact]
        public async Task EntityCreatesWithIdAndVersion()
        {
            await CTest<EntityContext<EntityClass>>
                .Given(a => a.EntityService())
                .When(i => i.CreateTheEntity())
                .Then(t => t.VersionIs(1))
                .And(t => t.IdIsGenerated())
                .And(t => t.EventIsRaised($"{typeof(EntityClass).Name}_Created"))
                .ExecuteAsync();
        }
    }
}
