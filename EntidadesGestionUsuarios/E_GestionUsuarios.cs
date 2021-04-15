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
        }
        public E_Usuarios(string accion, int idUsuario, int idTipoUsuario, string nombreUsuario, string aPaternoUsuario, string aMaternoUsuario, string emailUsuario, string passWordUsuario)
        {
            _Accion = accion;
            _IdUsuario = idUsuario;
            _IdTipoUsuario = idTipoUsuario;
            _NombreUsuario = nombreUsuario;
            _APaternoUsuario = aPaternoUsuario;
            _AMaternoUsuario = aMaternoUsuario;
            _EmailUsuario = emailUsuario;
            _PassWordUsuario = passWordUsuario;
        }
        #endregion
    }
}
