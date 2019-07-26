using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Situation
{
    public class Conversation
    {      
      public List<ConversationNode> Nodes { get; set; }

      public List<ConversationNodeLink> Links { get; set; }

      private void finish() {
        // do something
      }
    }
}
