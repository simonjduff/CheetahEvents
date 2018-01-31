using System;
using System.Threading.Tasks;
using CheetahEvents.Core;

namespace CheetahEvents.Tests.Entities
{
    public partial class EntityCreationTests
    {
        public class EntityClass : EntityBase
        {
            public async Task ArbitraryMethod()
            {
                await RaiseEvent("ArbitraryMethod");
            }
        }
    }
}
