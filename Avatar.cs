using System;
using System.Collections.Generic;
using System.Linq;

namespace Doors
{
    class Avatar
    {
        public string Name { get; set; }
        public Room CurrentRoom { get; set; }

        public void Navigate(Direction direction)
        {

            Door door = null;
            switch (direction)
            {
                case Direction.North:
                    door = CurrentRoom.NorthDoor;
                    break;
                case Direction.South:
                    door = CurrentRoom.SouthDoor;
                    break;
                case Direction.East:
                    door = CurrentRoom.EastDoor;
                    break;
                case Direction.West:
                    door = CurrentRoom.WestDoor;
                    break;
            }

            if(door == null)
            {
                Console.WriteLine("There is no door in that direction");
                return;
            }


            // Limitation, the user cannot teleport between two non-adjacent rooms using this method
            // since we use the current room to determine which is the room we are in, and therefore
            // the other room will be the room we are going to
            if (door.Room1 == CurrentRoom)
            {
                CurrentRoom = door.Room2;
            }
            else if (door.Room2 == CurrentRoom)
            {
                CurrentRoom = door.Room1;
            }

            Console.WriteLine("You open the door...");
        }

        public void Look()
        {
            Console.WriteLine($"You are in room {CurrentRoom.RoomId}");
            List<string> exits = new();

            if (CurrentRoom.NorthDoor != null) exits.Add("North");
            if (CurrentRoom.SouthDoor != null) exits.Add("South");
            if (CurrentRoom.EastDoor != null) exits.Add("East");
            if (CurrentRoom.WestDoor != null) exits.Add("West");

            if (exits.Count == 1)
            {
                Console.WriteLine($"You see an exit to the {exits.First()}");
            }
            else
            {
                var exitsList = string.Join(", ", exits.Take(exits.Count - 1));
                Console.WriteLine($"You see exits to the {exitsList} and {exits.Last()}");
            }
        }
    }
}