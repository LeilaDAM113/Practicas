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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PruebaFormulario3
{
    /// <summary>
    /// Lógica de interacción para UserControlPathButton.xaml
    /// </summary>
    public partial class UserControlPathButton : UserControl
    {
		public DependencyProperty labelTextProperty = DependencyProperty.Register(nameof(labelText), typeof(string), typeof(UserControlPathButton), new PropertyMetadata(labelTextPropertyChanged));

		private static void labelTextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var userControlPath = (UserControlPathButton)d;
			userControlPath.labelPath.Content = e.NewValue.ToString();
		}
		public UserControlPathButton()
		{
			InitializeComponent();
		}
		public string labelText
		{
			get => (string)GetValue(labelTextProperty);
			set => SetValue(labelTextProperty, value);
		}
	}
}

