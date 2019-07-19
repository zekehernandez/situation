using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Situation
{
    public abstract class Interaction
    {      
      [JsonIgnore]
      public Game Game { get; set; }
      public string Name { get; set; }
      public bool IsAvailable { get; set; }
      public abstract void interact();
    }

    public class LocationChangeInteraction : Interaction
    {
      public int ToLocationId { get; set; } 
      public override void interact() 
      {
        Game.changeCurrentLocation(ToLocationId);
      }
    }

    public class EventInteraction : Interaction
    {
      public GameEvent GameEvent { get; set; }

      public override void interact(){
        Game.QueuedEvents.Enqueue(GameEvent);
      }
    }
}
