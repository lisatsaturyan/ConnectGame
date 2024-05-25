using ConnectGame;
using ConnectGameTest;

namespace ConnectGameTest
{
        [TestClass]
        public class PlayerTests
        {
            [TestMethod]
            public void Player_Initialization()
            {
                var player1 = new Player("Player1", 'X');
                var player2 = new Player("Player2", 'O');

                Assert.AreEqual("Player1", player1.Name);
                Assert.AreEqual('X', player1.Token);
                Assert.AreEqual("Player2", player2.Name);
                Assert.AreEqual('O', player2.Token);
            }
        }
    }

