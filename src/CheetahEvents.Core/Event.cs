using System;
using System.Collections.Generic;

namespace CheetahEvents.Core
{
    public class Event
    {
        public Event(string messageType,
            EntityBase entity)
        {
            EventType = messageType;
            Version = entity.Version;
            Id = entity.Id;
        }

        public string EventType { get; }
        public int Version {get;}
        public Guid Id {get;}
    }
}