using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrDatosSQL;
using EntidadesGestionUsuarios;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;

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
            if (SQLD.IBM_Entidad<E_Usuarios>("IBM_Usuario", EntidadUsuario).Contains("Exito"))
                return "Exito: Los datos del usuario fueron borrados correctamente";
            return "Error: Los datos del usuario no pudieron ser borrados";
        }

        public string InsertarUsuario(E_Usuarios EntidadUsuario)
        {
            E_Usuarios EU = BuscaUsuario(EntidadUsuario.EmailUsuario);
            if (EU == null)
            {
                EntidadUsuario.Accion = "INSERTAR";
                if (SQLD.IBM_Entidad<E_Usuarios>("IBM_Usuario", EntidadUsuario).Contains("Exito"))
                    return "Exito: Los datos del usuario fueron registrados correctamente.";
                return "Error: Los datos del usuario no pudieron ser registrados correctamente.";
            }
            else { return "Error: Los datos del usuario no pudieron ser registrados. <br /El correo electronico ya fue asignado a otro usuario>"; }

        }

        public string ModificarUsuario(E_Usuarios EntidadUsuario)
        {
            EntidadUsuario.Accion = "MODIFICAR";
            
            if (SQLD.IBM_Entidad<E_Usuarios>("IBM_Usuario", EntidadUsuario).Contains("Exito"))
                return "Exito: Los datos del usuario fueron modificados.";
            return "Error: Los datos del usuario no pudieron modificados.";
            /*if (SQLD.IBM_Entidad<E_Usuarios>("IBM_Usuarios", EntidadUsuario).Contains("Exito"))
            {
                return "Exito: Los datos del usuario fueron modificados correctamente.";
            }
            return "Error: Los datos del usuario no pudieron ser modificados correctamente.";*/
        }

        public DataTable DT_LstUsuarios() { return SQLD.DT_ListadoGeneral("Usuarios", "APaternoUsuario, AMaternoUsuario"); }

        public List<E_Usuarios> LstUsuarios() { return StrDatosSQL.D_ConvierteDatos.ConvertirDTALista<E_Usuarios>(DT_LstUsuarios()); }

        public E_Usuarios BuscaUsuario(int pIDUsuario)
        { return (from Usuario in LstUsuarios() where Usuario.IdUsuario == pIDUsuario select Usuario).FirstOrDefault(); }

        public E_Usuarios BuscaUsuario(string Email)
        { return (from Usuario in LstUsuarios() where Usuario.EmailUsuario == Email select Usuario).FirstOrDefault(); }

        public List<E_Usuarios> BuscaUsuarioTipo(int Tipo)
        { return (from Usuario in LstUsuarios() where Usuario.IdTipoUsuario == Tipo select Usuario).ToList(); }

        public List<E_Usuarios> LstBuscaUsuarios(string Criterio)
        {
            return (from Usuario in LstUsuarios()
                    where (Usuario.NombreUsuario.ToUpper().Contains(Criterio.ToUpper())) ||
                    Usuario.APaternoUsuario.ToUpper().Contains(Criterio.ToUpper()) ||
                    Usuario.AMaternoUsuario.ToUpper().Contains(Criterio.ToUpper()) ||
                    Usuario.EmailUsuario.ToUpper().Contains(Criterio.ToUpper())
                    select Usuario).ToList();
        }
        public E_Usuarios ValidaUsuario(string email, string pass)
        { return (from Usuario in LstUsuarios() where Usuario.EmailUsuario == email && Usuario.PassWordUsuario == pass select Usuario).FirstOrDefault(); }

        public string InsertarCodigo(E_Codigo EntidadCodigo)
        {
            EntidadCodigo.Accion = "INSERTAR";
            if (SQLD.IBM_Entidad<E_Codigo>("InsertCodigo", EntidadCodigo).Contains("Exito"))
                return "Exito: Codigo Generado y enviado.";
            return "Error: No se pudo almacenar el codigo en la Base De Datos.";
        }
        public DataTable DT_LstCodigos() { return SQLD.DT_ListadoGeneral("CodRecuperacion", "Codigo, EmailUsuario"); }
        public List<E_Codigo> LstCodigos() { return StrDatosSQL.D_ConvierteDatos.ConvertirDTALista<E_Codigo>(DT_LstCodigos()); }
        public E_Codigo BuscaCodigo(string Email)
        { return (from Codigo in LstCodigos() where Codigo.EmailUsuario == Email select Codigo).FirstOrDefault(); }
        public DataTable DT_LstModulos() { return SQLD.DT_ListadoGeneral("Modulos", "IdModulo,NombreModulo,UrlModulo,IdPadre"); }
        public List<E_Menu> LstModulos() { return StrDatosSQL.D_ConvierteDatos.ConvertirDTALista<E_Menu>(DT_LstModulos()); }
        public DataTable DT_LstPrivilegios() { return SQLD.DT_ListadoGeneral("Privilegios", "IdTipoUsuario,IdModulo,IdPrivilegio"); }
        public List<E_Privilegios> LstPrivilegios() { return StrDatosSQL.D_ConvierteDatos.ConvertirDTALista<E_Privilegios>(DT_LstPrivilegios()); }

        public void InsertarFirma(Byte[] Firma, int IdUsuario)
        {
            SqlCommand SqlComando;
            SQLD.Conexion.Open();
            SqlComando = new SqlCommand("INSERT INTO Firmas(IdUsuario,Firma) VALUES(@IdUsuario,@Firma)", SQLD.Conexion);
            SqlComando.Parameters.AddWithValue("@IdUsuario", IdUsuario);
            SqlComando.Parameters.AddWithValue("@Firma", Firma);

            SqlComando.ExecuteNonQuery();
        }
    }

}
