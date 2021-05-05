using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion.GestionUsuarios
{
    public partial class CuentaDocente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BtnSubirArchivo.Visible = false;
            FuFirma.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void BtnSubirArchivo_Click(object sender, EventArgs e)
        {

        }

        protected void BtnSubir_Click(object sender, EventArgs e)
        {
            BtnSubirArchivo.Visible = true;
            FuFirma.Visible = true;
            BtnSubir.Visible = false;
        }
    }
}