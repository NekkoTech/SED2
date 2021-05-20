<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wuc_Email.ascx.cs" Inherits="Presentacion.Controles.wuc_Email" %>
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/css/bootstrap.min.css" rel="stylesheet">
<div class="form-control">
    <asp:TextBox ID="tbEmail" placeholder="usuario@uabc.edu.mx" CssClass="form-control" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvtbEmail" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="tbEmail" CssClass="text-danger" Display="Dynamic">Especifique su correo electronico</asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="revtbEmail" runat="server" ErrorMessage="RegularExpressionValidator" ControlToValidate="tbEmail" Display="Dynamic" CssClass="text-danger" ValidationExpression="\w+([-+.']\w+)*@uabc.edu.mx">Formato de email erroneo</asp:RegularExpressionValidator>
</div>