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
        public DataTable DT_LstUsuariosBloqueados() { SQLD.Conexion.Close(); return SQLD.DT_ListadoGeneral("Bloqueos", "IdUsuario"); }
        public List<E_Usuarios> LstUsuarios() { return StrDatosSQL.D_ConvierteDatos.ConvertirDTALista<E_Usuarios>(DT_LstUsuarios()); }
        public List<E_Usuarios> LstUsuariosBloqueados() { return StrDatosSQL.D_ConvierteDatos.ConvertirDTALista<E_Usuarios>(DT_LstUsuariosBloqueados()); }
        
        
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

        public DataTable DT_LstCodAlumno() { SQLD.Conexion.Close(); return SQLD.DT_ListadoGeneral("CodAlumno", "IdCodAlumno, IdRSA, Codigo"); }
        public List<E_CodAlumno> LstCodAlumno() { return StrDatosSQL.D_ConvierteDatos.ConvertirDTALista<E_CodAlumno>(DT_LstCodAlumno()); }
        /*public E_CodAlumno BuscaCodAlumno(string Codigo)
        { return (from CodAlumno in LstCodAlumno() where CodAlumno.Codigo == Codigo select CodAlumno).FirstOrDefault(); }*/
        public E_CodAlumno BuscaCodAlumno(string Cod)
        { return (from Codigo in LstCodAlumno() where Codigo.Codigo == Cod select Codigo).FirstOrDefault(); }
        public E_CodAlumno BuscaCodAlumnoRSA(int RSA)
        { return (from Codigo in LstCodAlumno() where Codigo.IdRSA==RSA select Codigo).FirstOrDefault(); }
        public string BorraCodAlumno(int pIdCodAlumno)
        {
            E_CodAlumno ECA = new E_CodAlumno()
            {
                Accion = "BORRAR",
                IdCodAlumno = pIdCodAlumno
            };
            if (SQLD.IBM_Entidad<E_CodAlumno>("IB_CodAlumno", ECA).Contains("Exito"))
                return "Exito: El registro fue borrado";
            return "Error: El registro no pudo ser borrado";
        }
        public string InsertarCodAlumno(E_CodAlumno EntidadCodAlumno)
        {
            EntidadCodAlumno.Accion = "INSERTAR";

            if (SQLD.IBM_Entidad<E_CodAlumno>("IB_CodAlumno", EntidadCodAlumno).Contains("Exito"))
                return "Exito: Correo enviado";
            return "Error: No se pudo enviar el correo";
        }
       
        /// <summary>
        /// Segmento de codigo de Negocios Para el manejo de los codigos de comprobacion
        /// </summary>
        /// <param name="EntidadCodigo"></param>
        /// <returns></returns>
        public E_Usuarios UsuarioBloqueado(int id)
        { return (from Bloqueos in LstUsuariosBloqueados() where Bloqueos.IdUsuario == id select Bloqueos).FirstOrDefault(); }
        public string InsertarBloqueo(int id)
        {
            SqlCommand SqlComando;
            E_Firma EF = BuscaFirma(id);
            SQLD.Conexion.Open();

            int code;
            SqlComando = new SqlCommand("INSERT INTO Bloqueos(IdUsuario) VALUES(@IdUsuario)", SQLD.Conexion);
            SqlComando.Parameters.AddWithValue("@IdUsuario", id);
            code = SqlComando.ExecuteNonQuery();

            if (code == 1)
            {
                SQLD.Conexion.Close();
                return "Exito: Usuario bloqueado";
            }
            SQLD.Conexion.Close();
            return "Error: El usuario no pudo ser bloqueado";
        }
        public string EliminarBloqueo(int id)
        {
            SqlCommand SqlComando;
            E_Firma EF = BuscaFirma(id);
            SQLD.Conexion.Open();

            int code;
            SqlComando = new SqlCommand("DELETE FROM Bloqueos WHERE IdUsuario=@IdUsuario", SQLD.Conexion);
            SqlComando.Parameters.AddWithValue("@IdUsuario", id);
            code = SqlComando.ExecuteNonQuery();

            if (code == 1)
            {
                SQLD.Conexion.Close();
                return "Exito: Usuario desbloqueado";
            }
            SQLD.Conexion.Close();
            return "Error: El usuario no pudo ser desbloqueado";
        }
        public string InsertarCodigo(E_Codigo EntidadCodigo)
        {
            EntidadCodigo.Accion = "INSERTAR";
            if (SQLD.IBM_Entidad<E_Codigo>("InsertCodigo", EntidadCodigo).Contains("Exito"))
                return "Exito: Codigo Generado y enviado.";
            return "Error: No se pudo almacenar el codigo en la Base De Datos.";
        }
        public string BorrarCodigo(E_Codigo EntidadCodigo)
        {

            SqlCommand SqlComando;
            SQLD.Conexion.Open();

            int code;

            SqlComando = new SqlCommand("DELETE FROM CodRecuperacion WHERE EmailUsuario = @EmailUsuario", SQLD.Conexion);
            SqlComando.Parameters.AddWithValue("@EmailUsuario", EntidadCodigo.EmailUsuario);
            code = SqlComando.ExecuteNonQuery();
            if (code == 1)
            {
                SQLD.Conexion.Close();
                return "Exito: Firma insertado";
            }
            SQLD.Conexion.Close();
            return "Error: Firma no pudo ser ingresada";
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
        public E_PlanEstudio BuscaPlanMateria(int IdMateria)
        {
            List<E_Atributos> LEA = LstAtributos();
            List<E_PlanEstudio> LEM = LstPlanes();
            List<E_AtribMateria> LEAM = LstAtribMateria();
            E_PlanEstudio RLEM = new E_PlanEstudio();

            foreach (E_PlanEstudio m in LEM)
            {
                foreach (E_Atributos a in LEA)
                {
                    foreach (E_AtribMateria am in LEAM)
                    {
                        if (a.IdPlan==m.IdPlan && am.IdMateria == IdMateria && a.IdAtributo == am.IdAtributo)
                        {
                            return m;
                        }
                    }

                }
            }


            return RLEM;
        }
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

            string query = "SELECT * FROM Atributos WHERE IdPlan=" + IdPlan;

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
                SQLD.Conexion.Close();
                return ListAtrib;
            }
            SQLD.Conexion.Close();
            return ListAtrib;


        }
        public DataTable DT_LstAtributos() { return SQLD.DT_ListadoGeneral("Atributos", "IdAtributo"); }
        public List<E_Atributos> LstAtributos() { return StrDatosSQL.D_ConvierteDatos.ConvertirDTALista<E_Atributos>(DT_LstAtributos()); }
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
        /// <summary>
        /// Atributos-Materias
        /// </summary>
        /// <param name="IdMateria"></param>
        /// <param name="IdAtributo"></param>
        /// <param name="Aportacion"></param>
        /// <returns></returns>
        public string ModificarAtributoMateria(int IdMateria, int IdAtributo, string Aportacion)
        {
            SqlCommand SqlComando;
            E_Materias EM = BuscaMateria(IdMateria);
            SQLD.Conexion.Open();
            int code;

            if (EM != null)
            {
                SqlComando = new SqlCommand("UPDATE Atributo_Materia SET Aportacion = @Aportacion WHERE IdMateria = @IdMateria AND IdAtributo=@IdAtributo", SQLD.Conexion);
                SqlComando.Parameters.AddWithValue("@IdMateria", IdMateria);
                SqlComando.Parameters.AddWithValue("@IdAtributo", IdAtributo);
                SqlComando.Parameters.AddWithValue("@Aportacion", Aportacion);
                code = SqlComando.ExecuteNonQuery();
                if (code == 1)
                {
                    SQLD.Conexion.Close();
                    return "Exito: Aportacion Modificada";
                }
            }
            SQLD.Conexion.Close();
            return "Error: Aportacion no Modificada";
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
                    return "Exito: Aportacion insertada";
                }
            }
            SQLD.Conexion.Close();
            return "Error: Aportacion no pudo ser ingresada";
        }
        public string EliminarAtributoMateria(int IdMateria, int IdAtributo)
        {
            SqlCommand SqlComando;
            SQLD.Conexion.Open();
            int code;

            SqlComando = new SqlCommand("DELETE FROM Atributo_Materia WHERE IdMateria=@IdMateria AND IdAtributo=@IdAtributo", SQLD.Conexion);
            SqlComando.Parameters.AddWithValue("@IdMateria", IdMateria);
            SqlComando.Parameters.AddWithValue("@IdAtributo", IdAtributo);
            code = SqlComando.ExecuteNonQuery();
            if (code == 1)
            {
                SQLD.Conexion.Close();
                return "Exito: Aportacion insertada";
            }

            SQLD.Conexion.Close();
            return "Error: Aportacion no pudo ser ingresada";
        }
        public DataTable DT_LstAtribMaterias() { return SQLD.DT_ListadoGeneral("Atributo_Materia", "IdAtributoMateria"); }
        public List<E_AtribMateria> LstAtribMateria() { return StrDatosSQL.D_ConvierteDatos.ConvertirDTALista<E_AtribMateria>(DT_LstAtribMaterias()); }
        public E_AtribMateria BuscaAtribMateria(int IdAM)
        { return (from AM in LstAtribMateria() where AM.IdAtributoMateria == IdAM select AM).FirstOrDefault(); }
        /// <summary>
        /// Manejo de la Clase Materia
        /// </summary>
        /// <param name="Materias"></param>
        /// <param name="IdMateria"></param>
        public DataTable DT_LstMaterias() { return SQLD.DT_ListadoGeneral("Materias", "IdMateria, Materia, Clave, IdDocente, Semestre"); }
        public List<E_Materias> LstMaterias() { return StrDatosSQL.D_ConvierteDatos.ConvertirDTALista<E_Materias>(DT_LstMaterias()); }
        public DataTable LstMateriasInnerJoinEncuadre(int IdCoordinador)
        {
            List<E_Materias> ListM = LstMaterias();
            List<E_Encuadres> ListE = LstEncuadres();
            DataTable table = new DataTable();
            table.Columns.Add("IdMateria", typeof(int));
            table.Columns.Add("Materia", typeof(string));
            table.Columns.Add("Clave", typeof(string));
            table.Columns.Add("Estado", typeof(string));
            int tieneRSA = 0;
            foreach (E_Materias M in ListM)
            {
                foreach (E_Encuadres E in ListE)
                {
                    if (E.IdMateria == M.IdMateria)
                    {
                        tieneRSA = 1;
                        if (E.IdCoordinador == IdCoordinador)
                            switch (E.EstadoEncuadre)
                            {
                                case 0:
                                    table.Rows.Add(E.IdMateria, M.Materia, M.Clave, "Sin Llenar");
                                    break;
                                case 1:
                                    table.Rows.Add(E.IdMateria, M.Materia, M.Clave, "Guardado");
                                    break;
                                case 2:
                                    table.Rows.Add(E.IdMateria, M.Materia, M.Clave, "Enviado");
                                    break;
                                case 3:
                                    table.Rows.Add(E.IdMateria, M.Materia, M.Clave, "Rechazado");
                                    break;
                                case 4:
                                    table.Rows.Add(E.IdMateria, M.Materia, M.Clave, "Aceptado");
                                    break;
                                case 5:
                                    table.Rows.Add(E.IdMateria, M.Materia, M.Clave, "Firmado");
                                    break;
                            }
                    }
                }
                if (tieneRSA == 0)
                {
                    E_PlanEstudio EP = BuscaPlanMateria(M.IdMateria);
                    if (EP.IdCoordinador == IdCoordinador)
                    {
                        table.Rows.Add(M.IdMateria, M.Materia, M.Clave, "Sin Llenar");
                    }
                }
                tieneRSA = 0;
            }
            return table;
        }
        public DataTable LstMateriasInnerJoinEncuadreDocente(int IdDocente)
        {
            List<E_Materias> ListM = BuscaMateriasDocente(IdDocente);
            List<E_Encuadres> ListE = LstEncuadres();
            DataTable table = new DataTable();
            table.Columns.Add("IdMateria", typeof(int));
            table.Columns.Add("Materia", typeof(string));
            table.Columns.Add("Clave", typeof(string));
            table.Columns.Add("Estado", typeof(string));
            int tieneRSA = 0;
            foreach (E_Materias M in ListM)
            {
                foreach (E_Encuadres E in ListE)
                {
                    if (E.IdMateria == M.IdMateria)
                    {
                        tieneRSA = 1;
                        if (M.IdDocente == IdDocente)
                        {
                            switch (E.EstadoEncuadre)
                            {
                                case 0:
                                    table.Rows.Add(E.IdMateria, M.Materia, M.Clave, "Sin Llenar");
                                    break;
                                case 1:
                                    table.Rows.Add(E.IdMateria, M.Materia, M.Clave, "Guardado");
                                    break;
                                case 2:
                                    table.Rows.Add(E.IdMateria, M.Materia, M.Clave, "Enviado");
                                    break;
                                case 3:
                                    table.Rows.Add(E.IdMateria, M.Materia, M.Clave, "Rechazado");
                                    break;
                                case 4:
                                    table.Rows.Add(E.IdMateria, M.Materia, M.Clave, "Aceptado");
                                    break;
                                case 5:
                                    table.Rows.Add(E.IdMateria, M.Materia, M.Clave, "Firmado");
                                    break;
                            }
                        }
                    }
                }
                if (tieneRSA == 0)
                {
                    if (M.IdDocente == IdDocente)
                    {
                        table.Rows.Add(M.IdMateria, M.Materia, M.Clave, "Sin Llenar");
                    }
                }
                tieneRSA = 0;
            }
            return table;
        }

        public List<E_Materias> LstBuscaMaterias(int IdPlan)
        {
            List<E_Atributos> LEA = LstAtributos();
            List<E_Materias> LEM = LstMaterias();
            List<E_AtribMateria> LEAM = LstAtribMateria();
            List<E_Materias> RLEM = new List<E_Materias>();

            foreach (E_Atributos a in LEA)
            {
                foreach (E_AtribMateria am in LEAM)
                {
                    foreach (E_Materias m in LEM)
                    {
                        if (a.IdPlan == IdPlan && am.IdMateria == m.IdMateria && a.IdAtributo == am.IdAtributo)
                        {
                            if (!RLEM.Contains(m))
                                RLEM.Add(m);
                        }
                    }

                }
            }


            return RLEM;
        }
        public List<E_Materias> BuscaMateriasDocente(int IdDocente)
        { return (from Materia in LstMaterias() where Materia.IdDocente == IdDocente select Materia).ToList(); }
        public E_Materias BuscaMateria(int IdMateria)
        { return (from Materia in LstMaterias() where Materia.IdMateria == IdMateria select Materia).FirstOrDefault(); }
        public E_Materias BuscaMateriaClave(string Clave)
        { return (from Materia in LstMaterias() where Materia.Clave == Clave select Materia).FirstOrDefault(); }
        public string InsertarMateria(E_Materias EntidadMateria)
        {
            EntidadMateria.Accion = "INSERTAR";

            if (SQLD.IBM_Entidad<E_Materias>("IBM_Materias", EntidadMateria).Contains("Exito"))
                return "Exito: Materia Ingresada Exitosamente.";
            return "Error: No se pudo agregar la Materia.";
        }
        public string ModificarMateria(E_Materias EntidadMateria)
        {
            EntidadMateria.Accion = "MODIFICAR";
            if (SQLD.IBM_Entidad<E_Materias>("IBM_Materias", EntidadMateria).Contains("Exito"))
                return "Exito: La Materia Fue Modificada.";
            return "Error: No se pudo modicar la materia.";
        }
        public string EliminarMateria(E_Materias EntidadMateria)
        {
            EntidadMateria.Accion = "BORRAR";
            if (SQLD.IBM_Entidad<E_Materias>("IBM_Materias", EntidadMateria).Contains("Exito"))
                return "Exito: La Materia Fue Eliminada.";
            return "Error: No se pudo eliminar la materia.";
        }

        /// <summary>
        /// Segmento de Encuadres y RSA
        /// </summary>
        /// 
        public DataTable DT_LstEncuadres() { return SQLD.DT_ListadoGeneral("Encuadres", "IdEncuadre, NombreEncuadre, UrlEncuadre"); }
        public List<E_Encuadres> LstEncuadres() { return StrDatosSQL.D_ConvierteDatos.ConvertirDTALista<E_Encuadres>(DT_LstEncuadres()); }
        public List<E_Encuadres> BuscaEncuadreMateria(int IdMateria)
        { return (from Encuadre in LstEncuadres() where Encuadre.IdMateria == IdMateria select Encuadre).ToList(); }
        public E_Encuadres BuscaEncuadre(int IdMateria)
        { return (from Encuadre in LstEncuadres() where Encuadre.IdMateria == IdMateria select Encuadre).FirstOrDefault(); }
        public string InsertaEncuadre(string NombreEncuadre, string UrlEncuadre, int IdMateria, int IdCoordinador)
        {
            SqlCommand SqlComando;
            int code;
            SQLD.Conexion.Open();
            SqlComando = new SqlCommand("INSERT INTO Encuadres(NombreEncuadre,UrlEncuadre,IdMateria,IdCoordinador,Calificacion,EstadoEncuadre,Observaciones) VALUES(@NombreEncuadre,@UrlEncuadre,@IdMateria,@IdCoordinador,@Calificacion,@EstadoEncuadre,@Observaciones)", SQLD.Conexion);
            SqlComando.Parameters.AddWithValue("@NombreEncuadre", NombreEncuadre);
            SqlComando.Parameters.AddWithValue("@UrlEncuadre", UrlEncuadre);
            SqlComando.Parameters.AddWithValue("@IdCoordinador", IdCoordinador);
            SqlComando.Parameters.AddWithValue("@IdMateria", IdMateria);
            SqlComando.Parameters.AddWithValue("@EstadoEncuadre", 1);
            SqlComando.Parameters.AddWithValue("@Calificacion", "");
            SqlComando.Parameters.AddWithValue("@Observaciones", "");
            code = SqlComando.ExecuteNonQuery();

            if (code == 1)
            {
                SQLD.Conexion.Close();
                return "Exito: Encuadre Insertado";
            }
            SQLD.Conexion.Close();
            return "Error: Encuadre No pudo ser registrado";
        }
        public string EliminarEncuadre(int IdEncuadre)
        {
            SqlCommand SqlComando;
            int code;
            SQLD.Conexion.Open();
            SqlComando = new SqlCommand("DELETE FROM Encuadres WHERE IdEncuadre = @IdEncuadre", SQLD.Conexion);
            SqlComando.Parameters.AddWithValue("@IdEncuadre", IdEncuadre);
            code = SqlComando.ExecuteNonQuery();

            if (code == 1)
            {
                SQLD.Conexion.Close();
                return "Exito: Encuadre Eliminado";
            }
            SQLD.Conexion.Close();
            return "Error: Encuadre No pudo ser eliminado";
        }
        public string ModificarEncuadre(E_Encuadres EE)
        {
            SqlCommand SqlComando;
            int code;
            SQLD.Conexion.Open();
            SqlComando = new SqlCommand("UPDATE Encuadres SET NombreEncuadre=@NombreEncuadre,UrlEncuadre=@UrlEncuadre,IdMateria=@IdMateria,IdCoordinador=@IdCoordinador,Calificacion=@Calificacion,EstadoEncuadre=@EstadoEncuadre,Observaciones=@Observaciones WHERE IdEncuadre=@IdEncuadre", SQLD.Conexion);
            SqlComando.Parameters.AddWithValue("@NombreEncuadre", EE.NombreEncuadre);
            SqlComando.Parameters.AddWithValue("@UrlEncuadre", EE.UrlEncuadre);
            SqlComando.Parameters.AddWithValue("@IdCoordinador", EE.IdCoordinador);
            SqlComando.Parameters.AddWithValue("@IdMateria", EE.IdMateria);
            SqlComando.Parameters.AddWithValue("@EstadoEncuadre", EE.EstadoEncuadre);
            SqlComando.Parameters.AddWithValue("@Calificacion", EE.Calificacion);
            SqlComando.Parameters.AddWithValue("@Observaciones", EE.Observaciones);
            SqlComando.Parameters.AddWithValue("@IdEncuadre", EE.IdEncuadre);
            code = SqlComando.ExecuteNonQuery();

            if (code == 1)
            {
                SQLD.Conexion.Close();
                return "Exito: Encuadre Evaluado";
            }
            SQLD.Conexion.Close();
            return "Error: Encuadre No pudo ser Evaluado";
        }
        public DataTable DT_LstRSA() { SQLD.Conexion.Close(); return SQLD.DT_ListadoGeneral("RSA", "IdRSA"); }
        public DataTable DT_LstRSAPDF() { SQLD.Conexion.Close(); return SQLD.DT_ListadoGeneral("DocumentoRSA", "IdRSA"); }
        public List<E_RSA> LstRSA() { return StrDatosSQL.D_ConvierteDatos.ConvertirDTALista<E_RSA>(DT_LstRSA()); }
        public E_RSA BuscaRSA(int IdMateria)
        { return (from RSA in LstRSA() where RSA.IdMateria == IdMateria select RSA).FirstOrDefault(); }
        public E_RSA BuscaIdRSA(int IdRSA)
        { return (from RSA in LstRSA() where RSA.IdRSA == IdRSA select RSA).FirstOrDefault(); }
        public string InsertarRSA(E_RSA EntidadRSA)
        {
            EntidadRSA.Accion = "INSERTAR";
           
            if (SQLD.IBM_Entidad<E_RSA>("IBM_RSA", EntidadRSA).Contains("Exito"))
                return "Exito: RSA Ingresado Exitosamente.";
            return "Error: No se pudo agregar el RSA.";
        }
        public string ModificarRSA(E_RSA EntidadRSA)
        {
            EntidadRSA.Accion = "MODIFICAR";
            /*string msg = SQLD.IBM_Entidad<E_RSA>("IBM_RSA", EntidadRSA);
            return msg;*/
            if (SQLD.IBM_Entidad<E_RSA>("IBM_RSA", EntidadRSA).Contains("Exito"))
                return "Exito: El RSA fue modificado con exito.";
            return "Error: El RSA no pudo ser modificado.";
        }
        public string EliminarRSA(E_RSA EntidadRSA)
        {
            EntidadRSA.Accion = "BORRAR";

            if (SQLD.IBM_Entidad<E_RSA>("IBM_RSA", EntidadRSA).Contains("Exito"))
                return "Exito: Fue Borrado con exito.";
            return "Error: No pudo ser borrado el RSA.";
        }
        public DataTable LstMateriasInnerJoinRSA(int IdCoordinador)
        {
            List<E_Materias> ListM = LstMaterias();
            List<E_RSA> ListR = LstRSA();
            DataTable table = new DataTable();
            table.Columns.Add("IdMateria", typeof(int));
            table.Columns.Add("Materia", typeof(string));
            table.Columns.Add("Clave", typeof(string));
            table.Columns.Add("Estado", typeof(string));
            int tieneRSA = 0;
            foreach (E_Materias M in ListM)
            {
                foreach (E_RSA E in ListR)
                {
                    if (E.IdMateria == M.IdMateria)
                    {
                        tieneRSA = 1;
                        if (E.IdCoordinador == IdCoordinador)
                            switch (E.Status)
                            {
                                case 0:
                                    table.Rows.Add(E.IdMateria, M.Materia, M.Clave, "Sin Llenar");
                                    break;
                                case 1:
                                    table.Rows.Add(E.IdMateria, M.Materia, M.Clave, "Guardado");
                                    break;
                                case 2:
                                    table.Rows.Add(E.IdMateria, M.Materia, M.Clave, "Enviado");
                                    break;
                                case 3:
                                    table.Rows.Add(E.IdMateria, M.Materia, M.Clave, "Rechazado");
                                    break;
                                case 4:
                                    table.Rows.Add(E.IdMateria, M.Materia, M.Clave, "Aceptado");
                                    break;
                            }
                    }
                }
                if (tieneRSA == 0)
                {
                    E_PlanEstudio EP = BuscaPlanMateria(M.IdMateria);
                    if (EP.IdCoordinador == IdCoordinador)
                    {
                        table.Rows.Add(M.IdMateria, M.Materia, M.Clave, "Sin Llenar");
                    }
                }
                tieneRSA = 0;
            }
            return table;
        }
        public DataTable LstMateriasInnerJoinRSADocente(int IdDocente)
        {
            List<E_Materias> ListM = BuscaMateriasDocente(IdDocente);
            List<E_RSA> ListR = LstRSA();
            DataTable table = new DataTable();
            table.Columns.Add("IdMateria", typeof(int));
            table.Columns.Add("Materia", typeof(string));
            table.Columns.Add("Clave", typeof(string));
            table.Columns.Add("Estado", typeof(string));
            int tieneRSA = 0;
            foreach (E_Materias M in ListM)
            {
                foreach (E_RSA E in ListR)
                {
                    if (E.IdMateria == M.IdMateria)
                    {
                        tieneRSA = 1;
                        if (M.IdDocente == IdDocente)
                        {
                            switch (E.Status)
                            {
                                case 0:
                                    table.Rows.Add(E.IdMateria, M.Materia, M.Clave, "Sin Llenar");
                                    break;
                                case 1:
                                    table.Rows.Add(E.IdMateria, M.Materia, M.Clave, "Guardado");
                                    break;
                                case 2:
                                    table.Rows.Add(E.IdMateria, M.Materia, M.Clave, "Enviado");
                                    break;
                                case 3:
                                    table.Rows.Add(E.IdMateria, M.Materia, M.Clave, "Rechazado");
                                    break;
                                case 4:
                                    table.Rows.Add(E.IdMateria, M.Materia, M.Clave, "Aceptado");
                                    break;
                                case 5:
                                    table.Rows.Add(E.IdMateria, M.Materia, M.Clave, "Firmado");
                                    break;
                            }
                        }
                    }
                }
                if (tieneRSA == 0)
                {
                    if (M.IdDocente == IdDocente)
                    {
                        table.Rows.Add(M.IdMateria, M.Materia, M.Clave, "Sin Llenar");
                    }
                }
                tieneRSA = 0;
            }
            return table;
        }
        public string InsertarRSAPDF(string NombreEncuadre, string UrlEncuadre, int IdMateria, int IdRSA)
        {
            SqlCommand SqlComando;
            int code;
            SQLD.Conexion.Open();
            SqlComando = new SqlCommand("INSERT INTO DocumentoRSA(RSAUrl,NombreRSA, IdRSA, Calificacion, Observaciones) VALUES (@RSAUrl,@NombreRSA,@IdRSA,@Calificacion, @Observaciones)", SQLD.Conexion);
            SqlComando.Parameters.AddWithValue("@NombreRSA", NombreEncuadre);
            SqlComando.Parameters.AddWithValue("@RSAUrl", UrlEncuadre);
            SqlComando.Parameters.AddWithValue("@IdRSA", IdRSA);
            SqlComando.Parameters.AddWithValue("@Calificacion", "");
            SqlComando.Parameters.AddWithValue("@Observaciones", "");


            code = SqlComando.ExecuteNonQuery();

            if (code == 1)
            {
                SQLD.Conexion.Close();
                return "Exito: RSA Insertado";
            }
            SQLD.Conexion.Close();
            return "Error: RSA No pudo ser registrado";
        }
        public string EliminarRSAPDF(int IdRSAPDF)
        {
            SqlCommand SqlComando;
            int code;
            SQLD.Conexion.Open();
            SqlComando = new SqlCommand("DELETE FROM DocumentoRSA WHERE IdRSADocumento = @IdRSAPDF", SQLD.Conexion);
            SqlComando.Parameters.AddWithValue("@IdRSAPDF", IdRSAPDF);
            code = SqlComando.ExecuteNonQuery();

            if (code == 1)
            {
                SQLD.Conexion.Close();
                return "Exito: Encuadre Eliminado";
            }
            SQLD.Conexion.Close();
            return "Error: Encuadre No pudo ser eliminado";
        }
        public string ModificarRSAPDF(E_RSADocumento ERSA)
        {
            SqlCommand SqlComando;
            int code;
            SQLD.Conexion.Open();
            SqlComando = new SqlCommand("UPDATE DocumentoRSA SET RSAUrl=@RSAUrl,NombreRSA=@NombreRSA, Calificacion=@Calificacion, Observaciones=@Observaciones WHERE IdRSA=@IdRSA", SQLD.Conexion);
            SqlComando.Parameters.AddWithValue("@NombreRSA", ERSA.NombreRSA);
            SqlComando.Parameters.AddWithValue("@RSAUrl", ERSA.RSAUrl);
            SqlComando.Parameters.AddWithValue("@IdRSA", ERSA.IdRSA);
            SqlComando.Parameters.AddWithValue("@Calificacion", ERSA.Calificacion);
            SqlComando.Parameters.AddWithValue("@Observaciones", ERSA.Observaciones);
            code = SqlComando.ExecuteNonQuery();

            if (code == 1)
            {
                SQLD.Conexion.Close();
                return "Exito: RSA Modificado";
            }
            SQLD.Conexion.Close();
            return "Error: RSA no pudo ser ingresado";
        }
        public DataTable DT_LstDocumentoRSA() { SQLD.Conexion.Close(); return SQLD.DT_ListadoGeneral("DocumentoRSA", "IdRSA"); }
        public List<E_RSADocumento> LstRSADocumento() { return StrDatosSQL.D_ConvierteDatos.ConvertirDTALista<E_RSADocumento>(DT_LstDocumentoRSA()); }
        public E_RSADocumento BuscaDocumentoRSA(int IdRSA)
        { return (from Documento in LstRSADocumento() where Documento.IdRSA == IdRSA select Documento).FirstOrDefault(); }
        public DataTable DT_LstPorcentajes() { SQLD.Conexion.Close(); return SQLD.DT_ListadoGeneral("Porcentajes", "IdPorcentaje"); }
        public List<E_Porcentajes> LstPorcentajes() { return StrDatosSQL.D_ConvierteDatos.ConvertirDTALista<E_Porcentajes>(DT_LstPorcentajes()); }
        public List<E_Porcentajes> BuscaPorcentajes(int IdRSA)
        { return (from Porcentaje in LstPorcentajes() where Porcentaje.IdRSA == IdRSA select Porcentaje).ToList(); }

        public string InsertarPorcentajes(E_Porcentajes EntidadPorcentaje)
        {
            EntidadPorcentaje.Accion = "INSERTAR";
            string msg = SQLD.IBM_Entidad<E_Porcentajes>("IBM_Porcentajes", EntidadPorcentaje);
            return msg;
            /*if (SQLD.IBM_Entidad<E_Porcentajes>("IBM_Porcentajes", EntidadPorcentaje).Contains("Exito"))
                return "Exito: Procentaje Ingresado.";
            return "Error: No pudo ser ingresado el porcentaje.";*/
        }
        public string ModificarPorcentajes(E_Porcentajes EntidadPorcentaje)
        {
            EntidadPorcentaje.Accion = "MODIFICAR";

            if (SQLD.IBM_Entidad<E_Porcentajes>("IBM_Porcentajes", EntidadPorcentaje).Contains("Exito"))
                return "Exito: Procentaje Modificado.";
            return "Error: No pudo ser Modificado el porcentaje.";
        }
        public string EliminarPorcentajes(E_Porcentajes EntidadPorcentaje)
        {
            EntidadPorcentaje.Accion = "BORRAR";

            if (SQLD.IBM_Entidad<E_Porcentajes>("IBM_Porcentajes", EntidadPorcentaje).Contains("Exito"))
                return "Exito: Procentaje Eliminado.";
            return "Error: No pudo ser eliminar el porcentaje.";
        }
        /// <summary>
        /// Manejo de las fechas
        /// </summary>
        /// <param name="EntidadFecha"></param>
        /// <returns></returns>
        public string InsertarFecha(E_Fecha EntidadFecha)
        {
            EntidadFecha.Accion = "INSERTAR";
            if (SQLD.IBM_Entidad<E_Fecha>("IBM_Fecha", EntidadFecha).Contains("Exito"))
                return "Exito: Fecha insertada.";
            return "Error: No se pudo agregar la fecha.";
        }
        public string ModificarFecha(E_Fecha EntidadFecha)
        {
            EntidadFecha.Accion = "MODIFICAR";
            if (SQLD.IBM_Entidad<E_Fecha>("IBM_Fecha", EntidadFecha).Contains("Exito"))
                return "Exito: La fecha fue Modificado.";
            return "Error: No se pudo modicar la fecha.";
        }
        public string EliminarFecha(E_Fecha EntidadFecha)
        {
            EntidadFecha.Accion = "BORRAR";
            if (SQLD.IBM_Entidad<E_Fecha>("IBM_Fecha", EntidadFecha).Contains("Exito"))
                return "Exito: La fecha fue eliminada.";
            return "Error: No se pudo eliminar la fecha.";
        }
        public DataTable DT_LstFecha() { return SQLD.DT_ListadoGeneral("Fecha", "IdFecha, FechaInicial, FechaFinal, isGlobal, IdPlanEstudio"); }
        public List<E_Fecha> LstFecha() { return StrDatosSQL.D_ConvierteDatos.ConvertirDTALista<E_Fecha>(DT_LstFecha()); }
        public E_Fecha BuscaFechaPlanEstudio(int IdPlanEstudio)
        { return (from Fecha in LstFecha() where Fecha.IdPlanEstudio == IdPlanEstudio select Fecha).FirstOrDefault(); }
        public E_Fecha BuscaFecha(int IdFecha)
        { return (from Fecha in LstFecha() where Fecha.IdFecha == IdFecha select Fecha).FirstOrDefault(); }
        public E_Fecha BuscaGlobal()
        { return (from Fecha in LstFecha() where Fecha.isGlobal == 1 select Fecha).FirstOrDefault(); }

        /// <summary>
        /// Funciones De Funcionamiento
        /// </summary>
        /// <param name="dropDownList"></param>
        /// <param name="usuario"></param>
        //Llena un dropdownlist remoto mediante una peticion sql personalizada
        public void LlenaDropDown(DropDownList dropDownList, string usuario)
        {
            List<E_Usuarios> Usuarios = LstUsuarios();

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
                            if (EP == null)
                            {
                                dropDownList.Items.Add(new ListItem(usuario + " " + u.NombreUsuario + " " + u.APaternoUsuario + " " + u.AMaternoUsuario, u.IdUsuario.ToString()));
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

        public int UltimoRegistro(string Tabla, string Id)
        {

            SQLD.Conexion.Open();//Se abre la conexion

            string query = "SELECT Max(" + Id + ") FROM " + Tabla;

            SqlCommand cmd = new SqlCommand(query, SQLD.Conexion);
            int MaxId = Convert.ToInt32(cmd.ExecuteScalar());
            SQLD.Conexion.Close();
            return MaxId;
        }
    }

}
