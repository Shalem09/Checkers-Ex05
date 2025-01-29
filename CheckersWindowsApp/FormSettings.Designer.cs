using System.Drawing;
using System.Collections;


namespace CheckersWindowsApp
{
    partial class FormSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.boardSizeGroupBox = new System.Windows.Forms.GroupBox();
            this.radioButton6x6 = new System.Windows.Forms.RadioButton();
            this.radioButton8x8 = new System.Windows.Forms.RadioButton();
            this.radioButton10x10 = new System.Windows.Forms.RadioButton();
            this.players_label = new System.Windows.Forms.Label();
            this.player1_label = new System.Windows.Forms.Label();
            this.textBoxFirstPlayer = new System.Windows.Forms.TextBox();
            this.checkBoxSecondPlayer = new System.Windows.Forms.CheckBox();
            this.textBoxSecondPlayer = new System.Windows.Forms.TextBox();
            this.done_button = new System.Windows.Forms.Button();
            this.boardSizeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // boardSizeGroupBox
            // 
            this.boardSizeGroupBox.Controls.Add(this.radioButton6x6);
            this.boardSizeGroupBox.Controls.Add(this.radioButton8x8);
            this.boardSizeGroupBox.Controls.Add(this.radioButton10x10);
            this.boardSizeGroupBox.Location = new System.Drawing.Point(33, 15);
            this.boardSizeGroupBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.boardSizeGroupBox.Name = "boardSizeGroupBox";
            this.boardSizeGroupBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.boardSizeGroupBox.Size = new System.Drawing.Size(452, 85);
            this.boardSizeGroupBox.TabIndex = 10;
            this.boardSizeGroupBox.TabStop = false;
            this.boardSizeGroupBox.Text = "Board Size:";
            //this.boardSizeGroupBox.Enter += new System.EventHandler(this.boardSizeGroupBox_Enter);
            // 
            // radioButton6x6
            // 
            this.radioButton6x6.AutoSize = true;
            this.radioButton6x6.Location = new System.Drawing.Point(52, 40);
            this.radioButton6x6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButton6x6.Name = "radioButton6x6";
            this.radioButton6x6.Size = new System.Drawing.Size(81, 29);
            this.radioButton6x6.TabIndex = 4;
            this.radioButton6x6.TabStop = true;
            this.radioButton6x6.Text = "6X6";
            this.radioButton6x6.UseVisualStyleBackColor = true;
            this.radioButton6x6.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButton8x8
            // 
            this.radioButton8x8.AutoSize = true;
            this.radioButton8x8.Location = new System.Drawing.Point(203, 40);
            this.radioButton8x8.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButton8x8.Name = "radioButton8x8";
            this.radioButton8x8.Size = new System.Drawing.Size(81, 29);
            this.radioButton8x8.TabIndex = 5;
            this.radioButton8x8.TabStop = true;
            this.radioButton8x8.Text = "8X8";
            this.radioButton8x8.UseVisualStyleBackColor = true;
            this.radioButton8x8.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButton10x10
            // 
            this.radioButton10x10.AutoSize = true;
            this.radioButton10x10.Location = new System.Drawing.Point(336, 40);
            this.radioButton10x10.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButton10x10.Name = "radioButton10x10";
            this.radioButton10x10.Size = new System.Drawing.Size(105, 29);
            this.radioButton10x10.TabIndex = 6;
            this.radioButton10x10.TabStop = true;
            this.radioButton10x10.Text = "10X10";
            this.radioButton10x10.UseVisualStyleBackColor = true;
            this.radioButton10x10.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // players_label
            // 
            this.players_label.AutoSize = true;
            this.players_label.Location = new System.Drawing.Point(40, 104);
            this.players_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.players_label.Name = "players_label";
            this.players_label.Size = new System.Drawing.Size(90, 25);
            this.players_label.TabIndex = 7;
            this.players_label.Text = "Players:";
            // 
            // player1_label
            // 
            this.player1_label.AutoSize = true;
            this.player1_label.Location = new System.Drawing.Point(75, 160);
            this.player1_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.player1_label.Name = "player1_label";
            this.player1_label.Size = new System.Drawing.Size(97, 25);
            this.player1_label.TabIndex = 8;
            this.player1_label.Text = "Player 1:";
            // 
            // textBoxFirstPlayer
            // 
            this.textBoxFirstPlayer.Location = new System.Drawing.Point(291, 156);
            this.textBoxFirstPlayer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxFirstPlayer.Name = "Player1_TextBox";
            this.textBoxFirstPlayer.Size = new System.Drawing.Size(193, 31);
            this.textBoxFirstPlayer.TabIndex = 0;
            // 
            // checkBoxSecondPlayer
            // 
            this.checkBoxSecondPlayer.AutoSize = true;
            this.checkBoxSecondPlayer.Location = new System.Drawing.Point(80, 212);
            this.checkBoxSecondPlayer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxSecondPlayer.Name = "Player2_checkBox";
            this.checkBoxSecondPlayer.Size = new System.Drawing.Size(129, 29);
            this.checkBoxSecondPlayer.TabIndex = 9;
            this.checkBoxSecondPlayer.Text = "Player 2:";
            this.checkBoxSecondPlayer.UseVisualStyleBackColor = true;
            this.checkBoxSecondPlayer.CheckedChanged += new System.EventHandler(this.Player2_checkBox_CheckedChanged);
            // 
            // textBoxSecondPlayer
            // 
            this.textBoxSecondPlayer.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBoxSecondPlayer.Location = new System.Drawing.Point(291, 212);
            this.textBoxSecondPlayer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxSecondPlayer.Name = "Player2_TextBox";
            this.textBoxSecondPlayer.Size = new System.Drawing.Size(193, 31);
            this.textBoxSecondPlayer.TabIndex = 2;
            this.textBoxSecondPlayer.Text = "[Computer]";
            // 
            // done_button
            // 
            this.done_button.Location = new System.Drawing.Point(340, 302);
            this.done_button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.done_button.Name = "done_button";
            this.done_button.Size = new System.Drawing.Size(145, 40);
            this.done_button.TabIndex = 3;
            this.done_button.Text = "Done";
            this.done_button.UseVisualStyleBackColor = true;
            this.done_button.Click += new System.EventHandler(this.done_button_Click);
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 400);
            this.Controls.Add(this.boardSizeGroupBox);
            this.Controls.Add(this.players_label);
            this.Controls.Add(this.player1_label);
            this.Controls.Add(this.textBoxFirstPlayer);
            this.Controls.Add(this.checkBoxSecondPlayer);
            this.Controls.Add(this.textBoxSecondPlayer);
            this.Controls.Add(this.done_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormSettings";
            this.Text = "Game Settings";
            this.boardSizeGroupBox.ResumeLayout(false);
            this.boardSizeGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox boardSizeGroupBox;
        private System.Windows.Forms.RadioButton radioButton6x6;
        private System.Windows.Forms.RadioButton radioButton8x8;
        private System.Windows.Forms.RadioButton radioButton10x10;
        private System.Windows.Forms.Label players_label;
        private System.Windows.Forms.Label player1_label;
        private System.Windows.Forms.TextBox textBoxFirstPlayer;
        private System.Windows.Forms.CheckBox checkBoxSecondPlayer;
        private System.Windows.Forms.TextBox textBoxSecondPlayer;
        private System.Windows.Forms.Button done_button;
    }
}

