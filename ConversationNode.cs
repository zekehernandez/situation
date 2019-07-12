using System;
using System.Collections.Generic;

namespace Situation
{
    public class ConversationNode
    {      
      public Conversation Conversation { get; set; }
      public string OptionText { get; set; }
      public string Prompt { get; set; }
      public List<ConversationNode> Responses { get; set; }
    }
}
