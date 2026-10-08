using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
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
using PruebaFormulario5.ViewModel;
using PruebaFormulario6.View.Base;
using ReactiveUI;
using ReactiveUI.Binding;

namespace PruebaFormulario5.View
{
	/// <summary>
	/// Lógica de interacción para LoginView.xaml
	/// </summary>
	public partial class LoginView
	{

		public LoginView()
		{

			InitializeComponent();
			ViewModel = new LoginViewModel();
			DataContext = ViewModel;

			this.WhenActivated(d =>
			{
				d(this.BindUnsafe(ViewModel, vm => vm.UserName,
				 v => v.TextBoxUsername.Text));

				d(this.BindUnsafe(ViewModel, vm => vm.PassWord,
				 v => v.TextBoxPassword.Text));

				d(this.BindCommandUnsafe(ViewModel, vm => vm.doLoginCommand,
				 v => v.ButtonLogin, null));

				d(this.WhenAnyValueUnsafe(v => v.ViewModel.UserName)
				 .Subscribe(username =>
				 {
					 if (string.IsNullOrEmpty(username))
						 TextBoxUsername.Background =
			  new SolidColorBrush(Colors.Aquamarine);
				 }));

				var textEvent = Observable.FromEventPattern<TextChangedEventArgs>(
				 TextBoxUsername, nameof(TextBoxUsername.TextChanged));
				d(textEvent.Subscribe());
			});
		}
	}