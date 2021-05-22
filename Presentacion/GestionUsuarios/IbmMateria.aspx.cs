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
        E_Usuarios SEU = new E_Usuarios();
        E_PlanEstudio EP = new E_PlanEstudio();
        List<E_Atributos> LEA= new List<E_Atributos>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("ValidaUsuario.aspx");
            }
            SEU = (E_Usuarios)Session["Usuario"];
            NU.LlenaDropDown(DdlDocentes, "Docente");
            string MsgOpcion = Session["Mensaje"].ToString();
            if (MsgOpcion == "Modificar")
            {

            }
            if (!IsPostBack)
            {
                EP=NU.BuscaPlanCoordinador(SEU.IdUsuario);
                if (EP != null)
                {
                    LEA=NU.BuscaAtributos(EP.IdPlan);
                    LlenaAtributos(LEA);
                    wuc_Text1.Enabled = false;
                    wuc_Text2.Enabled = false;
                    wuc_Text3.Enabled = false;
                    wuc_Text4.Enabled = false;
                    wuc_Text5.Enabled = false;
                    wuc_Text6.Enabled = false;
                    wuc_Text7.Enabled = false;
                    if (MsgOpcion == "Agregar")
                    {
                        BtnModificar.Visible = false;
                        BtnGuardar.Visible = true;
                        LblHeader.Visible = false;

                    }
                    else
                    {

                        BtnModificar.Visible = true;
                        BtnGuardar.Visible = false;

                    }
                    
                }
                else
                {
                    Master.ModalMsg("Aun no esta registrado en algun Plan");
                }
               
                
            }
        }

        protected void BtnRegresar_Click(object sender, EventArgs e)
        {

        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {

        }

        protected void BtnModificar_Click(object sender, EventArgs e)
        {

        }

        protected void LlenaAtributos(List<E_Atributos> ListAtrib)
        {
            switch (ListAtrib.Count)
            {
                case 1:
                    wuc_Text1.Text = ListAtrib[0].Atributo;

                    break;
                case 2:
                    wuc_Text1.Text = ListAtrib[0].Atributo;
                    wuc_Text2.Text = ListAtrib[1].Atributo;
                    break;
                case 3:
                    wuc_Text1.Text = ListAtrib[0].Atributo;
                    wuc_Text2.Text = ListAtrib[1].Atributo;
                    wuc_Text3.Text = ListAtrib[2].Atributo;

                    break;
                case 4:
                    wuc_Text1.Text = ListAtrib[0].Atributo;
                    wuc_Text2.Text = ListAtrib[1].Atributo;
                    wuc_Text3.Text = ListAtrib[2].Atributo;
                    wuc_Text4.Text = ListAtrib[3].Atributo;
                    break;
                case 5:
                    wuc_Text1.Text = ListAtrib[0].Atributo;
                    wuc_Text2.Text = ListAtrib[1].Atributo;
                    wuc_Text3.Text = ListAtrib[2].Atributo;
                    wuc_Text4.Text = ListAtrib[3].Atributo;
                    wuc_Text5.Text = ListAtrib[4].Atributo;

                    break;
                case 6:
                    wuc_Text1.Text = ListAtrib[0].Atributo;
                    wuc_Text2.Text = ListAtrib[1].Atributo;
                    wuc_Text3.Text = ListAtrib[2].Atributo;
                    wuc_Text4.Text = ListAtrib[3].Atributo;
                    wuc_Text5.Text = ListAtrib[4].Atributo;
                    wuc_Text6.Text = ListAtrib[5].Atributo;
                    break;
                case 7:
                    wuc_Text1.Text = ListAtrib[0].Atributo;
                    wuc_Text2.Text = ListAtrib[1].Atributo;
                    wuc_Text3.Text = ListAtrib[2].Atributo;
                    wuc_Text4.Text = ListAtrib[3].Atributo;
                    wuc_Text5.Text = ListAtrib[4].Atributo;
                    wuc_Text6.Text = ListAtrib[5].Atributo;
                    wuc_Text7.Text = ListAtrib[6].Atributo;
                    break;
            }
        }
    }
}