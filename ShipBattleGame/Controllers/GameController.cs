using ShipBattleGame.ConsoleHelper;
using System;

namespace ShipBattleGame.Controllers
{
    public class GameController
    {
        public static void Game()
        {
            Message.Print("\nLet's start a game!");
            do
            {
                var cellToShoot = UserInput.GetUserInput();
                var shipAfterShooting = ShootingController.GetShipWithDestroyedDeck(ShipController.ships, cellToShoot);
                if (shipAfterShooting != null)
                {
                    var stateOfShip = shipAfterShooting.GetStateOfShip(shipAfterShooting);
                    BattleFieldController.DisplayAfterShooting();
                    Message.Print(stateOfShip);
                }
                else
                {
                    BattleFieldController.DisplayAfterShooting();
                    Message.Print("You missed!");
                }

            } while (ShootingController.AllShipsAreDestroyed(BattleFieldController.BattleField) || BattleFieldController.BattleField.Count == 0);

            Message.Print("\nGame is over! Good fight!");
            UserInput.Exit();
        }
    }
}
