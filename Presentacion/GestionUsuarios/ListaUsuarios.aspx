<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/MP_BaseMaster.Master" AutoEventWireup="true" CodeBehind="ListaUsuarios.aspx.cs" Inherits="Presentacion.GestionUsuarios.ListaUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphContenedorBase" runat="server">
<br />
    <div>
       <asp:TextBox class="form-control box" ID="TextBox1" runat="server"></asp:TextBox>

    </div>
    <br />
    <table class="table table-bordered">
        <thead>
            <tr>
                <th scope="col">Nombre</th>
                <th scope="col">Carrera</th>
                <th scope="col">Accion</th>
            </tr>
        </thead>
    </table>
</asp:Content>

