using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PruebaFormulario5.Services;
using PruebaFormulario5.ViewModel.Base;
using ReactiveUI.Wpf;
using System.Windows.Input;
using System.Reactive;
using ReactiveUI;

namespace PruebaFormulario5.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly ILoginService loginService;
        private string userName;
        private string passWord;
        private ReactiveCommand<Unit,Unit> loginCommand;
        public LoginViewModel() {

			loginCommand = ReactiveCommand.CreateFromTask<Unit, Unit>(PerformDoLoginAsync);
			loginService = CustomDependecyService.get<LoginService>();
		}

		private Task<Unit> PerformDoLoginAsync(Unit _)
		{
			loginService.doLogin(userName, passWord);
			return Task.FromResult(Unit.Default);
		}
		public string UserName
        {
            get => userName;
            set => this.RaiseAndSetIfChanged(ref userName, value);
        }
		public string PassWord
		{
			get => passWord;
			set => this.RaiseAndSetIfChanged(ref passWord, value);
		}
        public ReactiveCommand<Unit,Unit> doLoginCommand => loginCommand;
	}
}
