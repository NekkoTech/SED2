<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/MasterCoordinadorMenu.Master" AutoEventWireup="true" CodeBehind="FechaCoordinador.aspx.cs" Inherits="Presentacion.GestionUsuarios.FechaCoordinador" %>

<%@ MasterType VirtualPath="../PaginasMaestras/MasterCoordinadorMenu.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphContenedorBase" runat="server">
       <div class="text-center">
    <asp:Label ID="Label1" runat="server" Text="Asignar fechas de entrega: Encuadres y RSA"></asp:Label>
        </div>
    <div class="container-sm w-50 card rounded-3 text-center">
        <div class="card-body">
            <asp:Label ID="Label2" runat="server" Text="Seleccione fechas de entrega para los documentos"></asp:Label>
    <div class="text-center">
    <asp:Label ID="lblFechas" runat="server" Text=""></asp:Label>
        </div>
            <div class="container">
            <div class="form-group row">
            <table>
                <tr>
                    <td>
                    <div>
                        <asp:Label ID="lblInicio" runat="server" Text="Inicio de entrega:   "></asp:Label>
                        <asp:TextBox ID="tbInicio" runat="server" Enabled="false"></asp:TextBox>
                        <asp:ImageButton ID="IBInicio" runat="server" Height="17px" ImageUrl="../img/calendar.png" Width="21px" OnClick="IBInicio_Click" />
                        <asp:Calendar ID="CInicio" runat="server" onselectionchanged="CInicio_SelectionChanged" Visible="False"></asp:Calendar>
                    </div>
                    </td>
                    <td>
                    <div>
                        <asp:Label ID="lblFinal" runat="server" Text="Fin de entrega:   "></asp:Label>
                        <asp:TextBox ID="tbFinal" runat="server" Enabled="false"></asp:TextBox>
                        <asp:ImageButton ID="IBFinal" runat="server" Height="17px" ImageUrl="../img/calendar.png" Width="21px" OnClick="IBFinal_Click" />
                        <asp:Calendar ID="CFinal" runat="server" onselectionchanged="CFinal_SelectionChanged" Visible="False"></asp:Calendar>
                    </div>
                    </td>
                    </tr>
            </table>
                </div>
                </div>
                    <asp:Button ID="btnGuardar" runat="server" CssClass="btn-success rounded" Text="Guardar Fechas" Width="150px" OnClick="btnGuardar_Click1" />
                </div>

            </div>
        </div>

    </div>







</asp:Content>
