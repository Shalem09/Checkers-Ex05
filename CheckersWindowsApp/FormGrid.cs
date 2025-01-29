using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CheckersLibrary;

namespace CheckersWindowsApp
{
    public partial class FormGrid : Form
    {
        private Button[,] boardButtons;   // need to add m_
        private List<Button> allButtons = new List<Button>();   // need to add m_
        private int m_boardSize; 
        private Game game;
        private string m_player1Name;
        private string m_player2Name;
        private int player1Score = 0;
        private int player2Score = 0;
        private Button selectedButton = null; // שומר את הכפתור שנבחר (הכלי שזז)
        private bool isFirstClick = true; // האם זו הלחיצה הראשונה?
        private int currentPlayer = 0; // 0 - שחקן ראשון (X), 1 - שחקן שני (O)


        public FormGrid(int i_size, string i_player1Name, string i_player2Name, bool i_IsPlayer2Computer)
        {
            InitializeComponent();
            m_boardSize = i_size;
            m_player1Name = i_player1Name;
            m_player2Name = i_player2Name;
            Text = "Damka"; 
            InitializeBoard();
            InitializeGame();
            CreateBoard(m_boardSize); 
        }

        private void InitializeBoard()
        {
            int tileSize = 50; 
            int margin = 20;
         
            ClientSize = new Size(m_boardSize * tileSize + margin * 2, m_boardSize * tileSize + margin * 2 + 50);

           
            player1_label.Text = $"{m_player1Name} - Score: {player1Score}";
            player2_label.Text = $"{m_player2Name} - Score: {player2Score}";

            player1_label.Location = new Point(margin, 10);
            player2_label.Location = new Point(ClientSize.Width - player2_label.Width - margin, 10);
        }

        private void InitializeGame()
        {
            game = new Game(m_boardSize);
            game.InitializeGame(m_boardSize, m_player1Name, m_player2Name);
        }

        private void CreateBoard(int size)
        {
            boardButtons = new Button[size, size];

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
                    boardButtons[row, col] = button;
                    allButtons.Add(button);

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

        //private void button_Click(object sender, EventArgs e)
        //{
        //    Button clickedButton = sender as Button;
        //    if (clickedButton == null) return;

        //    // Toggle the color of the clicked button
        //    if (clickedButton.BackColor == Color.White)
        //    {
        //        clickedButton.BackColor = Color.FromArgb(37, 179, 255);
        //    }
        //    else
        //    {
        //        clickedButton.BackColor = Color.White;
        //    }

        //    // Update all other buttons based on the click event
        //    foreach (Button btn in allButtons)
        //    {
        //        // אם עוד כפתור נלחץ אז מפעילם את המתודה של בדיקה


        //    }

        //    clickedButton.Click -= button_Click;
        //    clickedButton.Click += button_SecondClick;
        //}

        private void button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton == null) return;

            if (isFirstClick) // בחירת כלי
            {
                if (clickedButton.Text == "X" && currentPlayer == 0 ||
                    clickedButton.Text == "O" && currentPlayer == 1)
                {
                    selectedButton = clickedButton;
                    clickedButton.BackColor = Color.LightBlue; // סימון בחירה
                    isFirstClick = false;
                }
            }
            else // בחירת משבצת יעד
            {
                Point fromPos = (Point)selectedButton.Tag;
                Point toPos = (Point)clickedButton.Tag;

                bool isEatingMove = game.GetOptionalEatMoves(game.m_Board, selectedButton.Text[0]).Contains($"{fromPos.X}{fromPos.Y}>{toPos.X}{toPos.Y}");

                if (game.GetOptionalMoves(game.m_Board, selectedButton.Text[0]).Contains($"{fromPos.X}{fromPos.Y}>{toPos.X}{toPos.Y}") ||
                    isEatingMove)
                {
                    game.MakeMove($"{fromPos.X}{fromPos.Y}>{toPos.X}{toPos.Y}", game.m_Board, isEatingMove);
                    UpdateBoardUI();
                    currentPlayer = 1 - currentPlayer; // החלפת תור
                }

                selectedButton.BackColor = Color.White; // ניקוי סימון
                selectedButton = null;
                isFirstClick = true;
            }
        }

        private void UpdateBoardUI()
        {
            for (int row = 0; row < m_boardSize; row++)
            {
                for (int col = 0; col < m_boardSize; col++)
                {
                    ePieceType piece = game.m_Board.GetPieceAt(row, col);

                    if (piece == ePieceType.X)
                        boardButtons[row, col].Text = "X";
                    else if (piece == ePieceType.O)
                        boardButtons[row, col].Text = "O";
                    else if (piece == ePieceType.K)
                        boardButtons[row, col].Text = "K";
                    else if (piece == ePieceType.U)
                        boardButtons[row, col].Text = "U";
                    else
                        boardButtons[row, col].Text = "";
                }
            }
        }

        private void CheckForMoreEats(Point lastMove)
        {
            List<string> eatMoves = new List<string>();
            if (game.HasMoreEatMovesNew(new List<int> { lastMove.X, lastMove.Y }, game.m_Board, ref eatMoves))
            {
                MessageBox.Show("You must continue eating!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isFirstClick = false;
                selectedButton = boardButtons[lastMove.X, lastMove.Y]; 
                selectedButton.BackColor = Color.LightBlue;
            }
        }

        private void button_SecondClick(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton == null) return;

            // Reset the clicked button
            clickedButton.BackColor = Color.White;

            // Reset all other buttons to their default color
            foreach (Button btn in allButtons)
            {
                if (btn.Enabled) // Don't change disabled buttons
                {
                    btn.BackColor = Color.White;
                }
            }

            clickedButton.Click -= button_SecondClick;
            clickedButton.Click += button_Click;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
