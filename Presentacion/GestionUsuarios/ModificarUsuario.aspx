<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="~/PaginasMaestras/MasterAdministradorMenu.Master" AutoEventWireup="true" CodeBehind="ModificarUsuario.aspx.cs" Inherits="Presentacion.GestionUsuarios.ModificarUsuario" %>

<%@ MasterType VirtualPath="../PaginasMaestras/MasterAdministradorMenu.Master" %>
<%@ Register Src="../Controles/wuc_Text.ascx" TagPrefix="uc1" TagName="wuc_Text" %>
<%@ Register Src="../Controles/wuc_CrearUsuarioPassWord.ascx" TagPrefix="uc1" TagName="wuc_CrearUsuarioPassWord" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphContenedorBase" runat="server">
    <br />
    <div class="container">
        <nav style="--bs-breadcrumb-divider: '>';" aria-label="breadcrumb">
            <ol class="breadcrumb bg-white">
                <li class="breadcrumb-item"><a href="InicioMain.aspx">Inicio</a></li>
                <li class="breadcrumb-item"><a href="ListaUsuarios.aspx">Administrar Usuarios</a></li>
                <li class="breadcrumb-item active">Modificar Usuario</li>
            </ol>
        </nav>
        <div class="form-group row">
            <label class="col-sm-2 col-form-label">Nombre(s)</label>
            <div class="col-sm-10">
                <uc1:wuc_Text runat="server" ID="tbNombre" />
            </div>
        </div>
        <br />
        <div class="form-group row">
            <label class="col-sm-2 col-form-label">Apellido Paterno</label>
            <div class="col-sm-10">
                <asp:TextBox ID="tbAPat" runat="server" CssClass="form-control box w-100"></asp:TextBox><br />
                <asp:RegularExpressionValidator ID="revtbAPat" runat="server" ErrorMessage="RegularExpressionValidator" ControlToValidate="tbAPat" Display="Dynamic" CssClass="text-danger" ValidationExpression="^[A-Za-zñÑ ]+$">Caracter invalido</asp:RegularExpressionValidator>
            </div>
        </div>
        <br />
        <div class="form-group row">
            <label class="col-sm-2 col-form-label">Apellido Materno</label>
            <div class="col-sm-10">
                <asp:TextBox ID="tbAMat" runat="server" CssClass="form-control box w-100"></asp:TextBox><br />
                <script>
                    function doCustomValidate(source, args) {
                        args.IsValid = false;
                        if (document.getElementById('<% =tbAPat.ClientID %>').value.length > 0) {
                            args.IsValid = true;
                        }
                        if (document.getElementById('<% =tbAMat.ClientID %>').value.length > 0) {
                            args.IsValid = true;
                        }
                    }
                </script>
                <asp:RegularExpressionValidator ID="revtbAMat" runat="server" ErrorMessage="RegularExpressionValidator" ControlToValidate="tbAmat" Display="Dynamic" CssClass="text-danger" ValidationExpression="^[A-Za-zñÑ ]+$">Caracter invalido</asp:RegularExpressionValidator>
                <br/><asp:CustomValidator 
                    ID="cvApellidos" 
                    runat="server" 
                    ClientValidationFunction="doCustomValidate"
                    ValidateEmptyText="true" 
                    Display="Dynamic" 
                    CssClass="text-danger" 
                    ErrorMessage="cvApellidos">
                    Ingresar al menos un apellido
                </asp:CustomValidator>
            </div>
        </div>
        <br />
        <div class="form-group row">
            <label class="col-sm-2 col-form-label">Numero Empleado</label>
            <div class="col-sm-10">
                <asp:TextBox ID="tbNumeroEmpleado" CssClass="form-control box" runat="server" Enabled="False"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="form-group row">
            <label class="col-sm-2 col-form-label">Correo Institucional</label>
            <div class="col-sm-10">
                <asp:TextBox ID="tbEmail" CssClass="form-control box" runat="server" Enabled="False"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="form-group row">
            <label class="col-sm-2 col-form-label">Contraseña</label>
            <div class="col-sm-10">
                <asp:TextBox runat="server" ID="tbPassWord" CssClass="form-control box"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="form-row align-content-center text-center">
            <div class="col align-content-start">
                <asp:Label CssClass="start-0" ID="Label1" runat="server" Text="LblTipoDeRol">Tipo de Rol</asp:Label>
            </div>
            <div class="col">
                <asp:Button runat="server" ID="btnSubdirector" CssClass="btn btn-light btn-outline-dark mb-2 box margen" OnClick="ChangeColorSubd" CausesValidation="false" Text="SUBDIRECTOR"></asp:Button>

            </div>
            <div class="col">
                <asp:Button runat="server" ID="btnCoordinador" CssClass="btn btn-light btn-outline-dark mb-2 box margen" OnClick="ChangeColorCoord" CausesValidation="false" Text="COORDINADOR"></asp:Button>
            </div>
            <div class="col">
                <asp:Button runat="server" ID="btnDocente" CssClass="btn btn-light btn-outline-dark mb-2 box margen" OnClick="ChangeColorDoc" CausesValidation="false" Text="DOCENTE"></asp:Button>
            </div>

        </div>
        <br />
        <div class="align-content-center text-center">
            <asp:Button runat="server" ID="btnRegresar" CssClass="btn mb-2 boton margen whitefont" CausesValidation="false" Text="Regresar" OnClick="btnRegresar_Click"></asp:Button>
            <asp:Button runat="server" CssClass="btn btn-primary mb-2 boton" Text="Modificar" OnClick="Button1_Click"></asp:Button><br />
            <asp:Label ID="lblRespuesta" runat="server" CssClass="text-danger"></asp:Label>
        </div>
    </div>

     <div id="confirmation-modal-mensaje" class="modal fade" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false">
            <div class="modal-dialog modal-notify modal-info" role="document">
                <div class="modal-content">
                    <div id="ModalHeader" runat="server">
                        <p class="heading lead text-center"><span id="ModalTitulo" runat="server"></span></p>
                    </div>
                    <div class="modal-body">
                        <span id="ModalBody" runat="server"></span>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" OnClick="btnConfirmar_Click" data-dismiss="modal"/>
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" data-dismiss="modal"/>
                    </div>
                </div>
            </div>
        </div>
     <script>
         $('#MyModal').on('shown.bs.modal', function () {
             $('#myInput').trigger('focus')
         })
         function openconfirmationModalMensaje() {
             $('#confirmation-modal-mensaje').modal('show');
         }
            //function openMasterModalPeticion() {
             //   $('#master-modal-peticiones').modal('show');
            //}
     </script>
</asp:Content>
