using EntidadesGestionUsuarios;
using NegociosGestionUsuarios;
using Presentacion.Controles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion.GestionUsuarios
{
    public partial class FormularioRSA2 : System.Web.UI.Page
    {
        N_Usuarios NU = new N_Usuarios();
        E_Materias EM = new E_Materias();
        private string BackGroundHeader;
        private string BtnColor;
        E_Usuarios EU = new E_Usuarios();
        E_Usuarios SEU = new E_Usuarios();
        E_PlanEstudio EP = new E_PlanEstudio();
        List<E_Atributos> LEA = new List<E_Atributos>();
        E_RSA ER = new E_RSA();
        List<wuc_Text_SR> ListTb = new List<wuc_Text_SR>();
        List<E_Porcentajes> ListEPO = new List<E_Porcentajes>();
        E_Porcentajes EPO = new E_Porcentajes();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("ValidaUsuario.aspx");
            }
            else
            {
                E_Usuarios EU = (E_Usuarios)Session["Usuario"];
                switch (EU.IdTipoUsuario)
                {
                    case 1:
                        Response.Redirect("InicioMain.aspx");
                        break;
                    case 3:
                        Response.Redirect("InicioCoordinador.aspx");
                        break;
                    case 2:
                        Response.Redirect("InicioSubdirector.aspx");
                        break;
                }
            }
            ER = (E_RSA)Session["RSA"];
            EU = (E_Usuarios)Session["Usuario"];
            EM = (E_Materias)Session["Materia"];
            EP = NU.BuscaPlanMateria(EM.IdMateria);
            if (ER != null)
            {
                LEA = NU.BuscaAtributos(EP.IdPlan);
                LlenaAtributos(LEA);
                if (ER.Status == 1 || ER.Status == 3)
                {
                    ListEPO = NU.BuscaPorcentajes(ER.IdRSA);
                    if (ListEPO.Count > 0)
                    {
                        if (!IsPostBack)
                        {
                            LlenaCampos();
                            if (ER.Status == 3)
                            {
                                E_RSADocumento ERD = NU.BuscaDocumentoRSA(ER.IdRSA);
                                tbObservaciones.Text = ERD.Observaciones;
                                tbObservaciones.Enabled = false;
                                btnModal.Visible = true;
                            }
                        }
                            
                    }

                }

            }
        }
        protected void LlenaAtributos(List<E_Atributos> ListAtrib)
        {
            LlenaTbList();
            for (int i = 0; i < ListAtrib.Count; i++)
            {
                ListTb[i].Text = ListAtrib[i].Atributo;
            }
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

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            LlenaPorcentajes();
            Session["ListaEPO"] = ListEPO;
            Response.Redirect("FormularioRSA3.aspx");
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            LlenaPorcentajes();

            if (ER.Status == 1 || ER.Status == 3)
            {
                if (NU.ModificarRSA(ER).Contains("Exito"))
                {
                    List<E_Porcentajes> LEP = NU.BuscaPorcentajes(ER.IdRSA);
                    if (LEP.Count>0)
                    {
                        int i = 0;
                        foreach (E_Porcentajes P in ListEPO)
                        {
                            P.IdPorcentaje = LEP[i].IdPorcentaje;
                            P.IdRSA = LEP[i].IdRSA;
                            P.IdAtributo = LEP[i].IdAtributo;
                            i++;
                            if (LEP.Count != 0)
                            {
                                string msg = NU.ModificarPorcentajes(P);
                            }
                            else
                            {
                                string msg = NU.InsertarPorcentajes(P);
                            }

                        }
                    }
                    else
                    {
                        foreach (E_Porcentajes P in ListEPO)
                        {
                            string msg=NU.InsertarPorcentajes(P);
                        }
                    }

                    
                }
            }
            if (ER.Status == 0)
            {
                ER.Status = 1;
                if (NU.InsertarRSA(ER).Contains("Exito"))
                {
                    foreach (E_Porcentajes P in ListEPO)
                    {
                        NU.InsertarPorcentajes(P);
                    }
                }
            }


        }

        private void LlenaPorcentajes()
        {
            ListEPO.Clear();
            EPO = new E_Porcentajes();
            if (LEA.Count >= 1)
                EPO.IdAtributo = LEA[0].IdAtributo;
            //else
            //    EPO.IdAtributo = 0;
            EPO.Tecnica = TbTecnica1.Text;
            EPO.Porcentaje = Tb11.Text + "-" + Tb12.Text + "-" + Tb13.Text + "-" + Tb14.Text;
            EPO.IdRSA = ER.IdRSA;
            ListEPO.Add(EPO);

            EPO = new E_Porcentajes();
            if (LEA.Count >= 2)
                EPO.IdAtributo = LEA[1].IdAtributo;
            //else
            //    EPO.IdAtributo = 0;
            EPO.Tecnica = TbTecnica2.Text;
            EPO.Porcentaje = Tb21.Text + "-" + Tb22.Text + "-" + Tb23.Text + "-" + Tb24.Text;
            EPO.IdRSA = ER.IdRSA;
            ListEPO.Add(EPO);

            EPO = new E_Porcentajes();
            if (LEA.Count >= 3)
                EPO.IdAtributo = LEA[2].IdAtributo;
            //else
            //    EPO.IdAtributo ;
            EPO.Tecnica = TbTecnica3.Text;
            EPO.Porcentaje = Tb31.Text + "-" + Tb32.Text + "-" + Tb33.Text + "-" + Tb34.Text;
            EPO.IdRSA = ER.IdRSA;
            ListEPO.Add(EPO);

            EPO = new E_Porcentajes();
            if(LEA.Count>=4)
                EPO.IdAtributo = LEA[3].IdAtributo;
            //else
            //    EPO.IdAtributo = 0;
            EPO.Tecnica = TbTecnica4.Text;
            EPO.Porcentaje = Tb41.Text + "-" + Tb42.Text + "-" + Tb43.Text + "-" + Tb44.Text;
            EPO.IdRSA = ER.IdRSA;
            ListEPO.Add(EPO);

            EPO = new E_Porcentajes();
            if (LEA.Count >= 5)
                EPO.IdAtributo = LEA[4].IdAtributo;
            //else
            //    EPO.IdAtributo = 0;
            EPO.Tecnica = TbTecnica5.Text;
            EPO.Porcentaje = Tb51.Text + "-" + Tb52.Text + "-" + Tb53.Text + "-" + Tb54.Text;
            EPO.IdRSA = ER.IdRSA;
            ListEPO.Add(EPO);

            EPO = new E_Porcentajes();
            if (LEA.Count >= 6)
                EPO.IdAtributo = LEA[5].IdAtributo;
            //else
            //    EPO.IdAtributo = 0;
            EPO.Tecnica = TbTecnica6.Text;
            EPO.Porcentaje = Tb61.Text + "-" + Tb62.Text + "-" + Tb63.Text + "-" + Tb64.Text;
            EPO.IdRSA = ER.IdRSA;
            ListEPO.Add(EPO);

            EPO = new E_Porcentajes();
            if (LEA.Count >= 7)
                EPO.IdAtributo = LEA[6].IdAtributo;
            //else
            //    EPO.IdAtributo = 0;
            EPO.Tecnica = TbTecnica7.Text;
            EPO.Porcentaje = Tb71.Text + "-" + Tb72.Text + "-" + Tb73.Text + "-" + Tb74.Text;
            EPO.IdRSA = ER.IdRSA;
            ListEPO.Add(EPO);

        }

        private void LlenaCampos()
        {
            for (int i = 0; i < ListEPO.Count; i++)
            {
                string[] port;
                switch (i)
                {
                    case 0:
                        port = ListEPO[0].Porcentaje.Split('-');
                        TbTecnica1.Text = ListEPO[0].Tecnica;
                        Tb11.Text = port[0];
                        Tb12.Text = port[1];
                        Tb13.Text = port[2];
                        Tb14.Text = port[3];
                        break;
                    case 1:
                        port = ListEPO[1].Porcentaje.Split('-');
                        TbTecnica2.Text = ListEPO[1].Tecnica;
                        Tb21.Text = port[0];
                        Tb22.Text = port[1];
                        Tb23.Text = port[2];
                        Tb24.Text = port[3];
                        break;
                    case 2:
                        port = ListEPO[2].Porcentaje.Split('-');
                        TbTecnica3.Text = ListEPO[2].Tecnica;
                        Tb31.Text = port[0];
                        Tb32.Text = port[1];
                        Tb33.Text = port[2];
                        Tb34.Text = port[3];
                        break;
                    case 3:
                        port = ListEPO[3].Porcentaje.Split('-');
                        TbTecnica4.Text = ListEPO[3].Tecnica;
                        Tb41.Text = port[0];
                        Tb42.Text = port[1];
                        Tb43.Text = port[2];
                        Tb44.Text = port[3];
                        break;
                    case 4:
                        port = ListEPO[4].Porcentaje.Split('-');
                        TbTecnica5.Text = ListEPO[4].Tecnica;
                        Tb51.Text = port[0];
                        Tb52.Text = port[1];
                        Tb53.Text = port[2];
                        Tb54.Text = port[3];
                        break;
                    case 5:
                        port = ListEPO[5].Porcentaje.Split('-');
                        TbTecnica6.Text = ListEPO[5].Tecnica;
                        Tb61.Text = port[0];
                        Tb62.Text = port[1];
                        Tb63.Text = port[2];
                        Tb64.Text = port[3];
                        break;
                    case 6:
                        port = ListEPO[6].Porcentaje.Split('-');
                        TbTecnica7.Text = ListEPO[6].Tecnica;
                        Tb71.Text = port[0];
                        Tb72.Text = port[1];
                        Tb73.Text = port[2];
                        Tb74.Text = port[3];
                        break;
                }
            }
        }

        protected void btnObservaciones_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openMasterModalObservaciones()", true);
        }
    }
}