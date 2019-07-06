using System;
using System.Collections.Generic;

namespace Situation
{
    public class GameFactory
    {

      public GameFactory() 
      {
        // make a singleton I guess, or maybe it doesn't need to be a class
      }

      public Game createNewGame() 
      {
        Game game = new Game();

        // Create Locations
        Location overworld = new Location
        {
          LocationId = 0,
          LocationName = "City"
        };

        Location coffeeShop = new Location 
        {
          LocationId = 1,
          LocationName = "Coffee Shop"
        };

        Location policeStation = new Location 
        {
          LocationId = 2,
          LocationName = "Police Station"
        };

        // Add Routes
        overworld.Interactables = new List<Interactable> 
        {
          new Interactable 
          {
            Name = "Go Somewhere",
            Interactions = new List<Interaction> 
            {
              new LocationChangeInteraction 
              {
                Game = game,
                Name = "Go to the Coffee Shop",
                ToLocationId = 1
              },
              new LocationChangeInteraction 
              {
                Game = game,
                Name = "Go to the Police Station",
                ToLocationId = 2
              }
            }
          }
        };

        coffeeShop.Interactables = new List<Interactable> 
        {
          new Interactable 
          {
            Name = "Use the Door",
            Interactions = new List<Interaction> 
            {
              new LocationChangeInteraction 
              {
                Game = game,
                Name = "Leave the Coffee Shop",
                ToLocationId = 0
              }
            }
          }
        };

        policeStation.Interactables = new List<Interactable> 
        {
          new Interactable 
          {
            Name = "Use the Door",
            Interactions = new List<Interaction> 
            {
              new LocationChangeInteraction 
              {
                Game = game,
                Name = "Leave the Police Station",
                ToLocationId = 0
              }
            }
          }
        };

        game.Locations.AddRange(new List<Location> 
        {
          overworld, coffeeShop, policeStation
        });

        game.changeCurrentLocation(0);

        return game;
      }
    }
}
