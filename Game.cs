using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace Situation
{
    public interface IGame
    {      
      List<Interactable> getInteractables();
      Location getCurrentLocation();
    }

    public sealed class GameMaster
    {
    private static GameMaster instance = null;
    private static readonly object padlock = new object();

    public static Game game;

    GameMaster() {}

    public void loadGame() {
      game = JsonConvert.DeserializeObject<Game>(File.ReadAllText(@"game-state.json"),
        new JsonSerializerSettings 
        { 
          TypeNameHandling = TypeNameHandling.Auto
        });
    }

    public void saveGame() {
      string json = JsonConvert.SerializeObject(this, Formatting.Indented,
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

    public class Game : IGame
    {
      public List<Location> Locations { get; set; }

      private int currentLocationId;

      public Queue<GameEvent> QueuedEvents { get; set; }

      public Game() 
      {
        Locations = new List<Location>();
        QueuedEvents = new Queue<GameEvent>();
      }

      public void changeCurrentLocation(int locationId) 
      {
        currentLocationId = locationId;
      }

      public Location getCurrentLocation() 
      {
        Location currentLocation = Locations.Find(location => location.LocationId == currentLocationId);
        return currentLocation;
      }
      
      public List<Interactable> getInteractables() 
      {
        return getCurrentLocation().Interactables;
      }
    }
}
