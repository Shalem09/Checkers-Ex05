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
        public string Player1Name => textBoxFirstPlayer.Text;
        public string Player2Name => checkBoxSecondPlayer.Checked ? textBoxSecondPlayer.Text : "Computer";
        public bool IsPlayer2Computer => checkBoxSecondPlayer.Checked;



        public FormSettings()
        {
            InitializeComponent();
            InitializeDefaults();
        }

        private void InitializeDefaults()
        {
            textBoxSecondPlayer.ForeColor = Color.Gray;
            textBoxSecondPlayer.Enabled = false;
            radioButton6x6.Checked = true;
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
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

        private void openGameBoard()
        {
            FormGrid gameBoard = new FormGrid(BoardSize, Player1Name, Player2Name, IsPlayer2Computer);
            gameBoard.Show();
            Hide(); 
        }

        private void done_button_Click(object sender, EventArgs e)
        {
            CheckBoardSize();
            openGameBoard();
        }

        private void Player2_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSecondPlayer.Checked)
            {
                if (string.IsNullOrWhiteSpace(textBoxSecondPlayer.Text) || textBoxSecondPlayer.Text == "[Computer]")
                {
                    textBoxSecondPlayer.Text = "";
                }
                textBoxSecondPlayer.ForeColor = Color.Black;
                textBoxSecondPlayer.Enabled = true;
            }
            else
            {
                textBoxSecondPlayer.Text = "[Computer]";
                textBoxSecondPlayer.ForeColor = Color.Gray;
                textBoxSecondPlayer.Enabled = false;
            }
        }

        private void Player2_TextBox_Enter(object sender, EventArgs e)
        {
            if (textBoxSecondPlayer.Text == "[Computer]")
            {
                textBoxSecondPlayer.Text = "";
                textBoxSecondPlayer.ForeColor = Color.Black;
            }
        }

        private void Player2_TextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxSecondPlayer.Text))
            {
                textBoxSecondPlayer.Text = "[Computer]";
                textBoxSecondPlayer.ForeColor = Color.Gray;
            }
        }
    }
}
