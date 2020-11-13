# Doors of Despair

A text-based adventure game, based on this reddit question:

https://www.reddit.com/r/csharp/comments/jt8psg/help_designing_a_door_c_model/

**NOTE:** This project uses C# 9 and targets .NET 5.0. Mase sure you have the latest Visual Studio 16.8 and the dotnet 5.0 SDK.

## The Problem

What is a door? How does it connect two rooms?

We start from the view of a door. It exists in a room, we open it and it leads to another room. That door is facing a direction, so 
in the first room we know that facing a door, it leads in a direction to another room.

Let's start with this model:

```
enum Direction
{
	North,
	South,
	East,
	West
}

public class Door
{
    public int DoorID;
    public int RoomID;
    public int ExitToRoomID;
    public Direction Direction; 
}
```

This model has a design flaw. A door is explicitly one-way.  This is because we have:

* a Current Room 
* a Target Room
* a Direction

The workaround is to create another door from the second room to the first in the opposite direction, but these doors are completely different.

## A solution

First of all, if we're using C#, we should use object references as it creates ways to model things that are intuitive.

Instead of thinking of a door leading to a room (one-way) think of it as a portal between two rooms.

```
public class Door
{
    public int DoorID { get; set; }
    public Room Room1 { get; set; }
    public Room Room2 { get; set; }
}
```

And now a Room has four doors, in each cardinal direction 

```
public class Room
{
	public int RoomId { get; set; }
	public Door NorthDoor { get; set; }
	public Door SouthDoor { get; set; }
	public Door EastDoor { get; set; }
	public Door WestDoor { get; set; }
}
```

How do we create a door? We should only create it once, and we should pass the rooms it will connect.

* Given two rooms, we want to create a Door between the rooms.
* Create a Door
* Assign one room to Room1 and another room to Room2
* Assign one of the first Room's doors to the door
* Assign one of the second Room's doors to the door

But how? Remember, when we create a door, one is implicitly in one cardinal direction and another is in the opposite. From here we see that:

* North-South connection is redundant with South-North. Same with East-West.
* Therefore, there are only two ways to connect rooms (NS) and (EW)

So we need to have some sort of convention when creating doors. Someway to enforce creation so someone writing code doesn't accidentally  create a 
South-North doorway expecting it to behave as such.

**Attempt 1**

Using one method, and an enum type.

```
public void CreateDoorway(Room room1, Room room2, ConnectionType connectionType)
```

This works, but it can be confusing. Which is room1? Which is room2? While DRY can be tempting, clarity in an API is often more beneficial.


**Attempt 2**

Using two methods.

```
public void CreateNorthSouthDoorway(Room north, Room south)

public void CreateWestEastDoorway(Room west, Room east)
```

This API is much clearer, and self-documenting.

## Next steps

Is there a better way to implement this? Fork it and let me know!

Meanwhile, here's a working reference implementation.  I plan on extending it for fun. It's meant to be an educational tool on data modelling 
and interaction between objects. 

