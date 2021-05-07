<%@ Page Title="" MaintainScrollPositionOnPostback="true"  Language="C#" MasterPageFile="~/PaginasMaestras/MasterDocenteMenu.Menu" AutoEventWireup="true" CodeBehind="ModificarUsuario.aspx.cs" Inherits="Presentacion.GestionUsuarios.ModificarUsuario" %>

<%@ Register Src="../Controles/wuc_Text.ascx" TagPrefix="uc1" TagName="wuc_Text" %>
<%@ Register Src="../Controles/wuc_NumeroEmpleado.ascx" TagPrefix="uc1" TagName="wuc_NumeroEmpleado" %>
<%@ Register Src="../Controles/wuc_CrearUsuarioCorreo.ascx" TagPrefix="uc1" TagName="wuc_CrearUsuarioCorreo" %>
<%@ Register Src="../Controles/wuc_CrearUsuarioPassWord.ascx" TagPrefix="uc1" TagName="wuc_CrearUsuarioPassWord" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphContenedorBase" runat="server">
    <br />
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
                <asp:TextBox  runat="server" ID="tbPassWord" CssClass="form-control box"></asp:TextBox>
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
                <asp:Button runat="server" CssClass="btn btn-primary mb-2 boton" Text="Modificar" OnClick="Button1_Click"></asp:Button><br />
            <asp:Label ID="lblRespuesta" runat="server" CssClass="text-danger"></asp:Label>
        </div>

</asp:Content>
