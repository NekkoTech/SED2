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
        
        protected void Page_Load(object sender, EventArgs e)
        {
            NU.LlenaDropDown(DdlCoordinadores, "SELECT * FROM Usuarios where IdTipoUsuario=3");
        }

        protected void BtnRegresar_Click(object sender, EventArgs e)
        {

        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            
            EP.NombrePlan = wuc_Text.Text.ToString();
            EP.IdPlan = 0;
            EP.IdCoordinador = DdlCoordinadores.SelectedValue;
            NU.InsertarPlan(EP);
            EA.IdPlan=NU.UltimoRegistro("PlanEstudio","IdPlan");
            if (EA.IdPlan != -1)
            {
                int i = 0;
                GeneraLista();
                foreach (string c in ListText)
                {
                    EA.IdAtributo = i;
                    i++;
                    EA.Atributo = c.ToString();
                    string Msg=NU.InsertarAtributo(EA);

                }
                Master.ModalMsg("Exito: El plan y los atributos fueron registrados exitosamente");
            }else
            {
                Master.ModalMsg("Error: Hubo un error al agregar el Plan de Estudio");
            }

        }
        protected void GeneraLista()
        {
            ListText.Add(wuc_Text1.Text.ToString());
            ListText.Add(wuc_Text2.Text.ToString());
            ListText.Add(wuc_Text3.Text.ToString());
            ListText.Add(wuc_Text4.Text.ToString());
            ListText.Add(wuc_Text5.Text.ToString());
            ListText.Add(wuc_Text6.Text.ToString());
            ListText.Add(wuc_Text7.Text.ToString());
        }
    }
}