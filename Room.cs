namespace Doors
{
    class Room
    {
        public int RoomId { get; set; }
        public Door NorthDoor { get; set; }
        public Door SouthDoor { get; set; }
        public Door EastDoor { get; set; }
        public Door WestDoor { get; set; }
    }
}