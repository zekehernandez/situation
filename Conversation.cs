using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Situation
{
    public class Conversation
    {      
      [JsonIgnore]
      public Game Game { get; set; }
      public ConversationNode Entry { get; set; }

      private void finish() {
        // do something
      }
    }
}
