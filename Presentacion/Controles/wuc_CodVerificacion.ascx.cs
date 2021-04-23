using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion.Controles
{
    public partial class wuc_CodVerificacion : System.Web.UI.UserControl
    {
        public string Text
        {
            get { return tbCodVerificacion.Text.ToUpper().Trim(); }
            set { tbCodVerificacion.Text = value; }
        }
        public bool Enabled
        {
            set { tbCodVerificacion.Enabled = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}