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
        E_Usuarios EU = new E_Usuarios();
        E_Usuarios PEU = new E_Usuarios();
        E_Atributos EA = new E_Atributos();
        static List<string> ListText = new List<string>();
        List<E_Atributos> ListAtrib = new List<E_Atributos>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("ValidaUsuario.aspx");
            }
            EU = (E_Usuarios)Session["Usuario"];
            NU.LlenaDropDown(DdlCoordinadores, "Coordinador");
            string MsgOpcion = Session["Mensaje"].ToString();
            if (MsgOpcion == "Modificar")
            {
                EP = (E_PlanEstudio)Session["Plan"];
                ListAtrib = NU.BuscaAtributos(EP.IdPlan);
                PEU = NU.BuscaUsuario(EP.IdCoordinador);
                
            }
            if (!IsPostBack)
            {
                if (MsgOpcion == "Agregar")
                {
                    BtnModificar.Visible = false;
                    BtnGuardar.Visible = true;
                    LblHeader.Visible = false;
                }
                else
                {
                    DdlCoordinadores.Items.Add(new ListItem("Coordinador " + PEU.NombreUsuario + " " + PEU.APaternoUsuario + " " + PEU.AMaternoUsuario, PEU.IdUsuario.ToString()));
                    DdlCoordinadores.SelectedValue = EP.IdCoordinador.ToString();
                    BtnModificar.Visible = true;
                    BtnGuardar.Visible = false;
                    
                    wuc_Text.Text = EP.NombrePlan;
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

        protected void BtnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaPlanEstudio.aspx");
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (DdlCoordinadores.Enabled == true)
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
                        if (c.Length > 0)
                        {
                            EA.IdAtributo = i;
                            i++;
                            EA.Atributo = c.ToString();
                            string Msg = NU.InsertarAtributo(EA);
                        }
                    }
                    Master.ModalMsg("Exito: El plan y los atributos fueron registrados exitosamente");
                }
                else
                {
                    Master.ModalMsg("Error: Hubo un error al agregar el Plan de Estudio");
                }
            }
            else
            {
                Master.ModalMsg("Error: No hay Coordinadores Disponibles");
            }
            

        }
        protected void GeneraLista()
        {
            ListText.Clear();
            if (wuc_Text1.Text.Length>0)
            {
                ListText.Add(wuc_Text1.Text.ToString());
            }
            if (wuc_Text2.Text.Length > 0)
            {
                ListText.Add(wuc_Text2.Text.ToString());
            }
            if (wuc_Text3.Text.Length > 0)
            {
                ListText.Add(wuc_Text3.Text.ToString());
            }
            if (wuc_Text4.Text.Length > 0)
            {
                ListText.Add(wuc_Text4.Text.ToString());
            }
            if (wuc_Text5.Text.Length > 0)
            {
                ListText.Add(wuc_Text5.Text.ToString());
            }
            if (wuc_Text6.Text.Length > 0)
            {
                ListText.Add(wuc_Text6.Text.ToString());
            }
            if (wuc_Text7.Text.Length > 0)
            {
                ListText.Add(wuc_Text7.Text.ToString());
            }
        }

        protected void BtnModificar_Click(object sender, EventArgs e)
        {
            EP.NombrePlan = wuc_Text.Text.ToString();
            EP.IdCoordinador = Convert.ToInt32(DdlCoordinadores.SelectedValue);
            string msg = NU.ModificarPlan(EP);
            if (msg == "Exito: El Plan Fue Modificado.")
            {
                GeneraLista();
                if (ListText.Count > ListAtrib.Count)
                {
                    for (int i = 0; i < ListAtrib.Count; i++)
                    { 
                        ListAtrib[i].Atributo = ListText[i].ToString();
                        string Msg = NU.ModificarAtributo(ListAtrib[i]);
                    }
                    for (int i = 0; i < ListText.Count-ListAtrib.Count; i++)
                    {
                        E_Atributos a=new E_Atributos();
                        a.IdAtributo = i;
                        a.Atributo = ListText[ListAtrib.Count+i].ToString();
                        a.IdPlan = EP.IdPlan;
                        string Msg = NU.InsertarAtributo(a);
                    }
                }
                else
                {

                }
                
                Master.ModalMsg("Exito: El plan y los atributos fueron modificados exitosamente");
            }
            else
            {
                Master.ModalMsg("Error: Hubo un error al modificar el Plan de Estudio");
            }
        }
    }
}