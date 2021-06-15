<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/MasterDocenteMenu.Master" AutoEventWireup="true" CodeBehind="ListaRSAD.aspx.cs" Inherits="Presentacion.GestionUsuarios.ListaRSAD" %>

<%@ MasterType VirtualPath="../PaginasMaestras/MasterDocenteMenu.Master" %>
<%@ Register Src="~/Controles/wuc_RepPassWord.ascx" TagPrefix="uc1" TagName="wuc_RepPassWord" %>
<%@ Register Src="~/Controles/wuc_Email.ascx" TagPrefix="uc1" TagName="wuc_Email" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphContenedorBase" runat="server">
    <div class="container">
        <div class="row">
            <nav style="--bs-breadcrumb-divider: '>';" aria-label="breadcrumb">
                <ol class="breadcrumb bg-white">
                    <li class="breadcrumb-item"><a href="InicioDocente.aspx">Inicio</a></li>
                    <li class="breadcrumb-item">RSA</li>
                </ol>
            </nav>
        </div>
        <div class="row">
            <div class="text-center">
                <!--asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />Extraer estado de la base de datos-->
                <asp:GridView ID="GvMaterias" CssClass="GridViewStyle" HeaderStyle-CssClass="HeaderStyle" runat="server" AutoGenerateColumns="False" DataKeyNames="IdMateria" OnRowCommand="GvMaterias_RowCommand" OnSelectedIndexChanged="GvMaterias_SelectedIndexChanged" Width="900px">
                    <Columns>
                        <asp:BoundField DataField="Materia" HeaderText="Nombre Materia" SortExpression="Materia" />
                        <asp:BoundField DataField="Clave" HeaderText="Clave" SortExpression="Clave" />
                        
                        
                        <asp:TemplateField HeaderText="Acciones" ItemStyle-Width="200px">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnEvaluar"  CssClass="btn btn-success box"   CommandArgument="<%# Container.DataItemIndex%>" CommandName="Llenar" runat="server">Llenar</asp:LinkButton>
                                <asp:LinkButton ID="LinkButton1"  CssClass="btn btn-success box"   CommandArgument="<%# Container.DataItemIndex%>" CommandName="Firmar" runat="server">Firmar</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SDSPlanEstudio" runat="server" ConnectionString="<%$ ConnectionStrings:ConexionBD %>" SelectCommand="SELECT [Materia], [IdMateria], [Clave] FROM [Materias]"></asp:SqlDataSource>
                
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
    <!--Modal De Funcionamiento de peticiones-->
        <div id="master-modal-contra" class="modal fade" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false">
            <div class="modal-dialog modal-notify modal-info" role="document">
                <div class="modal-content">
                    <div id="Div1" runat="server">
                        <p class="heading lead text-center">Para Firmar el RSA es necesario ingresar su contraseña de nuevo</p>
                    </div>
                    <div class="modal-body">
                        <uc1:wuc_RepPassWord runat="server" ID="wuc_RepPassWord" />
                    </div>
                    <div class="modal-footer">
                            <asp:Button ID="Button2" type="button" CssClass="btn btn-danger" runat="server" OnClick="ComprobarContra_Click" Text="Eliminar"/>
                    </div>
                </div>
            </div>
        </div>
    <!--Modal De Funcionamiento de peticiones-->
        <div id="master-modal-correo" class="modal fade" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false">
            <div class="modal-dialog modal-notify modal-info" role="document">
                <div class="modal-content">
                    <div id="Div2" runat="server">
                        <p class="heading lead text-center">Ingrese el correo del Jefe de Grupo de la Materia</p>
                    </div>
                    <div class="modal-body">
                        <uc1:wuc_Email runat="server" ID="wuc_Email" />
                    </div>
                    <div class="modal-footer">
                            <asp:Button ID="Button1" type="button" CssClass="btn btn-danger" runat="server" OnClick="CorreoAlumno_Click" Text="Eliminar"/>
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
        function openMasterModalCorreo() {
            $('#master-modal-correo').modal('show');
        }
        function openMasterModalContra() {
            $('#master-modal-contra').modal('show');
        }

    </script>
</asp:Content>
