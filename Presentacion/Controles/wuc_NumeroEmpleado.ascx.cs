using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion.Controles
{
    public partial class wuc_NumeroEmpleado : System.Web.UI.UserControl
    {
        public string Text
        {
            get { return tbNumeroEmpleado.Text.Trim(); }
            set { tbNumeroEmpleado.Text = value; }
        }
        public bool Enabled
        {
            set { tbNumeroEmpleado.Enabled = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}