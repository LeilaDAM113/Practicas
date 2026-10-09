using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ServiceModel;
using EjemploWCF;
namespace EjemploCursoWebASPNET
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
		

		}

		protected void btn_Login_Click(object sender, EventArgs e)
		{
			IService1 servicio = new Connection().CrearConexion();
			if (servicio.verificarAcceso(txt_Username.Text, txt_password.Text))
			{
				Response.Redirect("DatosPage.aspx");
			}
			else
			{
				Response.Write("<script>alert('Usuario Incorrecto');</script>");
			}
		}
	}
}