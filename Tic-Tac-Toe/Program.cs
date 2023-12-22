// See https://aka.ms/new-console-template for more information
using Game;


var game = new Tic_Tac_Toe();
game.InitiateNewGame();
void RenderTicTacToe()
{
    for (int j = 0; j < 3; j++)
    {
        var index = j * 3;
        Console.Write(game.Locations[index]);
        Console.Write("|");
        Console.Write(game.Locations[index + 1]);
        Console.Write("|");
        Console.WriteLine(game.Locations[index + 2]);
    }
}

var movesLeft = false;
char? playerWon = null;
var gameFinished = false;
var playerTurn = 'O';
var playerInput = 0;

void TakeUserInput()
{
    bool inputTaken = false;
    while(!inputTaken)
    {
        Console.Clear();
        RenderTicTacToe();

        Console.Write($"{playerTurn}'s Turn: ");
        
        if (int.TryParse(Console.ReadLine(), out playerInput))
        {
            if (playerInput > 0 && playerInput < 10)
                inputTaken = true;
            else
            {
                Console.WriteLine("Error! Number must be between 0 and 9. Press any key.");
                Console.ReadKey();
            }                
        }        
    }

}

do
{
    Console.Clear();
    RenderTicTacToe();

    TakeUserInput();

    game.InsertUserInput(playerTurn, playerInput - 1);

    var gameFilled = game.AreLocationsFilled();
    playerWon = game.DetermineWin();
    movesLeft = !gameFilled;

    if (!movesLeft || playerWon != null)
        gameFinished = true;

    if (!gameFinished)
        if (playerTurn == 'O')
            playerTurn = 'X';
        else
            playerTurn = 'O';

} while (!gameFinished);

if (playerWon != null)
    Console.WriteLine($"{playerTurn} Won!");
else
    Console.WriteLine("No spaces left");


