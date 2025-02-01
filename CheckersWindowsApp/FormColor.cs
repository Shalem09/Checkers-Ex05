using System;
using System.Drawing;
using System.Windows.Forms;

namespace CheckersWindowsApp
{
    public partial class FormColor : Form
    {
        public event Action<Color> ColorChosen; // Event to notify listeners

        public FormColor()
        {
            InitializeComponent();
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            Bitmap pixelData = (Bitmap)pictureBox.Image;
            Color color = pixelData.GetPixel(e.X, e.Y);
            textBoxRedValue.Text = color.R.ToString();
            textBoxGreenValue.Text = color.G.ToString();
            textBoxBlueValue.Text = color.B.ToString();
            panelSelectedColor.BackColor = color;
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            Bitmap pixelData = (Bitmap) pictureBox.Image;
            Color color = pixelData.GetPixel(e.X, e.Y);
            labelSmallScreen.BackColor = color;
            labelRGBColors.Text = "R: " + color.R.ToString()
                                + " G: " + color.G.ToString()
                                + " B: " + color.B.ToString();
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            ColorChosen?.Invoke(panelSelectedColor.BackColor);
            Close();
        }
    }
}
