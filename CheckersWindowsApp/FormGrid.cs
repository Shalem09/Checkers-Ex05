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
        private readonly int r_BoardSize;
        private Game m_Game;
        private readonly Player r_FirstPlayer = new Player();
        private readonly Player r_SecondPlayer = new Player();
        private Player m_CurrentPlayer = new Player();
        private Button m_SelectedButton = null;

        public FormGrid(int i_size, string i_player1Name, string i_player2Name, 
            Color i_FirstPlayerLabelColor, Color i_SecondPlayerLabelColor)
        {
            InitializeComponent();
            r_BoardSize = i_size;
            r_FirstPlayer.SetName(i_player1Name);
            r_FirstPlayer.SetSymbol('X');
            r_SecondPlayer.SetName(i_player2Name);
            r_SecondPlayer.SetSymbol('O');
            Text = "Damka";
            initializeGame(i_FirstPlayerLabelColor, i_SecondPlayerLabelColor);
            initializeBoard();
            createBoard(r_BoardSize);

        }

        private void initializeBoard()
        {
            int tileSize = 50;
            int margin = 20;

            ClientSize = new Size(r_BoardSize * tileSize + margin * 2, r_BoardSize * tileSize + margin * 2 + 50);

            if (m_Game != null)
            {
                labelFirstPlayer.Text = $"{r_FirstPlayer.m_Name} - Score: {m_Game.m_Players[0].m_Score}";
                labelSecondPlayer.Text = $"{r_SecondPlayer.m_Name} - Score: {m_Game.m_Players[1].m_Score}";
            }
            else
            {
                labelFirstPlayer.Text = $"{r_FirstPlayer.m_Name} - Score: 0";
                labelSecondPlayer.Text = $"{r_SecondPlayer.m_Name} - Score: 0";
            }
            labelFirstPlayer.Location = new Point(margin, 10);
            labelSecondPlayer.Location = new Point(ClientSize.Width - labelSecondPlayer.Width - margin, 10);
        }

        private void initializeGame(Color i_FirstPlayerLabelColor, Color i_SecondPlayerLabelColor)
        {

            m_Game = new Game(r_BoardSize);
            m_Game.InitializeGame(r_BoardSize, r_FirstPlayer.m_Name, r_SecondPlayer.m_Name);
            m_CurrentPlayer = r_FirstPlayer;
            labelFirstPlayer.ForeColor = i_FirstPlayerLabelColor;
            labelSecondPlayer.ForeColor = i_SecondPlayerLabelColor;
        }

        private void createBoard(int i_Size)
        {
            m_BoardButtons = new Button[i_Size, i_Size];

            int buttonSize = 50;
            int startX = 20, startY = 50;
            int playerRows = i_Size == 6 ? 2 : i_Size == 8 ? 3 : 4;

            for (int row = 0; row < i_Size; row++)
            {
                for (int col = 0; col < i_Size; col++)
                {
                    Button button = new Button();
                    button.Font = new Font(button.Font.FontFamily, 15, FontStyle.Bold);
                    button.Width = buttonSize;
                    button.Height = buttonSize;
                    button.Left = startX + col * buttonSize;
                    button.Top = startY + row * buttonSize;
                    button.Tag = new Point(row, col);
                    button.Click += button_FirstClick;
                    Controls.Add(button);
                    m_BoardButtons[row, col] = button;

                    if ((row + col) % 2 == 0)
                    {
                        button.BackColor = Color.Gray;
                        button.Enabled = false;
                    }
                    else
                    {
                        button.BackColor = Color.White;
                    }
                }
            }

            updateBoardUI();
        }

        private void setButtonSetTextColor(Button i_Button)
        {
            if(i_Button.Text == "O" || i_Button.Text == "U")
            {
                i_Button.ForeColor = FormSettings.m_SecondPlayerLabelColor;
            }

            if (i_Button.Text == "X" || i_Button.Text == "K")
            {
                i_Button.ForeColor = FormSettings.m_FirstPlayerLabelColor;
            }
        }

        private void button_FirstClick(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if ((clickedButton.Text == "X" || clickedButton.Text == "K") && m_CurrentPlayer.m_Symbol == 'X' ||
                (clickedButton.Text == "O" || clickedButton.Text == "U") && m_CurrentPlayer.m_Symbol == 'O')
            {
                m_SelectedButton = clickedButton;
                clickedButton.BackColor = Color.LightBlue;
                UpdateAllButtonsToSecondClick();
            }
        }

        private void button_SecondClick(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (m_SelectedButton == null) return;

            Point fromPos = (Point)m_SelectedButton.Tag;
            Point toPos = (Point)clickedButton.Tag;

            if (fromPos != toPos)
            {
                List<int> moveMade = new List<int>
                {
                    fromPos.X, fromPos.Y, toPos.X, toPos.Y,
                };

                makeMove(moveMade, clickedButton);
            }

            if (m_SelectedButton != null)
            {
                m_SelectedButton.BackColor = Color.White;
            }

            m_SelectedButton = null;

            UpdateAllButtonsToFirstClick();
        }

        // מתודה שרושמת את כל הכפתורים הקיימים בלוח למתודת ה "קליק השני"
        private void UpdateAllButtonsToSecondClick()
        {
            foreach (Control control in Controls)
            {
                if (control is Button button)
                {
                    button.Click -= button_FirstClick;
                    button.Click += button_SecondClick;
                }
            }
        }

        // מתודה שרושמת את כל הכפתורים הקיימים בלוח למתודת ה "קליק הראשון"
        private void UpdateAllButtonsToFirstClick()
        {
            foreach (Control control in Controls)
            {
                if (control is Button button)
                {
                    button.Click -= button_SecondClick;
                    button.Click += button_FirstClick;
                }
            }
        }

        private void makeMove(List<int> i_MoveMade, Button i_ClickedButton)
        {
            bool isMoveValid = false;
            bool isErrorShown = false;

            List<List<int>> optionalMoves = m_Game.GetOptionalEatMoves(m_Game.m_Board, m_SelectedButton.Text[0]);
            bool isEatingMove = m_Game.ContainsMove(optionalMoves, i_MoveMade);

            // Check if the player must eat
            if (!isEatingMove && optionalMoves.Count > 0)
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
                    optionalMoves = m_Game.GetOptionalMoves(m_Game.m_Board, m_SelectedButton.Text[0]);
                }
            }

            if (m_Game.ContainsMove(optionalMoves, i_MoveMade) && isMoveValid)
            {
                m_Game.MakeMove(i_MoveMade, m_Game.m_Board, isEatingMove);
                updateBoardUI();

                Player winner;
                //bool isGameOver = IsGameOver(out winner);

                bool hasFurtherEatingMove = false;
                if (isEatingMove && !m_Game.m_IsGameOver)
                {
                    Point newPos = new Point(i_MoveMade[2], i_MoveMade[3]);
                    List<List<int>> furtherEatingMoves = m_Game.GetOptionalEatMoves(m_Game.m_Board, i_ClickedButton.Text[0]);

                    foreach (List<int> move in furtherEatingMoves)
                    {
                        if (move[0] == newPos.X && move[1] == newPos.Y)
                        {
                            hasFurtherEatingMove = true;
                            break;
                        }
                    }
                }

                if (hasFurtherEatingMove)
                {
                    m_SelectedButton.BackColor = Color.White;
                    i_ClickedButton.BackColor = Color.LightBlue;
                    m_SelectedButton = i_ClickedButton;
                }
                else
                {
                    m_CurrentPlayer = (m_CurrentPlayer == r_SecondPlayer) ? r_FirstPlayer : r_SecondPlayer;
                    gameProcess();
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

        private void updateBoardUI()
        {
            for (int row = 0; row < r_BoardSize; row++)
            {
                for (int col = 0; col < r_BoardSize; col++)
                {
                    ePieceType piece = m_Game.m_Board.GetPieceAt(row, col);

                    switch (piece)
                    {
                        case ePieceType.None:
                            m_BoardButtons[row, col].Text = "";
                            break;

                        case ePieceType.O:
                            m_BoardButtons[row, col].Text = ePieceType.O.ToString();
                            break;

                        case ePieceType.U:
                            m_BoardButtons[row, col].Text = ePieceType.U.ToString();
                            break;

                        case ePieceType.X:
                            m_BoardButtons[row, col].Text = ePieceType.X.ToString();
                            break;

                        case ePieceType.K:
                            m_BoardButtons[row, col].Text = ePieceType.K.ToString();
                            break;
                    }

                    setButtonSetTextColor(m_BoardButtons[row, col]);
                }
            }
        }

        private void gameProcess()
        {
            bool isComputerTurn = m_CurrentPlayer.m_Name == "Computer";

            if (isComputerTurn)
            {
                m_Game.MakeMoveForComputer(m_Game.m_Board);

                m_CurrentPlayer = (m_CurrentPlayer == r_SecondPlayer) ? r_FirstPlayer : r_SecondPlayer;

                List<List<int>> movesForX = m_Game.GetOptionalEatMoves(m_Game.m_Board, 'X');

                if (movesForX.Count > 0)
                {
                    updateBoardUI();
                    return;
                }
            }

            updateBoardUI();

            // אם יש צעדים אוםציונליים לשחקן השני, לא לסיים את המשחק

            bool  isGameOver = IsGameOver(out Player winner);

            if (isGameOver)
            {
                EndGame(winner);
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
                m_Game.CalculateScore(m_Game.m_Players);
            }

            return o_Winner != null;
        }

        private Player checkForNoMoreTokens()
        {
            Player winner = null;
            int counterX = 0, counterO = 0;

            for (int i = 0; i < r_BoardSize; i++)
            {
                for (int j = 0; j < r_BoardSize; j++)
                {
                    ePieceType piece = m_Game.m_Board.GetPieceAt(i, j);

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
                winner = m_Game.m_Players[0];
            }
            else if (counterX == 0)
            {
                winner = m_Game.m_Players[1];
            }

            return winner;
        }

        private Player checkForValidatedMoves()
        {
            Player winner = null;

            List<List<int>> movesForO = m_Game.GetOptionalEatMoves(m_Game.m_Board, 'O');
            movesForO.AddRange(m_Game.GetOptionalMoves(m_Game.m_Board, 'O'));

            List<List<int>> movesForX = m_Game.GetOptionalEatMoves(m_Game.m_Board, 'X');
            movesForX.AddRange(m_Game.GetOptionalMoves(m_Game.m_Board, 'X'));

            if (movesForO.Count == 0 && movesForX.Count == 0)
            {
                winner = null; // תיקו
            }
            else if (movesForO.Count == 0)
            {
                winner = m_Game.m_Players[0];
            }
            else if (movesForX.Count == 0)
            {
                winner = m_Game.m_Players[1];
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
            initializeBoard();
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
            m_Game.RestartGame();
            updateBoardUI();
            gameProcess();
        }

        private void FormGrid_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}