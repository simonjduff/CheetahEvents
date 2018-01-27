using System.Threading.Tasks;

namespace CheetahEvents.Core
{
    public interface ISubscriber
    {
        Task RaiseEvent(Event e);
    }
}