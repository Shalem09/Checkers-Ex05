using System.Drawing;

namespace CheckersWindowsApp
{
    partial class FormColor
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
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.label = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.labelRGBColors = new System.Windows.Forms.Label();
            this.labelSmallScreen = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelSelectedColor = new System.Windows.Forms.Panel();
            this.textBoxBlueValue = new System.Windows.Forms.TextBox();
            this.textBoxGreenValue = new System.Windows.Forms.TextBox();
            this.textBoxRedValue = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.Icon = new Icon(Properties.Resources.CheckersLogo, 30, 30);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.Dock = System.Windows.Forms.DockStyle.Top;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label.Location = new System.Drawing.Point(0, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(676, 67);
            this.label.TabIndex = 0;
            this.label.Text = "Color Picker";
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox
            // 
            this.pictureBox.Image = global::CheckersWindowsApp.Properties.Resources.rgbSpectrum;
            this.pictureBox.Location = new System.Drawing.Point(116, 90);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(226, 156);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // labelRGBColors
            // 
            this.labelRGBColors.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelRGBColors.Location = new System.Drawing.Point(116, 408);
            this.labelRGBColors.Name = "labelRGBColors";
            this.labelRGBColors.Size = new System.Drawing.Size(244, 44);
            this.labelRGBColors.TabIndex = 2;
            this.labelRGBColors.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSmallScreen
            // 
            this.labelSmallScreen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelSmallScreen.Location = new System.Drawing.Point(409, 408);
            this.labelSmallScreen.Name = "labelSmallScreen";
            this.labelSmallScreen.Size = new System.Drawing.Size(162, 44);
            this.labelSmallScreen.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panelSelectedColor);
            this.groupBox1.Controls.Add(this.textBoxBlueValue);
            this.groupBox1.Controls.Add(this.textBoxGreenValue);
            this.groupBox1.Controls.Add(this.textBoxRedValue);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(103, 494);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(497, 253);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selected Color";
            // 
            // panelSelectedColor
            // 
            this.panelSelectedColor.Location = new System.Drawing.Point(291, 59);
            this.panelSelectedColor.Name = "panelSelectedColor";
            this.panelSelectedColor.Size = new System.Drawing.Size(189, 175);
            this.panelSelectedColor.TabIndex = 6;
            // 
            // textBoxBlueValue
            // 
            this.textBoxBlueValue.Location = new System.Drawing.Point(157, 197);
            this.textBoxBlueValue.Name = "textBoxBlueValue";
            this.textBoxBlueValue.ReadOnly = true;
            this.textBoxBlueValue.Size = new System.Drawing.Size(100, 31);
            this.textBoxBlueValue.TabIndex = 5;
            // 
            // textBoxGreenValue
            // 
            this.textBoxGreenValue.Location = new System.Drawing.Point(157, 127);
            this.textBoxGreenValue.Name = "textBoxGreenValue";
            this.textBoxGreenValue.ReadOnly = true;
            this.textBoxGreenValue.Size = new System.Drawing.Size(100, 31);
            this.textBoxGreenValue.TabIndex = 4;
            // 
            // textBoxRedValue
            // 
            this.textBoxRedValue.Location = new System.Drawing.Point(157, 65);
            this.textBoxRedValue.Name = "textBoxRedValue";
            this.textBoxRedValue.ReadOnly = true;
            this.textBoxRedValue.Size = new System.Drawing.Size(100, 31);
            this.textBoxRedValue.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label5.Location = new System.Drawing.Point(27, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 37);
            this.label5.TabIndex = 2;
            this.label5.Text = "Blue";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.Location = new System.Drawing.Point(27, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 37);
            this.label4.TabIndex = 1;
            this.label4.Text = "Green";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(27, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 37);
            this.label3.TabIndex = 0;
            this.label3.Text = "Red";
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.AutoSize = true;
            this.buttonConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.buttonConfirm.Location = new System.Drawing.Point(271, 781);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(137, 47);
            this.buttonConfirm.TabIndex = 7;
            this.buttonConfirm.Text = "Choose";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // FormColor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 880);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelSmallScreen);
            this.Controls.Add(this.labelRGBColors);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FormColor";
            this.Text = "Color Picker";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label labelRGBColors;
        private System.Windows.Forms.Label labelSmallScreen;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxBlueValue;
        private System.Windows.Forms.TextBox textBoxGreenValue;
        private System.Windows.Forms.TextBox textBoxRedValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelSelectedColor;
        private System.Windows.Forms.Button buttonConfirm;
    }
}