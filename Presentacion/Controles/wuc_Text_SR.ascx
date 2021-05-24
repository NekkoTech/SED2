<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wuc_Text_SR.ascx.cs" Inherits="Presentacion.Controles.wuc_Text_SR" %>
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/css/bootstrap.min.css" rel="stylesheet">
 <link href="../CSS/CrearUsuarios.css" rel="stylesheet">

<asp:TextBox ID="tbTexto"  CssClass="form-control box w-100" runat="server"></asp:TextBox>
<asp:RegularExpressionValidator ID="revtbTexto" runat="server" ErrorMessage="RegularExpressionValidator" ControlToValidate="tbTexto" Display="Dynamic" CssClass="text-danger" ValidationExpression="^[A-Za-zñÑ ]+$">Caracter invalido</asp:RegularExpressionValidator>
