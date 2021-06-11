<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/MasterDocenteMenu.Master" AutoEventWireup="true" CodeBehind="FormularioRSA3.aspx.cs" Inherits="Presentacion.GestionUsuarios.FormularioRSA3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphContenedorBase" runat="server">
    <br />
    <div class="row">
       
         <div class="col">
             <table class="center" style="width:70%">
                 <tr>
                     <td>Hrs semestrales Teoría</td>
                     <td><asp:TextBox ID="tbHorasTeoria" runat="server"  CssClass="form-control box w-100" Width="200px"></asp:TextBox></td>
                     <td>Hrs semestrales Lab</td>
                     <td><asp:TextBox ID="tbHorasLab" runat="server"  CssClass="form-control box w-100" Width="200px"></asp:TextBox></td>
                     <td>Hrs semestrales Taller o Práctica</td>
                     <td><asp:TextBox ID="tbHorasTaller" runat="server"  CssClass="form-control box w-100" Width="200px"></asp:TextBox></td>
                 </tr>
                 <tr>
                     <td>Hrs semestrales Asesoría</td>
                     <td><asp:TextBox ID="tbHorasAsesoria" runat="server"  CssClass="form-control box w-100" Width="200px"></asp:TextBox></td>
                     <td>Numero de Alumnos</td>
                     <td><asp:TextBox ID="tbAlumnos" runat="server"  CssClass="form-control box w-100" Width="200px"></asp:TextBox></td>
                     <td>Porcentaje Alumnos aprobados</td>
                     <td><asp:TextBox ID="tbAprobados" runat="server"  CssClass="form-control box w-100" Width="200px"></asp:TextBox></td>
                 </tr>
                 <tr>
                     <td>Porcentaje Inasistencias alumnos</td>
                     <td><asp:TextBox ID="tbInasistenciasA" runat="server"  CssClass="form-control box w-100" Width="200px"></asp:TextBox></td>
                     <td>Porcentaje Inasistencias profesor</td>
                     <td><asp:TextBox ID="tbInasistenciasP" runat="server"  CssClass="form-control box w-100" Width="200px"></asp:TextBox></td>
                     <td>Porcentaje cubierto del curso</td>
                     <td><asp:TextBox ID="tbCurso" runat="server"  CssClass="form-control box w-100" Width="200px"></asp:TextBox></td>
                 </tr>
                 <tr>
                     <td>Numero de Exámenes Parciales</td>
                     <td><asp:TextBox ID="tbExamenes" runat="server"  CssClass="form-control box w-100" Width="200px"></asp:TextBox></td>
                 </tr>
             </table>
          </div>
    </div>
    <br />
    <div class="container">
        <div >
             <label class="col-sm-8 col-form-label">¿Requiere utilizar la computadora en su curso para lograr el aprendizaje significativo de sus estudiantes?</label> 
                        <asp:DropDownList CssClass="form-control" ID="DdPC" runat="server" Width="100px">
                        <asp:ListItem Text="SI" Value="1" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="NO" Value="2"></asp:ListItem>
                        </asp:DropDownList>
        </div>
        <div >
             <label class="col-sm-8 col-form-label">Número de horas a la semana que utiliza la computadora en su curso</label> 
            <asp:TextBox ID="TbHorasPC" runat="server" CssClass="form-control box w-100" Width="200px"></asp:TextBox>
        </div>
        <div >
            <label class="col-sm-8 col-form-label">Indique que programas utiliza</label> 
            <asp:TextBox ID="TbProgramas" runat="server" CssClass="form-control box w-100" Width="200px"></asp:TextBox>
        </div>
        <div >
            <label class="col-sm-8 col-form-label">Comentarios y áreas de mejora</label> 
            <asp:TextBox ID="TbComentarios" runat="server" CssClass="form-control box w-100" Width="500px"></asp:TextBox>
        </div>
         <div >
            <label class="col-sm-8 col-form-label">Celular</label> 
            <asp:TextBox ID="TbCelular" runat="server" CssClass="form-control box w-100" Width="300px"></asp:TextBox>
        </div>
        <br />
        <div class="form-row align-content-center text-center">
              <div class="col">
                <asp:Button runat="server" ID="btnRegresar" CssClass="btn btn-light boton mb-2 box margen"  Text="Regresar"></asp:Button>

            </div>
            <div class="col">
                 <asp:Button runat="server" ID="btnEnviar" CssClass="btn btn-light boton mb-2 box margen"   Text="Enviar RSA"></asp:Button>
            </div>
         </div>
    </div>
</asp:Content>
