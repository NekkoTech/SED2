<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wuc_NumeroEmpleado.ascx.cs" Inherits="Presentacion.Controles.wuc_NumeroEmpleado" %>
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/css/bootstrap.min.css" rel="stylesheet">
<link href="../CSS/CrearUsuarios.css" rel="stylesheet">

<asp:TextBox ID="tbNumeroEmpleado"  CssClass="form-control box" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="rfvtbNumeroEmpleado" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="tbNumeroEmpleado" CssClass="text-danger" Display="Dynamic">Campo Requerido</asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="revtbNumeroEmpleado" runat="server" ErrorMessage="RegularExpressionValidator" ControlToValidate="tbNumeroEmpleado" Display="Dynamic" CssClass="text-danger" ValidationExpression="^[0-9]{5}$">Formato invalido</asp:RegularExpressionValidator>
