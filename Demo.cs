using System;
using System.Collections.Generic;

namespace Situation
{
    class Demo
    {
        static void Main(string[] args)
        {
            GameFactory factory = new GameFactory();
            Game game = factory.createNewGame();
            
            while(true) 
            {
              // Event Loop
              processEvents(game);
              // Main Loop
              Location location = game.getCurrentLocation();
              List<Interactable> interactables = game.getInteractables();

              Console.WriteLine();
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
          Console.WriteLine(conversation.Entry.Prompt);

          presentConversationResponses(conversation.Entry.Responses);
        }

        static void presentConversationResponses(List<ConversationNode> responses)
        {
          for (var j = 0; j < responses.Count; j++)
          {
            Console.WriteLine(string.Format("[{0}]: {1}", j+1, responses[j].OptionText));
          }; 
          Console.WriteLine("[0]: Say Goodbye");
        }
    }
}
