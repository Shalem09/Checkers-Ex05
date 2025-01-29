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
            this.Player1_TextBox = new System.Windows.Forms.TextBox();
            this.Player2_checkBox = new System.Windows.Forms.CheckBox();
            this.Player2_TextBox = new System.Windows.Forms.TextBox();
            this.done_button = new System.Windows.Forms.Button();
            this.boardSizeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // boardSizeGroupBox
            // 
            this.boardSizeGroupBox.Controls.Add(this.radioButton6x6);
            this.boardSizeGroupBox.Controls.Add(this.radioButton8x8);
            this.boardSizeGroupBox.Controls.Add(this.radioButton10x10);
            this.boardSizeGroupBox.Location = new System.Drawing.Point(25, 12);
            this.boardSizeGroupBox.Name = "boardSizeGroupBox";
            this.boardSizeGroupBox.Size = new System.Drawing.Size(339, 68);
            this.boardSizeGroupBox.TabIndex = 10;
            this.boardSizeGroupBox.TabStop = false;
            this.boardSizeGroupBox.Text = "Board Size:";
            this.boardSizeGroupBox.Enter += new System.EventHandler(this.boardSizeGroupBox_Enter);
            // 
            // radioButton6x6
            // 
            this.radioButton6x6.AutoSize = true;
            this.radioButton6x6.Location = new System.Drawing.Point(39, 32);
            this.radioButton6x6.Name = "radioButton6x6";
            this.radioButton6x6.Size = new System.Drawing.Size(63, 24);
            this.radioButton6x6.TabIndex = 3;
            this.radioButton6x6.TabStop = true;
            this.radioButton6x6.Text = "6X6";
            this.radioButton6x6.UseVisualStyleBackColor = true;
            this.radioButton6x6.CheckedChanged += new System.EventHandler(this.radioButton6x6_CheckedChanged);
            // 
            // radioButton8x8
            // 
            this.radioButton8x8.AutoSize = true;
            this.radioButton8x8.Location = new System.Drawing.Point(152, 32);
            this.radioButton8x8.Name = "radioButton8x8";
            this.radioButton8x8.Size = new System.Drawing.Size(63, 24);
            this.radioButton8x8.TabIndex = 4;
            this.radioButton8x8.TabStop = true;
            this.radioButton8x8.Text = "8X8";
            this.radioButton8x8.UseVisualStyleBackColor = true;
            this.radioButton8x8.CheckedChanged += new System.EventHandler(this.radioButton8x8_CheckedChanged);
            // 
            // radioButton10x10
            // 
            this.radioButton10x10.AutoSize = true;
            this.radioButton10x10.Location = new System.Drawing.Point(252, 32);
            this.radioButton10x10.Name = "radioButton10x10";
            this.radioButton10x10.Size = new System.Drawing.Size(81, 24);
            this.radioButton10x10.TabIndex = 7;
            this.radioButton10x10.TabStop = true;
            this.radioButton10x10.Text = "10X10";
            this.radioButton10x10.UseVisualStyleBackColor = true;
            this.radioButton10x10.CheckedChanged += new System.EventHandler(this.radioButton10x10_CheckedChanged);
            // 
            // players_label
            // 
            this.players_label.AutoSize = true;
            this.players_label.Location = new System.Drawing.Point(30, 83);
            this.players_label.Name = "players_label";
            this.players_label.Size = new System.Drawing.Size(64, 20);
            this.players_label.TabIndex = 6;
            this.players_label.Text = "Players:";
            this.players_label.Click += new System.EventHandler(this.players_label_Click);
            // 
            // player1_label
            // 
            this.player1_label.AutoSize = true;
            this.player1_label.Location = new System.Drawing.Point(56, 128);
            this.player1_label.Name = "player1_label";
            this.player1_label.Size = new System.Drawing.Size(69, 20);
            this.player1_label.TabIndex = 8;
            this.player1_label.Text = "Player 1:";
            this.player1_label.Click += new System.EventHandler(this.player1_label_Click);
            // 
            // Player1_TextBox
            // 
            this.Player1_TextBox.Location = new System.Drawing.Point(218, 125);
            this.Player1_TextBox.Name = "Player1_TextBox";
            this.Player1_TextBox.Size = new System.Drawing.Size(146, 26);
            this.Player1_TextBox.TabIndex = 0;
            this.Player1_TextBox.TextChanged += new System.EventHandler(this.Player1_TextBox_TextChanged);
            // 
            // Player2_checkBox
            // 
            this.Player2_checkBox.AutoSize = true;
            this.Player2_checkBox.Location = new System.Drawing.Point(60, 170);
            this.Player2_checkBox.Name = "Player2_checkBox";
            this.Player2_checkBox.Size = new System.Drawing.Size(95, 24);
            this.Player2_checkBox.TabIndex = 1;
            this.Player2_checkBox.Text = "Player 2:";
            this.Player2_checkBox.UseVisualStyleBackColor = true;
            this.Player2_checkBox.CheckedChanged += new System.EventHandler(this.Player2_checkBox_CheckedChanged);
            // 
            // Player2_TextBox
            // 
            this.Player2_TextBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.Player2_TextBox.Location = new System.Drawing.Point(218, 170);
            this.Player2_TextBox.Name = "Player2_TextBox";
            this.Player2_TextBox.Size = new System.Drawing.Size(146, 26);
            this.Player2_TextBox.TabIndex = 9;
            this.Player2_TextBox.Text = "[Computer]";
            this.Player2_TextBox.TextChanged += new System.EventHandler(this.Player2_TextBox_TextChanged);
            this.Player2_TextBox.Enter += new System.EventHandler(this.Player2_TextBox_Enter);
            this.Player2_TextBox.Leave += new System.EventHandler(this.Player2_TextBox_Leave);
            // 
            // done_button
            // 
            this.done_button.Location = new System.Drawing.Point(255, 242);
            this.done_button.Name = "done_button";
            this.done_button.Size = new System.Drawing.Size(109, 32);
            this.done_button.TabIndex = 2;
            this.done_button.Text = "Done";
            this.done_button.UseVisualStyleBackColor = true;
            this.done_button.Click += new System.EventHandler(this.done_button_Click);
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 320);
            this.Controls.Add(this.boardSizeGroupBox);
            this.Controls.Add(this.players_label);
            this.Controls.Add(this.player1_label);
            this.Controls.Add(this.Player1_TextBox);
            this.Controls.Add(this.Player2_checkBox);
            this.Controls.Add(this.Player2_TextBox);
            this.Controls.Add(this.done_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormSettings";
            this.Text = "Game Settings";
            this.Load += new System.EventHandler(this.FormSettings_Load);
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
        private System.Windows.Forms.TextBox Player1_TextBox;
        private System.Windows.Forms.CheckBox Player2_checkBox;
        private System.Windows.Forms.TextBox Player2_TextBox;
        private System.Windows.Forms.Button done_button;
    }
}

