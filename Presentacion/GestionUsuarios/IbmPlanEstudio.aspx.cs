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
    public partial class IbmPlanEstudio : System.Web.UI.Page
    {
        N_Usuarios NU = new N_Usuarios();
        E_PlanEstudio EP = new E_PlanEstudio();
        E_Atributos EA = new E_Atributos();
        List<string> ListText = new List<string>();
        List<E_Atributos> ListAtrib = new List<E_Atributos>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("ValidaUsuario.aspx");
            }
            NU.LlenaDropDown(DdlCoordinadores, "SELECT * FROM Usuarios where IdTipoUsuario=3", "Coordinador");
            string MsgOpcion = Session["Mensaje"].ToString();
            if (MsgOpcion == "Modificar")
            {
                EP = (E_PlanEstudio)Session["Plan"];
                ListAtrib = NU.BuscaAtributos(EP.IdPlan);
            }
            if (!IsPostBack)
            {
                if (MsgOpcion == "Agregar")
                {
                    BtnModificar.Visible = false;
                    BtnGuardar.Visible = true;
                }
                else
                {
                    
                    BtnModificar.Visible = true;
                    BtnGuardar.Visible = false;
                    DdlCoordinadores.SelectedValue = EP.IdCoordinador.ToString();
                    wuc_Text.Text = EP.NombrePlan;
                    wuc_Text1.Text = ListAtrib[0].Atributo;
                    wuc_Text2.Text = ListAtrib[1].Atributo;
                    wuc_Text3.Text = ListAtrib[2].Atributo;
                    wuc_Text4.Text = ListAtrib[3].Atributo;
                    wuc_Text5.Text = ListAtrib[4].Atributo;
                    wuc_Text6.Text = ListAtrib[5].Atributo;
                    wuc_Text7.Text = ListAtrib[6].Atributo;

                }
            }


        }

        protected void BtnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaPlanEstudio.aspx");
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {

            EP.NombrePlan = wuc_Text.Text.ToString();
            EP.IdPlan = 0;
            EP.IdCoordinador = Convert.ToInt32(DdlCoordinadores.SelectedValue);
            NU.InsertarPlan(EP);
            EA.IdPlan = NU.UltimoRegistro("PlanEstudio", "IdPlan");
            if (EA.IdPlan != -1)
            {
                int i = 0;
                GeneraLista();
                foreach (string c in ListText)
                {
                    EA.IdAtributo = i;
                    i++;
                    EA.Atributo = c.ToString();
                    string Msg = NU.InsertarAtributo(EA);

                }
                Master.ModalMsg("Exito: El plan y los atributos fueron registrados exitosamente");
            }
            else
            {
                Master.ModalMsg("Error: Hubo un error al agregar el Plan de Estudio");
            }

        }
        protected void GeneraLista()
        {
            ListText.Clear();
            ListText.Add(wuc_Text1.Text.ToString());
            ListText.Add(wuc_Text2.Text.ToString());
            ListText.Add(wuc_Text3.Text.ToString());
            ListText.Add(wuc_Text4.Text.ToString());
            ListText.Add(wuc_Text5.Text.ToString());
            ListText.Add(wuc_Text6.Text.ToString());
            ListText.Add(wuc_Text7.Text.ToString());
        }

        protected void BtnModificar_Click(object sender, EventArgs e)
        {
            EP.NombrePlan = wuc_Text.Text.ToString();
            EP.IdCoordinador = Convert.ToInt32(DdlCoordinadores.SelectedValue);
            string msg = NU.ModificarPlan(EP);
            if (msg == "Exito: El Plan Fue Modificado.")
            {
                //int i = 0;
                GeneraLista();
                /*foreach (string c in ListText)
                {
                    foreach(E_Atributos a in ListAtrib)
                    {

                        EA.Atributo = c.ToString();
                        EA.IdPlan = EP.IdPlan;
                        string Msg = NU.ModificarAtributo(EA);
                    }
                    

                }*/
                for(int i = 0; i < ListAtrib.Count; i++)
                {
                    ListAtrib[i].Atributo = ListText[i].ToString();
                    string Msg= NU.ModificarAtributo(ListAtrib[i]);
                }
                Master.ModalMsg("Exito: El plan y los atributos fueron registrados exitosamente");
            }
            else
            {
                Master.ModalMsg("Error: Hubo un error al modificar el Plan de Estudio");
            }
        }
    }
}