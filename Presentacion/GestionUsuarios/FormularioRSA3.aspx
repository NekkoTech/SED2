<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/MasterDocenteMenu.Master" AutoEventWireup="true" CodeBehind="FormularioRSA3.aspx.cs" Inherits="Presentacion.GestionUsuarios.FormularioRSA3" %>

<%@ MasterType VirtualPath="../PaginasMaestras/MasterDocenteMenu.Master" %>
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
                     <asp:RequiredFieldValidator ID="RfvHorasTeoria" ControlToValidate="TbHorasTeoria" runat="server" ErrorMessage="Ingrese Elas Horas de Teoria"></asp:RequiredFieldValidator>
                     <td>Hrs semestrales Lab</td>
                     <td><asp:TextBox ID="tbHorasLab" runat="server"  CssClass="form-control box w-100" Width="200px"></asp:TextBox></td>
                     <asp:RequiredFieldValidator ID="RfvHorasLab" ControlToValidate="TbHorasLab" runat="server" ErrorMessage="Ingrese Las Horas de Laboratorio"></asp:RequiredFieldValidator>
                     <td>Hrs semestrales Taller o Práctica</td>
                     <td><asp:TextBox ID="tbHorasTaller" runat="server"  CssClass="form-control box w-100" Width="200px"></asp:TextBox></td>
                     <asp:RequiredFieldValidator ID="RfvHorasTaller" ControlToValidate="TbHorasTaller" runat="server" ErrorMessage="Ingrese Las Horas del Taller"></asp:RequiredFieldValidator>
                 </tr>
                 <tr>
                     <td>Hrs semestrales Asesoría</td>
                     <td><asp:TextBox ID="tbHorasAsesoria" runat="server"  CssClass="form-control box w-100" Width="200px"></asp:TextBox></td>
                     <asp:RequiredFieldValidator ID="RfvHorasAsesoria" ControlToValidate="TbHorasAsesoria" runat="server" ErrorMessage="Ingrese Las Horas de Asesoria"></asp:RequiredFieldValidator>
                     <td>Numero de Alumnos</td>
                     <td><asp:TextBox ID="tbAlumnos" runat="server"  CssClass="form-control box w-100" Width="200px"></asp:TextBox></td>
                     <asp:RequiredFieldValidator ID="RfvAlumnos" ControlToValidate="TbAlumnos" runat="server" ErrorMessage="Ingrese El Numero de Alumnos"></asp:RequiredFieldValidator>
                     <td>Porcentaje Alumnos aprobados</td>
                     <td><asp:TextBox ID="tbAprobados" runat="server"  CssClass="form-control box w-100" Width="200px"></asp:TextBox></td>
                     <asp:RequiredFieldValidator ID="RfvAprovad" ControlToValidate="TbAprobados" runat="server" ErrorMessage="Ingrese El Porcentaje de Alumnos"></asp:RequiredFieldValidator>
                 </tr>
                 <tr>
                     <td>Porcentaje Inasistencias alumnos</td>
                     <td><asp:TextBox ID="tbInasistenciasA" runat="server"  CssClass="form-control box w-100" Width="200px"></asp:TextBox></td>
                     <asp:RequiredFieldValidator ID="RfvInA" ControlToValidate="TbInasistenciasA" runat="server" ErrorMessage="Ingrese La cantidad de Inasistencias"></asp:RequiredFieldValidator>
                     <td>Porcentaje Inasistencias profesor</td>
                     <td><asp:TextBox ID="tbInasistenciasP" runat="server"  CssClass="form-control box w-100" Width="200px"></asp:TextBox></td>
                     <asp:RequiredFieldValidator ID="RfvInP" ControlToValidate="TbInasistenciasP" runat="server" ErrorMessage="Ingrese La cantidad de Inasistencias"></asp:RequiredFieldValidator>
                     <td>Porcentaje cubierto del curso</td>
                     <td><asp:TextBox ID="tbCurso" runat="server"  CssClass="form-control box w-100" Width="200px"></asp:TextBox></td>
                     <asp:RequiredFieldValidator ID="RfvCurso" ControlToValidate="TbCurso" runat="server" ErrorMessage="Ingrese Porcentaje Cubierto del Curso"></asp:RequiredFieldValidator>
                 </tr>
                 <tr>
                     <td>Numero de Exámenes Parciales</td>
                     <td><asp:TextBox ID="tbExamenes" runat="server"  CssClass="form-control box w-100" Width="200px"></asp:TextBox></td>
                     <asp:RequiredFieldValidator ID="RvfExamenes" ControlToValidate="TbExamenes" runat="server" ErrorMessage="Ingrese La Cantidad de Examenes Parciales"></asp:RequiredFieldValidator>
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
             <asp:RequiredFieldValidator ID="RvfCelular" ControlToValidate="TbCelular" runat="server" ErrorMessage="Ingrese Su Numero de Telefono"></asp:RequiredFieldValidator>
        </div>
        <br />
        <div class="form-row align-content-center text-center">
              <div class="col">
                <asp:Button runat="server" ID="btnRegresar" CssClass="btn btn-light boton mb-2 box margen"  Text="Regresar"></asp:Button>

            </div>
            <div class="col">
                 <asp:Button runat="server" ID="Button1" CssClass="btn btn-warning box mb-2 margen" Font-Size="Large"   Text="Guardar Informacion" OnClick="btnGuardar_Click"></asp:Button>
            </div>
             <div class="col">
                 <asp:Button runat="server" ID="btnModal" CssClass="btn btn-warning mb-2 box margen" Font-Size="Large"  Text="Ver Retroalimentacion" OnClick="btnObservaciones_Click" Visible="false"></asp:Button>
            </div>
            <div class="col">
                 <asp:Button runat="server" ID="btnEnviar" CssClass="btn btn-light boton mb-2 box margen"   Text="Enviar RSA" OnClick="btnEnviar_Click"></asp:Button>
            </div>
         </div>
    </div>
     <!--Modal De Funcionamiento de peticiones-->
    <div id="master-modal-Observaciones" class="modal fade" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-notify modal-info" role="document">
            <div class="modal-content">
                <div id="Div1" runat="server">
                    <p class="heading lead text-center">Retroalimentacion:</p>
                </div>
                <div class="modal-body">
                    <asp:Label ID="LblObservaciones" runat="server" Text="Observaciones:"></asp:Label>
                    <asp:TextBox ID="tbObservaciones" Width="200" Height="200" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnObservaciones" type="button" CssClass="btn btn-danger" runat="server" data-dismiss="modal" Text="Cerrar" CausesValidation="false"/>
                </div>
            </div>
        </div>
    </div>
    <script>

        function openMasterModalPeticion() {
            $('#master-modal-peticiones').modal('show');
        }
        function openMasterModalObservaciones() {
            $('#master-modal-Observaciones').modal('show');
        }
    </script>
</asp:Content>
