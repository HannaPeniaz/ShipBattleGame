using ShipBattleGame.Controllers;
using ShipBattleGame.Structures;
using System.Collections.Generic;

namespace ShipBattleGame.Models
{
    public class Ship
    {
        public static int Size;
        public List<Point> Coordinates;
        public PositionOnField Orienation;
        public static State DamageLevel;

        public enum PositionOnField
        {
            Vertical,
            Horizontal
        }

        public enum State
        {
            Destroyed,
            Injured
        }

        public Ship(int size, Point startPoint, PositionOnField orienation)
        {
            Size = size;
            Orienation = orienation;
            Coordinates = Orienation == PositionOnField.Vertical ? CreateVerticalShip(size, startPoint) : CreateHorizontalShip(size, startPoint);
        }

        public State GetStateOfShip(Ship ship)
        {
            foreach (var coordinate in ship.Coordinates)
            {
                var coordinateIsDestroyed = BattleFieldController.BattleField[new Point { X = coordinate.X, Y = coordinate.Y }] == "X";
                if (!coordinateIsDestroyed)
                {
                    return State.Injured;
                }
            }
            return State.Destroyed;
        }

        private List<Point> CreateVerticalShip(int size, Point startPoint)
        {
            var shipCoordinates = new List<Point>();
            var temp = 0;
            for (var i = startPoint.Y - 1; temp < size; i++)
            {
                shipCoordinates.Add(new Point() { X = startPoint.X, Y = startPoint.Y++ });
                temp++;
            }

            return shipCoordinates;
        }

        private List<Point> CreateHorizontalShip(int size, Point startPoint)
        {
            var shipCoordinates = new List<Point>();
            var temp = 0;
            for (var i = startPoint.X; temp < size; i++)
            {
                shipCoordinates.Add(new Point() { X = startPoint.X++, Y = startPoint.Y });
                temp++;
            }

            return shipCoordinates;
        }
    }
}
