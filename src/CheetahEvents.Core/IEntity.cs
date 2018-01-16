using System;

namespace CheetahEvents.Core
{
    public interface IEntity
    {
        Guid Id{get;set;}
        int Version{get;set;}
    }
}