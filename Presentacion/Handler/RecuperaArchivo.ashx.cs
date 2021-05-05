using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace ArchivosSQL.Handler
{
  /// <summary>
  /// Summary description for RecuperaArchivo
  /// </summary>
  public class RecuperaArchivo : IHttpHandler
  {

    public void ProcessRequest(HttpContext context)
    {
      var Id = context.Request.QueryString["IdUsuario"];

      SqlConnection Conexion = new SqlConnection("Data Source=DESKTOP-JR5AFKC;Initial Catalog=SED; Integrated Security=true;");
      Conexion.Open();

      DataTable DT = new DataTable();
      SqlDataAdapter DA;
      DA = new SqlDataAdapter("SELECT * FROM Firmas where IdUsuario=" + Id, Conexion);
      DA.Fill(DT);

      if (DT != null)
      {
        context.Response.ContentType = "image/png";
        Stream Str = new MemoryStream((byte[])DT.Rows[0]["Firma"]);

        byte[] buffer = new byte[4096];
        int SecuenciaByte = Str.Read(buffer, 0, 4096);

        while (SecuenciaByte > 0)
        {
          context.Response.OutputStream.Write(buffer, 0, SecuenciaByte);
          SecuenciaByte = Str.Read(buffer, 0, 4096);
        }
      }
    }
    public bool IsReusable
    {
      get
      {
        return false;
      }
    }
  }
}