<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/MP_BaseMaster.Master" AutoEventWireup="true" CodeBehind="InfoCuenta.aspx.cs" Inherits="Presentacion.GestionUsuarios.InfoCuenta" %>

<%@ Register Src="../Controles/wuc_CrearUsuarioPassWord.ascx" TagPrefix="uc1" TagName="wuc_CrearUsuarioPassWord" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphContenedorBase" runat="server">
        <br />
    <div class="text-center">
        <asp:Label ID="lblInfoCuenta" runat="server" CssClass="xxlarge" Text="Información de su cuenta"></asp:Label>
    </div>
    <br />
       <div class="form-group row">
       <label class="col-sm-2 col-form-label">Nombre(s)</label>
    <div class="col-sm-10">
        <asp:TextBox ID="tbNombre" CssClass="form-control box" runat="server" Enabled="False"></asp:TextBox>
    </div>
   </div>
    <br />
    <div class="form-group row">
       <label class="col-sm-2 col-form-label">Apellido Paterno</label>
    <div class="col-sm-10">
        <asp:TextBox ID="tbAPat" CssClass="form-control box" runat="server" Enabled="False"></asp:TextBox>
    </div>
   </div>
    <br />
    <div class="form-group row">
       <label class="col-sm-2 col-form-label">Apellido Materno</label>
    <div class="col-sm-10">
        <asp:TextBox ID="tbAMat" CssClass="form-control box" runat="server" Enabled="False"></asp:TextBox>
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
        <uc1:wuc_CrearUsuarioPassWord runat="server" ID="tbPassWord" /><br />
        <asp:Label ID="lblIngresaContraseña" runat="server" Text="Ingrese su nueva contraseña"></asp:Label>
    </div>
   </div>
  <br />
    <div class="form-row text-center">
        <asp:Button runat="server" CssClass="btn btn-primary mb-2 boton" Text="Guardar" OnClick="Button1_Click"></asp:Button>
        <asp:Label ID="lblRespuesta" runat="server" CssClass="text-danger"></asp:Label>
    </div>
</asp:Content>
