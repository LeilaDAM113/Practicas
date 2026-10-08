using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PruebaFormulario5.Services;
using PruebaFormulario5.ViewModel.Base;

namespace PruebaFormulario5.ViewModel
{
	public class LoginViewModel : BaseViewModel
	{
		private readonly ILoginService loginService;
		private string userName;
		private string passWord;
		private ICommand loginCommand;
		public LoginViewModel()
		{
			loginCommand = new Command(PerformDoLoginCommand);
			loginService = CustomDependecyService.get<LoginService>();
		}


		public string UserName
		{
			get => userName;
			set
			{
				userName = value;
				raiseProperty();
			}
		}
		public string PassWord
		{
			get => passWord;
			set
			{
				passWord = value;
				raiseProperty();
			}
		}
		public ICommand doLoginCommand => loginCommand;

		private void PerformDoLoginCommand()
		{
			//new LoginService().doLogin(userName,passWord);
			CustomDependecyService.get<LoginService>().doLogin(userName, passWord);
		}
	}
}
