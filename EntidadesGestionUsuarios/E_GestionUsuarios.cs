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
        public E_Codigo(string Accion,string codigo, string EmailUsuario)
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
}
