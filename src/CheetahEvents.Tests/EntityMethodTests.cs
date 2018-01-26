using System.Threading.Tasks;
using CheetahEvents.Tests.Contexts;
using CheetahEvents.Tests.Steps;
using CheetahTesting;
using Xunit;
using static CheetahEvents.Tests.Entities.EntityCreationTests;

namespace CheetahEvents.Tests
{
    public class EntityMethodTests
    {
        [Fact]
        public async Task CallingMethodOnEntityRaisesEvent()
        {
            await CTest<EntityContext<EntityClass>>
                .Given(a => a.EntityService())
                .When(i => i.CreateTheEntity())
                .AndAsync(async i => await i.MethodIsCalledAsync(async e => await e.ArbitraryMethod()))
                .Then(t => t.EventIsRaised($"{typeof(EntityClass).Name}_Created"))
                .And(t => t.EventIsRaised($"{typeof(EntityClass).Name}_ArbitraryMethod"))
                .And(t => t.VersionIs(2))
                .ExecuteAsync();
        }
    }
}