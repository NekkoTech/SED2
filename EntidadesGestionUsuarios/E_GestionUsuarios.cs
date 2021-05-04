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
    public class E_Menu
    {
        #region Atributos
        private int _IdModulo;
        private string _NombreModulo;
        private string _UrlModulo;
        private int _IdPadre;
        #endregion
        #region Encapsulamientos
        public int IdModulo { get => _IdModulo; set => _IdModulo = value; }
        public string NombreModulo { get => _NombreModulo; set => _NombreModulo = value; }
        public string UrlModulo { get => _UrlModulo; set => _UrlModulo = value; }
        public int IdPadre { get => _IdPadre; set => _IdPadre = value; }
        #endregion
        #region Constructores
        public E_Menu()
        {
            IdModulo = 0;
            NombreModulo = string.Empty;
            UrlModulo = string.Empty;
        }
        public E_Menu(int IdModulo, string Nombre, string Url, int idPadre)
        {
            this.IdModulo = IdModulo;
            this.NombreModulo = Nombre;
            this.UrlModulo = Url;
            IdPadre = idPadre;
        }
        #endregion
    }
    public class E_Privilegios
    {
        #region Atributos
        private int _IdTipoUsuario;
        private int _IdModulo;
        private int _IdPrivilegio;

        #endregion
        #region Encapsulamientos
        public int IdTipoUsuario { get => _IdTipoUsuario; set => _IdTipoUsuario = value; }
        public int IdModulo { get => _IdModulo; set => _IdModulo = value; }
        public int IdPrivilegio { get => _IdPrivilegio; set => _IdPrivilegio = value; }


        #endregion
        #region Constructores
        public E_Privilegios(int idTipoUsuario, int idModulo, int idPrivilegio)
        {
            IdTipoUsuario = idTipoUsuario;
            IdModulo = idModulo;
            IdPrivilegio = idPrivilegio;
        }

        public E_Privilegios()
        {
        }
        #endregion
    }
}
