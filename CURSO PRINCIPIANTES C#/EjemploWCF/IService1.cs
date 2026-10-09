using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EjemploWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        List<Usuarios> obtenerUsuarios();

        [OperationContract]
        bool verificarAcceso(string user, string pass);

        [OperationContract]
        void insertarUsuario(string user, string pass);

        [OperationContract]
        void eliminarUsuario(string user);

        [OperationContract]
        bool desactivarUsuario(string user);

        // TODO: agregue aquí sus operaciones de servicio
    }


    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
   
}
