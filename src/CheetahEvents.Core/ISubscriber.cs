using System.Threading.Tasks;

namespace CheetahEvents.Core
{
    public interface ISubscriber
    {
        Task RaiseEvent(string eventName);
    }
}