﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NegociosGestionUsuarios;
using EntidadesGestionUsuarios;

namespace Presentacion.GestionUsuarios
{
    public partial class CuentaDocente : System.Web.UI.Page
    {
        E_Usuarios EU = new E_Usuarios();
        N_Usuarios NU = new N_Usuarios();
        protected void Page_Load(object sender, EventArgs e)
        {
            EU = (E_Usuarios)Session["Usuario"];
            if (EU == null)
                Response.Redirect("ValidaUsuario.aspx");
            
            BtnSubirArchivo.Visible = false;
            FuFirma.Visible = false;
            tbNombre.Text = EU.NombreUsuario;
            tbAPat.Text = EU.APaternoUsuario;
            tbAMat.Text = EU.AMaternoUsuario;
            tbEmail.Text = EU.EmailUsuario;
            tbNumeroEmpleado.Text = EU.NumeroEmpleado;
            tbNombre.Enabled = false; 
            tbAPat.Enabled = false;
            tbAMat.Enabled = false;
            tbEmail.Enabled = false;
            tbNumeroEmpleado.Enabled = false;


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

        protected void BtnSubirArchivo_Click1(object sender, EventArgs e)
        {
            HttpPostedFile HpfFirma = FuFirma.PostedFile;
            if (FuFirma.HasFile)
            {
                int TamFirma = FuFirma.PostedFile.ContentLength;
                Byte[] ByteFirma = new Byte[TamFirma];
                HpfFirma.InputStream.Read(ByteFirma, 0, TamFirma);
                NU.InsertarFirma(ByteFirma, EU.IdUsuario);
                BtnSubir.Visible = true;
                BtnSubirArchivo.Visible = false;
                FuFirma.Visible = false;    
                //ImgFirma.
            }
        }
    }
}