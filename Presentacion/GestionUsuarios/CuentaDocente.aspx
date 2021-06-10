<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/MasterDocenteMenu.Master" AutoEventWireup="true" CodeBehind="CuentaDocente.aspx.cs" Inherits="Presentacion.GestionUsuarios.CuentaDocente" %>

<%@ Register Src="~/Controles/wuc_Text.ascx" TagPrefix="uc1" TagName="wuc_Text" %>
<%@ Register Src="~/Controles/wuc_RepPassWord.ascx" TagPrefix="uc1" TagName="wuc_RepPassWord" %>
<%@ Register Src="~/Controles/wuc_PassWord.ascx" TagPrefix="uc1" TagName="wuc_PassWord" %>
<%@ Register Src="~/Controles/wuc_Email.ascx" TagPrefix="uc1" TagName="wuc_Email" %>
<%@ Register Src="~/Controles/wuc_NumeroEmpleado.ascx" TagPrefix="uc1" TagName="wuc_NumeroEmpleado" %>
<%@ Register Src="~/Controles/wuc_CrearUsuarioPassWord.ascx" TagPrefix="uc1" TagName="wuc_CrearUsuarioPassWord" %>
<%@ Register Src="~/Controles/wuc_CrearUsuarioCorreo.ascx" TagPrefix="uc1" TagName="wuc_CrearUsuarioCorreo" %>
<%@ MasterType VirtualPath="../PaginasMaestras/MasterDocenteMenu.Master" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphContenedorBase" runat="server">
    <br />
    <br />
    <div class="container">
        <nav style="--bs-breadcrumb-divider: '>';" aria-label="breadcrumb">
            <ol class="breadcrumb bg-white">
                <li class="breadcrumb-item"><a href="InicioMain.aspx">Inicio</a></li>
                <li class="breadcrumb-item active" aria-current="page">Cuenta</li>
            </ol>
        </nav>
        <br />
        <div class="row">

            <div class="col-8">
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
                        <uc1:wuc_Text runat="server" ID="tbAPat" />
                    </div>
                </div>
                <br />
                <div class="form-group row">
                    <label class="col-sm-2 col-form-label">Apellido Materno</label>
                    <div class="col-sm-10">
                        <uc1:wuc_Text runat="server" ID="tbAMat" ValidateRequestMode="Disabled"/>
                    </div>
                </div>
                <br />
                <div class="form-group row">
                    <label class="col-sm-2 col-form-label">Numero Empleado</label>
                    <div class="col-sm-10">
                        <uc1:wuc_NumeroEmpleado runat="server" ID="tbNumeroEmpleado" />
                    </div>
                </div>
                <br />
                <div class="form-group row">
                    <label class="col-sm-2 col-form-label">Correo Institucional</label>
                    <div class="col-sm-10">
                        <uc1:wuc_CrearUsuarioCorreo runat="server" ID="tbEmail" />
                    </div>
                </div>
                <br />
                <div class="form-group row">
                    <label class="col-sm-2 col-form-label">Contraseña</label>
                    <div class="col-sm-10">
                        <asp:Button ID="BtnCambio" CssClass="btn btn-success" runat="server" Text="Cambiar Contraseña" OnClick="BtnCambio_Click" />
                        <uc1:wuc_RepPassWord runat="server" ID="TbRepPassWord" visible="false"/>
                    </div>
                </div>
                <br />
                <br />
                <div class="form-row text-center">

                    <asp:Button ID="BtnGuardar" runat="server" CssClass="btn btn-success boton" Text="Guardar" CausesValidation="false" OnClick="Button1_Click"></asp:Button>
                    <asp:Label ID="lblRespuesta" runat="server" CssClass="text-danger"></asp:Label>
                </div>
            </div>
            <div class="col-4">


                <div class="card" style="width: 20rem; top: 0px; left: 0px;">
                    
                    
                    <asp:Image ID="ImgFirma" runat="server" Width="300px" Height="250px" CssClass="card-img" />
                    <div class="card-body">
                        <asp:FileUpload ID="FuFirma" runat="server" CssClass="form-control" Width="250px" />
                        <asp:Label ID="LblMensaje" runat="server"></asp:Label>
                        <asp:Button ID="BtnSubir" CssClass="btn btn-success" Width="60px" runat="server" Text="Subir" OnClick="BtnSubir_Click" CausesValidation="false" />
                    </div>
                </div>
            </div>

        </div>
    </div>
    
    <!--Modal De Funcionamiento de peticiones-->
    <div id="master-modal-peticiones" class="modal fade" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-notify modal-info" role="document">
            <div class="modal-content">
                <div id="EModalHeader" runat="server">
                    <p class="heading lead text-center"><span id="EModalTitulo" runat="server"></span></p>
                </div>
                <div class="modal-body">
                    <span id="EModalBody" runat="server"></span>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="BtnCancelar" type="button" CssClass="btn btn-danger" runat="server" data-dismiss="modal" Text="Cancelar" />
                    <asp:Button ID="BtnConfirmar" type="button" CssClass="btn btn-success" runat="server" OnClick="BtnConfirmar_Click" Text="Guardar" CausesValidation="false" />
                </div>
            </div>
        </div>
    </div>
    <script>

        function openMasterModalPeticion() {
            $('#master-modal-peticiones').modal('show');
        }
        
    </script>

</asp:Content>
