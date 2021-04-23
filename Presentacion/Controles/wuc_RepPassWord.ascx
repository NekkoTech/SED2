<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wuc_RepPassWord.ascx.cs" Inherits="Presentacion.Controles.wuc_RepPassWord" %>
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/css/bootstrap.min.css" rel="stylesheet">
<div class="form-control">
    <asp:TextBox ID="tbPassWord" placeholder="Nueva Contraseña" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvtbPassWord" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="tbPassWord" CssClass="text-danger" Display="Dynamic">Especifique la nueva contraseña</asp:RequiredFieldValidator>
    <br />
    <asp:TextBox ID="tbRepPassWord" placeholder="Repite Contraseña" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvtbRepPassWord" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="tbRepPassWord" CssClass="text-danger" Display="Dynamic">Se requiere confirmar la contraseña</asp:RequiredFieldValidator>
    <br />
    <asp:CompareValidator ID="cvPassWords" runat="server" ControlToCompare="tbRepPassWord" ControlToValidate="tbPassWord" Display="Dynamic" CssClass="text-danger" ErrorMessage="CompareValidator">La contraseña y la confirmacion no son iguales</asp:CompareValidator>
</div>