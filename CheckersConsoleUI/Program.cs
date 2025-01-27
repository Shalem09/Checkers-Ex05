using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using CheckersLibrary;

namespace CheckersConsoleUI
{
    public class Program
    {
        private static Game s_Game;

        public static void Main()
        {
            Console.WriteLine("Welcome to Checkers!");

            InitializeGame();
            eOpponentType opponentType = s_Game.m_Players[1].m_Name == "Computer" ? eOpponentType.Computer : eOpponentType.Player;

            while (true)
            {
                PlayGame(opponentType);

                if (continueToAnotherGame())
                {
                    s_Game.RestartGame();
                }
                else
                {
                    Console.WriteLine("Bye bye!");
                    break;
                }
            }
        }

        private static string PlayerVsPlayer(ref Player i_CurrentPlayer, string i_Move)
        {
            Player previousPlayer = i_CurrentPlayer == s_Game.m_Players[0] ? s_Game.m_Players[1] : s_Game.m_Players[0];

            PrintBoard(previousPlayer, i_Move);

            string playerMove = HandlePlayerMove(s_Game.m_Board, i_CurrentPlayer);
            i_CurrentPlayer = i_CurrentPlayer == s_Game.m_Players[0] ? s_Game.m_Players[1] : s_Game.m_Players[0];

            return playerMove;
        }

        private static string PlayerVsComputer(ref Player i_CurrentPlayer, string i_Move)
        {
            string move = null;

            if (i_CurrentPlayer.m_Name == "Computer")
            {
                PrintBoard(s_Game.m_Players[0], i_Move);
                Console.WriteLine($"Computer is thinking...{Environment.NewLine}Press 'enter' to reavel it's move");
                Console.ReadKey();

                move = s_Game.MakeMoveForComputer(s_Game.m_Board, i_CurrentPlayer.m_Symbol);
                i_CurrentPlayer = s_Game.m_Players[0];
            }
            else
            {
                PrintBoard(s_Game.m_Players[1], i_Move);
                move = HandlePlayerMove(s_Game.m_Board, i_CurrentPlayer);
                i_CurrentPlayer = s_Game.m_Players[1];
            }

            return move;
        }

        private static void PlayGame(eOpponentType i_OpponentType)
        {
            Player currentPlayer = s_Game.m_Players[0];
            string move = null;

            while (true)
            {
                switch (i_OpponentType)
                {
                    case eOpponentType.Player:
                        move = PlayerVsPlayer(ref currentPlayer, move);
                        break;
                    case eOpponentType.Computer:
                        move = PlayerVsComputer(ref currentPlayer, move);
                        break;
                }

                if (CheckForGameOver())
                {
                    s_Game.CalculateScore(s_Game.m_Players);
                    determineGameOutcome();
                    break;
                }
            }

            PrintScoreBoard();
        }

        private static void InitializeGame()
        {
            int boardSize = getBoardSizeFromMenu();

            Console.Write("Enter Player 1 name: ");
            string player1Name = Console.ReadLine();

            string player2Name = getPlayerOrComputer();

            s_Game = new Game();
            s_Game.InitializeGame(boardSize, player1Name, player2Name);
        }

        private static int getBoardSizeFromMenu()
        {
            int boardSize;
            while (true)
            {
                Console.WriteLine("Select the board size:");
                Console.WriteLine("1. 6x6");
                Console.WriteLine("2. 8x8");
                Console.WriteLine("3. 10x10");
                Console.Write("Enter your choice (1-3): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            boardSize = 6;
                            break;
                        case 2:
                            boardSize = 8;
                            break;
                        case 3:
                            boardSize = 10;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
                            continue;
                    }
                    break; // Exit the loop if a valid choice is made
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
                }
            }

            Console.WriteLine($"You selected a {boardSize}x{boardSize} board.");
            return boardSize;
        }

        private static string getPlayerOrComputer()
        {
            string secondPlayerName;
            while (true)
            {
                Console.WriteLine("Do you want to play against another player or computer?");
                Console.WriteLine("1. Player");
                Console.WriteLine("2. Computer");
                Console.Write("Enter your choice (1-2): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter Player 2 name: ");
                            secondPlayerName = Console.ReadLine();
                            break;
                        case 2:
                            secondPlayerName = "Computer";
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
                            continue;
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
                }
            }

