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
                       <asp:TextBox ID="TbCarrera" runat="server" CssClass="form-control box w-100" Width="700px" Enabled="false"></asp:TextBox> 
                 </td>
                 <td>
                     <label class="col-sm-2 col-form-label">Semestre</label> 
                     <asp:TextBox ID="TbSemestre" runat="server" CssClass="form-control box w-100" Width="700px" Enabled="false"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td>
                       <label class="col-sm-6 col-form-label">Numero de Empleado</label>
                       <asp:TextBox ID="TbNumEmpleado" runat="server" CssClass="form-control box w-100" Width="700px" Enabled="false"></asp:TextBox> 
                 </td>
                 <td>
                     <label class="col-sm-6 col-form-label">Nombre del Docente</label> 
                     <asp:TextBox ID="TbNombreDocente" runat="server" CssClass="form-control box w-100" Width="700px" Enabled="false"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                  <td>
                       <label class="col-sm-6 col-form-label">Nombre de Asignatura</label>
                       <asp:TextBox ID="TbAsignatura" runat="server" CssClass="form-control box w-100" Width="700px" Enabled="false"></asp:TextBox> 
                 </td>
                 <td>
                     <label class="col-sm-6 col-form-label">Clave de Asignatura</label> 
                     <asp:TextBox ID="TbClaveAsig" runat="server" CssClass="form-control box w-100" Width="700px" Enabled="false"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td>
                     <label class="col-sm-8 col-form-label">¿Cuál es la fecha de la última actualización de los Apuntes docentes (AD)?</label> 
                     <asp:TextBox ID="TbFecha" runat="server" CssClass="form-control box w-100" Width="700px"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RfvFechaAD" ControlToValidate="TbFecha" runat="server" ErrorMessage="Ingrese El Campo de Fecha"></asp:RequiredFieldValidator>
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
                     <asp:RequiredFieldValidator ID="RvfSemestres" ControlToValidate="TbSemestresImp" runat="server" ErrorMessage="Ingrese Los Semestres impartidos"></asp:RequiredFieldValidator>
                 </td>
             </tr>
         </table>
         <div class="form-row align-content-center text-center">
              <div class="col">
                <asp:Button runat="server" ID="btnRegresar" CssClass="btn btn-light boton mb-2 box margen"  Text="Regresar" OnClick="btnRegresar_Click" CausesValidation="false"></asp:Button>

            </div>
             <div class="col">
                 <asp:Button runat="server" ID="Button1" CssClass="btn btn-warning box mb-2 margen" Font-Size="Large"   Text="Guardar Informacion" OnClick="btnGuardar_Click"></asp:Button>
            </div>
             <div class="col">
                 <asp:Button runat="server" ID="btnModal" CssClass="btn btn-warning mb-2 box margen" Font-Size="Large"  Text="Ver Retroalimentacion" OnClick="btnObservaciones_Click" Visible="false"></asp:Button>
            </div>
            <div class="col">
                 <asp:Button runat="server" ID="btnSiguiente" CssClass="btn btn-light boton mb-2 box margen"   Text="Siguiente Pagina" OnClick="btnSiguiente_Click"></asp:Button>
            </div>
             
         </div>
        </div>
        </div>
        <!--Modal De Funcionamiento de peticiones-->
    <div id="master-modal-peticiones" class="modal fade" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-notify modal-info" role="document">
            <div class="modal-content">
                <div id="EModalHeader" runat="server" class="bg-danger">
                    <p class="heading lead text-center">Alerta</p>
                </div>
                <div class="modal-body">
                    <span id="EModalBody" runat="server">Al regresar se descartara toda la informacion no guardada, ¿seguro que desea continuar?</span>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnCancelar" type="button" CssClass="btn btn-danger" runat="server" data-dismiss="modal" Text="Cancelar" />
                    <asp:Button ID="btnConfirmar" type="button" CssClass="btn btn-success" runat="server" OnClick="btnConfirmar_Click" Text="Descartar" CausesValidation="false" />
                </div>
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