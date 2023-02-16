using ShipBattleGame.Structures;
using System;
using System.Collections.Generic;

namespace ShipBattleGame.Controllers
{
    public class BattleFieldController
    {
        public static Dictionary<Point, string> BattleField = new Dictionary<Point, string> { };

        public enum XCoordinates
        {
            A = 1,
            B,
            C,
            D,
            E,
            F,
            G,
            H,
            I,
            J
        }

        public static void Display()
        {
            ShipController.SetCoordinates();
            CellController.SetEmpty();
            CellController.SetShips();
            DisplayBattleField(BattleField);
        }

        public static void DisplayAfterShooting()
        {
            DisplayBattleField(BattleField);
        }

        private static void DisplayBattleField(Dictionary<Point, string> battleFieldWithCoordinates)
        {
            Console.Clear();
            Console.WriteLine("\tA\tB\tC\tD\tE\tF\tG\tH\tI\tJ");
            for (int x = 1; x < 11; x++)
            {
                Console.Write(x);
                for (int y = 1; y < 11; y++)
                {
                    var a = battleFieldWithCoordinates[new Point { X = y, Y = x }];
                    Console.Write($"\t{a}");
                }
                Console.WriteLine();
                Console.WriteLine("\t----\t----\t----\t----\t----\t----\t----\t----\t----\t----");
            }
        }
    }
}
