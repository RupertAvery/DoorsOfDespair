using System;
using System.Linq;

namespace Doors
{

    class Program
    {
        static World world = new();
        
        static Avatar avatar = new();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the rooms of despair!");
            Console.WriteLine("Enter a command or type \"help\" for a list of commands");

            Room room1 = world.CreateRoom();
            Room room2 = world.CreateRoom();
            Room room3 = world.CreateRoom();
            Room room4 = world.CreateRoom();
            Room room5 = world.CreateRoom();

            world.CreateNorthSouthDoorway(room1, room3);
            world.CreateEastWestDoorway(room2, room3);
            world.CreateEastWestDoorway(room3, room4);
            world.CreateNorthSouthDoorway(room3, room5);

            avatar.CurrentRoom = room3;

             MainLoop();
        }

        static void MainLoop()
        {
            bool playing = true;
            while (playing)
            {
                var input = Console.ReadLine();
                var commands = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(x => x.ToLower()).ToArray();

                switch (commands[0])
                {
                    case "quit":
                        playing = false;
                        break;
                    case "go":
                        switch (commands[1])
                        {
                            case "north" or "n":
                                avatar.Navigate(Direction.North);
                                break;
                            case "south" or "s":
                                avatar.Navigate(Direction.South);
                                break;
                            case "east" or "e":
                                avatar.Navigate(Direction.East);
                                break;
                            case "west" or "w":
                                avatar.Navigate(Direction.West);
                                break;
                        }
                        break;
                    case "look":
                        avatar.Look();
                        break;
                    case "help":
                        Console.WriteLine("Here's what you can do");
                        Console.WriteLine("");
                        Console.WriteLine("go [north|south|east|west|n|s|e|w] ");
                        Console.WriteLine("look");
                        Console.WriteLine("quit");
                        Console.WriteLine("");
                        break;
                    default:
                        Console.WriteLine($"Sorry, I don't know \"{commands[0]}\"");
                        break;
                }
            }

        }


    }
}
