
namespace CheckersWindowsApp
{
    partial class FormGrid
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
            this.player1_label = new System.Windows.Forms.Label();
            this.player2_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.player1_label.AutoSize = true;
            this.player1_label.Location = new System.Drawing.Point(101, 32);
            this.player1_label.Name = "player1_label";
            this.player1_label.Size = new System.Drawing.Size(69, 20);
            this.player1_label.TabIndex = 0;
            this.player1_label.Text = "Player 1:";
            this.player1_label.Click += new System.EventHandler(this.player1_label_Click);
            // 
            // label2
            // 
            this.player2_label.AutoSize = true;
            this.player2_label.Location = new System.Drawing.Point(419, 32);
            this.player2_label.Name = "label2";
            this.player2_label.Size = new System.Drawing.Size(69, 20);
            this.player2_label.TabIndex = 1;
            this.player2_label.Text = "Player 2:";
            this.player2_label.Click += new System.EventHandler(this.player2_label_Click);
            // 
            // FormGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 581);
            this.Controls.Add(this.player2_label);
            this.Controls.Add(this.player1_label);
            this.Name = "FormGrid";
            this.Text = "FormGrid";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label player1_label;
        private System.Windows.Forms.Label player2_label;
    }
}