using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NegociosGestionUsuarios;
using EntidadesGestionUsuarios;
using System.Net;
using System.Net.Mail;
using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Image = iTextSharp.text.Image;
using System.IO;

namespace Presentacion.GestionUsuarios
{
    public partial class ListaRSADocente : System.Web.UI.Page
    {
        N_Usuarios NU = new N_Usuarios();
        E_Materias EM = new E_Materias();
        private string BackGroundHeader;
        private string BtnColor;
        E_Usuarios EU = new E_Usuarios();
        E_Usuarios SEU = new E_Usuarios();
        E_PlanEstudio EP = new E_PlanEstudio();
        List<E_Porcentajes> ListEPO = new List<E_Porcentajes>();
        E_RSA ER = new E_RSA();
        protected void Page_Load(object sender, EventArgs e)
        {

            EU = (E_Usuarios)Session["Usuario"];
            GvMaterias.DataSource = NU.LstMateriasInnerJoinRSADocente(EU.IdUsuario);

            if (!IsPostBack)
            {
                GvMaterias.DataBind();
            }
            //if (GvMaterias.Rows.Count == 0)
            //Master.ModalMsg("Error:No hay Materias Registradas");

        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {

        }
        protected void Agregar_Click(object sender, EventArgs e)
        {

        }
        protected void Eliminar_Click(object sender, EventArgs e)
        {


        }

        protected void GvMaterias_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void GvMaterias_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           
            if (e.CommandName == "Llenar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int IdMateria = Convert.ToInt32(GvMaterias.DataKeys[index].Value.ToString());
                EM = new N_Usuarios().BuscaMateria(IdMateria);
                EP = NU.BuscaPlanMateria(EM.IdMateria);
                E_Fecha EF = NU.BuscaFechaPlanEstudio(EP.IdPlan);
                int f = (int)(DateTime.Now - EF.FechaFinal).TotalDays;
                if (f < 0) 
                {
                    E_RSA ER = NU.BuscaRSA(EM.IdMateria);
                    if (ER != null)
                    {
                        switch (ER.Status)
                        {
                            case 1:
                                Session["Materia"] = EM;
                                Session["RSA"] = ER;
                                Session["Mensaje"] = "Llenar";
                                Response.Redirect("FormularioRSA.aspx");
                                break;
                            case 2:
                                Master.ModalMsg("Error: El RSA ya fue enviado, espere a la respuesta de su Coordinador");
                                break;
                            case 3:
                                if (ER != null)
                                {
                                    Session["Materia"] = EM;
                                    Session["RSA"] = ER;
                                    Session["Mensaje"] = "Llenar";
                                    Response.Redirect("FormularioRSA.aspx");
                                }
                                else
                                {
                                    Master.ModalMsg("Error: La materia no tiene RSA registrado");
                                }

                                break;
                            case 4:
                                Master.ModalMsg("Informacion: El RSA ya fue aceptado, espere a que el Jefe firme el Documento");
                                break;
                            case 5:
                                Master.ModalMsg("Error: El proceso del RSA ya fue terminado, puede descargarlo para visualizarlo");
                                break;
                        }
                    }
                    else
                    {
                        Session["Materia"] = EM;
                        Session["RSA"] = ER;
                        Session["Mensaje"] = "Llenar";
                        Response.Redirect("FormularioRSA.aspx");
                    }
                }
                else
                {
                    Master.ModalMsg("Error: La fecha para subir los archivos ya paso");
                }

            }
            if (e.CommandName == "Firmar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int IdMateria = Convert.ToInt32(GvMaterias.DataKeys[index].Value.ToString());
                EM = new N_Usuarios().BuscaMateria(IdMateria);
                EP = NU.BuscaPlanMateria(EM.IdMateria);
                E_Fecha EF = NU.BuscaFechaPlanEstudio(EP.IdPlan);
                int f = (int)(DateTime.Now - EF.FechaFinal).TotalDays;
                if (f < 0)
                {
                    E_RSA ER = NU.BuscaRSA(EM.IdMateria);
                    if (ER != null)
                    {
                        if (ER.Status == 4)
                        {
                            Session["MatFirmar"] = EM;
                            Session["RSAFirmar"] = ER;
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openMasterModalContra()", true);
                        }
                        else
                        {
                            if (ER.Status != 5)
                                Master.ModalMsg("Error: El RSA debe ser aceptado por el coordinador para poder Firmarlo");
                            else
                                Master.ModalMsg("Informacion: Ya se realizo la firma del documento");
                        }
                    }
                }
                else
                {
                    Master.ModalMsg("Error: La fecha para subir los archivos ya paso");
                }

            }
            if (e.CommandName == "Descargar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int IdMateria = Convert.ToInt32(GvMaterias.DataKeys[index].Value.ToString());
                EM = new N_Usuarios().BuscaMateria(IdMateria);
                ER = NU.BuscaRSA(EM.IdMateria);
                
                if (ER != null)
                {
                    EP = NU.BuscaPlanCoordinador(ER.IdCoordinador);
                    if (ER.Status == 5)
                    {
                        E_RSADocumento ED = NU.BuscaDocumentoRSA(ER.IdRSA);
                        string FilePath = Server.MapPath("..\\RSA\\"+EP.NombrePlan+"\\"+ED.NombreRSA);
                        WebClient User = new WebClient();
                        Byte[] FileBuffer = User.DownloadData(FilePath);
                        if (FileBuffer != null)
                        {
                            Response.ContentType = "application/pdf";
                            Response.AppendHeader("Content-Disposition", "attachment; filename=RSA.pdf");
                            Response.TransmitFile(FilePath);
                            Response.End();
                        }
                    }
                    else
                    {
                        Master.ModalMsg("Error: Solo se puede realizar la descarga cuando el RSA se encuentra firmado");
                    }
                }
                else
                {
                    Master.ModalMsg("Error: Aun no se encuentra con registro Activo de RSA");
                }
            }

        }

