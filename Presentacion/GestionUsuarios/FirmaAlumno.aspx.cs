using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NegociosGestionUsuarios;
using EntidadesGestionUsuarios;
using System.Drawing;
using iTextSharp.text.pdf;
using System.IO;

namespace Presentacion.GestionUsuarios
{
    public partial class FirmaAlumno : System.Web.UI.Page
    {
        E_Usuarios EU = new E_Usuarios();
        N_Usuarios NU = new N_Usuarios();
        E_RSA ER = new E_RSA();
        E_CodAlumno EA = new E_CodAlumno();
        Byte[] ByteFirma;
        E_Firma EF = new E_Firma();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Codigo"] == null)
            {
                Response.Redirect("ValidaUsuario.aspx");
            }
            EA = (E_CodAlumno)Session["Codigo"];
            ER = NU.BuscaRSA(EA.IdRSA);
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

        protected void BtnFirmar_Click(object sender, EventArgs e)
        {
            ByteFirma =(Byte[])Session["Firma"];
            ER = NU.BuscaIdRSA(EA.IdRSA);
            E_PlanEstudio EPE = NU.BuscaPlanCoordinador(ER.IdCoordinador);
            E_RSADocumento ERD = NU.BuscaDocumentoRSA(ER.IdRSA);
            E_Materias EM = NU.BuscaMateria(ER.IdMateria);
            string savePath = "..\\RSA\\";
            var folder = Server.MapPath(savePath + "\\" + EPE.NombrePlan.Trim());
            using (Stream inputPdfStream = new FileStream(ERD.RSAUrl.Trim(), FileMode.Open, FileAccess.Read, FileShare.Read))
            using (Stream outputPdfStream = new FileStream(folder+"\\"+EM.Clave+"-"+EM.Materia+"-Firmado.pdf", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                var reader = new PdfReader(inputPdfStream);
                var stamper = new PdfStamper(reader, outputPdfStream);
                var pdfContentByte = stamper.GetOverContent(1);

                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(ByteFirma);
                image.SetAbsolutePosition(310, 160);
                //image.WidthPercentage = 0.05f;
                image.ScalePercent(40f);
                pdfContentByte.AddImage(image);
                stamper.Close();
            }
            ERD.RSAUrl = folder + "\\" + EM.Clave + "-" + EM.Materia + "-Firmado.pdf";
            ERD.NombreRSA = EM.Clave + "-" + EM.Materia + "-Firmado.pdf";
            string msg=NU.ModificarRSAPDF(ERD);
            ER.Status = 5;
            msg=NU.ModificarRSA(ER);
            msg = NU.BorraCodAlumno(EA.IdCodAlumno);
            Response.Redirect("ValidaUsuario.aspx");
        }
    }
}