using System;
using System.Collections.Generic;

namespace Situation
{
    public abstract class Interaction
    {      
      public string Name { get; set; }
      public abstract void interact(Game game);
    }

    public class LocationChangeInteraction : Interaction
    {
      public int ToLocationId { get; set; } 
      public override void interact(Game game) 
      {
        game.changeCurrentLocation(ToLocationId);
      }
    }
}
