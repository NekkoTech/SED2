<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/MasterAdministradorMenu.Master" AutoEventWireup="true" CodeBehind="ListaUsuarios.aspx.cs" Inherits="Presentacion.GestionUsuarios.ListaUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphContenedorBase" runat="server">
    <br />
    <div class="container">
        <nav style="--bs-breadcrumb-divider: '>';" aria-label="breadcrumb">
            <ol class="breadcrumb bg-white">
                <li class="breadcrumb-item"><a href="InicioMain.aspx">Inicio</a></li>
                <li class="breadcrumb-item active" aria-current="page">Administrar Usuarios</li>
            </ol>
        </nav>
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
    </div>

</asp:Content>

