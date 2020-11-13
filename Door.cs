namespace Doors
{
    class Door
    {
        public int DoorId { get; set; }
        public int KeyId { get; set; }
        public bool CanPickLock { get; set; }
        public Room Room1 { get; set; }
        public Room Room2 { get; set; }
        public bool IsLocked { get; set; }
    }
}