<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wuc_PassWord.ascx.cs" Inherits="Presentacion.Controles.wuc_PassWord" %>
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/css/bootstrap.min.css" rel="stylesheet">
<div class="form-control">
    <asp:TextBox ID="tbPassWord" placeholder="Contraseña" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvtbPassWord" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="tbPassWord" CssClass="text-danger" Display="Dynamic">Especifique su Contraseña</asp:RequiredFieldValidator>
</div>
