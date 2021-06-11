<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/MasterDocenteMenu.Master" AutoEventWireup="true" CodeBehind="FormularioRSA.aspx.cs" Inherits="Presentacion.GestionUsuarios.FormularioRSA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphContenedorBase" runat="server">
     <br />
    <br />
    <div class="container">
     <div class="form-group row">
         <table>
             <tr>
                 <td>
                       <label class="col-sm-2 col-form-label">Carrera</label>
                       <asp:TextBox ID="TbCarrera" runat="server" CssClass="form-control box w-100" Width="700px"></asp:TextBox> 
                 </td>
                 <td>
                     <label class="col-sm-2 col-form-label">Semestre</label> 
                     <asp:TextBox ID="TbSemestre" runat="server" CssClass="form-control box w-100" Width="700px"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td>
                       <label class="col-sm-6 col-form-label">Numero de Empleado</label>
                       <asp:TextBox ID="TbNumEmpleado" runat="server" CssClass="form-control box w-100" Width="700px"></asp:TextBox> 
                 </td>
                 <td>
                     <label class="col-sm-6 col-form-label">Nombre del Docente</label> 
                     <asp:TextBox ID="TbNombreDocente" runat="server" CssClass="form-control box w-100" Width="700px"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                  <td>
                       <label class="col-sm-6 col-form-label">Nombre de Asignatura</label>
                       <asp:TextBox ID="TbAsignatura" runat="server" CssClass="form-control box w-100" Width="700px"></asp:TextBox> 
                 </td>
                 <td>
                     <label class="col-sm-6 col-form-label">Clave de Asignatura</label> 
                     <asp:TextBox ID="TbClaveAsig" runat="server" CssClass="form-control box w-100" Width="700px"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td>
                     <label class="col-sm-8 col-form-label">¿Cuál es la fecha de la última actualización de los Apuntes docentes (AD)?</label> 
                     <asp:TextBox ID="TbFecha" runat="server" CssClass="form-control box w-100" Width="700px"></asp:TextBox>
                     
                 </td>
                 <td>
                      <label class="col-sm-8 col-form-label">¿Proporcionó una copia de la última actualización de los AD al coordinador?</label> 
                        <asp:DropDownList CssClass="align-self-md-center" ID="DdlAD" runat="server" Width="100px">
                        <asp:ListItem Text="SI" Value="1" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="NO" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                 </td>
             </tr>
              <tr>
                 <td>
                     <label class="col-sm-8 col-form-label">En su caso. ¿Cuál es la fecha de la última actualización del Manual de Prácticas (MP)?</label> 
                     <asp:TextBox ID="TbFecha2" runat="server" CssClass="form-control box w-100" Width="700px"></asp:TextBox>
                     
                 </td>
                 <td>
                      <label class="col-sm-8 col-form-label">Si aplica, ¿Proporcionó una copia de la última actualización del MP al coordinador?</label> 
                        <asp:DropDownList CssClass="align-self-md-center" ID="DdlMP" runat="server"  Width="100px">
                        <asp:ListItem Text="SI" Value="1" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="NO" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                 </td>
             </tr>
             <tr>
                 <td>
                     <label class="col-sm-8 col-form-label">¿Cuántos semestres ha impartido esta materia?</label>
                     <asp:TextBox ID="tbSemestresImp" runat="server" CssClass="form-control box w-100" Width="150px" ></asp:TextBox><br />
                 </td>
             </tr>
         </table>
         <div class="form-row align-content-center text-center">
              <div class="col">
                <asp:Button runat="server" ID="btnRegresar" CssClass="btn btn-light boton mb-2 box margen"  Text="Regresar"></asp:Button>

            </div>
            <div class="col">
                 <asp:Button runat="server" ID="btnSiguiente" CssClass="btn btn-light boton mb-2 box margen"   Text="Siguiente Pagina"></asp:Button>
            </div>
         </div>
        </div>
        
</asp:Content>