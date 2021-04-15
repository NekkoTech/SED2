using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrDatosSQL;
using EntidadesGestionUsuarios;

namespace NegociosGestionUsuarios
{
    public class N_Usuarios
    {
        readonly D_SQL_Datos SQLD = new D_SQL_Datos();

        public string BorraUsuario(int pIdUsuario)
        {
            E_Usuarios EntidadUsuario = new E_Usuarios()
            {
                Accion = "BORRAR",
                IdUsuario = pIdUsuario
            };
            if (SQLD.IBM_Entidad<E_Usuarios>("IBM_Usuarios", EntidadUsuario).Contains("Exito"))
                return "Exito: Los datos del usuario fueron borrados correctamente";
            return "Error: El usuario no pudieron ser borrados";
        }
    }
}
