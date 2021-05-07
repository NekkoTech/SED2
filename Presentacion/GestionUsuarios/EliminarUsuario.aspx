<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="~/PaginasMaestras/MP_BaseMaster.Master" AutoEventWireup="true" CodeBehind="EliminarUsuario.aspx.cs" Inherits="Presentacion.GestionUsuarios.EliminarUsuario" %>


<%@ MasterType VirtualPath="../PaginasMaestras/MasterDocenteMenu.Master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CphContenedorBase" runat="server">

    <br />
    <div class="container">
        <nav style="--bs-breadcrumb-divider: '>';" aria-label="breadcrumb">
            <ol class="breadcrumb bg-white">
                <li class="breadcrumb-item"><a href="InicioMain.aspx">Inicio</a></li>
                <li class="breadcrumb-item"><a href="ListaUsuarios.aspx">Administrar Usuarios</a></li>
                <li class="breadcrumb-item active">Eliminar Usuario</li>
            </ol>
        </nav>
        <div class="form-group row">
            <label class="col-sm-2 col-form-label">Nombre(s)</label>
            <div class="col-sm-10">
                <asp:TextBox ID="tbNombre" CssClass="form-control box" runat="server" Enabled="False"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="form-group row">
            <label class="col-sm-2 col-form-label">Apellido Paterno</label>
            <div class="col-sm-10">
                <asp:TextBox ID="tbAPat" CssClass="form-control box" runat="server" Enabled="False"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="form-group row">
            <label class="col-sm-2 col-form-label">Apellido Materno</label>
            <div class="col-sm-10">
                <asp:TextBox ID="tbAMat" CssClass="form-control box" runat="server" Enabled="False"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="form-group row">
            <label class="col-sm-2 col-form-label">Numero Empleado</label>
            <div class="col-sm-10">
                <asp:TextBox ID="tbNumeroEmpleado" CssClass="form-control box" runat="server" Enabled="False"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="form-group row">
            <label class="col-sm-2 col-form-label">Correo Institucional</label>
            <div class="col-sm-10">
                <asp:TextBox ID="tbEmail" CssClass="form-control box" runat="server" Enabled="False"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="form-group row">
            <label class="col-sm-2 col-form-label">Contraseña</label>
            <div class="col-sm-10">
                <asp:TextBox ID="tbPassWord" CssClass="form-control box" runat="server" Enabled="False"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class=" text-center">

            <asp:Button runat="server" ID="btnSubdirector" CssClass="btn btn-light btn-outline-dark mb-2 box margen" CausesValidation="false" Text="SUBDIRECTOR"></asp:Button>


            <asp:Button runat="server" ID="btnCoordinador" CssClass="btn btn-light btn-outline-dark mb-2 box margen" CausesValidation="false" Text="COORDINADOR"></asp:Button>


            <asp:Button runat="server" ID="btnDocente" CssClass="btn btn-light btn-outline-dark mb-2 box margen" CausesValidation="false" Text="DOCENTE"></asp:Button>


        </div>
        <br />
        <div class="align-content-center text-center">
            <asp:Button runat="server" ID="btnRegresar" CssClass="btn mb-2 boton margen whitefont" CausesValidation="false" Text="Regresar" OnClick="btnRegresar_Click"></asp:Button>
            <asp:Button runat="server" ID="btnBorrar" CssClass="btn mb-2 boton margen whitefont" CausesValidation="false" Text="Eliminar" OnClick="btnBorrar_Click"></asp:Button>
            <br />
            <asp:Label ID="lblRespuesta" runat="server" CssClass="text-danger"></asp:Label>
        </div>
    </div>

</asp:Content>
