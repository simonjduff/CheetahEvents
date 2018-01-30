using System.Threading.Tasks;

namespace CheetahEvents.Core
{
    public interface IEntityService<T>
        where T : EntityBase
    {
        Task<T> NewEntity();
    }
}