using ShipBattleGame.Models;
using ShipBattleGame.Structures;
using System;
using System.Collections.Generic;
using static ShipBattleGame.Controllers.BattleFieldController;

namespace ShipBattleGame.Controllers
{
    public class CellController
    {
        public static Dictionary<Point, string> GetMapCoordinates()
        {
            Dictionary<Point, string> battleArea = new Dictionary<Point, string>();
            for (int x = 1; x < 11; x++)
            {
                for (int y = 1; y < 11; y++)
                {
                    battleArea.Add(new Point(x, y), Enum.GetName(typeof(XCoordinates), x) + y);
                }
            }

            return battleArea;
        }

        public static void SetEmpty()
        {
            for (int x = 1; x < 11; x++)
            {
                for (int y = 1; y < 11; y++)
                {
                    BattleField[new Point { X = y, Y = x }] = "·";
                }
            }
        }

        public static void SetShips()
        {
            var ships = ShipController.CreateShips();
            foreach (var ship in ships)
            {
                SetOneShip(ship);
            }
        }

        private static void SetOneShip(Ship ship)
        {
            foreach (var coordinate in ship.Coordinates)
            {
                BattleField[new Point { X = coordinate.X, Y = coordinate.Y }] = Enum.GetName(typeof(XCoordinates), coordinate.X) + coordinate.Y;
            }
        }
    }
}
