<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/MasterDocenteMenu.Master" AutoEventWireup="true" CodeBehind="CuentaDocente.aspx.cs" Inherits="Presentacion.GestionUsuarios.CuentaDocente" %>

<%@ Register Src="~/Controles/wuc_Text.ascx" TagPrefix="uc1" TagName="wuc_Text" %>
<%@ Register Src="~/Controles/wuc_RepPassWord.ascx" TagPrefix="uc1" TagName="wuc_RepPassWord" %>
<%@ Register Src="~/Controles/wuc_PassWord.ascx" TagPrefix="uc1" TagName="wuc_PassWord" %>
<%@ Register Src="~/Controles/wuc_Email.ascx" TagPrefix="uc1" TagName="wuc_Email" %>
<%@ Register Src="~/Controles/wuc_NumeroEmpleado.ascx" TagPrefix="uc1" TagName="wuc_NumeroEmpleado" %>
<%@ Register Src="~/Controles/wuc_CrearUsuarioPassWord.ascx" TagPrefix="uc1" TagName="wuc_CrearUsuarioPassWord" %>
<%@ Register Src="~/Controles/wuc_CrearUsuarioCorreo.ascx" TagPrefix="uc1" TagName="wuc_CrearUsuarioCorreo" %>



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
                        <uc1:wuc_Text runat="server" ID="tbAMat" />
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
                        <uc1:wuc_CrearUsuarioPassWord runat="server" ID="tbPassWord" />
                    </div>
                </div>
                <br />
                <br />
                <div class="form-row text-center">

                    <asp:Button runat="server" CssClass="btn btn-primary mb-2 boton" Text="Guardar" OnClick="Button1_Click"></asp:Button>
                    <asp:Label ID="lblRespuesta" runat="server" CssClass="text-danger"></asp:Label>
                </div>
            </div>
            <div class="col-4">
                
                
                <div class="card" style="width: 20rem; top: 0px; left: 0px;">
                    <a href='<%# string.Format("http://localhost:64369/Handler/RecuperaArchivo.ashx?IdUsuario={0}",Eval("IdUsuario")) %>'></a>
                    <asp:Image ID="ImgFirma" Width="300px" Height="250px" CssClass="card-img" ImageUrl='<%# string.Format("http://localhost:64369/Handler/RecuperaArchivo.ashx?IdUsuario={0}", Eval("IdUsuario")) %>' runat="server" />
                    <div class="card-body">
                        <asp:FileUpload ID="FuFirma" runat="server" CssClass="form-control" Width="250px" />
                        <asp:Button ID="BtnSubirArchivo" CssClass="btn btn-success" Width="60px" runat="server" Text="Subir" CausesValidation="false" OnClick="BtnSubirArchivo_Click1" />
                        <asp:Button ID="BtnSubir" CssClass="btn btn-success" Width="60px" runat="server" Text="Subir" OnClick="BtnSubir_Click" CausesValidation="false"/>
                    </div>
                </div>
            </div>

        </div>
    </div>


</asp:Content>
