using System.Collections.Generic;

namespace Doors
{
    /*
     * The World class keeps track of the door and room ids in a central place so that they are always unique.
     * This is the place we will add methods to create Doors and Rooms
     */

    class World
    {
        private int lastDoorId;
        private int lastRoomId;

        // Use a Dictionary so that we can lookup a door or room by it's ID if we need to do that
        public Dictionary<int, Door> Doors { get; } = new Dictionary<int, Door>();
        public Dictionary<int, Room> Rooms { get; } = new Dictionary<int, Room>();

        public Room CreateRoom()
        {
            return new Room { RoomId = lastRoomId++ };
        }

        // A doorway is created using a convention.
        // We can only create a door using 2 methods, North-South and East-West
        // This is to keep things simple

        public void CreateNorthSouthDoorway(Room north, Room south, bool isLocked = false)
        {
            var door = new Door();
            door.DoorId = lastDoorId++;
            door.IsLocked = isLocked;
            door.Room1 = north;
            door.Room2 = south;

            north.SouthDoor = door;
            south.NorthDoor = door;

            Doors.Add(door.DoorId, door);
        }

        public void CreateEastWestDoorway(Room east, Room west, bool isLocked = false)
        {
            var door = new Door();
            door.DoorId = lastDoorId++;
            door.IsLocked = isLocked;
            door.Room1 = east;
            door.Room2 = west;

            east.WestDoor = door;
            west.EastDoor = door;

            Doors.Add(door.DoorId, door);
        }

    }
}
