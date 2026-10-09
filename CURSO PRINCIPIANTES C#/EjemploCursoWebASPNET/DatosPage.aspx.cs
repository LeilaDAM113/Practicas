using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EjemploWCF;

namespace EjemploCursoWebASPNET
{
    public partial class DatosPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			IService1 servicio = new Connection().CrearConexion();
			GridView1.DataSource= servicio.obtenerUsuarios();
            GridView1.DataBind();
		}
    }
}