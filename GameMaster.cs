using System;
using System.IO;
using Newtonsoft.Json;

namespace Situation
{
    public sealed class GameMaster
    {
    private static GameMaster instance = null;
    private static readonly object padlock = new object();

    public static Game Game;

    GameMaster() {}

    public void loadGame() {
      Game = JsonConvert.DeserializeObject<Game>(File.ReadAllText(@"game-state.json"),
        new JsonSerializerSettings 
        { 
          TypeNameHandling = TypeNameHandling.Auto
        });
    }

    public void saveGame() {
      string json = JsonConvert.SerializeObject(Game, Formatting.Indented,
      new JsonSerializerSettings 
      { 
        // PreserveReferencesHandling = PreserveReferencesHandling.Objects,
        TypeNameHandling = TypeNameHandling.Auto
      });

      File.WriteAllText(@"game-state.json", json);
    }

    public static GameMaster Instance
    {
      get
      {
        lock (padlock)
        {
          if (instance == null)
          {
            instance = new GameMaster();
          }
          return instance;
        }
      }
    }
  }
}