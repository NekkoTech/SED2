<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wuc_CrearUsuarioPassWord.ascx.cs" Inherits="Presentacion.Controles.wuc_CrearUsuarioPassWord" %>
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/css/bootstrap.min.css" rel="stylesheet">
<link href="../CSS/CrearUsuarios.css" rel="stylesheet">
    <asp:TextBox ID="tbPassWord" CssClass="form-control box" runat="server" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvtbPassWord" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="tbPassWord" CssClass="text-danger" Display="Dynamic">Especifique su Contraseña</asp:RequiredFieldValidator>
