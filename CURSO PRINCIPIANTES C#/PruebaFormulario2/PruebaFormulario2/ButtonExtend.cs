using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaFormulario2
{
    public class ButtonExtend:Button
    {
        public ButtonExtend()
        {
            this.MouseEnter += MouseEnterButton;
			
		}

        private void MouseEnterButton(object sender, EventArgs e)
        {
            this.BackColor = Color.Aquamarine;
        }
        protected override void Dispose(bool disposing)
        {
			this.MouseEnter -= MouseEnterButton;
			base.Dispose(disposing);
        }
    }
}
