using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesGestionUsuarios
{
    public class E_Usuarios
    {
        #region Atributos
        private string _Accion;
        private int _IdUsuario;
        private int _IdTipoUsuario;
        private string _NombreUsuario;
        private string _APaternoUsuario;
        private string _AMaternoUsuario;
        private string _NumeroEmpleado;
        private string _EmailUsuario;
        private string _PassWordUsuario;
        #endregion
        #region Encapsulamiento
        public string Accion { get => _Accion; set => _Accion = value; }
        public int IdUsuario { get => _IdUsuario; set => _IdUsuario = value; }
        public int IdTipoUsuario { get => _IdTipoUsuario; set => _IdTipoUsuario = value; }
        public string NombreUsuario { get => _NombreUsuario; set => _NombreUsuario = value; }
        public string APaternoUsuario { get => _APaternoUsuario; set => _APaternoUsuario = value; }
        public string AMaternoUsuario { get => _AMaternoUsuario; set => _AMaternoUsuario = value; }
        public string EmailUsuario { get => _EmailUsuario; set => _EmailUsuario = value; }
        public string PassWordUsuario { get => _PassWordUsuario; set => _PassWordUsuario = value; }
        public string NumeroEmpleado { get => _NumeroEmpleado; set => _NumeroEmpleado = value; }
        #endregion
        #region Constructores
        public E_Usuarios()
        {
            _Accion = string.Empty;
            _IdUsuario = 0;
            _IdTipoUsuario = 0;
            _NombreUsuario = string.Empty;
            _APaternoUsuario = string.Empty;
            _AMaternoUsuario = string.Empty;
            _EmailUsuario = string.Empty;
            _PassWordUsuario = string.Empty;
            _NumeroEmpleado = string.Empty;
        }
        public E_Usuarios(string accion, int idUsuario, int idTipoUsuario, string nombreUsuario, string aPaternoUsuario, string aMaternoUsuario, string emailUsuario, string passWordUsuario, string NumeroEmpleado)
        {
            _Accion = accion;
            _IdUsuario = idUsuario;
            _IdTipoUsuario = idTipoUsuario;
            _NombreUsuario = nombreUsuario;
            _APaternoUsuario = aPaternoUsuario;
            _AMaternoUsuario = aMaternoUsuario;
            _EmailUsuario = emailUsuario;
            _PassWordUsuario = passWordUsuario;
            _NumeroEmpleado = NumeroEmpleado;
        }
        #endregion
    }
    public class E_Codigo
    {
        #region Atributos
        private string _Accion;
        private string _Codigo;
        private string _EmailUsuario;


        #endregion
        #region Encapsulamiento
        public string Accion { get => _Accion; set => _Accion = value; }
        public string Codigo { get => _Codigo; set => _Codigo = value; }
        public string EmailUsuario { get => _EmailUsuario; set => _EmailUsuario = value; }
        #endregion
        #region Constructores
        public E_Codigo(string Accion, string codigo, string EmailUsuario)
        {
            this.Accion = Accion;
            this.Codigo = codigo;
            this.EmailUsuario = EmailUsuario;
        }
        public E_Codigo()
        {
            this.Accion = string.Empty;
            this.Codigo = string.Empty;
            this.EmailUsuario = string.Empty;
        }
        #endregion
    }
    public class E_Firma
    {
        #region Atributos
        private int _IdUsuario;
        private Byte[] _Firma;
        private int _IdFirma;
        #endregion
        #region Encapsulamientos
        public int IdUsuario { get => _IdUsuario; set => _IdUsuario = value; }
        public byte[] Firma { get => _Firma; set => _Firma = value; }
        public int IdFirma { get => _IdFirma; set => _IdFirma = value; }
        #endregion
        #region Constructor
        public E_Firma()
        {
            IdUsuario = 0;
            Firma = null;
            IdFirma = 0;
        }
        #endregion
    }
    public class E_PlanEstudio
    {
        #region Atributos
        private string _Accion;
        private int _IdPlan;
        private string _NombrePlan;
        private int _IdCoordinador;


        #endregion
        #region Encapsulamientos
        public int IdPlan { get => _IdPlan; set => _IdPlan = value; }
        public string NombrePlan { get => _NombrePlan; set => _NombrePlan = value; }
        public int IdCoordinador { get => _IdCoordinador; set => _IdCoordinador = value; }
        public string Accion { get => _Accion; set => _Accion = value; }
        #endregion
        #region Constructores
        public E_PlanEstudio(int idPlan, string nombrePlan, int idCoordinador, string accion)
        {
            _IdPlan = idPlan;
            _NombrePlan = nombrePlan;
            _IdCoordinador = idCoordinador;
            Accion = accion;
        }

        public E_PlanEstudio()
        {
            this.IdPlan = 0;
            this.IdCoordinador = 0;
            this.NombrePlan = string.Empty;
        }


        #endregion
    }
    public class E_Atributos
    {
        #region Atributos
        private string _Accion;
        private int _IdAtributo;
        private string _Atributo;
        private int _IdPlan;

        #endregion
        #region Encapsulamientos

        public string Accion { get => _Accion; set => _Accion = value; }
        public int IdAtributo { get => _IdAtributo; set => _IdAtributo = value; }
        public string Atributo { get => _Atributo; set => _Atributo = value; }
        public int IdPlan { get => _IdPlan; set => _IdPlan = value; }




        #endregion
        #region Constructores
        public E_Atributos(string accion, int idAtributo, string atributo, int idPlan)
        {
            Accion = accion;
            IdAtributo = idAtributo;
            Atributo = atributo;
            IdPlan = idPlan;

        }

        public E_Atributos()
        {
            Accion = string.Empty;
            IdAtributo = 0;
            Atributo = string.Empty;
            IdPlan = 0;
        }

        #endregion
    }
    public class E_Materias
    {
        #region Atributos
        private string _Accion;
        private int _IdMateria;
        private string _Materia;
        private string _Clave;
        private int _IdDocente;
        private int _Semestre;

        #endregion
        #region Encapsulamientos
        public string Accion { get => _Accion; set => _Accion = value; }
        public int IdMateria { get => _IdMateria; set => _IdMateria = value; }
        public string Materia { get => _Materia; set => _Materia = value; }
        public string Clave { get => _Clave; set => _Clave = value; }
        public int IdDocente { get => _IdDocente; set => _IdDocente = value; }
        public int Semestre { get => _Semestre; set => _Semestre = value; }



        #endregion
        #region Constructores

        public E_Materias(string accion, int idMateria, string materia, string clave, int idDocente, int semestre)
        {
            Accion = accion;
            IdMateria = idMateria;
            Materia = materia;
            Clave = clave;
            IdDocente = idDocente;
            Semestre = semestre;
        }

        public E_Materias()
        {
            Accion = string.Empty;
            IdMateria = 0;
            Materia = string.Empty;
            Clave = string.Empty;
            IdDocente = 0;
            Semestre = 0;
        }

        #endregion
    }
    public class E_AtribMateria
    {
        #region Atributos
        private int _IdAtributoMateria;
        private int _IdAtributo;
        private int _IdMateria;
        private string _Aportacion;
        #endregion
        #region Encapsulamientos
        public int IdAtributoMateria { get => _IdAtributoMateria; set => _IdAtributoMateria = value; }
        public int IdAtributo { get => _IdAtributo; set => _IdAtributo = value; }
        public int IdMateria { get => _IdMateria; set => _IdMateria = value; }
        public string Aportacion { get => _Aportacion; set => _Aportacion = value; }
        #endregion
        #region Constructores

        public E_AtribMateria()
        {
            IdAtributoMateria = 0;
            IdMateria = 0;
            IdAtributo = 0;
            Aportacion = string.Empty;
        }
        #endregion
    }
    public class E_Encuadres
    {
        #region Atributos
        private int _IdEncuadre;
        private string _NombreEncuadre;
        private string _UrlEncuadre;
        private int _IdMateria;
        private int _IdCoordinador;
        private string _Calificacion;
        private int _EstadoEncuadre;
        private string _Observaciones;

        #endregion
        #region Encapsulamientos
        public int IdEncuadre { get => _IdEncuadre; set => _IdEncuadre = value; }
        public string NombreEncuadre { get => _NombreEncuadre; set => _NombreEncuadre = value; }
        public string UrlEncuadre { get => _UrlEncuadre; set => _UrlEncuadre = value; }
        public int IdMateria { get => _IdMateria; set => _IdMateria = value; }
        public int IdCoordinador { get => _IdCoordinador; set => _IdCoordinador = value; }
        public string Calificacion { get => _Calificacion; set => _Calificacion = value; }
        public int EstadoEncuadre { get => _EstadoEncuadre; set => _EstadoEncuadre = value; }
        public string Observaciones { get => _Observaciones; set => _Observaciones = value; }


        #endregion
        #region Constructores
        public E_Encuadres()
        {
        }

        #endregion
    }
    public class E_RSA
    {
        #region Atributos
        private string _Accion;
        private int _IdRSA;
        private int _Grupo;
        private string _FechaAD;
        private int _CopiaAD;
        private string _FechaMP;
        private int _CopiaMP;
        private int _Semestres;
        private int _HorasTeoria;
        private int _HorasLab;
        private int _HorasTaller;
        private int _HorasAsesoria;
        private int _NumAlumnos;
        private string _PorAprobados;
        private string _PorAsistencia;
        private string _PorMasistencia;
        private int _NumExamenes;
        private string _PorCurso;
        private string _ReqPC;
        private int _HorasPC;
        private string _Programa;
        private string _Comentarios;
        private string _Celular;
        private int _Status;//0. Sin llenar | 1. Docente Guardo | 2. Enviado | 3. Rechazado | 4. Aceptado | 5. Fuera de Fecha
        private int _IdMateria;
        private int _IdCoordinador;

        #endregion
        #region Encapsulamientos
        public int IdRSA { get => _IdRSA; set => _IdRSA = value; }
        public int Grupo { get => _Grupo; set => _Grupo = value; }
        public string FechaAD { get => _FechaAD; set => _FechaAD = value; }
        public int CopiaAD { get => _CopiaAD; set => _CopiaAD = value; }
        public string FechaMP { get => _FechaMP; set => _FechaMP = value; }
        public int CopiaMP { get => _CopiaMP; set => _CopiaMP = value; }
        public int Semestres { get => _Semestres; set => _Semestres = value; }
        public int HorasTeoria { get => _HorasTeoria; set => _HorasTeoria = value; }
        public int HorasLab { get => _HorasLab; set => _HorasLab = value; }
        public int HorasAsesoria { get => _HorasAsesoria; set => _HorasAsesoria = value; }
        public int NumAlumnos { get => _NumAlumnos; set => _NumAlumnos = value; }
        public string PorAprobados { get => _PorAprobados; set => _PorAprobados = value; }
        public string PorAsistencia { get => _PorAsistencia; set => _PorAsistencia = value; }
        public string PorMasistencia { get => _PorMasistencia; set => _PorMasistencia = value; }
        public int NumExamenes { get => _NumExamenes; set => _NumExamenes = value; }
        public string PorCurso { get => _PorCurso; set => _PorCurso = value; }
        public string ReqPC { get => _ReqPC; set => _ReqPC = value; }
        public int HorasPC { get => _HorasPC; set => _HorasPC = value; }
        public string Programa { get => _Programa; set => _Programa = value; }
        public string Comentarios { get => _Comentarios; set => _Comentarios = value; }
        public string Celular { get => _Celular; set => _Celular = value; }
        public int Status { get => _Status; set => _Status = value; }
        public int IdMateria { get => _IdMateria; set => _IdMateria = value; }
        public int IdCoordinador { get => _IdCoordinador; set => _IdCoordinador = value; }
        public string Accion { get => _Accion; set => _Accion = value; }
        public int HorasTaller { get => _HorasTaller; set => _HorasTaller = value; }


        #endregion
        #region Constructores
        public E_RSA()
        {
            IdRSA = 0;
            Grupo = 0;
            FechaAD = " ";
            CopiaAD = 0;
            FechaMP = " ";
            CopiaMP = 0;
            Semestres = 0;
            HorasAsesoria = 0;
            HorasLab = 0;
            HorasTeoria = 0;
            HorasTaller = 0;
            NumAlumnos = 0;
            PorAprobados = " ";
            PorAsistencia = " ";
            PorMasistencia = " ";
            NumExamenes = 0;
            NumAlumnos = 0;
            PorCurso = " ";
            ReqPC = " ";
            HorasPC = 0;
            Programa = " ";
            Comentarios = " ";
            Celular = " ";
            Status = 0;
            IdMateria = 0;
            IdCoordinador = 0;

        }
        #endregion
    }
    public class E_Porcentajes
    {
        #region Atributos
        private string _Accion;
        private int _IdPorcentaje;
        private int _IdAtributo;
        private string _Tecnica;
        private string _Porcentaje;
        private int _IdRSA;

        #endregion
        #region Encapsulamientos
        public string Accion { get => _Accion; set => _Accion = value; }
        public int IdAtributo { get => _IdAtributo; set => _IdAtributo = value; }
        public string Porcentaje { get => _Porcentaje; set => _Porcentaje = value; }
        public int IdRSA { get => _IdRSA; set => _IdRSA = value; }
        public string Tecnica { get => _Tecnica; set => _Tecnica = value; }
        public int IdPorcentaje { get => _IdPorcentaje; set => _IdPorcentaje = value; }


        #endregion
        #region Constructores
        public E_Porcentajes()
        {
            Accion = string.Empty;
            IdAtributo = 0;
            IdPorcentaje = 0;
            Porcentaje = string.Empty;
            Tecnica = string.Empty;
            IdRSA = 0;
        }

        #endregion
    }
    public class E_RSADocumento
    {
        #region Atributos
        private string _Accion;
        private int _IdRSADocumento;
        private string _RSAUrl;
        private string _NombreRSA;
        private string _Calificacion;
        private string _Observaciones;
        private int _IdRSA;

        #endregion
        #region Encapsulamientos
        public string Accion { get => _Accion; set => _Accion = value; }
        public int IdRSADocumento { get => _IdRSADocumento; set => _IdRSADocumento = value; }
        public string RSAUrl { get => _RSAUrl; set => _RSAUrl = value; }
        public string NombreRSA { get => _NombreRSA; set => _NombreRSA = value; }
        public int IdRSA { get => _IdRSA; set => _IdRSA = value; }
        public string Calificacion { get => _Calificacion; set => _Calificacion = value; }
        public string Observaciones { get => _Observaciones; set => _Observaciones = value; }


        #endregion
        #region Constructores
        public E_RSADocumento()
        {
            Accion = string.Empty;
            IdRSADocumento = 0;
            RSAUrl = string.Empty;
            NombreRSA = string.Empty;
            Calificacion = string.Empty;
            Observaciones = string.Empty;
            IdRSA = 0;
        }

        #endregion
        

    }
  
    public class E_CodAlumno
    {
        #region Atributos
        private string _Accion;
        private int _IdCodAlumno;
        private int _IdRSA;
        private string _Codigo;
        #endregion
        #region Encapsulamientos
        public string Accion { get => _Accion; set => _Accion = value; }
        public int IdCodAlumno { get => _IdCodAlumno; set => _IdCodAlumno = value; }
        public int IdRSA { get => _IdRSA; set => _IdRSA = value; }
        public string Codigo { get => _Codigo; set => _Codigo = value; }
        #endregion
        #region Constructores

        public E_CodAlumno()
        {
            _Accion = string.Empty;
            IdCodAlumno = 0;
            IdRSA = 0;
            Codigo = string.Empty;
        }

        #endregion
    }

    public class E_Fecha
    {
        #region Atributos
        private string _Accion;
        private int _IdFecha;
        private DateTime _FechaInicial;
        private DateTime _FechaFinal;
        private int _isGlobal;
        private int _IdPlanEstudio;
        #endregion
        #region Encapsulamientos
        public string Accion { get => _Accion; set => _Accion = value; }
        public int IdFecha { get => _IdFecha; set => _IdFecha = value; }
        public DateTime FechaInicial { get => _FechaInicial; set => _FechaInicial = value; }
        public DateTime FechaFinal { get => _FechaFinal; set => _FechaFinal = value; }
        public int isGlobal { get => _isGlobal; set => _isGlobal = value; }
        public int IdPlanEstudio { get => _IdPlanEstudio; set => _IdPlanEstudio = value; }

        #endregion
        #region Constructores

        public E_Fecha()
        {
            _Accion = string.Empty;
            IdFecha = 0;
            FechaInicial = new DateTime();
            FechaFinal = new DateTime();
            isGlobal = 0;
            IdPlanEstudio = 0;
        }

        #endregion
    }


}
