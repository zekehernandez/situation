using System;
using System.Collections.Generic;

namespace Situation
{
    class Demo
    {
        static void Main(string[] args)
        {
            GameMaster.Instance.loadGame();
            Game game = GameMaster.Game;
            
            while(true) 
            {
              // Event Loop
              processEvents(game);
              // Main Loop
              Location location = game.getCurrentLocation();
              List<Interactable> interactables = game.getInteractables();

              Console.WriteLine();

              stateLocation(location.LocationName);

              presentInteractables(interactables);

              int selection = 0;
              if (readInt(out selection)) 
              {
                if (selection == 0) 
                {
                  break;
                } 
                else if (selection-1 >= 0 && selection-1 < interactables.Count)
                {
                  Interactable interactable = interactables[selection-1];

                  presentInteractions(interactable.Interactions);

                  if (readInt(out selection)) 
                  {
                    if (selection == 0) 
                    {
                      break;
                    } 
                    else if (selection-1 >= 0 && selection-1 < interactable.Interactions.Count)
                    {
                        Interaction interaction = interactable.Interactions[selection-1];
                        interaction.interact();
                    }
                  }
                }
              }
            }

            GameMaster.Instance.saveGame();
        }

        static void stateLocation(string locationName) 
        {
          Console.WriteLine(string.Format("You are in the {0}", locationName));
        }

        static void presentInteractables(List<Interactable> interactables) 
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine();
            for (var i = 0; i < interactables.Count; i++)
            {
              Console.WriteLine(string.Format("[{0}]: {1}", i+1, interactables[i].Name));
            }
            Console.WriteLine("[0]: Exit Game");
        }

        static void presentInteractions(List<Interaction> interactions)
        {
          Console.WriteLine();
          for (var j = 0; j < interactions.Count; j++)
          {
            Console.WriteLine(string.Format("[{0}]: {1}", j+1, interactions[j].Name));
          }; 
          Console.WriteLine("[0]: Exit Game");
        }

        static bool readInt(out int result) 
        {
          var input = Console.ReadLine();
          return int.TryParse(input, out result);
        }

        static void processEvents(Game game) 
        {
          while(game.QueuedEvents.Count > 0) 
          {
            GameEvent gameEvent = game.QueuedEvents.Dequeue();
            switch(gameEvent.EventType) {
              case EventType.Conversation:
              {
                ConversationEvent conversationEvent = gameEvent as ConversationEvent;
                playConversation(conversationEvent.Conversation);
                continue;
              }
              default: continue;
            }    
          }
        }

        static void playConversation(Conversation conversation) 
        {
          Console.WriteLine();

          ConversationNode node = conversation.Nodes[0];

          Console.WriteLine('"' + node.Text + '"');
          
          var links = conversation.Links.FindAll(link => link.FromNodeId == node.NodeId);

          while(links.Count > 0) {

            var i = links.FindIndex(link => link.Auto);
            if (i != -1) {
                node = conversation.Nodes.Find(x => x.NodeId == links[i].ToNodeId);
                links = conversation.Links.FindAll(link => link.FromNodeId == node.NodeId);
                Console.WriteLine();
                Console.WriteLine('"' + node.Text + '"');
            } else {
              presentConversationResponses(links);

              int selection = 0;
              if (readInt(out selection)) 
              {
                if (selection > 0 && selection <= links.Count) 
                {
                  node = conversation.Nodes.Find(x => x.NodeId == links[selection-1].ToNodeId);
                  links = conversation.Links.FindAll(link => link.FromNodeId == node.NodeId);
                  Console.WriteLine();
                  Console.WriteLine('"' + node.Text + '"');
                }
              }
            }
          }
        }

        static void presentConversationResponses(List<ConversationNodeLink> responses)
        {
          for (var j = 0; j < responses.Count; j++)
          {
            Console.WriteLine(string.Format("[{0}]: {1}", j+1, responses[j].OptionText));
          }; 
        }
    }
}
