using System;
using System.Collections.Generic;

namespace Situation
{
    public class ConversationNodeLink
    {     
      public int FromNodeId { get; set; }
      public int ToNodeId { get; set; }
      public string OptionText { get; set; }
      public bool Auto { get; set; } = false;
    }
}
