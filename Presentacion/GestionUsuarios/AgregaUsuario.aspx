﻿<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="~/PaginasMaestras/MasterAdministradorMenu.Master" AutoEventWireup="true" CodeBehind="AgregaUsuario.aspx.cs" Inherits="Presentacion.GestionUsuarios.AgregaUsuario" %>

<%@ Register Src="../Controles/wuc_Text.ascx" TagPrefix="uc1" TagName="wuc_Text" %>
<%@ Register Src="../Controles/wuc_NumeroEmpleado.ascx" TagPrefix="uc1" TagName="wuc_NumeroEmpleado" %>
<%@ Register Src="../Controles/wuc_CrearUsuarioCorreo.ascx" TagPrefix="uc1" TagName="wuc_CrearUsuarioCorreo" %>
<%@ Register Src="../Controles/wuc_CrearUsuarioPassWord.ascx" TagPrefix="uc1" TagName="wuc_CrearUsuarioPassWord" %>
<%@ MasterType VirtualPath="../PaginasMaestras/MasterAdministradorMenu.Master" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CphContenedorBase" runat="server">
    <br />
    <br />
    <div class="container">
        <nav style="--bs-breadcrumb-divider: '>';" aria-label="breadcrumb">
            <ol class="breadcrumb bg-white">
                <li class="breadcrumb-item"><a href="InicioMain.aspx">Inicio</a></li>
                <li class="breadcrumb-item"><a href="ListaUsuarios.aspx">Administrar Usuarios</a></li>
                <li class="breadcrumb-item">Agregar Usuarios</li>
            </ol>
        </nav>
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
                <asp:TextBox ID="tbPassWord" placeholder="Contraseña" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
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
            </div><br />
          <br /><asp:Label ID="lblErrorTipoUsuario" runat="server" Text="" CssClass="text-danger"></asp:Label>
        </div>
        
        <br />
        <div class="text-center align-content-center">

            <asp:Button runat="server" CssClass="btn btn-primary mb-2 boton" Text="Guardar" OnClick="Button1_Click"></asp:Button><br />
            <asp:Label ID="lblRespuesta" runat="server" CssClass="text-danger"></asp:Label>
        </div>
    </div>
</asp:Content>
