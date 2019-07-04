using System;
using System.Collections.Generic;

namespace Situation
{
    public class Location
    {
      public int LocationId { get; set; }
      public string LocationName { get; set; }

      public List<Interactable> Interactables { get; set; }
    
      public Location() { }
    }
}
