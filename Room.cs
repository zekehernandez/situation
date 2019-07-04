using System;
using System.Collections.Generic;

namespace Situation
{
    public class Room
    {
      public int RoomId { get; set; }
      public string RoomName { get; set; }

      public Room(int id, string name) {
        RoomId = id;
        RoomName = name;
      }

 
    }
}
