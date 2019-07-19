using System;
using System.Collections.Generic;

namespace Situation
{
    public interface IGame
    {      
      List<Interactable> getInteractables();
      Location getCurrentLocation();
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
