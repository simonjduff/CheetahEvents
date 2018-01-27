using System;
using System.Collections.Generic;

namespace CheetahEvents.Core
{
    public class Event
    {
        public Event(string messageType,
            EntityBase entity)
        {
            MessageType = messageType;
            Version = entity.Version;
            Id = entity.Id;
        }

        public string MessageType { get; }
        public int Version {get;}
        public Guid Id {get;}
    }
}