using System;
using System.Collections.Generic;

namespace CheetahEvents.Core
{
    public class Event
    {
        public Event(string messageType)
        {
            MessageType = messageType;
        }
        public string MessageType { get; }
    }
}