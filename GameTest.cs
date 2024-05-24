using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectGame;

namespace ConnectGameTest
{

    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void Game_InitializesCorrectly()
        {
            var game = new Game("Alice", "Bob");

            Assert.IsNotNull(game.Player1);
            Assert.IsNotNull(game.Player2);
            Assert.IsNotNull(game.Board);

            Assert.IsTrue(game.Player1.Token == 'X' || game.Player2.Token == 'X');
            Assert.IsTrue(game.Player1.Token == 'O' || game.Player2.Token == 'O');
        }

        [TestMethod]
        public void Game_SwitchesPlayersAfterTurn()
        {
            var game = new Game("Alice", "Bob");
            var initialPlayer = game.CurrentPlayer;

            game.PlayTurn(0);
            Assert.AreNotEqual(initialPlayer, game.CurrentPlayer);
        }
    }
}

