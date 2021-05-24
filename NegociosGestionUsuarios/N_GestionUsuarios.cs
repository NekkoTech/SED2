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
        /// <summary>
        /// Manejo de Usuarios
        /// </summary>
        /// <param name="EntidadUsuarios"></param>
        /// <returns></returns>
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
            E_Usuarios EU2 = BuscaUsuarioNE(EntidadUsuario.NumeroEmpleado);
            if (EU == null && EU2 == null)
            {
                EntidadUsuario.Accion = "INSERTAR";
                if (SQLD.IBM_Entidad<E_Usuarios>("IBM_Usuario", EntidadUsuario).Contains("Exito"))
                    return "Exito: Los datos del usuario fueron registrados correctamente.";
                return "Error: Los datos del usuario no pudieron ser registrados correctamente.";
            }
            else { return "Error: Los datos del usuario no pudieron ser registrados. <br /El correo electronico o el número de empleado ya fue asignado a otro usuario>"; }

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

        public DataTable DT_LstUsuarios() { SQLD.Conexion.Close(); return SQLD.DT_ListadoGeneral("Usuarios", "APaternoUsuario, AMaternoUsuario"); }

        public List<E_Usuarios> LstUsuarios() { return StrDatosSQL.D_ConvierteDatos.ConvertirDTALista<E_Usuarios>(DT_LstUsuarios()); }

        public E_Usuarios BuscaUsuario(int pIDUsuario)
        { return (from Usuario in LstUsuarios() where Usuario.IdUsuario == pIDUsuario select Usuario).FirstOrDefault(); }

        public E_Usuarios BuscaUsuario(string Email)
        { return (from Usuario in LstUsuarios() where Usuario.EmailUsuario == Email select Usuario).FirstOrDefault(); }

        public E_Usuarios BuscaUsuarioNE(string NumeroEmpleado)
        { return (from Usuario in LstUsuarios() where Usuario.NumeroEmpleado == NumeroEmpleado select Usuario).FirstOrDefault(); }

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

        public List<E_Usuarios> LstBuscaUsuariosTipo(string Criterio, int TipoUsuario)
        {
            return (from Usuario in LstUsuarios()
                    where ((Usuario.NombreUsuario.ToUpper().Contains(Criterio.ToUpper())) ||
                    Usuario.APaternoUsuario.ToUpper().Contains(Criterio.ToUpper()) ||
                    Usuario.AMaternoUsuario.ToUpper().Contains(Criterio.ToUpper()) ||
                    Usuario.EmailUsuario.ToUpper().Contains(Criterio.ToUpper())) && Usuario.IdTipoUsuario == TipoUsuario
                    select Usuario).ToList();
        }

        public E_Usuarios ValidaUsuario(string email, string pass)
        { return (from Usuario in LstUsuarios() where Usuario.EmailUsuario == email && Usuario.PassWordUsuario == pass select Usuario).FirstOrDefault(); }
        /// <summary>
        /// Segmento de codigo de Negocios Para el manejo de los codigos de comprobacion
        /// </summary>
        /// <param name="EntidadCodigo"></param>
        /// <returns></returns>
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
        public DataTable DT_LstFirmas() { return SQLD.DT_ListadoGeneral("Firmas", "IdFirma"); }
        public List<E_Firma> LstFirmas() { return StrDatosSQL.D_ConvierteDatos.ConvertirDTALista<E_Firma>(DT_LstFirmas()); }
        public E_Firma BuscaFirma(int IdUsuario)
        { return (from Firma in LstFirmas() where Firma.IdUsuario == IdUsuario select Firma).FirstOrDefault(); }
        public string InsertarFirma(Byte[] Firma, int IdUsuario)
        {
            SqlCommand SqlComando;
            E_Firma EF = BuscaFirma(IdUsuario);
            SQLD.Conexion.Open();
            
            int code;
            
            if (EF != null)
            {
                SqlComando = new SqlCommand("UPDATE Firmas SET Firma=@Firma WHERE IdFirma=@IdFirma", SQLD.Conexion);
                SqlComando.Parameters.AddWithValue("@IdFirma", EF.IdFirma);
                SqlComando.Parameters.AddWithValue("@Firma", Firma);
                code = SqlComando.ExecuteNonQuery();
            }
            else
            {
                SqlComando = new SqlCommand("INSERT INTO Firmas(IdUsuario,Firma) VALUES(@IdUsuario,@Firma)", SQLD.Conexion);
                SqlComando.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                SqlComando.Parameters.AddWithValue("@Firma", Firma);
                code = SqlComando.ExecuteNonQuery();
            }
            if (code == 1)
            {
                SQLD.Conexion.Close();
                return "Exito: Firma insertado";
            }
            SQLD.Conexion.Close();
            return "Error: Firma no pudo ser ingresada";
        }
        
        /// <summary>
        /// Segmento de Negocios Para Planes de Estudio Y atributos
        /// </summary>
        /// <returns></returns>
        public DataTable DT_LstPlanes() { return SQLD.DT_ListadoGeneral("PlanEstudio", "IdPlan, NombrePlan, IdCoordinador"); }
        public List<E_PlanEstudio> LstPlanes() { return StrDatosSQL.D_ConvierteDatos.ConvertirDTALista<E_PlanEstudio>(DT_LstPlanes()); }
        public E_PlanEstudio BuscaPlanes(int IdPlan)
        { return (from Plan in LstPlanes() where Plan.IdPlan == IdPlan select Plan).FirstOrDefault(); }
        public E_PlanEstudio BuscaPlanCoordinador(int IdCoordinador)
        { return (from Plan in LstPlanes() where Plan.IdCoordinador == IdCoordinador select Plan).FirstOrDefault(); }
        public List<E_PlanEstudio> LstBuscaPlan(string Criterio)
        {
            return (from Plan in LstPlanes() where Plan.NombrePlan.ToUpper().Contains(Criterio.ToUpper()) select Plan).ToList();
        }
        public string InsertarPlan(E_PlanEstudio EntidadPlan)
        {
            EntidadPlan.Accion = "INSERTAR";
            if (SQLD.IBM_Entidad<E_PlanEstudio>("IBM_Plan", EntidadPlan).Contains("Exito"))
                return "Exito: Plan Insertado.";
            return "Error: No se pudo agregar el plan de estudio.";
        }
        public string ModificarPlan(E_PlanEstudio EntidadPlan)
        {
            EntidadPlan.Accion = "MODIFICAR";
            if (SQLD.IBM_Entidad<E_PlanEstudio>("IBM_Plan", EntidadPlan).Contains("Exito"))
                return "Exito: El Plan Fue Modificado.";
            return "Error: No se pudo modicar el plan de estudio.";
        }
        public string EliminarPlan(E_PlanEstudio EntidadPlan)
        {
            EntidadPlan.Accion = "BORRAR";
            if (SQLD.IBM_Entidad<E_PlanEstudio>("IBM_Plan", EntidadPlan).Contains("Exito"))
                return "Exito: El Plan Fue Eliminadoo.";
            return "Error: No se pudo eliminar el plan de estudio.";
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
        public string ModificarAtributo(E_Atributos EntidadAtributo)
        {
            EntidadAtributo.Accion = "MODIFICAR";
            if (SQLD.IBM_Entidad<E_Atributos>("IBM_Atributos", EntidadAtributo).Contains("Exito"))
                return "Exito: Atributo modificado correctamente.";
            return "Error: No se pudo modicar el atributo.";
        }
        public string EliminarAtributo(E_Atributos EntidadAtributo)
        {
            EntidadAtributo.Accion = "BORRAR";
            if (SQLD.IBM_Entidad<E_Atributos>("IBM_Atributos", EntidadAtributo).Contains("Exito"))
                return "Exito: Atributo eliminado correctamente.";
            return "Error: No se pudo eliminado el atributo.";
        }
        public string InsertarAtributoMateria(int IdMateria, int IdAtributo, string Aportacion)
        {
            SqlCommand SqlComando;
            E_Materias EM = BuscaMateria(IdMateria);
            SQLD.Conexion.Open();
            int code;

            if (EM != null)
            {
                SqlComando = new SqlCommand("INSERT INTO Atributo_Materia(IdMateria,IdAtributo,Aportacion) VALUES(@IdMateria,@IdAtributo,@Aportacion)", SQLD.Conexion);
                SqlComando.Parameters.AddWithValue("@IdMateria", IdMateria);
                SqlComando.Parameters.AddWithValue("@IdAtributo", IdAtributo);
                SqlComando.Parameters.AddWithValue("@Aportacion", Aportacion);
                code = SqlComando.ExecuteNonQuery();
                if (code == 1)
                {
                    SQLD.Conexion.Close();
                    return "Exito: Firma insertado";
                }
            }
            SQLD.Conexion.Close();
            return "Error: Firma no pudo ser ingresada";
        }
        /// <summary>
        /// Manejo de la Clase Materia
        /// </summary>
        /// <param name="Materias"></param>
        /// <param name="IdMateria"></param>
        public DataTable DT_LstMaterias() { return SQLD.DT_ListadoGeneral("Materias", "IdMateria, Materia, Clave, IdDocente, Semestre"); }
        public List<E_Materias> LstMaterias() { return StrDatosSQL.D_ConvierteDatos.ConvertirDTALista<E_Materias>(DT_LstMaterias()); }
        public E_Materias BuscaMateria(int IdMateria)
        { return (from Materia in LstMaterias() where Materia.IdMateria == IdMateria select Materia).FirstOrDefault(); }
        public E_Materias BuscaMateriaClave(string Clave)
        { return (from Materia in LstMaterias() where Materia.Clave == Clave select Materia).FirstOrDefault(); }
        public string InsertarMateria(E_Materias EntidadMateria)
        {
            EntidadMateria.Accion = "INSERTAR";
            string msg = SQLD.IBM_Entidad<E_Materias>("IBM_Materias", EntidadMateria);
            return msg;
            /*if ()
                return "Exito: Materia Ingresada Exitosamente.";
            return "Error: No se pudo agregar la Materia.";*/
        }
        public string ModificarMateria(E_Materias EntidadMateria)
        {
            EntidadMateria.Accion = "MODIFICAR";
            if (SQLD.IBM_Entidad<E_PlanEstudio>("IBM_Materia", EntidadMateria).Contains("Exito"))
                return "Exito: La Materia Fue Modificada.";
            return "Error: No se pudo modicar la materia.";
        }
        public string EliminarMateria(E_Materias EntidadMateria)
        {
            EntidadMateria.Accion = "BORRAR";
            if (SQLD.IBM_Entidad<E_PlanEstudio>("IBM_Materia", EntidadMateria).Contains("Exito"))
                return "Exito: La Materia Fue Eliminada.";
            return "Error: No se pudo eliminar la materia.";
        }
        
        //Llena un dropdownlist remoto mediante una peticion sql personalizada
        public void LlenaDropDown(DropDownList dropDownList, string usuario)
        {
            List<E_Usuarios> Usuarios=LstUsuarios();
            
            switch (usuario)
            {
                case "Docente":
                    foreach (E_Usuarios u in Usuarios)
                    {
                        if (u.IdTipoUsuario == 4)
                        {
                            dropDownList.Items.Add(new ListItem(usuario + " " + u.NombreUsuario + " " + u.APaternoUsuario + " " + u.AMaternoUsuario, u.IdUsuario.ToString()));
                        }
                    }
                    break;
                case "Coordinador":
                    foreach (E_Usuarios u in Usuarios)
                    {
                        if (u.IdTipoUsuario == 3)
                        {
                            E_PlanEstudio EP = BuscaPlanCoordinador(u.IdUsuario);
                            if (EP==null)
                            {
                                dropDownList.Items.Add(new ListItem(usuario + " " + u.NombreUsuario + " " + u.APaternoUsuario + "" + u.AMaternoUsuario, u.IdUsuario.ToString()));
                            }
                            
                        }
                    }
                    break;
            }
            if (dropDownList.Items.Count == 0)
            {
                dropDownList.Enabled = false;
            }

            SQLD.Conexion.Close();
        }

        public int UltimoRegistro(string Tabla,string Id)
        {
            
            SQLD.Conexion.Open();//Se abre la conexion

            string query = "SELECT Max("+Id+") FROM "+Tabla;

            SqlCommand cmd = new SqlCommand(query, SQLD.Conexion);
            int MaxId = Convert.ToInt32(cmd.ExecuteScalar());
            SQLD.Conexion.Close();
            return MaxId;
        }
    }

}
