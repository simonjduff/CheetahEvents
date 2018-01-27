using System;
using System.Collections.Generic;

namespace CheetahEvents.Core
{
    public class Event
    {
        public Event(string messageType,
            int version)
        {
            MessageType = messageType;
            Version = version;
        }
        public string MessageType { get; }
        public int Version { get; }
    }
}