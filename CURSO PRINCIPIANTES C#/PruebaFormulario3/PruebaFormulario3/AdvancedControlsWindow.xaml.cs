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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PruebaFormulario3
{
    /// <summary>
    /// Lógica de interacción para AdvancedControlsWindow.xaml
    /// </summary>
    public partial class AdvancedControlsWindow : Window
    {
        private List<Car> cars= new List<Car>();
        public AdvancedControlsWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            sampleList.ItemsSource = cars;
        }
    }
}