        protected void ComprobarContra_Click(object sender, EventArgs e)
        {
            if (tbPassWord.Text == tbRepPassWord.Text)
            {
                if (tbPassWord.Text == EU.PassWordUsuario)
                {
                    E_Materias mat = (E_Materias)Session["MatFirmar"];
                    E_RSA RSA = (E_RSA)Session["RSAFirmar"];
                    E_Firma EF = NU.BuscaFirma(EU.IdUsuario);
                    if (RSA.Status == 4)
                    {
                        if (EF != null)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openMasterModalCorreo()", true);
                        }
                        else
                        {
                            Master.ModalMsg("Error: Usted no a subido una firma al sistema, favor de subir una en su perfil");
                        }
                    }
                    if (RSA.Status == 2)
                    {
                        Master.ModalMsg("Error: Su coordinador aun no aprueba su RSA, no tiene permitido firmarlo");
                    }

                }
                else
                {
                    Master.ModalMsg("Error: Contraseña Incorrecta");
                }

            }
            else
            {
                lblMensajeModal.Text = "Las contaseñas no son iguales";
                lblMensajeModal.CssClass = "text-danger";
            }


        }
        protected void CorreoAlumno_Click(object sender, EventArgs e)
        {
            string[] correo = tbCorreo.Text.Split('@');
            if (correo[1] == "uabc.edu.mx")
            {
                E_CodAlumno ECD = new E_CodAlumno();
                string Codigo = GenerarCodigo();
                try
                {

                    MailMessage Email = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                    Email.SubjectEncoding = Encoding.UTF8;
                    Email.BodyEncoding = Encoding.UTF8;
                    Email.From = new MailAddress("SedFiad@gmail.com", "Administrador del sistema");
                    Email.Subject = "Codigo de Acceso A Alumno";
                    Email.Body = "Hola nos solicitaste recuperar tu contraseña. EL codigo de verificacion es : " + Codigo;


                    Email.To.Add(tbCorreo.Text);
                    SmtpServer.Port = 587; //SMTP de GMAIL
                    SmtpServer.Credentials = new NetworkCredential("SedFiad@gmail.com", "SEDFIAD@");      //Hay que crear las credenciales del correo emisor
                    SmtpServer.EnableSsl = true;
                    SmtpServer.Send(Email);
                    Session["Correo"] = Email;
                    //lblMensaje.Text = "Mensaje Enviado";
                }
                catch (SmtpException ex)
                {
                    //throw new Exception(lblMensaje.Text + ex);
                }
                E_RSA rsa = (E_RSA)Session["RSAFirmar"];
                //ECD = NU.BuscaCodAlumnoRSA(rsa.IdRSA);
                ECD.Codigo = Codigo.ToString();
                ECD.IdRSA = rsa.IdRSA;
                E_RSADocumento ERS = NU.BuscaDocumentoRSA(rsa.IdRSA);
                if (NU.InsertarCodAlumno(ECD).Contains("Exito"))
                {
                    GeneraRSA();
                    Master.ModalMsg("Exito: Se envio el codigo de acceso a la firma de RSA del jefe de grupo");
                }
            }
            else
            {
                lblCorreo.Text = "El correo no es institucional";
                lblMensajeModal.CssClass = "text-danger";
            }

            //Response.Redirect(".aspx");

        }

        public string GenerarCodigo()
        {
            string Codigo = string.Empty;
            int i;

            Random rnd = new Random();
            for (i = 0; i < 5; i++)
                Codigo += Convert.ToChar(rnd.Next(65, 90)).ToString();

            return Codigo;
        }




