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
    public partial class FormAdvancedControls : Form
    {
        private List<Car> cars=new List<Car>();
        public FormAdvancedControls()
        {
            InitializeComponent();
        }

        private void FormAdvancedControls_Load(object sender, EventArgs e)
        {
            cars.Add(new Car(){name="Aveo", maker="Ford");
			lbCoches.Items.Add("Ford");
            cmbCombo.Items.Add("Red");
            lbCoches.DataSource=cars;
            lbCoches.DisplayMember = "name";
            for (int i = 0; i < 10; i++) {
                pgPrueba.PerformStep(); 
            }
        }
    }
}
