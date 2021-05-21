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
    
    public partial class AgregaUsuario : System.Web.UI.Page
    {
        E_Usuarios EU = new E_Usuarios();
        N_Usuarios NU = new N_Usuarios();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("ValidaUsuario.aspx");
            }
            else
            {
                EU = (E_Usuarios)Session["Usuario"];
                switch (EU.IdTipoUsuario)
                {
                    case 2:
                        Response.Redirect("InicioSubdirector.aspx");
                        break;
                    case 3:
                        Response.Redirect("InicioCoordinador.aspx");
                        break;
                    case 4:
                        Response.Redirect("InicioDocente.aspx");
                        break;
                }
            }
            if (Session["TipoUsuario"]!=null)
            {
                int idtipo = (int)Session["TipoUsuario"];
                switch (idtipo)
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
            if (IsPostBack)
            {
                this.tbPassWord.Attributes.Add("value", this.tbPassWord.Text);
            }


        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

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
            EU = new E_Usuarios();
            EU.NombreUsuario = tbNombre.Text;
            EU.APaternoUsuario = tbAPat.Text;
            EU.AMaternoUsuario = tbAMat.Text;
            EU.EmailUsuario = tbEmail.Text;
            EU.NumeroEmpleado = tbNumeroEmpleado.Text;
            CreatePassword();
            EU.IdUsuario = 1;
            if (Session["TipoUsuario"]==null)
            {
                lblErrorTipoUsuario.Text = "Selecciona el tipo de usuario";
                return;
            }
            lblErrorTipoUsuario.Text = string.Empty;
            EU.IdTipoUsuario = (int)Session["TipoUsuario"];
            if(NU.InsertarUsuario(EU).Contains("Exito"))
            {
                Master.ModalMsg("Exito: El Usuario fue agregado exitosamente");
            }
            else
            {
                Master.ModalMsg("Error: El usuario no pudo ser agregado. El correo elenctronico o el número de empleado ya esta en el sistema");
            }
        }

        protected void CreatePassword()
        {
            if (tbPassWord.Text.ToString().Length>=8)
            {
                EU.PassWordUsuario = tbPassWord.Text.ToString();
                return;
            }
            if (tbPassWord.Text.ToString().Length>0)
            {
                EU.PassWordUsuario = tbPassWord.Text.ToString();
                int a = 8 - tbPassWord.Text.ToString().Length;
                while (a>0)
                {
                    EU.PassWordUsuario = "0" + EU.PassWordUsuario;
                    a--;
                };
                return;
            }
            if (tbPassWord.Text.ToString().Length==0)
            {
                string aux = tbEmail.Text.ToString();
                int i = 0;
                while (aux[i]!='@' && i<8)
                {
                    EU.PassWordUsuario = EU.PassWordUsuario + aux[i];
                    i++;
                };
                if (EU.PassWordUsuario.Length<8)
                {
                    i = 8 - EU.PassWordUsuario.Length;
                    while (i > 0)
                    {
                        EU.PassWordUsuario = "0" + EU.PassWordUsuario;
                        i--;
                    };
                }
                return;
            }
        }
        
    }
}