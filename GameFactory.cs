using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Situation
{
    public class GameFactory
    {

      public GameFactory() 
      {
        // make a singleton I guess, or maybe it doesn't need to be a class
      }

      public Game createNewGame() 
      {
        Game game = JsonConvert.DeserializeObject<Game>(File.ReadAllText(@"game-state.json"),
          new JsonSerializerSettings 
          { 
            TypeNameHandling = TypeNameHandling.Auto
          });

        return game;
      }
    }
}
