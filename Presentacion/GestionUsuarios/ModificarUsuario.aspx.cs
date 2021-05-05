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
    public partial class ModificarUsuario : System.Web.UI.Page
    {
        E_Usuarios EU = new E_Usuarios();
        N_Usuarios NU = new N_Usuarios();
        protected void Page_Load(object sender, EventArgs e)
        {
            /*if (Session["Usuario"]==null)
            {
                Response.Redirect("ValidaUsuario.aspx");
            }*/
            if (Session["UsuarioSeleccionado"] != null)
            {
                EU = (E_Usuarios)Session["UsuarioSeleccionado"];
                tbNombre.Text = EU.NombreUsuario;
                tbAPat.Text = EU.APaternoUsuario;
                tbAMat.Text = EU.AMaternoUsuario;
                tbEmail.Text = EU.EmailUsuario;
                tbNumeroEmpleado.Text = EU.NumeroEmpleado;
                tbPassWord.Text = EU.PassWordUsuario;
                switch (EU.IdTipoUsuario)
                {
                    case 2:
                        btnSubdirector.Style.Add("background-color", "#00723f");
                        break;
                    case 3:
                        btnCoordinador.Style.Add("background-color", "#00723f");
                        break;
                    case 4:
                        btnDocente.Style.Add("background-color", "#00723f");
                        break;
                }
            }
            if (Session["showModal"]!=null)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "<script>$('#MyModal').on('shown.bs.modal', function() {$('#myInput').trigger('focus')})</ script >", true);
            }
        }

        protected void ChangeColorSubd(object sender, EventArgs e)
        {
            btnSubdirector.Style.Add("background-color", "#00723f");
            btnCoordinador.Style.Add("background-color", "#ffffff");
            btnDocente.Style.Add("background-color", "#ffffff");
            Session["TipoUsuario"] = 2;
        }
        protected void ChangeColorCoord(object sender, EventArgs e)
        {
            btnSubdirector.Style.Add("background-color", "#ffffff");
            btnCoordinador.Style.Add("background-color", "#00723f");
            btnDocente.Style.Add("background-color", "#ffffff");
            Session["TipoUsuario"] = 3;
        }
        protected void ChangeColorDoc(object sender, EventArgs e)
        {
            btnSubdirector.Style.Add("background-color", "#ffffff");
            btnCoordinador.Style.Add("background-color", "#ffffff");
            btnDocente.Style.Add("background-color", "#00723f");
            Session["TipoUsuario"] = 4;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            EU.NombreUsuario = tbNombre.Text;
            EU.APaternoUsuario = tbAPat.Text;
            EU.AMaternoUsuario = tbAMat.Text;
            EU.NumeroEmpleado = tbNumeroEmpleado.Text;
            EU.EmailUsuario = tbEmail.Text;
            EU.PassWordUsuario = tbPassWord.Text;
            EU.IdUsuario = 1;
            EU.IdTipoUsuario = (int)Session["TipoUsuario"];
            if (NU.ModificarUsuario(EU).Contains("Exito"))
            {
                lblRespuesta.Text = "Los datos fueron modificados con exito";
            }
            else
            {
                lblRespuesta.Text = "Error, los datos no pudieron ser ingresados";
            }
            
            
        }
    }
}