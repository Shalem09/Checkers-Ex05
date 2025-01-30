using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CheckersLibrary;

namespace CheckersWindowsApp
{
    public partial class FormGrid : Form
    {
        private Button[,] m_BoardButtons;
        private readonly List<Button> r_AllButtons = new List<Button>();
        private readonly int r_boardSize;
        private Game game;
        private readonly Player r_FirstPlayer = new Player();
        private readonly Player r_SecondPlayer = new Player();
        private Player currentPlayer = new Player();
        private Button selectedButton = null;
        private bool isFirstClick = true;



        public FormGrid(int i_size, string i_player1Name, string i_player2Name, bool i_IsPlayer2Computer)
        {
            InitializeComponent();
            r_boardSize = i_size;
            r_FirstPlayer.SetName(i_player1Name);
            r_FirstPlayer.SetSymbol('X');
            r_SecondPlayer.SetName(i_player2Name);
            r_SecondPlayer.SetSymbol('O');
            Text = "Damka";
            InitializeBoard();
            InitializeGame();
            CreateBoard(r_boardSize);
        }

        private void InitializeBoard()
        {
            int tileSize = 50;
            int margin = 20;

            ClientSize = new Size(r_boardSize * tileSize + margin * 2, r_boardSize * tileSize + margin * 2 + 50);


            player1_label.Text = $"{r_FirstPlayer.m_Name} - Score: {r_FirstPlayer.m_Score}";
            player2_label.Text = $"{r_SecondPlayer.m_Name} - Score: {r_SecondPlayer.m_Score}";

            player1_label.Location = new Point(margin, 10);
            player2_label.Location = new Point(ClientSize.Width - player2_label.Width - margin, 10);
        }

        private void InitializeGame()
        {
            game = new Game(r_boardSize);
            game.InitializeGame(r_boardSize, r_FirstPlayer.m_Name, r_SecondPlayer.m_Name);
            currentPlayer = r_FirstPlayer;
        }

        private void CreateBoard(int size)
        {
            m_BoardButtons = new Button[size, size];

            int buttonSize = 50;
            int startX = 20, startY = 50;
            int playerRows = size == 6 ? 2 : size == 8 ? 3 : 4;

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Button button = new Button();
                    button.Width = buttonSize;
                    button.Height = buttonSize;
                    button.Left = startX + col * buttonSize;
                    button.Top = startY + row * buttonSize;
                    button.Tag = new Point(row, col);
                    button.Click += button_Click;
                    Controls.Add(button);
                    m_BoardButtons[row, col] = button;
                    r_AllButtons.Add(button);

                    if ((row + col) % 2 == 0)
                    {
                        button.BackColor = Color.Gray;
                        button.Enabled = false;
                    }
                    else
                    {
                        button.BackColor = Color.White;
                    }

                    if (row < playerRows && (row + col) % 2 == 1)
                    {
                        button.Text = ePieceType.O.ToString();
                    }
                    else if (row >= size - playerRows && (row + col) % 2 == 1)
                    {
                        button.Text = ePieceType.X.ToString();
                    }
                    else
                    {
                        button.Text = "";
                    }
                }
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton == null) return;

