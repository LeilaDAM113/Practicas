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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            buttonExtend1.Click += ButtonExtend1Click;
        }

        private void ButtonExtend1Click(object sender, EventArgs e)
        {
           
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
             buttonExtend1.Click -= ButtonExtend1Click;
        }
    }
}
