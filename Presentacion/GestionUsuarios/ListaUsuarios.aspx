<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/MasterAdministradorMenu.Master" AutoEventWireup="true" CodeBehind="ListaUsuarios.aspx.cs" Inherits="Presentacion.GestionUsuarios.ListaUsuarios" %>
<%@ MasterType VirtualPath="../PaginasMaestras/MasterAdministradorMenu.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphContenedorBase" runat="server">
    <link href="../CSS/CrearUsuarios.css" rel="stylesheet">
    <br />
    <div class="container">
        <nav style="--bs-breadcrumb-divider: '>';" aria-label="breadcrumb">
            <ol class="breadcrumb bg-white">
                <li class="breadcrumb-item"><a href="InicioMain.aspx">Inicio</a></li>
                <li class="breadcrumb-item active" aria-current="page">Administrar Usuarios</li>
            </ol>
        </nav>
    </div>
    
    <div class="container">
        <div class="form-group row">

         <asp:Panel runat="server" ID="pnlSearch" DefaultButton="btnBuscar">
        <div class="form-group row">
            <label class="col-sm-2 col-form-label">Tipo Usuario</label>
            <label class="col-sm-2 col-form-label ">Buscar Usuario</label>
            <div class="col-sm-10">
                <asp:DropDownList runat="server" ID="ddlTest" AutoPostBack="true" OnSelectedIndexChanged="ddlTest_SelectedIndexChanged">
                    <asp:ListItem Text="Todos" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Docente" Value="4"></asp:ListItem>
                    <asp:ListItem Text="Coordinador" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Sub Director" Value="2"></asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox class="form-control box2" ID="TextBox1" runat="server"></asp:TextBox>
                <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-primary mb-2 boton2" Text="Buscar" OnClick="btnBuscar_Click" />
                  <asp:Button CssClass="btn btn-primary mb-2 boton2" Text="Crea Usuario" runat="server" OnClick="Unnamed1_Click" />
            </div>

        </div>
        </asp:Panel>

        </div>
        <br />
        <div class="col text-center">
            <asp:GridView ID="GvUsuarios" runat="server" CssClass="GridViewStyle w-auto" HeaderStyle-CssClass="HeaderStyle" AutoGenerateColumns="False" DataKeyNames="IdUsuario" OnSelectedIndexChanged="GvUsuarios_SelectedIndexChanged" OnRowCommand="GvUsuarios_RowCommand" Width="1245px" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="NombreUsuario" HeaderText="Nombre" SortExpression="NombreUsuario" ItemStyle-Width="400px">
                    <ItemStyle Width="400px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="EmailUsuario" HeaderText="Correo" SortExpression="EmailUsuario" ItemStyle-Width="300px">
                    <ItemStyle Width="300px"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField HeaderText="Acciones" ItemStyle-Width="200px">
                    <ItemTemplate >
                        <asp:LinkButton ID="btnModificar" CssClass="btn LinkButton2 btn-outline-success" CommandName="Modificar" CommandArgument="<%# Container.DataItemIndex%>" runat="server" Width="50" Height="45"></asp:LinkButton>
                         <asp:LinkButton ID="btnBloquear" CssClass="btn LinkButton3 btn-outline-Warning" CommandName="Bloquear" CommandArgument="<%# Container.DataItemIndex%>" runat="server" Width="50" Height="45"></asp:LinkButton>
                        <asp:LinkButton ID="btnBorrar" CssClass="btn LinkButton btn-outline-danger" CommandArgument="<%# Container.DataItemIndex%>" CommandName="Borrar" runat="server" Width="50" Height="45"></asp:LinkButton>
                    </ItemTemplate>

                    <ItemStyle Width="200px"></ItemStyle>
                </asp:TemplateField>

            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />

            <HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        </div>
        
    </div>
    <asp:SqlDataSource ID="Usuarios" runat="server"
        ConnectionString="<%$ ConnectionStrings:ConexionBD %>"
        SelectCommand="SELECT [IdUsuario],[NombreUsuario], [EmailUsuario] FROM [Usuarios]"></asp:SqlDataSource>
    <br />

     <div id="confirmation-modal-mensaje" class="modal fade" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false">
            <div class="modal-dialog modal-notify modal-info" role="document">
                <div class="modal-content">
                    <div id="ModalHeader" runat="server">
                        <p class="heading lead text-center"><span id="ModalTitulo" runat="server"></span></p>
                    </div>
                    <div class="modal-body">
                        <span id="ModalBody" runat="server"></span>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" OnClick="btnConfirmar_Click" data-dismiss="modal"/>
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" data-dismiss="modal"/>
                    </div>
                </div>
            </div>
        </div>


            <script>
            $('#MyModal').on('shown.bs.modal', function () {
                $('#myInput').trigger('focus')
            })
            function openconfirmationModalMensaje() {
                $('#confirmation-modal-mensaje').modal('show');
            }
        </script>

                <div id="redireccion-modal-mensaje" class="modal fade" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false">
            <div class="modal-dialog modal-notify modal-info" role="document">
                <div class="modal-content">
                    <div id="Encabezado" runat="server">
                        <p class="heading lead text-center"><span id="TituloModalRedireccion" runat="server"></span></p>
                    </div>
                    <div class="modal-body">
                        <span id="CuerpoModalRedireccion" runat="server"></span>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnAceptarRedireccion" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" data-dismiss="modal"/>
                    </div>
                </div>
            </div>
        </div>


            <script>
            $('#MyModal').on('shown.bs.modal', function () {
                $('#myInput').trigger('focus')
            })
            function openRedireccionModalMensaje() {
                $('#redireccion-modal-mensaje').modal('show');
            }
            </script>
</asp:Content>