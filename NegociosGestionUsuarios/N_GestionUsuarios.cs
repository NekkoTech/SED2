using System;
using System.Collections.Generic;
using System.Linq;
using StrDatosSQL;
using EntidadesGestionUsuarios;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

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
        /*public DataTable DT_LstModulos() { return SQLD.DT_ListadoGeneral("Modulos", "IdModulo,NombreModulo,UrlModulo,IdPadre"); }
        public List<E_Menu> LstModulos() { return StrDatosSQL.D_ConvierteDatos.ConvertirDTALista<E_Menu>(DT_LstModulos()); }
        public DataTable DT_LstPrivilegios() { return SQLD.DT_ListadoGeneral("Privilegios", "IdTipoUsuario,IdModulo,IdPrivilegio"); }
        public List<E_Privilegios> LstPrivilegios() { return StrDatosSQL.D_ConvierteDatos.ConvertirDTALista<E_Privilegios>(DT_LstPrivilegios()); }*/
        public DataTable DT_LstPlanes() { return SQLD.DT_ListadoGeneral("PlanEstudio", "IdPlan, NombrePlan, IdCoordinador"); }
        public List<E_PlanEstudio> LstPlanes() { return StrDatosSQL.D_ConvierteDatos.ConvertirDTALista<E_PlanEstudio>(DT_LstPlanes()); }
        public E_PlanEstudio BuscaPlanes(int IdPlan)
        { return (from Plan in LstPlanes() where Plan.IdPlan == IdPlan select Plan).FirstOrDefault(); }
        public string InsertarPlan(E_PlanEstudio EntidadPlan)
        {
            EntidadPlan.Accion = "INSERTAR";
            if (SQLD.IBM_Entidad<E_PlanEstudio>("IBM_Plan", EntidadPlan).Contains("Exito"))
                return "Exito: Codigo Generado y enviado.";
            return "Error: No se pudo almacenar el codigo en la Base De Datos.";
        }
        public List<E_Atributos> BuscaAtributos(int IdPlan)
        {
            SQLD.Conexion.Open();//Se abre la conexion
            List<E_Atributos> ListAtrib = new List<E_Atributos>();
            
            string query = "SELECT * FROM Atributos WHERE IdPlan="+IdPlan;

            SqlCommand cmd = new SqlCommand(query, SQLD.Conexion);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();//Se ejecuta la peticion sql y se extraen los datos

            if (dr.HasRows)
            {
                int i = 0;
                while (dr.Read())//Se comprueba que tenga informacion y de ahi se llena uno por uno los datos 
                {
                    E_Atributos EA = new E_Atributos();
                    EA.IdPlan = IdPlan;
                    EA.IdAtributo = dr.GetInt32(0);
                    EA.Atributo = dr.GetString(1);
                    //i++;
                    ListAtrib.Add(EA);
                    
                }
                return ListAtrib;
            }
            return ListAtrib;
            SQLD.Conexion.Close();

        }

        public string InsertarAtributo(E_Atributos EntidadAtributo)
        {
            EntidadAtributo.Accion = "INSERTAR";
            if (SQLD.IBM_Entidad<E_Atributos>("IBM_Atributos", EntidadAtributo).Contains("Exito"))
                return "Exito: Codigo Generado y enviado.";
            return "Error: No se pudo almacenar el codigo en la Base De Datos.";
        }

        public void InsertarFirma(Byte[] Firma, int IdUsuario)
        {
            SqlCommand SqlComando;
            SQLD.Conexion.Open();
            SqlComando = new SqlCommand("INSERT INTO Firmas(IdUsuario,Firma) VALUES(@IdUsuario,@Firma)", SQLD.Conexion);
            SqlComando.Parameters.AddWithValue("@IdUsuario", IdUsuario);
            SqlComando.Parameters.AddWithValue("@Firma", Firma);
            SqlComando.ExecuteNonQuery();
        }
        //Llena un dropdownlist remoto mediante una peticion sql personalizada
        public void LlenaDropDown(DropDownList dropDownList, string sql)
        {
            SQLD.Conexion.Open();//Se abre la conexion

            string query = sql;

            SqlCommand cmd = new SqlCommand(query, SQLD.Conexion);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();//Se ejecuta la peticion sql y se extraen los datos

            if (dr.HasRows)
            {
                ListItem item;
                int i = 0;
                while (dr.Read())//Se comprueba que tenga informacion y de ahi se llena uno por uno los datos extraidos en el dropdownlist
                {
                    item = new ListItem("Coordinador "+dr[2].ToString()+" " + dr[3].ToString() +" " + dr[4].ToString(),dr[0].ToString());
                    dropDownList.Items.Insert(i,item);
                    i++;
                }
            }
            SQLD.Conexion.Close();
            
        }

        public int UltimoRegistro(string Tabla,string Id)
        {
            
            SQLD.Conexion.Open();//Se abre la conexion

            string query = "SELECT Max("+Id+") FROM "+Tabla;

            SqlCommand cmd = new SqlCommand(query, SQLD.Conexion);
            int MaxId = Convert.ToInt32(cmd.ExecuteScalar());
            return MaxId;
        }
    }

}
