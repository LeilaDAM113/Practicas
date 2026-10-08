using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using ReactiveUI;

namespace PruebaFormulario5.ViewModel.Base
{
    public abstract class BaseViewModel : ReactiveObject
    {
		public event PropertyChangedEventHandler PropertyChanged;
		public void raiseProperty([CallerMemberName] string propertyName = "")
		{
			if (PropertyChanged != null)
			{
				PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
			}

		}
	}
}
