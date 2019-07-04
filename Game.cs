using System;
using System.Collections.Generic;

namespace Situation
{
    public class Game
    {
      public List<Location> Locations { get; set; }

      private int currentLocationId;

      public Game() 
      {
        Locations = new List<Location>();
      }

      public Location getCurrentLocation() 
      {
        Location currentLocation = Locations.Find(location => location.LocationId == currentLocationId);
        return currentLocation;
      }

      public void changeCurrentLocation(int locationId) 
      {
        currentLocationId = locationId;
      }

 
    }
}
