
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.UI;
using EjemploWCF;
namespace EjemploCursoWebASPNET
{
    public class Connection
    {
		public EjemploWCF.IService1 Obj { get; set; }

		public IService1 CrearConexion()
		{
			WSHttpBinding basicHttpBinding = new WSHttpBinding();
			basicHttpBinding.Security.Mode = SecurityMode.None;
			basicHttpBinding.Name = "MetadataExchangeHttpBinding_IService1";
			EndpointAddress endpoint = new EndpointAddress("http://localhost:61416/Service1.svc/mex");
			return new Service1Client(basicHttpBinding, endpoint);
		}
	}
}
