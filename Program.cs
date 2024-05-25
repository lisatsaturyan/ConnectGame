using ConnectGame;
using System;

Console.WriteLine("Please Player1 Enter your Name:");
string player1Name = Console.ReadLine();

Console.WriteLine("Please Player2 Enter your Name:");
string player2Name = Console.ReadLine();

int rows, columns;
while (true)
{
    Console.Write("Enter the number of rows for the board: ");
    if (int.TryParse(Console.ReadLine(), out rows) && rows > 0)
    {
        break;
    }
    Console.WriteLine("Please enter a valid number of rows.");
}

while (true)
{
    Console.Write("Enter the number of columns for the board: ");
    if (int.TryParse(Console.ReadLine(), out columns) && columns > 0)
    {
        break;
    }
    Console.WriteLine("Please enter a valid number of columns.");
}

var game = new Game(player1Name, player2Name, rows, columns);
Console.WriteLine($"Welcome, {game.Player1.Name} and {game.Player2.Name}.");
Console.WriteLine($"The dimensions of the board are {rows}x{columns}.");
Console.WriteLine($"The player who starts the game is {game.CurrentPlayer.Name}.");

while (game.Winner == null)
{
    game.Board.PrintBoard();
    Console.WriteLine($"{game.CurrentPlayer.Name}, choose column? (0-{columns - 1})");

    if (int.TryParse(Console.ReadLine(), out int column) && column >= 0 && column < columns)
    {
        try
        {
            game.PlayTurn(column);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    else
    {
        Console.WriteLine("Invalid column, please choose another one.");
    }
}

game.Board.PrintBoard();
Console.WriteLine($"Congratulations {game.Winner.Name}, you won the game!");
