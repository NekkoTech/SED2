using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NegociosGestionUsuarios;
using EntidadesGestionUsuarios;

namespace Presentacion.GestionUsuarios
{
    
    public partial class IbmMateria : System.Web.UI.Page
    {
        N_Usuarios NU = new N_Usuarios();
        protected void Page_Load(object sender, EventArgs e)
        {
            NU.LlenaDropDown(dlDocentes, "SELECT * FROM Usuarios where IdTipoUsuario=4", "Docente");

        }
    }
}