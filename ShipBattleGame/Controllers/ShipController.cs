using ShipBattleGame.Models;
using ShipBattleGame.Structures;
using System;
using System.Collections.Generic;
using static ShipBattleGame.Models.Ship;

namespace ShipBattleGame.Controllers
{
    public class ShipController
    {
        public static readonly List<Ship> ships = new List<Ship> { };
        private static readonly List<Point> coordinates = new List<Point> { };

        public static List<Ship> CreateShips()
        {
            for (int numberOfShips = 1, numberOfDecks = 4; numberOfShips < 5; numberOfShips++)
            {
                for (int k = 1; k <= numberOfShips; k++)
                {
                    ships.Add(CreateShip(numberOfDecks));
                }
                numberOfDecks--;
            }

            return ships;
        }

        public static void SetCoordinates()
        {
            for (int x = 1; x <= 10; x++)
            {
                for (int y = 1; y <= 10; y++)
                {
                    coordinates.Add(new Point(x, y));
                }
            }
        }

        private static Ship CreateShip(int shipSize)
        {
            Ship ship;
            bool shipIsCorrect;
            do
            {
                ship = new Ship(shipSize, GetFirstCoordinate(), GetPositionForShip());
                shipIsCorrect = IsShipCorrect(ship);
            } while (!shipIsCorrect);

            return ship;
        }

        private static bool IsShipCorrect(Ship ship)
        {
            foreach (var coordinate in ship.Coordinates)
            {
                if (!coordinates.Contains(coordinate))
                {
                    return false;
                }
            }
            RemoveUsedCoordinates(ship);

            return true;
        }

        private static void RemoveUsedCoordinates(Ship ship)
        {
            foreach (var coordinate in ship.Coordinates)
            {
                Point cell = new Point(coordinate.X, coordinate.Y);
                for (var x = -1; x < 2; x++)
                {
                    for (var y = -1; y < 2; y++)
                    {
                        cell.X = coordinate.X + x; cell.Y = coordinate.Y + y;

                        if (coordinates.Contains(cell))
                        {
                            coordinates.Remove(cell);
                        }
                    }
                }
            }
        }

        private static Point GetFirstCoordinate()
        {
            Random r = new Random();
            var x = r.Next(1, 11);
            var y = r.Next(1, 11);
            var coordinate = new Point(x, y);

            return coordinate;
        }

        private static PositionOnField GetPositionForShip()
        {
            Random r = new Random();
            var position = r.Next(0, 2);

            return position == 0 ? PositionOnField.Horizontal : PositionOnField.Vertical;
        }
    }
}
