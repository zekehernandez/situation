using System;
using System.Collections.Generic;

namespace Situation
{
    public enum EventType {Conversation}
    public abstract class GameEvent
    {      
      public int EventId { get; set; }
      public string EventName { get; set; }

      public EventType EventType { get; set; }
    }

    public class ConversationEvent : GameEvent
    {
      public Conversation Conversation { get; set; }
    }
}
