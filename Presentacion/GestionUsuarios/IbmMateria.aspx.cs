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
        E_Materias EM = new E_Materias();
        List<string> ListAport = new List<string>();
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
                if (SEU.IdTipoUsuario == 3)
                {
                    EP = NU.BuscaPlanCoordinador(SEU.IdUsuario);
                }
                if (SEU.IdTipoUsuario == 2)
                {
                    EP = (E_PlanEstudio)Session["PlanSubdirector"];
                }
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
            EM = NU.BuscaMateriaClave(tbClave.Text.ToString());
            if (EM == null)
            {
                EM = new E_Materias();
                EM.IdMateria = 0;
                EM.Materia = tbNombre.Text.ToString();
                EM.Clave = tbClave.Text;
                EM.IdDocente= Convert.ToInt32(DdlDocentes.SelectedValue);
                EM.Semestre = Convert.ToInt32(DdlSemestre.SelectedValue);
                if (NU.InsertarMateria(EM).Contains("Exito"))
                {
                    
                    int IdMateria=NU.UltimoRegistro("Materias", "IdMateria");
                    ListAport = ListaAportaciones();
                    int i = 0;
                    foreach(E_Atributos a in LEA)
                    {
                        if (NU.InsertarAtributoMateria(IdMateria, a.IdAtributo,ListAport[0].ToString()).Contains("Exito"))
                        {
                            Master.ModalMsg("Exito: La materia fue insertada con Exito");
                        }
                        else
                        {
                            Master.ModalMsg("Error: La materia fue insertada, pero la relacion atributo-materia no se pudo realizar");
                        }
                    }
                }
                else
                {
                    Master.ModalMsg("Error: La materia no pudo ser insertada");
                }
            }
            else
            {
                Master.ModalMsg("Error: La clave de Materia Ya esta registrada");
            }

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
        protected List<string> ListaAportaciones()
        {
            List<string> ListAport= new List<string>();
            switch (LEA.Count)
            {
                case 1:
                    ListAport.Add(wuc_Text1.Text);

                    break;
                case 2:
                    ListAport.Add(wuc_Text1.Text);
                    ListAport.Add(wuc_Text2.Text);
                    break;
                case 3:
                    ListAport.Add(wuc_Text1.Text);
                    ListAport.Add(wuc_Text2.Text);
                    ListAport.Add(wuc_Text3.Text);

                    break;
                case 4:
                    ListAport.Add(wuc_Text1.Text);
                    ListAport.Add(wuc_Text2.Text);
                    ListAport.Add(wuc_Text3.Text);
                    ListAport.Add(wuc_Text4.Text);
                    break;
                case 5:
                    ListAport.Add(wuc_Text1.Text);
                    ListAport.Add(wuc_Text2.Text);
                    ListAport.Add(wuc_Text3.Text);
                    ListAport.Add(wuc_Text4.Text);
                    ListAport.Add(wuc_Text5.Text);

                    break;
                case 6:
                    ListAport.Add(wuc_Text1.Text);
                    ListAport.Add(wuc_Text2.Text);
                    ListAport.Add(wuc_Text3.Text);
                    ListAport.Add(wuc_Text4.Text);
                    ListAport.Add(wuc_Text5.Text);
                    ListAport.Add(wuc_Text6.Text);
                    break;
                case 7:
                    ListAport.Add(wuc_Text1.Text);
                    ListAport.Add(wuc_Text2.Text);
                    ListAport.Add(wuc_Text3.Text);
                    ListAport.Add(wuc_Text4.Text);
                    ListAport.Add(wuc_Text5.Text);
                    ListAport.Add(wuc_Text6.Text);
                    ListAport.Add(wuc_Text7.Text);
                    break;
            }
            return ListAport;
        }
    }
}