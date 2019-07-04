using System;

namespace Situation
{
    class Demo
    {
        static void Main(string[] args)
        {
            GameFactory factory = new GameFactory();
            Game game = factory.createNewGame();

            while(true) {
              Location location = game.getCurrentLocation();
              Console.WriteLine();
              Console.WriteLine();
              Console.WriteLine(string.Format("You are in the {0}", location.LocationName));
              Console.WriteLine("What would you like to do?");
              Console.WriteLine();
              for (var i = 0; i < location.Interactables.Count; i++)
              {
                Console.WriteLine(string.Format("[{0}]: {1}", i+1, location.Interactables[i].Name));
              }; 
              Console.WriteLine("[0]: Exit Game");

              var input = Console.ReadLine();

              int selection = 0;
              bool isInt = int.TryParse(input, out selection);

              if (isInt) 
              {
                if (selection == 0) 
                {
                  break;
                } 
                else if (selection-1 >= 0 && selection-1 < location.Interactables.Count)
                {
                  Interactable interactable = location.Interactables[selection-1];

                  for (var j = 0; j < interactable.Interactions.Count; j++)
                  {
                    Console.WriteLine(string.Format("[{0}]: {1}", j+1, interactable.Interactions[j].Name));
                  }; 
                  Console.WriteLine("[0]: Exit Game");

                  input = Console.ReadLine();

                  selection = 0;
                  isInt = int.TryParse(input, out selection);

                  if (isInt) 
                  {
                    if (selection == 0) 
                    {
                      break;
                    } 
                    else if (selection-1 >= 0 && selection-1 < interactable.Interactions.Count)
                    {
                        Interaction interaction = interactable.Interactions[selection-1];
                        interaction.interact(game);
                    }
                  }
                }
              }
            }
        }
    }
}
