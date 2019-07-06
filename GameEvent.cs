using System;
using System.Collections.Generic;

namespace Situation
{
    public class GameEvent
    {      
      public int EventId { get; set; }
      public string EventName { get; set; }
      public string TextResponse { get; set; } 
      public List<Choice> Choices { get; set; }
      public List<GameEvent> ChildEvents { get; set; }
    }
}