            if (isFirstClick)
            {
                if ((clickedButton.Text == "X" || clickedButton.Text == "K") && currentPlayer.m_Symbol == 'X' ||
                    (clickedButton.Text == "O" || clickedButton.Text == "U") && currentPlayer.m_Symbol == 'O')
                {
                    selectedButton = clickedButton;
                    clickedButton.BackColor = Color.LightBlue;
                    isFirstClick = false;
                }
            }
            else
            {
                Point fromPos = (Point)selectedButton.Tag;
                Point toPos = (Point)clickedButton.Tag;

                List<int> moveMade = new List<int>
                {
                    fromPos.X, fromPos.Y, toPos.X, toPos.Y,
                };

                makeMove(moveMade, clickedButton);

                if (selectedButton != null)
                {
                    selectedButton.BackColor = Color.White;
                }

                selectedButton = null;
                isFirstClick = true;

                GameProcess();
            }
        }

        private void makeMove(List<int> moveMade, Button i_ClickedButton)
        {
            bool isMoveValid = false;
            bool isErrorShown = false;

            List<List<int>> eatingMoves = game.GetOptionalEatMovesNew(game.m_Board, selectedButton.Text[0]);
            bool isEatingMove = game.ContainsMove(eatingMoves, moveMade);

            // Check if the player must eat
            if (!isEatingMove && eatingMoves.Count > 0)
            {
                MessageBox.Show(
                    "You have an eating move! Please make it.",
                    "Invalid Move",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                isErrorShown = true;
            }
            else
            {
                isMoveValid = true;
                if (!isEatingMove)
                {
                    eatingMoves = game.GetOptionalMovesNew(game.m_Board, selectedButton.Text[0]);
                }
            }

            if (game.ContainsMove(eatingMoves, moveMade) && isMoveValid)
            {
                game.MakeMoveNew(moveMade, game.m_Board, isEatingMove);
                UpdateBoardUI();

                Player winner;
                bool isGameOver = IsGameOver(out winner);

                bool hasFurtherEatingMove = false;
                if (isEatingMove && !isGameOver)
                {
                    Point newPos = new Point(moveMade[2], moveMade[3]);
                    List<List<int>> furtherEatingMoves = game.GetOptionalEatMovesNew(game.m_Board, i_ClickedButton.Text[0]);

                    foreach (List<int> move in furtherEatingMoves)
                    {
                        if (move[0] == newPos.X && move[1] == newPos.Y)
                        {
                            hasFurtherEatingMove = true;
                            break;
                        }
                    }
                }

                if (isGameOver)
                {
                    EndGame(winner);
                }
                else if (hasFurtherEatingMove)
                {
                    selectedButton.BackColor = Color.White;
                    i_ClickedButton.BackColor = Color.LightBlue;
                    selectedButton = i_ClickedButton;
                    isFirstClick = false;
                }
                else
                {
                    currentPlayer = (currentPlayer == r_SecondPlayer) ? r_FirstPlayer : r_SecondPlayer;
                    GameProcess();
                }
            }
            else if (!isErrorShown)
            {
                MessageBox.Show(
                    "You have made an invalid move! Please try again.",
                    "Invalid Move",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void UpdateBoardUI()
        {
            for (int row = 0; row < r_boardSize; row++)
            {
                for (int col = 0; col < r_boardSize; col++)
                {
                    ePieceType piece = game.m_Board.GetPieceAt(row, col);

                    if (piece == ePieceType.X)
                        m_BoardButtons[row, col].Text = "X";
                    else if (piece == ePieceType.O)
                        m_BoardButtons[row, col].Text = "O";
                    else if (piece == ePieceType.K)
                        m_BoardButtons[row, col].Text = "K";
                    else if (piece == ePieceType.U)
                        m_BoardButtons[row, col].Text = "U";
                    else
                        m_BoardButtons[row, col].Text = "";
                }
            }
        }

        private void GameProcess()
        {
            bool isComputerTurn = currentPlayer.m_Name == "Computer";
            bool isGameOver = false;

            if (isComputerTurn)
            {
                game.MakeMoveForComputerNew(game.m_Board, r_SecondPlayer.m_Symbol);
                currentPlayer = (currentPlayer == r_SecondPlayer) ? r_FirstPlayer : r_SecondPlayer;
            }

            UpdateBoardUI();

            Player winner;
            isGameOver = IsGameOver(out winner);

            if (isGameOver)
            {
                EndGame(winner);
            }
            else
            {
                isFirstClick = true;
            }
        }

        private bool IsGameOver(out Player o_Winner)
        {
            Player winner = checkForValidatedMoves();

            if (winner == null)
            {
                winner = checkForNoMoreTokens();
            }

            o_Winner = winner;

            if (o_Winner != null)
            {
                game.CalculateScore(game.m_Players);
            }

            return o_Winner != null;
        }

        private Player checkForNoMoreTokens()
        {
            Player winner = null;
            int counterX = 0, counterO = 0;

            for (int i = 0; i < r_boardSize; i++)
            {
                for (int j = 0; j < r_boardSize; j++)
                {
                    ePieceType piece = game.m_Board.GetPieceAt(i, j);

                    if (piece == ePieceType.X || piece == ePieceType.K)
                    {
                        counterX++;
                    }
                    else if (piece == ePieceType.O || piece == ePieceType.U)
                    {
                        counterO++;
                    }
                }
            }

            if (counterO == 0)
            {
                winner = game.m_Players[0];
            }
            else if (counterX == 0)
            {
                winner = game.m_Players[1];
            }

            return winner;
        }


        private Player checkForValidatedMoves()
        {
            Player winner = null;

            List<List<int>> movesForO = game.GetOptionalEatMovesNew(game.m_Board, 'O');
            movesForO.AddRange(game.GetOptionalMovesNew(game.m_Board, 'O'));

            List<List<int>> movesForX = game.GetOptionalEatMovesNew(game.m_Board, 'X');
            movesForX.AddRange(game.GetOptionalMovesNew(game.m_Board, 'X'));

            if (movesForO.Count == 0 && movesForX.Count == 0)
            {
                winner = null; // תיקו
            }
            else if (movesForO.Count == 0)
            {
                winner = game.m_Players[0];
            }
            else if (movesForX.Count == 0)
            {
                winner = game.m_Players[1];
            }

            return winner;
        }


        private static DialogResult firstPlayerWonMessageBox()
        {
            return MessageBox.Show($"Player 1 won!{Environment.NewLine} Another Round?", "Damka", MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);
        }

        private static DialogResult secondPlayerWonMessageBox()
        {
            return MessageBox.Show($"Player 2 won!{Environment.NewLine} Another Round?", "Damka", MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);
        }

        private static DialogResult tieMessageBox()
        {
            return MessageBox.Show($"Tie!{Environment.NewLine} Another Round?", "Damka", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
        }

        private void EndGame(Player i_Winner)
        {
            DialogResult result;

            if (i_Winner == null)
            {
                result = tieMessageBox();
            }
            else if (i_Winner.m_Name == r_FirstPlayer.m_Name)
            {
                result = firstPlayerWonMessageBox();
            }
            else
            {
                result = secondPlayerWonMessageBox();
            }

            if (result == DialogResult.Yes)
            {
                RestartGame();
            }
            else
            {
                Application.Exit();
            }
        }

        private void RestartGame()
        {
            game.RestartGame();
            UpdateBoardUI();
            GameProcess();
        }
    }
}