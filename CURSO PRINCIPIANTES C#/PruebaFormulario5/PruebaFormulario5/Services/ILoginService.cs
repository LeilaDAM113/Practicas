using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaFormulario5.Model;

namespace PruebaFormulario5.Services
{
    public interface ILoginService
    {
		UserData doLogin(string userName, string passWord);

	}
}
