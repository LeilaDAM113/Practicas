using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PruebaFormulario3
{
    /// <summary>
    /// Lógica de interacción para AnimationSampleWindow.xaml
    /// </summary>
    public partial class AnimationSampleWindow : Window
    {
        public AnimationSampleWindow()
        {
            InitializeComponent();
        }

        private void buttonAnimation_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation doubleAnimation=new DoubleAnimation();
            doubleAnimation.From = 1;
            doubleAnimation.To = 0;
            buttonAnimation.BeginAnimation(Button.OpacityProperty, doubleAnimation);
		}
	}
}
