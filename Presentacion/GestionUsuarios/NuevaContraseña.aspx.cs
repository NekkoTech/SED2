using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Text;
using NegociosGestionUsuarios;
using EntidadesGestionUsuarios;

namespace Presentacion.GestionUsuarios
{
    public partial class NuevaContraseña : System.Web.UI.Page
    {
        N_Usuarios NU = new N_Usuarios();
        E_Usuarios EU = new E_Usuarios();
        E_Codigo EC = new E_Codigo();
        string Email;
        protected void Page_Load(object sender, EventArgs e)
        {
            Email = (string)Session["Correo"];
        }

        protected void BtnCambiarContra_Click(object sender, EventArgs e)
        {
            EU=NU.BuscaUsuario(Email);
            EU.PassWordUsuario = tbNuevaContraseña.Text.ToString();
            string msg=NU.ModificarUsuario(EU);
            EC = (E_Codigo)Session["Codigo"];
            NU.BorrarCodigo(EC);
            Response.Redirect("ValidaUsuario.aspx");
        }
    }
}