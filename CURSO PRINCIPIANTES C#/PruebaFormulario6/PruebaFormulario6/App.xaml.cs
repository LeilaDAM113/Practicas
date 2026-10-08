using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using PruebaFormulario5;
using PruebaFormulario5.Services;
using ReactiveUI.Builder;

namespace PruebaFormulario6
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
		public App()
		{
			CustomDependecyService.register<LoginService>();
			_ = RxAppBuilder.CreateReactiveUIBuilder()
		  .WithWpf()
		  .BuildApp();
		}

	}
}
