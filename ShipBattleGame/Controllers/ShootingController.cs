using ShipBattleGame.Models;
using ShipBattleGame.Structures;
using System;
using System.Collections.Generic;
using static ShipBattleGame.Controllers.BattleFieldController;

namespace ShipBattleGame.Controllers
{
    public class ShootingController
    {

        public static Ship GetShipWithDestroyedDeck(List<Ship> ships, string shotCoordinate)
        {
            foreach (var ship in ships)
            {
                foreach (var coordinate in ship.Coordinates)
                {
                    var shipCoordinateIsDestroyed = shotCoordinate.ToUpper() == Enum.GetName(typeof(XCoordinates), coordinate.X) + coordinate.Y;

                    if (shipCoordinateIsDestroyed)
                    {
                        BattleField[new Point { X = coordinate.X, Y = coordinate.Y }] = "X";
                        return ship;
                    }
                }
            }
            return null;
        }

        public static bool AllShipsAreDestroyed(Dictionary<Point, string> battleFieldWithCoordinates)
        {
            foreach (var coordinate in battleFieldWithCoordinates)
            {
                bool coordinateIsDestroyed = coordinate.Value == "X";
                bool emptyCell = coordinate.Value == "·";
                if (coordinateIsDestroyed || emptyCell)
                {
                    continue;
                }

                return true;
            }

            return false;
        }
    }
}
