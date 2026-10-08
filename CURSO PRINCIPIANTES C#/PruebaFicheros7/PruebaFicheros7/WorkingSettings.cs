using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaFicheros7
{
    public class WorkingSettings
    {
        public void changeColor(System.Drawing.Color color)
        {
            Properties.Settings.Default.MoodColor = color;
            Properties.Settings.Default.Save();
        }
    }
}
