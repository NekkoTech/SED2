using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesGestionUsuarios;
using NegociosGestionUsuarios;

namespace Presentacion.PaginasMaestras
{
    public partial class MP_BaseMaster : System.Web.UI.MasterPage
    {
        E_Usuarios EU = new E_Usuarios();
        N_Usuarios NU = new N_Usuarios();
        //List<E_Menu> Menus = new List<E_Menu>();
        //List<E_Privilegios> Privilegios = new List<E_Privilegios>();
        protected void Page_Load(object sender, EventArgs e)
        {
            EU = (E_Usuarios)Session["Usuario"];
            if (EU != null)
            {
                /*Literal Mn = new Literal
                {
                    Text =
                    "<nav class=\"navbar navbar-expand-lg navbar-dark\" style=\"background-color: #00723f;\">" +
                        "<div class=\"container-fluid\">" +
                            "<a class=\"navbar-brand\" href=\"#\">SED</a>" +
                            "<button class=\"navbar-toggler\" type=\"button\" data-bs-toggle=\"collapse\" data-bs-target=\"#navbarNav\" aria-controls=\"navbarNav\" aria-expanded=\"false\" aria-label=\"Toggle navigation\">"+
                              "<span class=\"navbar-toggler-icon\"></span>"+
                            "</button>"+
                        "<div class=\"collapse navbar-collapse\" id=\"navbarNav\">" +
                        "<ul class=\"navbar-nav\">"
                        


                };
                
                Menus =NU.LstModulos();
                Privilegios = NU.LstPrivilegios();
                foreach(E_Menu menu in Menus)
                {
                    foreach(E_Privilegios priv in Privilegios)
                    {
                        if (priv.IdModulo == menu.IdModulo && priv.IdTipoUsuario== EU.IdTipoUsuario)
                        {
                            if (menu.IdPadre == 0)
                            {
                                Mn.Text += "<li class=\"nav-item\">" +
                                    "<a class=\"nav-link\" href=" + menu.UrlModulo + ">" + menu.NombreModulo + "</a>" +
                                    "</li>";
                            }
                            else
                            {

                            }
                                 
                        }
                    }
                }
                Mn.Text += "</ul>";
                Mn.Text += "</div>";
                Mn.Text += "</div>";
                Mn.Text += "</nav>";
                PnlMenuUsuario.Controls.Add(Mn);*/
            }

        }
    }
}