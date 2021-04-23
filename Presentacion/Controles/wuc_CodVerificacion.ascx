<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wuc_CodVerificacion.ascx.cs" Inherits="Presentacion.Controles.wuc_CodVerificacion" %>
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/css/bootstrap.min.css" rel="stylesheet">
<div class="form-control">
    <asp:TextBox ID="tbCodVerificacion" placeholder="Codigo" CssClass="form-control" runat="server"></asp:TextBox>
    <br />
    <asp:RequiredFieldValidator ID="rfvtbCodVerificacion" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="tbCodVerificacion" CssClass="text-danger" Display="Dynamic">Ingrese el codigo de verificacion</asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="revtbCodVerificacion" runat="server" ErrorMessage="RegularExpressionValidator" ControlToValidate="tbCodVerificacion" Display="Dynamic" CssClass="text-danger" ValidationExpression="^[a-zA-Z]{5}$">Formato erroneo (5 letras)</asp:RegularExpressionValidator>
</div>