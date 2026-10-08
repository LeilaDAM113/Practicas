using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaFormulario2
{
    public partial class CustomUserControl : UserControl
    {

        public string labelTitle
        {
            get => lblLabel.Text;
            set => lblLabel.Text = value;
        }

		public CustomUserControl()
        {
            InitializeComponent();
        }

        private void btnBoton_Click(object sender, EventArgs e)
        {
           DialogResult result= openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtBox.Text = openFileDialog1.FileName;
            }
        }
    }
}
