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
        public int m_BoardSize { get; private set; } = 8;
        public string m_Player1Name
        {
            get { return textBoxFirstPlayer.Text; }
        }
        public string m_Player2Name
        {
            get
            {
                return checkBoxSecondPlayer.Checked ? textBoxSecondPlayer.Text : "Computer";
            }
        }
        private Color m_BackgroundColor { get; set; } = Color.White;
        public static Color m_FirstPlayerLabelColor { get; private set; } = Color.Black;
        public static Color m_SecondPlayerLabelColor { get; private set; } = Color.Black;

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
                m_BoardSize = 6;
            }
            else if (radioButton8x8.Checked)
            {
                m_BoardSize = 8;
            }
            else if (radioButton10x10.Checked)
            {
                m_BoardSize = 10;
            }
        }

        private void openGameBoard()
        {
            FormGrid gameBoard = new FormGrid(
                m_BoardSize,
                m_Player1Name,
                m_Player2Name,
                m_FirstPlayerLabelColor,
                m_SecondPlayerLabelColor);

            gameBoard.BackColor = m_BackgroundColor;
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

        private void buttonBackgroundColor_Click(object sender, EventArgs e)
        {
            FormColor colorChooseFrom = new FormColor();
            colorChooseFrom.ColorChosen += onBackgroungColorChosen;

            colorChooseFrom.ShowDialog();
        }

        private void onBackgroungColorChosen(Color chosenColor)
        {
            m_BackgroundColor = chosenColor;
        }

        private void pictureBoxFirstPlayer_Click(object sender, EventArgs e)
        {
            FormColor colorChooseFrom = new FormColor();
            colorChooseFrom.ColorChosen += onFirstLabelColorChosen;

            colorChooseFrom.ShowDialog();
        }

        private void onFirstLabelColorChosen(Color chosenColor)
        {
            m_FirstPlayerLabelColor = chosenColor;
        }

        private void pictureBoxSecondPlayer_Click(object sender, EventArgs e)
        {
            FormColor colorChooseFrom = new FormColor();
            colorChooseFrom.ColorChosen += onSecondLabelColorChosen;

            colorChooseFrom.ShowDialog();
        }

        private void onSecondLabelColorChosen(Color chosenColor)
        {
            m_SecondPlayerLabelColor = chosenColor;
        }
    }
}
