using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Situation
{
    public abstract class Interaction
    {      
      public string Name { get; set; }
      public bool IsAvailable { get; set; }
      public abstract void interact();
    }

    public class LocationChangeInteraction : Interaction
    {
      public int ToLocationId { get; set; } 
      public override void interact() 
      {
        GameMaster.Game.changeCurrentLocation(ToLocationId);
      }
    }

    public class EventInteraction : Interaction
    {
      public GameEvent GameEvent { get; set; }

      public override void interact(){
        GameMaster.Game.QueuedEvents.Enqueue(GameEvent);
      }
    }
}
