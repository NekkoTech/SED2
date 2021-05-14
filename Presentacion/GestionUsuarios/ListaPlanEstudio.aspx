<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/MasterAdministradorMenu.Master" AutoEventWireup="true" CodeBehind="ListaPlanEstudio.aspx.cs" Inherits="Presentacion.GestionUsuarios.ListaPlanEstudio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphContenedorBase" runat="server">
    <div class="container">
        <div class="row">
            <nav style="--bs-breadcrumb-divider: '>';" aria-label="breadcrumb">
                <ol class="breadcrumb bg-white">
                    <li class="breadcrumb-item"><a href="InicioMain.aspx">Inicio</a></li>
                    <li class="breadcrumb-item">Planes de Estudio</li>
                </ol>
            </nav>
        </div>
        <div class="row text-center align-middle">
            <div class="col-2">
                <asp:Label ID="Label1" runat="server" CssClass="col-form-label" Text="Agregar Plan de Estudio"></asp:Label>
            </div>
            <div class="col-2">
                <asp:Button ID="BtnAgregar" runat="server" CssClass="btn btn-success m-2 form-control" Text="Agregar" OnClick="BtnAgregar_Click" />
            </div>
            <div class="col-2">
                <asp:Label ID="Label2" runat="server" CssClass="col-form-label" Text="Buscar Plan"></asp:Label>
            </div>
            <div class="col-4">
                <asp:TextBox ID="TbSearch" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="text-center">

                <asp:GridView ID="GvPlanes" CssClass="table table-hover table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SDSPlanEstudio" DataKeyNames="IdPlan" OnRowCommand="GvPlanes_RowCommand" OnSelectedIndexChanged="GvPlanes_SelectedIndexChanged" >
                    <Columns>
                        <asp:BoundField DataField="NombrePlan" HeaderText="Nombre" SortExpression="NombrePlan" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnBorrar" CssClass="btn btn-outline-danger h-50" CommandArgument="<%# Container.DataItemIndex%>" CommandName="Borrar" runat="server" Text="Borrar" Width="100" />
                                <asp:Button ID="btnModificar" CssClass="btn btn-outline-warning h-50" CommandName="Modificar" CommandArgument="<%# Container.DataItemIndex%>" runat="server" Text="Modificar" Width="100" />
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SDSPlanEstudio" runat="server" ConnectionString="<%$ ConnectionStrings:ConexionBD %>" SelectCommand="SELECT [IdPlan], [NombrePlan] FROM [PlanEstudio]"></asp:SqlDataSource>
            </div>

        </div>
    </div>
</asp:Content>
