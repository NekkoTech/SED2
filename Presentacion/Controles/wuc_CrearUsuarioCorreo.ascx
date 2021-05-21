<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wuc_CrearUsuarioCorreo.ascx.cs" Inherits="Presentacion.Controles.wuc_CrearUsuarioCorreo" %>
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/css/bootstrap.min.css" rel="stylesheet">
<link href="../CSS/CrearUsuarios.css" rel="stylesheet">
    <asp:TextBox ID="tbEmail" CssClass="form-control box" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvtbEmail" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="tbEmail" CssClass="text-danger" Display="Dynamic">Campo requerido</asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="revtbEmail" runat="server" ErrorMessage="RegularExpressionValidator" ControlToValidate="tbEmail" Display="Dynamic" CssClass="text-danger" ValidationExpression="\w+([-+.']\w+)*@uabc.edu.mx*">Formato de correo electronico erroneo</asp:RegularExpressionValidator>
