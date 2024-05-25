using ConnectGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConnectGameTest
{

    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void Board_InitializesCorrectly()
        {
            var board = new Board(9, 9);

            Assert.AreEqual(9, board.Rows);
            Assert.AreEqual(9, board.Columns);
        }

        [TestMethod]
        public void Board_DropTokenCorrectly()
        {
            var board = new Board(9, 9);
            var player = new Player("TestPlayer", 'X');

            board.DropToken(0, player);
            Assert.AreEqual(player, board.GetToken(8, 0));
        }

        [TestMethod]
        public void Board_DetectsHorizontalWin()
        {
            var board = new Board(9, 9);
            var player = new Player("TestPlayer", 'X');

            for (int i = 0; i < 4; i++)
            {
                board.DropToken(i, player);
            }

            Assert.IsTrue(board.CheckForWin(player));
        }

        [TestMethod]
        public void Board_DetectsVerticalWin()
        {
            var board = new Board(9, 9);
            var player = new Player("TestPlayer", 'X');

            for (int i = 0; i < 4; i++)
            {
                board.DropToken(0, player);
            }

            Assert.IsTrue(board.CheckForWin(player));
        }

        [TestMethod]
        public void Board_DetectsDiagonalWin()
        {
            var board = new Board(9, 9);
            var player = new Player("TestPlayer", 'X');

            board.DropToken(0, player);
            board.DropToken(1, new Player("OtherPlayer", 'O'));
            board.DropToken(1, player);
            board.DropToken(2, new Player("OtherPlayer", 'O'));
            board.DropToken(2, new Player("OtherPlayer", 'O'));
            board.DropToken(2, player);
            board.DropToken(3, new Player("OtherPlayer", 'O'));
            board.DropToken(3, new Player("OtherPlayer", 'O'));
            board.DropToken(3, new Player("OtherPlayer", 'O'));
            board.DropToken(3, player);

            Assert.IsTrue(board.CheckForWin(player));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Board_ThrowsExceptionWhenColumnFull()
        {
            var board = new Board(9, 9);
            var player = new Player("TestPlayer", 'X');

            for (int i = 0; i < 10; i++)
            {
                board.DropToken(0, player);
            }
        }
    }
}
