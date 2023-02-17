using ShipBattleGame.Controllers;
using ShipBattleGame.Structures;
using System;
using System.Collections.Generic;

namespace ShipBattleGame.ConsoleHelper
{
    public class UserInput
    {
        public static string GetUserInput()
        {
            string userInput;
            do
            {
                Message.Print("\nShoot!");
                userInput = Console.ReadLine();
                Message.Print("\nIncorrect coordinate! Enter valid one!");
            } while (!IsUserInputCorrect(userInput, CellController.GetMapCoordinates()));

            return userInput;
        }

        public static void Exit()
        {
            ConsoleKeyInfo cki;
            Message.Print("\nPress Esc to quit!");
            cki = Console.ReadKey();
            if (cki.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
        }

        private static bool IsUserInputCorrect(string userInput, Dictionary<Point, string> battleFieldWithShips)
        {
            var isInputCorrect = false;
            foreach (var ship in battleFieldWithShips)
            {
                if (ship.Value == userInput.ToUpper())
                {
                    isInputCorrect = true;
                    break;
                }
                isInputCorrect = false;
                continue;
            }

            return isInputCorrect;
        }
    }
}
