using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PruebaFormulario5.ViewModel.Base
{
    public class Command<T> : ICommand
    {
        Action<T> _execute;
        public event EventHandler CanExecuteChanged;

        public Command(Action<T> execute)
        {
            _execute = execute;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _execute?.Invoke((T)parameter);
        }
    }
    public class Command : ICommand
    {
        
        public Action _execute;
        public event EventHandler CanExecuteChanged;
		public Command(Action execute)
		{
			_execute = execute;
		}

		public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _execute.Invoke();
        }
    }
}
