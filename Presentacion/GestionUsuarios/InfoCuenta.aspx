<%@ Page Title="" Language="C#" MasterPageFile="../PaginasMaestras/MasterCoordinadorMenu.Master" AutoEventWireup="true" CodeBehind="InfoCuenta.aspx.cs" Inherits="Presentacion.GestionUsuarios.InfoCuenta" %>

<%@ Register Src="../Controles/wuc_Text.ascx" TagPrefix="uc1" TagName="wuc_Text" %>
<%@ Register Src="../Controles/wuc_RepPassWord.ascx" TagPrefix="uc1" TagName="wuc_RepPassWord" %>
<%@ Register Src="../Controles/wuc_PassWord.ascx" TagPrefix="uc1" TagName="wuc_PassWord" %>
<%@ Register Src="../Controles/wuc_Email.ascx" TagPrefix="uc1" TagName="wuc_Email" %>
<%@ Register Src="../Controles/wuc_NumeroEmpleado.ascx" TagPrefix="uc1" TagName="wuc_NumeroEmpleado" %>
<%@ Register Src="../Controles/wuc_CrearUsuarioPassWord.ascx" TagPrefix="uc1" TagName="wuc_CrearUsuarioPassWord" %>
<%@ Register Src="../Controles/wuc_CrearUsuarioCorreo.ascx" TagPrefix="uc1" TagName="wuc_CrearUsuarioCorreo" %>
<%@ MasterType VirtualPath="../PaginasMaestras/MasterCoordinadorMenu.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphContenedorBase" runat="server">
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
                        <uc1:wuc_text runat="server" ID="tbNombre" />
                    </div>
                </div>
                <br />
                <div class="form-group row">
                    <label class="col-sm-2 col-form-label">Apellido Paterno</label>
                    <div class="col-sm-10">
                        <uc1:wuc_text runat="server" ID="tbAPat" />
                    </div>
                </div>
                <br />
                <div class="form-group row">
                    <label class="col-sm-2 col-form-label">Apellido Materno</label>
                    <div class="col-sm-10">
                        <uc1:wuc_text runat="server" ID="tbAMat" ValidateRequestMode="Disabled"/>
                    </div>
                </div>
                <br />
                <div class="form-group row">
                    <label class="col-sm-2 col-form-label">Numero Empleado</label>
                    <div class="col-sm-10">
                        <uc1:wuc_numeroempleado runat="server" ID="tbNumeroEmpleado" />
                    </div>
                </div>
                <br />
                <div class="form-group row">
                    <label class="col-sm-2 col-form-label">Correo Institucional</label>
                    <div class="col-sm-10">
                        <uc1:wuc_crearusuariocorreo runat="server" ID="tbEmail" />
                    </div>
                </div>
                <br />
                <div class="form-group row">
                    <label class="col-sm-2 col-form-label">Contraseña</label>
                    <div class="col-sm-10">
                        <asp:Button ID="BtnCambio" CssClass="btn btn-success" runat="server" Text="Cambiar Contraseña" OnClick="BtnCambio_Click" />
                        <uc1:wuc_reppassword runat="server" ID="TbRepPassWord" visible="false"/>
                    </div>
                </div>
                <br />
                <br />
                <div class="form-row text-center">

                    <asp:Button ID="BtnGuardar" runat="server" CssClass="btn btn-success boton" Text="Guardar" CausesValidation="false" OnClick="Button1_Click"></asp:Button>
                    <br />
                    <asp:Label ID="lblRespuesta" runat="server" CssClass="text-danger"></asp:Label>
                </div>
            </div>
            <div class="col-4">
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