            return secondPlayerName;
        }

        private static bool continueToAnotherGame()
        {
            bool continuePlaying;
            Console.WriteLine("Do you want to play another game?");
            Console.WriteLine("another game continue with current players, score and size.");
            Console.Write("Enter your choice (y/n): ");
            while (true)
            {
                string input = Console.ReadLine();

                if (input.Length != 1)
                {
                    continue;
                }

                if (input.ToUpper() == "Y")
                {
                    continuePlaying = true;
                }
                else if (input.ToUpper() == "N")
                {
                    continuePlaying = false;
                }
                else
                {
                    Console.WriteLine("Wrong choice please enter y or n");
                    continue;
                }

                return continuePlaying;
            }
        }

        private static void PrintBoard(Player i_CurrentPlayer, string i_Move)
        {
            ePieceType[,] grid = s_Game.m_Board.Grid;
            int boardSize = grid.GetLength(0);
            string horizontalSeparator = "   " + new string('=', boardSize * 4 + 1);

            Console.Clear();
            Console.Write("   ");
            for (int col = 0; col < boardSize; col++)
            {
                Console.Write($"  {Convert.ToChar('a' + col)} ");
            }

            Console.WriteLine();

            for (int row = 0; row < boardSize; row++)
            {
                Console.WriteLine(horizontalSeparator);

                Console.Write($" {Convert.ToChar('A' + row)} ");
                for (int col = 0; col < boardSize; col++)
                {
                    Console.Write($"| {(char)grid[row, col]} ");
                }

                Console.WriteLine("|");
            }

            Console.WriteLine(horizontalSeparator);

            if (i_Move != null)
            {
                Console.WriteLine($"{i_CurrentPlayer.m_Name}'s ({i_CurrentPlayer.m_Symbol}) move was: {i_Move}");
            }

        }

        private static string HandlePlayerMove(Board i_Board, Player i_Player)
        {
            char currentPlayerSymbol = i_Player.m_Symbol;
            List<string> regularMoves = s_Game.GetOptionalMoves(i_Board, currentPlayerSymbol);
            string input = null;

            while (!s_Game.m_IsGameOver)
            {
                PrintBoard(i_Player, input);

                Console.WriteLine($"{i_Player.m_Name} ({i_Player.m_Symbol}) please make a move.");
                Console.WriteLine("Move looks like FROMROWfromcol>TOROWtocol, or q to quit");

                input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input) && input.Length == 1 && char.ToUpper(input[0]) == 'Q')
                {
                    s_Game.ChangeGameOverState(i_Player);
                    break;
                }

                if (!ValidateInput(input))
                {
                    continue;
                }

                string from = input.Substring(0, 2);
                string to = input.Substring(3, 2);

                int fromRow = from[0] - 'A';
                int fromCol = from[1] - 'a';
                int toRow = to[0] - 'A';
                int toCol = to[1] - 'a';

                if (!s_Game.IsValidPosition(fromRow, fromCol) || !s_Game.IsValidPosition(toRow, toCol))
                {
                    Console.WriteLine("Invalid move.");
                    continue;
                }

                List<string> eatMoves = s_Game.GetOptionalEatMoves(i_Board, currentPlayerSymbol);

                if (eatMoves.Count > 0)
                {
                    if (eatMoves.Contains(input))
                    {
                        s_Game.MakeMove(input, i_Board, true);

                        while (s_Game.HasMoreEatMoves(input, i_Board, ref eatMoves))
                        {
                            PrintBoard(i_Player, input);
                            Console.WriteLine($"{i_Player.m_Name} ({i_Player.m_Symbol}), you have additional eat moves.");
                            Console.WriteLine("Move looks like FROMROWfromcol>TOROWtocol:");
                            input = Console.ReadLine();

                            if (!ValidateInput(input))
                            {
                                continue;
                            }

                            if (!eatMoves.Contains(input))
                            {
                                Console.WriteLine("Invalid move. You must continue eating.");
                                continue;
                            }

                            s_Game.MakeMove(input, i_Board, true);
                        }

                        break;
                    }
                    else
                    {
                        Console.WriteLine("You have an eat move. You must perform it.");
                        continue;
                    }
                }
                else if (regularMoves.Count > 0)
                {
                    if (regularMoves.Contains(input))
                    {
                        s_Game.MakeMove(input, i_Board, false);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid move.");
                    }
                }
                else
                {
                    s_Game.ChangeGameOverState(null);
                }
            }

            return input;
        }

        private static bool ValidateInput(string input)
        {
            bool isValidated = true;

            if (string.IsNullOrWhiteSpace(input) || !input.Contains(">") || input.Length != 5)
            {
                Console.WriteLine("Invalid input format. Please use FROMROWfromcol>TOROWtocol.");
                isValidated = false;
            }

            return isValidated;
        }

        private static bool CheckForGameOver()
        {
            return s_Game.m_IsGameOver;
        }

        private static void PrintScoreBoard()
        {
            Console.WriteLine("Scores are:");

            foreach (Player p in s_Game.m_Players)
            {
                Console.WriteLine($"{p.m_Name}: {p.m_Score}");
            }
        }

        private static void determineGameOutcome()
        {
            Player winner = null;
            Player loser;

            if (s_Game.m_Quitter != null)
            {
                loser = s_Game.m_Quitter;

                foreach (Player player in s_Game.m_Players)
                {
                    if (player != loser)
                    {
                        winner = player;
                        break;
                    }
                }

                Console.WriteLine($"{loser.m_Name} has lost by quitting, {winner.m_Name} won the Game!");
            }
            else
            {
                Player player1 = s_Game.m_Players[0];
                Player player2 = s_Game.m_Players[1];

                if (player1.m_Score > player2.m_Score)
                {
                    winner = player1;
                    loser = player2;
                }
                else if (player2.m_Score > player1.m_Score)
                {
                    winner = player2;
                    loser = player1;
                }
                else
                {
                    Console.WriteLine("The game is a draw! Both players scored equally.");
                    return;
                }

                Console.WriteLine($"{loser.m_Name} has lost, {winner.m_Name} won the Game!");
                PrintScoreBoard();
            }
        }
    }
}