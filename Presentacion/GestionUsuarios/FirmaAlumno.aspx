<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/UsuariosSinLogeo.master" AutoEventWireup="true" CodeBehind="FirmaAlumno.aspx.cs" Inherits="Presentacion.GestionUsuarios.FirmaAlumno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CphMainLogin" runat="server">
    <div class="col-4">


                <div class="card" style="width: 20rem; top: 0px; left: 0px;">
                    
                    
                    <asp:Image ID="ImgFirma" runat="server" Width="300px" Height="250px" CssClass="card-img" />
                    <div class="card-body">
                        <asp:FileUpload ID="FuFirma" runat="server" CssClass="form-control" Width="250px" />
                        <asp:Label ID="LblMensaje" runat="server"></asp:Label>
                        <asp:Button ID="BtnSubir" CssClass="btn btn-success" Width="60px" runat="server" Text="Subir" OnClick="BtnSubir_Click" CausesValidation="false" />
                        <asp:Button ID="BtnFirmar" CssClass="btn btn-success" Width="60px" runat="server" Text="Firmar" OnClick="BtnFirmar_Click" CausesValidation="false" />
                    </div>
                </div>
            </div>
</asp:Content>
