using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaFormulario
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpenWebinars_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Hello World");
            lblOpenWebinars.Text = txtOpenWebinars.Text;
        }

        private void btnOpenWebinars_MouseEnter(object sender, EventArgs e)
        {
            btnOpenWebinars.BackColor = Color.Aquamarine;
        }

        private void txtOpenWebinars_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtOpenWebinars_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.D0)
            {
                lblOpenWebinars.Text = "Valor incorrecto";
                e.SuppressKeyPress = true;
            }
        }

        private void pbOpenWebinars_Click(object sender, EventArgs e)
        {
            pbOpenWebinars.Image = Image.FromFile("C:\\Users\\leila.fraile\\Downloads\\openwebinars_logo.jpg");
            //para ajustar la imagen al picture box
			pbOpenWebinars.SizeMode = PictureBoxSizeMode.StretchImage;

		}

        private void btnNextLesson_Click(object sender, EventArgs e)
        {
            new FormAdvancedControls().Show();
        }
    }
}
