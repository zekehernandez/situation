using System;
using System.Collections.Generic;

namespace Situation
{
    public class Interactable
    {
      public string Name { get; set;}
      public List<Interaction> Interactions { get; set; }
      public Interactable() { }
    }
}
