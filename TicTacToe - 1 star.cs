// ABDIEL WONG AVILA

//(*) Modify the code so that one player makes "#" marks instead of "X"marks, and the other player makes "@" marks instead of "O" marks.

//(*) Modify the code so that the player has to press ENTER to start the game after showing the start screen. Make sure that the player  knows that ENTER must be pressed to start the game.

//(*) Modify the code so that both players can enter their names before playing, so that the game over screen congratulates them by their name.


using System;
public class TicTacToe
{

    public const string X = "#";

    public const string O = "@";

    public string PlayerOne;

    public string PlayerTwo;

    public string[] board;

    public bool isPlayerOneTurn;


    public static void Main()

    {

        TicTacToe ttt = new TicTacToe();

        ttt.Start();

    }

    public void Start()

    {

        int input;

        Init(); // 1. Initialize Variables and Environment

        ShowGameStartScreen(); // 2. Show Game Start Screen

        do

        {

            ShowBoard(); // 3. Show Board

            do

            {

                ShowInputOptions(); // 4. Show Input Options

                input = GetInput(); // 5. Get Input

            }

            while (
            !IsValidInput(input)
            ); // 6. Validate Input

            ProcessInput(input); // 7. Process Input

            UpdateGameState(); // 8. Update Game State

        }

        while (
        !IsGameOver()
        ); // 9. Check Termination Condition

        ShowGameOverScreen(); // 10. Show Game Over Screen

    }

    public void Init()

    {

        board = new string[9];

        for (int i = 0; i < board.Length; i++)

        {

            board[i] = i.ToString();

        }

        isPlayerOneTurn = true;

    }

    public void ShowGameStartScreen()

    {
        Console.WriteLine("Welcome to Tic-Tac-Toe! \n\nPress ENTER to continue");

        while (Console.ReadKey().Key != ConsoleKey.Enter)
        {
            Console.WriteLine("\nPlease, press ENTER to continue");
        }

        Console.Clear();

        Console.WriteLine("Player 1: Please type your name and press Enter");

        PlayerOne = Console.ReadLine();

        Console.WriteLine("Thank you " + PlayerOne + "\n\n");

        Console.WriteLine("Player 2: Please type your name and press Enter");

        PlayerTwo = Console.ReadLine();

        Console.WriteLine("Thank you " + PlayerTwo);

    }

    public void ShowBoard()

    {

        string b = board[0] + "|" + board[1] + "|" + board[2] + "\n" +

        "-----\n" +

        board[3] + "|" + board[4] + "|" + board[5] + "\n" +

        "-----\n" +

        board[6] + "|" + board[7] + "|" + board[8] + "\n";

        Console.WriteLine("\n" + b);

    }

    public void ShowInputOptions()

    {

        Console.Write("Input any number between 0 and 8: ");

    }

    public int GetInput()

    {

        try

        {

            int input = Convert.ToInt32(Console.ReadLine()
            );

            return input;

        }

        catch (Exception e)

        {

            return -1;

        }

    }

    public bool IsValidInput(int input)

    {

        if (input < 0 || input > 8)

        {

            Console.WriteLine("Please input a number between 0 and 8.\n");

            return false;

        }

        else if (
        !IsEmpty(input)
        )

        {

            Console.WriteLine("Position " + input + " has already been played.\n");

            return false;

        }

        else

        {

            return true;

        }

    }

    public bool IsEmpty(int a)

    {

        return (board[a] != X && board[a] != O);

    }


    public void ProcessInput(int input)

    {

        if (isPlayerOneTurn)

        {

            board[input] = X;

        }

        else

        {

            board[input] = O;

        }

        ShowBoard();

    }

    public void UpdateGameState()

    {

        isPlayerOneTurn = !isPlayerOneTurn;

    }

    public bool IsGameOver()

    {

        return CheckWin(X) || CheckWin(O) || CheckDraw();

    }

    public bool CheckWin(string mark)

    {

        return CheckLine(mark, 0, 1, 2) || CheckLine(mark, 3, 4, 5) || CheckLine(mark, 6, 7, 8) || CheckLine(mark, 0, 3, 6) || CheckLine(mark, 1, 4, 7) || CheckLine(mark, 2, 5, 8) ||
               CheckLine(mark, 0, 4, 8) || CheckLine(mark, 2, 4, 6);

    }

    public bool CheckLine(string mark, int a, int b, int c)

    {

        return (board[a] == mark && board[b] == mark && board[c] == mark);

    }

    public bool CheckDraw()

    {

        for (int i = 0; i < board.Length; i++)

        {

            if (IsEmpty(i)
            ) { return false; }

        }

        return true;

    }

    public void ShowGameOverScreen()

    {

        ShowBoard();

        if (CheckWin(X)
        )

        {

            Console.WriteLine(PlayerOne + " won!\n");

        }

        else if (CheckWin(O)
        )

        {

            Console.WriteLine(PlayerTwo + " won!\n");

        }

        else

        {

            Console.WriteLine("Draw!\n");

        }

    }
}
// <-- NOT HERE.