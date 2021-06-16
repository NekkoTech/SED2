using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using EntidadesGestionUsuarios;
using NegociosGestionUsuarios;
using System.IO;
using System.Threading;
using System.Configuration;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Net;

namespace WSTimer
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            this.WriteToFile("Simple Service started {0}");
            this.ScheduleService();
        }

        protected override void OnStop()
        {
            this.WriteToFile("Simple Service stopped {0}");
            this.Schedular.Dispose();
        }

        private Timer Schedular;

        public void ScheduleService()
        {
            try
            {
                Schedular = new Timer(new TimerCallback(SchedularCallback));
                string mode = ConfigurationManager.AppSettings["Mode"].ToUpper();
                this.WriteToFile("Simple Service Mode: " + mode + " {0}");

                //Set the Default Time.
                DateTime scheduledTime = DateTime.MinValue;

                if (mode == "DAILY")
                {
                    //Get the Scheduled Time from AppSettings.
                    scheduledTime = DateTime.Parse(System.Configuration.ConfigurationManager.AppSettings["ScheduledTime"]);
                    if (DateTime.Now > scheduledTime)
                    {
                        //If Scheduled Time is passed set Schedule for the next day.
                        scheduledTime = scheduledTime.AddDays(1);
                    }
                }

                if (mode.ToUpper() == "INTERVAL")
                {
                    //Get the Interval in Minutes from AppSettings.
                    int intervalMinutes = Convert.ToInt32(ConfigurationManager.AppSettings["IntervalMinutes"]);

                    //Set the Scheduled Time by adding the Interval to Current Time.
                    scheduledTime = DateTime.Now.AddMinutes(intervalMinutes);
                    if (DateTime.Now > scheduledTime)
                    {
                        //If Scheduled Time is passed set Schedule for the next Interval.
                        scheduledTime = scheduledTime.AddMinutes(intervalMinutes);
                    }
                }

                TimeSpan timeSpan = scheduledTime.Subtract(DateTime.Now);
                string schedule = string.Format("{0} day(s) {1} hour(s) {2} minute(s) {3} seconds(s)", timeSpan.Days, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);

                this.WriteToFile("Simple Service scheduled to run after: " + schedule + " {0}");

                //Get the difference in Minutes between the Scheduled and Current Time.
                int dueTime = Convert.ToInt32(timeSpan.TotalMilliseconds);

                //Change the Timer's Due Time.
                Schedular.Change(dueTime, Timeout.Infinite);
            }
            catch (Exception ex)
            {
                WriteToFile("Simple Service Error on: {0} " + ex.Message + ex.StackTrace);

                //Stop the Windows Service.
                using (System.ServiceProcess.ServiceController serviceController = new System.ServiceProcess.ServiceController("SimpleService"))
                {
                    serviceController.Stop();
                }
            }
        }

        private void SchedularCallback(object e)
        {
            try
            {
                N_Usuarios NU = new N_Usuarios();
                List<E_Fecha> LEF = NU.LstFecha();
                List<E_PlanEstudio> LEP = NU.LstPlanes();
                List<E_Usuarios> LEU = new List<E_Usuarios>(); 
                foreach (E_Fecha f in LEF)
                {
                    if (f.isGlobal == 1)
                    {
                        DateTime now = DateTime.Now;
                        //int i = DateTime.Compare(now, f.FechaInicial);
                        int dr = (int)(f.FechaInicial-now).TotalDays;
                        if (dr>0)
                        {
                            foreach(E_Usuarios u in LEU)
                            {
                                if (u.IdTipoUsuario == 3)
                                {
                                    using (MailMessage Email = new MailMessage())
                                    {
                                        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                                        Email.SubjectEncoding = Encoding.UTF8;
                                        Email.BodyEncoding = Encoding.UTF8;
                                        Email.From = new MailAddress("SedFiad@gmail.com", "Administrador del sistema");
                                        Email.Subject = "Notificaciones SED: Estado de Encuadre";
                                        Email.Body = "Hola, el Subdirector Acaba de Subir las fechas para subir lo encuadres";


                                        Email.To.Add(u.EmailUsuario);
                                        SmtpServer.Port = 587; //SMTP de GMAIL
                                        SmtpServer.Credentials = new NetworkCredential("SedFiad@gmail.com", "SEDFIAD@");      //Hay que crear las credenciales del correo emisor
                                        SmtpServer.EnableSsl = true;
                                        SmtpServer.Send(Email);
                                        WriteToFile("Email sent successfully to: " + u.NombreUsuario+ " "+u.APaternoUsuario + " " + u.EmailUsuario);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        DateTime now = DateTime.Now;
                        int dr = (int)(f.FechaFinal-now).TotalDays;
                        if (dr >= 7)
                        {
                            foreach (E_PlanEstudio p in LEP)
                            {
                                if (f.IdPlanEstudio == p.IdPlan)
                                {
                                    foreach (E_Usuarios u in LEU)
                                    {
                                        if (u.IdTipoUsuario == 4)
                                        {
                                            List<E_Materias> LEM = NU.BuscaMateriasDocente(u.IdUsuario);
                                            foreach (E_Materias m in LEM)
                                            {
                                                if (p.IdPlan == NU.BuscaPlanMateria(m.IdMateria).IdPlan)
                                                {
                                                    using (MailMessage Email = new MailMessage())
                                                    {
                                                        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                                                        Email.SubjectEncoding = Encoding.UTF8;
                                                        Email.BodyEncoding = Encoding.UTF8;
                                                        Email.From = new MailAddress("SedFiad@gmail.com", "Administrador del sistema");
                                                        Email.Subject = "Notificaciones SED: Estado de Encuadre";
                                                        Email.Body = "Hola, el Subdirector Acaba de Subir las fechas para subir lo encuadres";


                                                        Email.To.Add(u.EmailUsuario);
                                                        SmtpServer.Port = 587; //SMTP de GMAIL
                                                        SmtpServer.Credentials = new NetworkCredential("SedFiad@gmail.com", "SEDFIAD@");      //Hay que crear las credenciales del correo emisor
                                                        SmtpServer.EnableSsl = true;
                                                        SmtpServer.Send(Email);
                                                        WriteToFile("Email sent successfully to: " + u.NombreUsuario + " " + u.APaternoUsuario + " " + u.EmailUsuario);
                                                    }
                                                }

                                            }
                                        }

                                    }

                                }
                            }
                        } 
                    }
                   
                }
                this.ScheduleService();
            }
            catch (Exception ex)
            {
                WriteToFile("Simple Service Error on: {0} " + ex.Message + ex.StackTrace);

                //Stop the Windows Service.
                using (System.ServiceProcess.ServiceController serviceController = new System.ServiceProcess.ServiceController("SimpleService"))
                {
                    serviceController.Stop();
                }
            }
        }

        private void WriteToFile(string text)
        {
            string path = @"C:\\ServiceLog.txt";
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(string.Format(text, DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")));
                writer.Close();
            }
        }
    }
}
