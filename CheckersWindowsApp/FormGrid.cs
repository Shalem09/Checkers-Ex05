using System;
using System.Drawing;
using System.Windows.Forms;
using CheckersLibrary;

namespace CheckersWindowsApp
{
    public partial class FormGrid : Form
    {
        private Button[,] boardButtons; 
        private int m_boardSize; 
        private Label[,] boardSquares; 
        private Game game;
        private string m_player1Name;
        private string m_player2Name;
        private int player1Score = 0;
        private int player2Score = 0;

        public FormGrid(int i_size, string i_player1Name, string i_player2Name, bool i_IsPlayer2Computer)
        {
            InitializeComponent();
            m_boardSize = i_size;
            m_player1Name = i_player1Name;
            m_player2Name = i_player2Name;
            this.Text = "Damka"; 
            InitializeBoard();
            InitializeGame();
            CreateBoard(m_boardSize); 
        }

        private void InitializeBoard()
        {
            boardSquares = new Label[m_boardSize, m_boardSize];
            int tileSize = 50; 
            int margin = 20;

         
            this.ClientSize = new Size(m_boardSize * tileSize + margin * 2, m_boardSize * tileSize + margin * 2 + 50);

           
            player1_label.Text = $"{m_player1Name} - Score: {player1Score}";
            player2_label.Text = $"{m_player2Name} - Score: {player2Score}";

            player1_label.Location = new Point(margin, 10);
            player2_label.Location = new Point(this.ClientSize.Width - player2_label.Width - margin, 10);

            for (int row = 0; row < m_boardSize; row++)
            {
                for (int col = 0; col < m_boardSize; col++)
                {
                    Label square = new Label
                    {
                        Size = new Size(tileSize, tileSize),
                        Location = new Point(margin + col * tileSize, margin + 40 + row * tileSize),
                        BorderStyle = BorderStyle.FixedSingle,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font("Arial", 16, FontStyle.Bold)
                    };

                    if ((row + col) % 2 == 0)
                    {
                        square.BackColor = Color.White; 
                    }
                    else
                    {
                        square.BackColor = Color.Gray; 
                    }

                    boardSquares[row, col] = square;
                    this.Controls.Add(square);
                }
            }
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
            int startX = 50, startY = 50; 

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Button btn = new Button();
                    btn.Width = buttonSize;
                    btn.Height = buttonSize;
                    btn.Left = startX + col * buttonSize;
                    btn.Top = startY + row * buttonSize;
                    btn.Tag = new Point(row, col); // שמירת המיקום בתוך ה-Tag
                    btn.Click += Button_Click; // הוספת אירוע לחיצה
                    this.Controls.Add(btn); // הוספת הכפתור לטופס
                    boardButtons[row, col] = btn; // שמירת הכפתור במטריצה
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && btn.Tag is Point)
            {
                Point pos = (Point)btn.Tag;
                MessageBox.Show($"You press on, row:{pos.X}, column: {pos.Y}");
            }
        }

        private void player1_label_Click(object sender, EventArgs e)
        {

        }

        private void player2_label_Click(object sender, EventArgs e)
        {

        }

        private void FormGrid_Load(object sender, EventArgs e)
        {

        }
    }
}
