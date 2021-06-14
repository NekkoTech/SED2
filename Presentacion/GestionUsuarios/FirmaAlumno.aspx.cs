﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NegociosGestionUsuarios;
using EntidadesGestionUsuarios;
using System.Drawing;

namespace Presentacion.GestionUsuarios
{
    public partial class FirmaAlumno : System.Web.UI.Page
    {
        E_Usuarios EU = new E_Usuarios();
        N_Usuarios NU = new N_Usuarios();
        Byte[] ByteFirma;
        E_Firma EF = new E_Firma();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSubir_Click(object sender, EventArgs e)
        {
            HttpPostedFile HpfFirma = FuFirma.PostedFile;
            if (FuFirma.HasFile)
            {

                string msg = HpfFirma.ContentType;
                if (msg == "image/jpg" || msg == "image/png" || msg == "image/jpeg")
                {
                    int TamFirma = FuFirma.PostedFile.ContentLength;
                    if (TamFirma <= 1250000)
                    {
                        ByteFirma = new Byte[TamFirma];
                        HpfFirma.InputStream.Read(ByteFirma, 0, TamFirma);
                        Session["Firma"] = ByteFirma;
                        Bitmap ImagenOriginalBinaria = new Bitmap(HpfFirma.InputStream);

                        string ImagenDataURL64 = "data:image/jpg;base64," + Convert.ToBase64String(ByteFirma);
                        ImgFirma.ImageUrl = ImagenDataURL64;
                    }
                    else
                    {

                        LblMensaje.Text = "Archivo Menor a 10 MB";
                    }
                }
                else
                {

                    LblMensaje.Text = "Ingrese un Arhivo con formato PNG, JPG o JPEG";
                }
            }
            else
            {

                LblMensaje.Text = "Seleccione una firma primero";
            }
        }
    }
}