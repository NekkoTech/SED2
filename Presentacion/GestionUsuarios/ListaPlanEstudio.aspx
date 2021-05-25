<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/MasterAdministradorMenu.Master" AutoEventWireup="true" CodeBehind="ListaPlanEstudio.aspx.cs" Inherits="Presentacion.GestionUsuarios.ListaPlanEstudio" %>

<%@ MasterType VirtualPath="../PaginasMaestras/MasterAdministradorMenu.Master" %>

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
            <div class="col-2 align-content-start">
                <asp:Button ID="BtnAgregar" runat="server" CssClass="btn btn-success form-control" Text="Agregar" OnClick="BtnAgregar_Click" />
            </div>
            <div class="col-2">
                <asp:Label ID="Label2" runat="server" CssClass="col-form-label" Text="Buscar Plan"></asp:Label>
            </div>
            <div class="col-2 align-middle">
                <asp:TextBox ID="TbSearch" runat="server" CssClass="form-control w-auto"></asp:TextBox>
                
            </div>
            <div class="col-1">
                <asp:Button ID="BtnBuscar" runat="server" CssClass="btn btn-success form-control w-auto" Text="Buscar" OnClick="btnBuscar_Click" />
            </div>
        </div>
        <div class="row">
            <div class="text-center">

                <asp:GridView ID="GvPlanes" CssClass="GridViewStyle" HeaderStyle-CssClass="HeaderStyle" runat="server" AutoGenerateColumns="False" DataKeyNames="IdPlan" OnRowCommand="GvPlanes_RowCommand" OnSelectedIndexChanged="GvPlanes_SelectedIndexChanged" Width="920px">
                    <Columns>
                        <asp:BoundField DataField="NombrePlan" HeaderText="Nombre del plan de estudio" SortExpression="NombrePlan" />
                        <asp:TemplateField HeaderText="Acciones" ItemStyle-Width="200px">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnModificar" CssClass="btn LinkButton2 btn-outline-warning"  CommandName="Modificar" CommandArgument="<%# Container.DataItemIndex%>" runat="server" Width="50"  Height="45"></asp:LinkButton>
                                <asp:LinkButton ID="btnBorrar"  CssClass="btn LinkButton btn-outline-danger"   CommandArgument="<%# Container.DataItemIndex%>" CommandName="Borrar" runat="server" Width="50" Height="45"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
                <br />

                <asp:GridView ID="GvPlanesSubdirector" CssClass="GridViewStyle" HeaderStyle-CssClass="HeaderStyle" runat="server" AutoGenerateColumns="False" DataKeyNames="IdPlan" Width="920px" DataSourceID="SDSPlanEstudio" OnSelectedIndexChanged="GvPlanesSubdirector_SelectedIndexChanged" OnRowCommand="GvPlanesSubdirector_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="NombrePlan" HeaderText="Nombre del plan de estudio" SortExpression="NombrePlan" />
                        <asp:TemplateField HeaderText="Acciones" ItemStyle-Width="200px">
                            <ItemTemplate>
                                <asp:Button ID="BtnConsultar" runat="server" Text="Consultar" CommandName="Consultar" CommandArgument="<%# Container.DataItemIndex%>"  CssClass="btn btn-success"/>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SDSPlanEstudio" runat="server" ConnectionString="<%$ ConnectionStrings:ConexionBD %>" SelectCommand="SELECT [IdPlan], [NombrePlan] FROM [PlanEstudio]"></asp:SqlDataSource>
            </div>

        </div>

    </div>
    <!--Modal De Funcionamiento de peticiones-->
        <div id="master-modal-agregar" class="modal fade" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false">
            <div class="modal-dialog modal-notify modal-info" role="document">
                <div class="modal-content">
                    <div id="AModalHeader" runat="server">
                        <p class="heading lead text-center"><span id="AModalTitulo" runat="server"></span></p>
                    </div>
                    <div class="modal-body">
                        <span id="AModalBody" runat="server"></span>
                    </div>
                    <div class="modal-footer">
                            
                            <asp:Button ID="BtnModalAgregar" type="button" CssClass="btn btn-success" runat="server" OnClick="Agregar_Click" Text="Agregar"/>
                            
                    </div>
                </div>
            </div>
        </div>
    <!--Modal De Funcionamiento de peticiones-->
        <div id="master-modal-peticiones" class="modal fade" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false">
            <div class="modal-dialog modal-notify modal-info" role="document">
                <div class="modal-content">
                    <div id="EModalHeader" runat="server">
                        <p class="heading lead text-center"><span id="EModalTitulo" runat="server"></span></p>
                    </div>
                    <div class="modal-body">
                        <span id="EModalBody" runat="server"></span>
                    </div>
                    <div class="modal-footer">
                            <asp:Button ID="BtnRegresar" type="button" CssClass="btn btn-success" runat="server" data-dismiss="modal" Text="Regresar"/>
                            <asp:Button ID="BtnEliminar" type="button" CssClass="btn btn-danger" runat="server" OnClick="Eliminar_Click" Text="Eliminar"/>
                    </div>
                </div>
            </div>
        </div>
    <script>
        
        function openMasterModalPeticion() {
            $('#master-modal-peticiones').modal('show');
        }
        function openMasterModalAgregar() {
            $('#master-modal-agregar').modal('show');
        }
    </script>
</asp:Content>
