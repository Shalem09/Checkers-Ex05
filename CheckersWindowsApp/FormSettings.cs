using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CheckersWindowsApp
{
    public partial class FormSettings : Form
    {
        public int BoardSize { get; private set; } = 8;
        public string Player1Name => Player1_TextBox.Text;
        public string Player2Name => Player2_checkBox.Checked ? "Computer" : Player2_TextBox.Text;
        public bool IsPlayer2Computer => Player2_checkBox.Checked;



        public FormSettings()
        {
            InitializeComponent();
            InitializeDefaults();
        }

        private void InitializeDefaults()
        {
            Player2_TextBox.Text = "[Computer]";
            Player2_TextBox.ForeColor = Color.Gray;
            Player2_TextBox.Enabled = false;
            radioButton8x8.Checked = true;
        }

        private void radioButton6x6_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoardSize();
        }

        private void radioButton8x8_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoardSize();
        }

        private void radioButton10x10_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoardSize();
        }

        private void CheckBoardSize()
        {
            if (radioButton6x6.Checked)
            {
                BoardSize = 6;
            }
            else if (radioButton8x8.Checked)
            {
                BoardSize = 8;
            }
            else if (radioButton10x10.Checked)
            {
                BoardSize = 10;
            }
        }

        private void OpenGameBoard()
        {
            FormGrid gameBoard = new FormGrid(BoardSize, Player1Name, Player2Name, IsPlayer2Computer);
            gameBoard.Show();
            this.Hide(); 
        }

        private void boardSizeGroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void Player1_TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void done_button_Click(object sender, EventArgs e)
        {
            CheckBoardSize();
            OpenGameBoard();
        }

        private void Player2_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Player2_checkBox.Checked)
            {
                Player2_TextBox.Text = "";
                Player2_TextBox.ForeColor = Color.Black;
                Player2_TextBox.Enabled = true;
            }
            else
            {
                Player2_TextBox.Text = "[Computer]";
                Player2_TextBox.ForeColor = Color.Gray;
                Player2_TextBox.Enabled = false;
            }
        }

        private void Player2_TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Player2_TextBox_Enter(object sender, EventArgs e)
        {
            if (Player2_TextBox.Text == "[Computer]")
            {
                Player2_TextBox.Text = "";
                Player2_TextBox.ForeColor = Color.Black;
            }
        }

        private void Player2_TextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Player2_TextBox.Text))
            {
                Player2_TextBox.Text = "[Computer]";
                Player2_TextBox.ForeColor = Color.Gray;
            }
        }

        private void player1_label_Click(object sender, EventArgs e)
        {

        }

        private void players_label_Click(object sender, EventArgs e)
        {

        }

        private void FormSettings_Load(object sender, EventArgs e)
        {

        }
    }
}