        protected void AtributosModalPeticiones(string Tipo, EventHandler handler)
        {
            switch (Tipo)
            {
                case "Agregar":
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
        /*protected void btnBuscar_Click(object sender, EventArgs e)
        {
            GvPlanes.DataSource = NU.LstBuscaPlan(TbSearch.Text.ToString());
            GvPlanes.DataBind();
        }*/
        protected void GeneraRSA()
        {
            ER = (E_RSA)Session["RSAFirmar"];
            EM = (E_Materias)Session["MatFirmar"];
            EP = NU.BuscaPlanCoordinador(ER.IdCoordinador);
            List<E_Porcentajes> LEPO = NU.BuscaPorcentajes(ER.IdRSA);
            string savePath = "..\\RSA\\";
            var folder = Server.MapPath(savePath + "\\" + EP.NombrePlan);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);

            }
            FileStream fs = new FileStream(folder + "\\" + EM.Clave.Trim() + "-" + EM.Materia.Trim() + ".pdf", FileMode.Create);
            E_RSADocumento ED = NU.BuscaDocumentoRSA(ER.IdRSA);
            if (ED == null)
            {
                if (NU.InsertarRSAPDF(EM.Clave.Trim() + "-" + EM.Materia.Trim() + ".pdf", folder + "\\" + EM.Clave.Trim() + " - " + EM.Materia.Trim() + ".pdf", EM.IdMateria, ER.IdRSA).Contains("Exito"))
                {
                    Console.WriteLine("PDF RSA Ingresado");
                }
            }
            else
            {
                ED = new E_RSADocumento();
                ED.NombreRSA = EM.Clave.Trim() + "-" + EM.Materia.Trim() + ".pdf";
                ED.IdRSA = ER.IdRSA;
                ED.RSAUrl = folder + "\\" + EM.Clave.Trim() + "-" + EM.Materia.Trim() + ".pdf";
                ED.Observaciones = " ";
                ED.Calificacion = "0";
                if (NU.ModificarRSAPDF(ED).Contains("Exito"))
                {
                    Console.WriteLine("PDF RSA Ingresado");
                }
            }

            Document doc = new Document(PageSize.LETTER, 5, 5, 7, 7);
            PdfWriter pw = PdfWriter.GetInstance(doc, fs);

            doc.Open();

            //Titulo y autor
            doc.AddAuthor("Prueba");
            doc.AddTitle("PDF prueba");

            //Definir la fuente
            iTextSharp.text.Font standarFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            iTextSharp.text.Font texto = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            iTextSharp.text.Font negritas = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            iTextSharp.text.Font sub = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.UNDERLINE, BaseColor.BLACK);
            iTextSharp.text.Font rojo = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.NORMAL, BaseColor.RED);

            //Encabezado
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Paragraph("                                                                                                                                                        RSA-01", standarFont));
            doc.Add(new Paragraph("                                                                                               REPORTE SEMESTRAL DE ASIGNATURA", standarFont));
            doc.Add(new Paragraph("                    REPORTE SEMESTRAL           FACULTAD DE INGENIERIA,ARQUITECTURA Y DISEÑO", standarFont));
            doc.Add(new Paragraph("                    PERIODO 2021-1                                                                                               UABC", standarFont));
            doc.Add(new Paragraph("                    Por favor llene una hoja por grupo", rojo));
            doc.Add(Chunk.NEWLINE);

            //Encabezado de columnas y declaracion
            PdfPTable tbEjemplo1 = new PdfPTable(2);
            PdfPTable tbEjemplo2 = new PdfPTable(2);
            PdfPTable tbEjemplo3 = new PdfPTable(10);
            PdfPTable tbEjemplo4 = new PdfPTable(2);
            PdfPTable tbEjemplo5 = new PdfPTable(5);
            PdfPTable tbEjemplo6 = new PdfPTable(5);
            PdfPTable tbEjemplo7 = new PdfPTable(2);
            PdfPTable tbEjemplo8 = new PdfPTable(6);
            PdfPTable tbEjemplo9 = new PdfPTable(6);
            PdfPTable tbEjemplo10 = new PdfPTable(6);
            PdfPTable tbEjemplo11 = new PdfPTable(6);
            PdfPTable tbEjemplo12 = new PdfPTable(3);
            PdfPTable tbEjemplo13 = new PdfPTable(6);
            PdfPTable tbEjemplo14 = new PdfPTable(6);
            PdfPTable tbEjemplo15 = new PdfPTable(6);
            PdfPTable tbEjemplo16 = new PdfPTable(6);
            PdfPTable tbEjemplo17 = new PdfPTable(6);
            PdfPTable tbEjemplo18 = new PdfPTable(6);
            PdfPTable tbEjemplo19 = new PdfPTable(6);
            PdfPTable tbEjemplo20 = new PdfPTable(3);
            PdfPTable tbEjemplo21 = new PdfPTable(2);
            PdfPTable tbEjemplo22 = new PdfPTable(1);
            PdfPTable tbEjemplo23 = new PdfPTable(1);
            PdfPTable tbEjemplo24 = new PdfPTable(2);
            PdfPTable tbEjemplo25 = new PdfPTable(2);

            tbEjemplo1.WidthPercentage = 85;
            tbEjemplo2.WidthPercentage = 85;
            tbEjemplo3.WidthPercentage = 85;
            tbEjemplo4.WidthPercentage = 85;
            tbEjemplo5.WidthPercentage = 85;
            tbEjemplo6.WidthPercentage = 85;
            tbEjemplo7.WidthPercentage = 85;
            tbEjemplo8.WidthPercentage = 85;
            tbEjemplo9.WidthPercentage = 85;
            tbEjemplo10.WidthPercentage = 85;
            tbEjemplo11.WidthPercentage = 85;
            tbEjemplo12.WidthPercentage = 85;
            tbEjemplo13.WidthPercentage = 85;
            tbEjemplo14.WidthPercentage = 85;
            tbEjemplo15.WidthPercentage = 85;
            tbEjemplo16.WidthPercentage = 85;
            tbEjemplo17.WidthPercentage = 85;
            tbEjemplo18.WidthPercentage = 85;
            tbEjemplo19.WidthPercentage = 85;
            tbEjemplo20.WidthPercentage = 85;
            tbEjemplo21.WidthPercentage = 85;
            tbEjemplo22.WidthPercentage = 85;
            tbEjemplo23.WidthPercentage = 85;
            tbEjemplo24.WidthPercentage = 85;
            tbEjemplo25.WidthPercentage = 85;


            //Contenido de columnas
            //tabla 1
            PdfPCell clNombre = new PdfPCell(new Phrase("Carrera: ", texto));
            clNombre.BorderWidth = 1;
            clNombre.BorderWidthBottom = 0.75f;

            PdfPCell clEmail = new PdfPCell(new Phrase(EP.NombrePlan.ToLowerInvariant(), texto));
            clNombre.BorderWidth = 1;
            clNombre.BorderWidthBottom = 0.75f;


            float[] widths = new float[] { 0.3f, 3f };
            tbEjemplo1.SetWidths(widths);
            tbEjemplo1.AddCell(clNombre);
            tbEjemplo1.AddCell(clEmail);
            //tabla 2
            PdfPCell clInfo = new PdfPCell(new Phrase("No. de Empleado y Nombre del profesor: ", texto));

            PdfPCell clDocente = new PdfPCell(new Phrase(EU.NumeroEmpleado + " " + EU.NombreUsuario + " " + EU.APaternoUsuario + " " + EU.AMaternoUsuario + "                                      Carrera   Asignatura ", texto));


            float[] widths2 = new float[] { 1f, 2.7f };
            tbEjemplo2.SetWidths(widths2);
            tbEjemplo2.AddCell(clInfo);
            tbEjemplo2.AddCell(clDocente);

            //tabla 3
            PdfPCell clClave = new PdfPCell(new Phrase("Clave Asignatura: " + EM.Clave + "                                                         Semestre:", texto));

            List<PdfPCell> LP = new List<PdfPCell>();
            PdfPCell clSemestre1 = new PdfPCell(new Phrase("1", texto));
            PdfPCell clSemestre2 = new PdfPCell(new Phrase("2", texto));
            PdfPCell clSemestre3 = new PdfPCell(new Phrase("3", texto));
            PdfPCell clSemestre4 = new PdfPCell(new Phrase("4", texto));
            PdfPCell clSemestre5 = new PdfPCell(new Phrase("5", texto));
            PdfPCell clSemestre6 = new PdfPCell(new Phrase("6", texto));
            PdfPCell clSemestre7 = new PdfPCell(new Phrase("7", texto));
            PdfPCell clSemestre8 = new PdfPCell(new Phrase("8", texto));
            PdfPCell clSemestre9 = new PdfPCell(new Phrase("9", texto));
            LP.Add(clSemestre1);
            LP.Add(clSemestre2);
            LP.Add(clSemestre3);
            LP.Add(clSemestre4);
            LP.Add(clSemestre5);
            LP.Add(clSemestre6);
            LP.Add(clSemestre7);
            LP.Add(clSemestre8);
            LP.Add(clSemestre9);
            foreach (PdfPCell pc in LP)
            {
                if (pc.Phrase.Content == EM.Semestre.ToString())
                {
                    pc.Phrase = new Phrase(EM.Semestre.ToString(), negritas);
                    //pc.Phrase.Font = negritas;
                }
            }
            float[] widths3 = new float[] { 1.5f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f };
            tbEjemplo3.SetWidths(widths3);
            tbEjemplo3.AddCell(clClave);
            tbEjemplo3.AddCell(clSemestre1);
            tbEjemplo3.AddCell(clSemestre2);
            tbEjemplo3.AddCell(clSemestre3);
            tbEjemplo3.AddCell(clSemestre4);
            tbEjemplo3.AddCell(clSemestre5);
            tbEjemplo3.AddCell(clSemestre6);
            tbEjemplo3.AddCell(clSemestre7);
            tbEjemplo3.AddCell(clSemestre8);
            tbEjemplo3.AddCell(clSemestre9);

            //tabla 4
            PdfPCell clNombreAsig = new PdfPCell(new Phrase("Nombre de la asignatura: " + EM.Materia, texto));
            PdfPCell clGrupo = new PdfPCell(new Phrase("Grupo:" + ER.Grupo, texto));
            float[] widths4 = new float[] { 2.5f, 0.6f };
            tbEjemplo4.SetWidths(widths4);
            tbEjemplo4.AddCell(clNombreAsig);
            tbEjemplo4.AddCell(clGrupo);

            //Tabla 5
            PdfPCell clpregunta1 = new PdfPCell(new Phrase("¿Cual es la fecha de la última actualización de los Apuntes Docentes (AD)?", texto));
            clpregunta1.HorizontalAlignment = Element.ALIGN_CENTER;
            PdfPCell clfecha1 = new PdfPCell(new Phrase(ER.FechaAD, texto));
            clfecha1.HorizontalAlignment = Element.ALIGN_CENTER;
            PdfPCell clpregunta2 = new PdfPCell(new Phrase("¿Proporcionó una copia de la última actualizacion de los AD al coordinador?", texto));
            PdfPCell clSi;
            PdfPCell clNo;
            if (ER.CopiaAD == 1)
            {
                clSi = new PdfPCell(new Phrase("SI", negritas));
                clSi.HorizontalAlignment = Element.ALIGN_CENTER;
                clNo = new PdfPCell(new Phrase("NO", texto));
                clNo.HorizontalAlignment = Element.ALIGN_CENTER;
            }
            else
            {
                clSi = new PdfPCell(new Phrase("SI", texto));
                clSi.HorizontalAlignment = Element.ALIGN_CENTER;
                clNo = new PdfPCell(new Phrase("NO", negritas));
                clNo.HorizontalAlignment = Element.ALIGN_CENTER;
            }

            float[] widths5 = new float[] { 1.4f, 0.8f, 1.4f, 0.4f, 0.4f };
            tbEjemplo5.SetWidths(widths5);
            tbEjemplo5.AddCell(clpregunta1);
            tbEjemplo5.AddCell(clfecha1);
            tbEjemplo5.AddCell(clpregunta2);
            tbEjemplo5.AddCell(clSi);
            tbEjemplo5.AddCell(clNo);

            //Tabla 6
            PdfPCell clpregunta3 = new PdfPCell(new Phrase("En su caso ¿Cual es la fecha de la última actualización del Manual de Prácticas (MP)?", texto));
            clpregunta3.HorizontalAlignment = Element.ALIGN_CENTER;
            PdfPCell clfecha2 = new PdfPCell(new Phrase(ER.FechaMP, texto));
            clfecha2.HorizontalAlignment = Element.ALIGN_CENTER;
            PdfPCell clpregunta4 = new PdfPCell(new Phrase("Si aplica,¿Proporcionó una copia de la última actualizacion del MP al coordinador?", texto));
            PdfPCell clSi2;
            PdfPCell clNo2;
            if (ER.CopiaMP == 1)
            {
                clSi2 = new PdfPCell(new Phrase("SI", negritas));
                clSi2.HorizontalAlignment = Element.ALIGN_CENTER;
                clNo2 = new PdfPCell(new Phrase("NO", texto));
                clNo2.HorizontalAlignment = Element.ALIGN_CENTER;
            }
            else
            {
                clSi2 = new PdfPCell(new Phrase("SI", texto));
                clSi2.HorizontalAlignment = Element.ALIGN_CENTER;
                clNo2 = new PdfPCell(new Phrase("NO", negritas));
                clNo2.HorizontalAlignment = Element.ALIGN_CENTER;
            }
            float[] widths6 = new float[] { 1.4f, 0.8f, 1.4f, 0.4f, 0.4f };
            tbEjemplo6.SetWidths(widths6);
            tbEjemplo6.AddCell(clpregunta3);
            tbEjemplo6.AddCell(clfecha2);
            tbEjemplo6.AddCell(clpregunta4);
            tbEjemplo6.AddCell(clSi2);
            tbEjemplo6.AddCell(clNo2);

            //Tabla 7
            PdfPCell clSemestres = new PdfPCell(new Phrase("¿Cuántos semestres ha impartido esta materia?", texto));
            clSemestres.HorizontalAlignment = Element.ALIGN_CENTER;
            PdfPCell clNumero = new PdfPCell(new Phrase(" " + ER.Semestres, texto));
            float[] widths7 = new float[] { 2.2f, 1f };
            tbEjemplo7.SetWidths(widths7);
            tbEjemplo7.AddCell(clSemestres);
            tbEjemplo7.AddCell(clNumero);

            //Tabla 8
            PdfPCell clHoraTeoria = new PdfPCell(new Phrase("Hrs semestrales Teoría", texto));
            PdfPCell clHoras1 = new PdfPCell(new Phrase("" + ER.HorasTeoria, texto));
            PdfPCell clNoAlumnos = new PdfPCell(new Phrase("No. de alumnos", texto));
            PdfPCell clAlumnos = new PdfPCell(new Phrase("" + ER.NumAlumnos, texto));
            PdfPCell clNoExamenes = new PdfPCell(new Phrase("No. de Exámenes parciales", texto));
            PdfPCell clExamenes = new PdfPCell(new Phrase("" + ER.NumExamenes, texto));
            float[] widths8 = new float[] { 0.9f, 0.2f, 0.9f, 0.2f, 0.9f, 0.2f };
            tbEjemplo8.SetWidths(widths8);
            tbEjemplo8.AddCell(clHoraTeoria);
            tbEjemplo8.AddCell(clHoras1);
            tbEjemplo8.AddCell(clNoAlumnos);
            tbEjemplo8.AddCell(clAlumnos);
            tbEjemplo8.AddCell(clNoExamenes);
            tbEjemplo8.AddCell(clExamenes);

            //Tabla 9
            PdfPCell clHoraLab = new PdfPCell(new Phrase("Hrs semestrales Lab", texto));
            PdfPCell clHoras2 = new PdfPCell(new Phrase("" + ER.HorasLab, texto));
            PdfPCell clAlumnosAprob = new PdfPCell(new Phrase("% Alumnos aprobados", texto));
            PdfPCell clAlumnos2 = new PdfPCell(new Phrase("" + ER.PorAprobados, texto));
            PdfPCell clCursoCubierto = new PdfPCell(new Phrase("% cubierto del curso", texto));
            PdfPCell clCurso = new PdfPCell(new Phrase("" + ER.PorCurso, texto));
            float[] widths9 = new float[] { 0.9f, 0.2f, 0.9f, 0.2f, 0.9f, 0.2f };
            tbEjemplo9.SetWidths(widths9);
            tbEjemplo9.AddCell(clHoraLab);
            tbEjemplo9.AddCell(clHoras2);
            tbEjemplo9.AddCell(clAlumnosAprob);
            tbEjemplo9.AddCell(clAlumnos2);
            tbEjemplo9.AddCell(clCursoCubierto);
            tbEjemplo9.AddCell(clCurso);

            //Tabla 10
            PdfPCell clHoraTaller = new PdfPCell(new Phrase("Hrs semestrales de Taller o Práctica", texto));
            PdfPCell clHoras3 = new PdfPCell(new Phrase("" + ER.HorasTaller, texto));
            PdfPCell clInasistenciaA = new PdfPCell(new Phrase("% Inasistencias alumnos", texto));
            PdfPCell clAlumnos3 = new PdfPCell(new Phrase("" + ER.PorAsistencia, texto));
            PdfPCell clblanco = new PdfPCell(new Phrase("", texto));
            PdfPCell clblanco2 = new PdfPCell(new Phrase("", texto));
            float[] widths10 = new float[] { 0.9f, 0.2f, 0.9f, 0.2f, 0.9f, 0.2f };
            tbEjemplo10.SetWidths(widths10);
            tbEjemplo10.AddCell(clHoraTaller);
            tbEjemplo10.AddCell(clHoras3);
            tbEjemplo10.AddCell(clInasistenciaA);
            tbEjemplo10.AddCell(clAlumnos3);
            tbEjemplo10.AddCell(clblanco);
            tbEjemplo10.AddCell(clblanco2);

            //Tabla 11
            PdfPCell clHoraAsesoria = new PdfPCell(new Phrase("Hrs semestrales de Asesoría", texto));
            PdfPCell clHoras4 = new PdfPCell(new Phrase("" + ER.HorasAsesoria, texto));
            PdfPCell clInasistenciaP = new PdfPCell(new Phrase("% Inasistencias Profesor", texto));
            PdfPCell clProfesor = new PdfPCell(new Phrase("" + ER.PorMasistencia, texto));
            PdfPCell clblanco3 = new PdfPCell(new Phrase("", texto));
            PdfPCell clblanco4 = new PdfPCell(new Phrase("", texto));
            float[] widths11 = new float[] { 0.9f, 0.2f, 0.9f, 0.2f, 0.9f, 0.2f };
            tbEjemplo11.SetWidths(widths11);
            tbEjemplo11.AddCell(clHoraAsesoria);
            tbEjemplo11.AddCell(clHoras4);
            tbEjemplo11.AddCell(clInasistenciaP);
            tbEjemplo11.AddCell(clProfesor);
            tbEjemplo11.AddCell(clblanco3);
            tbEjemplo11.AddCell(clblanco4);

            //Tabla 12
            PdfPTable tbAux = new PdfPTable(1);
            PdfPTable tbAux2 = new PdfPTable(4);

            PdfPCell clAtributo = new PdfPCell(new Phrase("Atributo(s) de Egreso", texto));
            clAtributo.HorizontalAlignment = Element.ALIGN_CENTER;
            PdfPCell clTecnica = new PdfPCell(new Phrase("Técnica de Evaluación", texto));
            clTecnica.HorizontalAlignment = Element.ALIGN_CENTER;
            PdfPCell clNiveles = new PdfPCell(new Phrase("Indique el porcentaje de alumnos en cada nivel (4 es sobresaliente)", texto));
            clNiveles.HorizontalAlignment = Element.ALIGN_CENTER;

            PdfPCell cl4 = new PdfPCell(new Phrase("4", texto));
            cl4.HorizontalAlignment = Element.ALIGN_CENTER;
            PdfPCell cl3 = new PdfPCell(new Phrase("3", texto));
            cl3.HorizontalAlignment = Element.ALIGN_CENTER;
            PdfPCell cl2 = new PdfPCell(new Phrase("2", texto));
            cl2.HorizontalAlignment = Element.ALIGN_CENTER;
            PdfPCell cl1 = new PdfPCell(new Phrase("1", texto));
            cl1.HorizontalAlignment = Element.ALIGN_CENTER;
            float[] widths12 = new float[] { 0.5f, 0.8f, 1.2f };
            tbAux2.AddCell(cl4);
            tbAux2.AddCell(cl3);
            tbAux2.AddCell(cl2);
            tbAux2.AddCell(cl1);

            tbAux.AddCell(clNiveles);
            tbAux.AddCell(tbAux2);
            tbEjemplo12.SetWidths(widths12);
            tbEjemplo12.AddCell(clAtributo);
            tbEjemplo12.AddCell(clTecnica);
            tbEjemplo12.AddCell(tbAux);

            //Tabla 13

            PdfPCell clAtributo1 = new PdfPCell(new Phrase("1", texto));
            clAtributo1.HorizontalAlignment = Element.ALIGN_CENTER;
            PdfPCell clTecnica1 = new PdfPCell(new Phrase(""+LEPO[0].Tecnica, texto));
            string[] aux = LEPO[0].Porcentaje.Split('-');
            PdfPCell clnivel4 = new PdfPCell(new Phrase(""+aux[3], texto));
            PdfPCell clnivel3 = new PdfPCell(new Phrase("" + aux[2], texto));
            PdfPCell clnivel2 = new PdfPCell(new Phrase("" + aux[1], texto));
            PdfPCell clnivel1 = new PdfPCell(new Phrase("" + aux[0], texto));
            float[] widths13 = new float[] { 0.5f, 0.8f, 0.3f, 0.3f, 0.3f, 0.3f };
            tbEjemplo13.SetWidths(widths13);
            tbEjemplo13.AddCell(clAtributo1);
            tbEjemplo13.AddCell(clTecnica1);
            tbEjemplo13.AddCell(clnivel4);
            tbEjemplo13.AddCell(clnivel3);
            tbEjemplo13.AddCell(clnivel2);
            tbEjemplo13.AddCell(clnivel1);

            //Tabla 14
            PdfPCell clAtributo2 = new PdfPCell(new Phrase("2", texto));
            clAtributo2.HorizontalAlignment = Element.ALIGN_CENTER;
            PdfPCell clTecnica2 = new PdfPCell(new Phrase(""+LEPO[1].Tecnica, texto));
            string[] aux2 = LEPO[1].Porcentaje.Split('-');
            PdfPCell clnivel42 = new PdfPCell(new Phrase("" + aux2[3], texto));
            PdfPCell clnivel32 = new PdfPCell(new Phrase("" + aux2[2], texto));
            PdfPCell clnivel22 = new PdfPCell(new Phrase("" + aux2[1], texto));
            PdfPCell clnivel12 = new PdfPCell(new Phrase("" + aux2[0], texto));

            tbEjemplo14.SetWidths(widths13);
            tbEjemplo14.AddCell(clAtributo2);
            tbEjemplo14.AddCell(clTecnica2);
            tbEjemplo14.AddCell(clnivel42);
            tbEjemplo14.AddCell(clnivel32);
            tbEjemplo14.AddCell(clnivel22);
            tbEjemplo14.AddCell(clnivel12);

            //Tabla 15
            PdfPCell clAtributo3 = new PdfPCell(new Phrase("3", texto));
            clAtributo3.HorizontalAlignment = Element.ALIGN_CENTER;
            PdfPCell clTecnica3 = new PdfPCell(new Phrase(""+LEPO[2].Tecnica, texto));
            string[] aux3 = LEPO[2].Porcentaje.Split('-');
            PdfPCell clnivel43 = new PdfPCell(new Phrase(""+aux3[3], texto));
            PdfPCell clnivel33 = new PdfPCell(new Phrase("" + aux3[2], texto));
            PdfPCell clnivel23 = new PdfPCell(new Phrase("" + aux3[1], texto));
            PdfPCell clnivel13 = new PdfPCell(new Phrase("" + aux3[0], texto));

            tbEjemplo15.SetWidths(widths13);
            tbEjemplo15.AddCell(clAtributo3);
            tbEjemplo15.AddCell(clTecnica3);
            tbEjemplo15.AddCell(clnivel43);
            tbEjemplo15.AddCell(clnivel33);
            tbEjemplo15.AddCell(clnivel23);
            tbEjemplo15.AddCell(clnivel13);

            //Tabla 16
            PdfPCell clAtributo4 = new PdfPCell(new Phrase("4", texto));
            clAtributo4.HorizontalAlignment = Element.ALIGN_CENTER;
            PdfPCell clTecnica4 = new PdfPCell(new Phrase(""+LEPO[3].Tecnica, texto));
            string[] aux4 = LEPO[3].Porcentaje.Split('-');
            PdfPCell clnivel44 = new PdfPCell(new Phrase(""+aux4[3], texto));
            PdfPCell clnivel34 = new PdfPCell(new Phrase("" + aux4[2], texto));
            PdfPCell clnivel24 = new PdfPCell(new Phrase("" + aux4[1], texto));
            PdfPCell clnivel14 = new PdfPCell(new Phrase("" + aux4[0], texto));

            tbEjemplo16.SetWidths(widths13);
            tbEjemplo16.AddCell(clAtributo4);
            tbEjemplo16.AddCell(clTecnica4);
            tbEjemplo16.AddCell(clnivel44);
            tbEjemplo16.AddCell(clnivel34);
            tbEjemplo16.AddCell(clnivel24);
            tbEjemplo16.AddCell(clnivel14);

            //Tabla 17
            PdfPCell clAtributo5 = new PdfPCell(new Phrase("5", texto));
            clAtributo5.HorizontalAlignment = Element.ALIGN_CENTER;
            PdfPCell clTecnica5 = new PdfPCell(new Phrase(""+LEPO[4].Tecnica, texto));
            string[] aux5 = LEPO[4].Porcentaje.Split('-');
            PdfPCell clnivel45 = new PdfPCell(new Phrase("" + aux5[3], texto));
            PdfPCell clnivel35 = new PdfPCell(new Phrase("" + aux5[2], texto));
            PdfPCell clnivel25 = new PdfPCell(new Phrase("" + aux5[1], texto));
            PdfPCell clnivel15 = new PdfPCell(new Phrase("" + aux5[0], texto));

            tbEjemplo17.SetWidths(widths13);
            tbEjemplo17.AddCell(clAtributo5);
            tbEjemplo17.AddCell(clTecnica5);
            tbEjemplo17.AddCell(clnivel45);
            tbEjemplo17.AddCell(clnivel35);
            tbEjemplo17.AddCell(clnivel25);
            tbEjemplo17.AddCell(clnivel15);

            //Tabla 18
            PdfPCell clAtributo6 = new PdfPCell(new Phrase("6", texto));
            clAtributo6.HorizontalAlignment = Element.ALIGN_CENTER;
            PdfPCell clTecnica6 = new PdfPCell(new Phrase(""+LEPO[5].Tecnica, texto));
            string[] aux6 = LEPO[5].Porcentaje.Split('-');
            PdfPCell clnivel46 = new PdfPCell(new Phrase("" + aux6[3], texto));
            PdfPCell clnivel36 = new PdfPCell(new Phrase("" + aux6[2], texto));
            PdfPCell clnivel26 = new PdfPCell(new Phrase("" + aux6[1], texto));
            PdfPCell clnivel16 = new PdfPCell(new Phrase("" + aux6[0], texto));

            tbEjemplo18.SetWidths(widths13);
            tbEjemplo18.AddCell(clAtributo6);
            tbEjemplo18.AddCell(clTecnica6);
            tbEjemplo18.AddCell(clnivel46);
            tbEjemplo18.AddCell(clnivel36);
            tbEjemplo18.AddCell(clnivel26);
            tbEjemplo18.AddCell(clnivel16);

            //Tabla 19
            PdfPCell clAtributo7 = new PdfPCell(new Phrase("7", texto));
            clAtributo7.HorizontalAlignment = Element.ALIGN_CENTER;
            PdfPCell clTecnica7 = new PdfPCell(new Phrase(""+LEPO[6].Tecnica, texto));
            string[] aux7 = LEPO[6].Porcentaje.Split('-');
            PdfPCell clnivel47 = new PdfPCell(new Phrase(""+aux7[3], texto));
            PdfPCell clnivel37 = new PdfPCell(new Phrase("" + aux7[2], texto));
            PdfPCell clnivel27 = new PdfPCell(new Phrase("" + aux7[1], texto));
            PdfPCell clnivel17 = new PdfPCell(new Phrase("" + aux7[0], texto));

            tbEjemplo19.SetWidths(widths13);
            tbEjemplo19.AddCell(clAtributo7);
            tbEjemplo19.AddCell(clTecnica7);
            tbEjemplo19.AddCell(clnivel47);
            tbEjemplo19.AddCell(clnivel37);
            tbEjemplo19.AddCell(clnivel27);
            tbEjemplo19.AddCell(clnivel17);


            //Tabla 20
            PdfPCell clReqPc = new PdfPCell(new Phrase("¿Requiere utilizar la computadora en su curso para lograr el aprendizaje significativo de sus estudiantes?", texto));
            clReqPc.HorizontalAlignment = Element.ALIGN_CENTER;
            PdfPCell clSi3;
            PdfPCell clNo3;
            if (ER.CopiaMP == 1)
            {
                clSi3 = new PdfPCell(new Phrase("SI", negritas));
                clSi3.HorizontalAlignment = Element.ALIGN_CENTER;
                clNo3 = new PdfPCell(new Phrase("NO", texto));
                clNo3.HorizontalAlignment = Element.ALIGN_CENTER;
            }
            else
            {
                clSi3 = new PdfPCell(new Phrase("SI", texto));
                clSi3.HorizontalAlignment = Element.ALIGN_CENTER;
                clNo3 = new PdfPCell(new Phrase("NO", negritas));
                clNo3.HorizontalAlignment = Element.ALIGN_CENTER;
            }
            float[] widths20 = new float[] { 3.5f, 0.3f, 0.3f };
            tbEjemplo20.SetWidths(widths20);
            tbEjemplo20.AddCell(clReqPc);
            tbEjemplo20.AddCell(clSi3);
            tbEjemplo20.AddCell(clNo3);

            //Tabla 21
            PdfPCell clHorasPc = new PdfPCell(new Phrase("Número de horas a la semana que utiliza la computadora en su curso", texto));
            clHorasPc.HorizontalAlignment = Element.ALIGN_CENTER;
            PdfPCell clHoras = new PdfPCell(new Phrase(" " + ER.HorasPC, texto));
            float[] widths21 = new float[] { 3.2f, 0.6f };
            tbEjemplo21.SetWidths(widths21);
            tbEjemplo21.AddCell(clHorasPc);
            tbEjemplo21.AddCell(clHoras);

            //Tabla 22
            PdfPCell clProgramas = new PdfPCell(new Phrase("Indique que programas utiliza:" + ER.Programa, texto));
            tbEjemplo22.AddCell(clProgramas);

            //Tabla 23
            PdfPCell clComentarios = new PdfPCell(new Phrase("Comentarios y áreas de mejora:" + ER.Comentarios, texto));

            tbEjemplo23.AddCell(clComentarios);

            //Tabla 24
            PdfPCell clCelular = new PdfPCell(new Phrase("Celular:" + ER.Celular, texto));
            PdfPCell clCorreo = new PdfPCell(new Phrase("Correo:" + EU.EmailUsuario, texto));
            float[] widths24 = new float[] { 2f, 2f };
            tbEjemplo24.SetWidths(widths24);
            tbEjemplo24.AddCell(clCelular);
            tbEjemplo24.AddCell(clCorreo);

            //Tabla 25
            E_Firma EF = NU.BuscaFirma(EU.IdUsuario);
            Image img = Image.GetInstance(EF.Firma);
            img.WidthPercentage = 25f;
            PdfPCell clFirmaProfesor = new PdfPCell(new Phrase("Firma del Docente", texto));
            clFirmaProfesor.AddElement(img);
            PdfPCell clFirmaAlumno = new PdfPCell(new Phrase("Nombre y firma del representante de grupo", texto));


            tbEjemplo24.SetWidths(widths24);
            tbEjemplo24.AddCell(clFirmaProfesor);
            tbEjemplo24.AddCell(clFirmaAlumno);

            doc.Add(tbEjemplo1);
            doc.Add(tbEjemplo2);
            doc.Add(tbEjemplo3);
            doc.Add(tbEjemplo4);
            doc.Add(tbEjemplo5);
            doc.Add(tbEjemplo6);
            doc.Add(tbEjemplo7);
            doc.Add(tbEjemplo8);
            doc.Add(tbEjemplo9);
            doc.Add(tbEjemplo10);
            doc.Add(tbEjemplo11);
            doc.Add(tbEjemplo12);
            doc.Add(tbEjemplo13);
            doc.Add(tbEjemplo14);
            doc.Add(tbEjemplo15);
            doc.Add(tbEjemplo16);
            doc.Add(tbEjemplo17);
            doc.Add(tbEjemplo18);
            doc.Add(tbEjemplo19);
            doc.Add(tbEjemplo20);
            doc.Add(tbEjemplo21);
            doc.Add(tbEjemplo22);
            doc.Add(tbEjemplo23);
            doc.Add(tbEjemplo24);
            doc.Add(tbEjemplo25);
            doc.Close();
            pw.Close();

        }

    }
}