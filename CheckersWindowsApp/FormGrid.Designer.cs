using System.Drawing;

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
            this.labelFirstPlayer = new System.Windows.Forms.Label();
            this.labelSecondPlayer = new System.Windows.Forms.Label();
            this.Icon = new Icon(Properties.Resources.CheckersLogo, 30, 30 );
            this.SuspendLayout();
            // 
            // labelFirstPlayer
            // 
            this.labelFirstPlayer.AutoSize = true;
            this.labelFirstPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelFirstPlayer.Location = new System.Drawing.Point(135, 40);
            this.labelFirstPlayer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFirstPlayer.Name = "labelFirstPlayer";
            this.labelFirstPlayer.Size = new System.Drawing.Size(140, 37);
            this.labelFirstPlayer.TabIndex = 0;
            this.labelFirstPlayer.Text = "Player 1:";
            // 
            // labelSecondPlayer
            // 
            this.labelSecondPlayer.AutoSize = true;
            this.labelSecondPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelSecondPlayer.Location = new System.Drawing.Point(559, 40);
            this.labelSecondPlayer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSecondPlayer.Name = "labelSecondPlayer";
            this.labelSecondPlayer.Size = new System.Drawing.Size(142, 37);
            this.labelSecondPlayer.TabIndex = 1;
            this.labelSecondPlayer.Text = "Player 2:";
            // 
            // FormGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 726);
            this.Controls.Add(this.labelSecondPlayer);
            this.Controls.Add(this.labelFirstPlayer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormGrid";
            this.Text = "FormGrid";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formGrid_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private System.Windows.Forms.Label labelFirstPlayer;
        private System.Windows.Forms.Label labelSecondPlayer;
    }
}