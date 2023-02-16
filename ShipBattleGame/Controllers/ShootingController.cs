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
                foreach (var shipPoint in ship.Coordinates)
                {
                    var shipDeckIsDestroyed = shotCoordinate.ToUpper() == Enum.GetName(typeof(XCoordinates), shipPoint.X) + shipPoint.Y;

                    if (shipDeckIsDestroyed)
                    {
                        BattleField[new Point { X = shipPoint.X, Y = shipPoint.Y }] = "X";
                        return ship;
                    }
                }
            }
            return null;
        }

        public static bool AllShipsAreDestroyed(Dictionary<Point, string> battleFieldWithCoordinates)
        {
            foreach (var shipPointValue in battleFieldWithCoordinates)
            {
                bool deckIsDestroyed = shipPointValue.Value == "X";
                bool emptyCell = shipPointValue.Value == "·";
                if (deckIsDestroyed || emptyCell)
                {
                    continue;
                }

                return true;
            }

            return false;
        }
    }
}
