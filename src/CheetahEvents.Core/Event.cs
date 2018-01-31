using System;
using System.Collections.Generic;

namespace CheetahEvents.Core
{
    public class Event
    {
        public Event(string messageType,
            EntityBase entity,
            object data = null)
        {
            EventType = messageType;
            Version = entity.Version;
            Id = entity.Id;
            Body = data;
        }

        public string EventType { get; }
        public int Version {get;}
        public Guid Id {get;}
        public object Body { get; set; }
    }
}