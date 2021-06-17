using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NegociosGestionUsuarios;
using EntidadesGestionUsuarios;
using Presentacion.Controles;

namespace Presentacion.GestionUsuarios
{

    public partial class IbmMateriaSubdirector : System.Web.UI.Page
    {
        N_Usuarios NU = new N_Usuarios();
        E_Usuarios SEU = new E_Usuarios();
        E_PlanEstudio EP = new E_PlanEstudio();
        List<E_Atributos> LEA = new List<E_Atributos>();
        E_Materias EM = new E_Materias();
        List<string> ListAport = new List<string>();
        List<E_AtribMateria> ListEM = new List<E_AtribMateria>();
        List<DropDownList> ListDdl = new List<DropDownList>();
        List<wuc_Text_SR> ListTb = new List<wuc_Text_SR>();
        private string BackGroundHeader;
        private string BtnColor;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
                Response.Redirect("ValidaUsuario.aspx");

            SEU = (E_Usuarios)Session["Usuario"];
            NU.LlenaDropDown(DdlDocentes, "Docente");
            string MsgOpcion = Session["Mensaje"].ToString();
            if (!IsPostBack)
            {
                if (SEU.IdTipoUsuario == 2)
                {
                    EP = (E_PlanEstudio)Session["PlanSubdirector"];
                    if (EP == null)
                    {
                        Response.Redirect("InicioSubdirector.aspx");
                        Session["NoPlan"] = "No existe plan";
                    }
                    else
                        Session["IdPlan"] = EP.IdPlan;
                }
                if (EP != null)
                {
                    LEA = NU.BuscaAtributos(EP.IdPlan);
                    LlenaAtributos(LEA);
                    foreach (wuc_Text_SR w in ListTb)
                    {
                        w.Enabled = false;
                    }

                    if (MsgOpcion == "Agregar")
                    {
                        BtnModificar.Visible = false;
                        BtnGuardar.Visible = true;
                        LblHeader.Visible = false;

                    }
                    else
                    {
                        EM = (E_Materias)Session["Materia"];
                        if (EM != null)
                        {
                            LblHeader.Visible = true;
                            tbNombre.Text = EM.Materia;
                            tbClave.Text = EM.Clave;
                            DdlSemestre.SelectedValue = EM.Semestre.ToString();
                            DdlDocentes.SelectedValue = EM.IdDocente.ToString();
                            ListEM = NU.LstAtribMateria();
                            LlenaDdlList();
                            if (ListEM != null)
                            {
                                int i = 0;
                                foreach (E_AtribMateria AM in ListEM)
                                {
                                    if (AM.IdMateria == EM.IdMateria)
                                    {
                                        ListDdl[i].SelectedValue = AM.Aportacion;
                                        i++;
                                    }
                                }
                            }
                        }
                        else
                        {
                            Response.Redirect("ListaMaterias.aspx");
                        }
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
            Response.Redirect("ListaMaterias.aspx");
        }
        protected void BtnGuardarModal_Click(object sender, EventArgs e)
        {
            EM = (E_Materias)Session["Materia"];
            //EM.IdMateria = 
            EM.Materia = tbNombre.Text.ToString();
            EM.Clave = tbClave.Text;
            EM.IdDocente = Convert.ToInt32(DdlDocentes.SelectedValue);
            EM.Semestre = Convert.ToInt32(DdlSemestre.SelectedValue);
            if (NU.ModificarMateria(EM).Contains("Exito"))
            {

                ListAport = ListaAportaciones();
                LEA = NU.BuscaAtributos((int)Session["IdPlan"]);
                int i = 0;
                foreach (E_Atributos a in LEA)
                {
                    if (NU.ModificarAtributoMateria(EM.IdMateria, a.IdAtributo, ListAport[i].ToString()).Contains("Exito"))
                    {
                        i++;
                        Master.ModalMsg("Exito: La Materia fue modificada con exito");
                    }
                    else
                    {
                        Master.ModalMsg("Error: La materia fue modificada, pero la modificacion de atributo-materia no se pudo realizar");
                    }
                }
            }
            else
            {
                Master.ModalMsg("Error: La materia no pudo ser modificada");
            }

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
                EM.IdDocente = Convert.ToInt32(DdlDocentes.SelectedValue);
                EM.Semestre = Convert.ToInt32(DdlSemestre.SelectedValue);
                if (NU.InsertarMateria(EM).Contains("Exito"))
                {

                    int IdMateria = NU.UltimoRegistro("Materias", "IdMateria");
                    ListAport = ListaAportaciones();
                    LEA = NU.BuscaAtributos((int)Session["IdPlan"]);
                    int i = 0;
                    foreach (E_Atributos a in LEA)
                    {
                        if (NU.InsertarAtributoMateria(IdMateria, a.IdAtributo, ListAport[i].ToString()).Contains("Exito"))
                        {
                            i++;
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
            ModalPeticiones("Modificar: ¿Desea guardar los cambios?");
            
        }

        protected void LlenaAtributos(List<E_Atributos> ListAtrib)
        {
            LlenaTbList();
            for (int i = 0; i < ListAtrib.Count; i++)
            {
                ListTb[i].Text = ListAtrib[i].Atributo;
            }
        }
        protected List<string> ListaAportaciones()
        {
            List<string> ListAport = new List<string>();
            EP = (E_PlanEstudio)Session["PlanSubdirector"];
            LEA = NU.BuscaAtributos(EP.IdPlan);
            switch (LEA.Count)
            {
                case 1:
                    ListAport.Add(DdlAtrib1.SelectedValue);

                    break;
                case 2:
                    ListAport.Add(DdlAtrib1.SelectedValue);
                    ListAport.Add(DdlAtrib2.SelectedValue);
                    break;
                case 3:
                    ListAport.Add(DdlAtrib1.SelectedValue);
                    ListAport.Add(DdlAtrib2.SelectedValue);
                    ListAport.Add(DdlAtrib3.SelectedValue);

                    break;
                case 4:
                    ListAport.Add(DdlAtrib1.SelectedValue);
                    ListAport.Add(DdlAtrib2.SelectedValue);
                    ListAport.Add(DdlAtrib3.SelectedValue);
                    ListAport.Add(DdlAtrib4.SelectedValue);
                    break;
                case 5:
                    ListAport.Add(DdlAtrib1.SelectedValue);
                    ListAport.Add(DdlAtrib2.SelectedValue);
                    ListAport.Add(DdlAtrib3.SelectedValue);
                    ListAport.Add(DdlAtrib4.SelectedValue);
                    ListAport.Add(DdlAtrib5.SelectedValue);
                    break;
                case 6:
                    ListAport.Add(DdlAtrib1.SelectedValue);
                    ListAport.Add(DdlAtrib2.SelectedValue);
                    ListAport.Add(DdlAtrib3.SelectedValue);
                    ListAport.Add(DdlAtrib4.SelectedValue);
                    ListAport.Add(DdlAtrib5.SelectedValue);
                    ListAport.Add(DdlAtrib6.SelectedValue);
                    break;
                case 7:
                    ListAport.Add(DdlAtrib1.SelectedValue);
                    ListAport.Add(DdlAtrib2.SelectedValue);
                    ListAport.Add(DdlAtrib3.SelectedValue);
                    ListAport.Add(DdlAtrib4.SelectedValue);
                    ListAport.Add(DdlAtrib5.SelectedValue);
                    ListAport.Add(DdlAtrib6.SelectedValue);
                    ListAport.Add(DdlAtrib7.SelectedValue);
                    break;
            }
            return ListAport;
        }
        protected void LlenaDdlList()
        {
            ListDdl.Clear();
            ListDdl.Add(DdlAtrib1);
            ListDdl.Add(DdlAtrib2);
            ListDdl.Add(DdlAtrib3);
            ListDdl.Add(DdlAtrib4);
            ListDdl.Add(DdlAtrib5);
            ListDdl.Add(DdlAtrib6);
            ListDdl.Add(DdlAtrib7);
        }
        protected void LlenaTbList()
        {
            ListTb.Clear();
            ListTb.Add(wuc_Text1);
            ListTb.Add(wuc_Text2);
            ListTb.Add(wuc_Text3);
            ListTb.Add(wuc_Text4);
            ListTb.Add(wuc_Text5);
            ListTb.Add(wuc_Text6);
            ListTb.Add(wuc_Text7);
        }
        public void ModalPeticiones(string pMsg)
        {
            String[] TipoMsg = pMsg.Split(':');
            AtributosModalPeticiones(TipoMsg[0]);
            EModalHeader.Attributes.Clear();
            EModalHeader.Attributes.Add("class", BackGroundHeader);
            EModalTitulo.InnerHtml = string.Format("{0}", TipoMsg[0]);
            EModalBody.InnerHtml = string.Format("{0}", TipoMsg[1]);
            BtnRegresarModal.Attributes.Add("class", BtnColor);
            BtnGuardarModal.Attributes.Add("class", BtnColor);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openMasterModalPeticion()", true);
        }
        protected void AtributosModalPeticiones(string Tipo)
        {
            switch (Tipo)
            {
                case "Modificar":
                    BackGroundHeader = Clr.ClrExito; BtnColor = Clr.BtnExito;
                    break;
                case "Eliminar":
                    BackGroundHeader = Clr.ClrPeligro; BtnColor = Clr.BtnPeligro;
                    break;
                case "Informacion": BackGroundHeader = Clr.ClrInformacion; BtnColor = Clr.BtnInformacion; break;
                case "Precaucion": BackGroundHeader = Clr.ClrPrecaucion; BtnColor = Clr.BtnPrecaucion; break;
                default: BackGroundHeader = Clr.ClrGeneral; BtnColor = Clr.BtnGeneral; break;
            }
        }
    }
}