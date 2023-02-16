using ShipBattleGame.Models;
using System;

namespace ShipBattleGame.ConsoleHelper
{
    public class Message
    {
        public static void Print(string message)
        {
            Console.WriteLine(message);
        }

        public static void Print(Ship.State status)
        {
            Console.WriteLine($"Ship is {status.ToString().ToLower()}!");
        }
    }
}
