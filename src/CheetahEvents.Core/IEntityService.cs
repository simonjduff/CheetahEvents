namespace CheetahEvents.Core
{
    public interface IEntityService<T>
        where T : EntityBase
    {
        T NewEntity();
    }
}