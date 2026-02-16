<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Pedidos.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="Gestor_DolcePiu.Pages.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Aca va el contenido de PERFIL
      <div >
          <div >
              DATOS PERSONALES
          </div>
          <div class="list-group" >
              <asp:Label ID="lblNombre" runat="server" Text="" CssClass="list-group-item" ></asp:Label>
              <asp:Label ID="lblApellido" runat="server" Text="" CssClass="list-group-item" ></asp:Label>
              <asp:Label ID="lblDni" runat="server" Text="" CssClass="list-group-item" ></asp:Label>
              <asp:Label ID="lblZona" runat="server" Text="" CssClass="list-group-item" ></asp:Label>
              <asp:Label ID="lblDireccion" runat="server" Text="" CssClass="list-group-item" ></asp:Label>              
              <asp:Label ID="lblTelefono" runat="server" Text="" CssClass="list-group-item" ></asp:Label>
              <asp:Label ID="lblEmail" runat="server" Text="" CssClass="list-group-item" ></asp:Label>
          </div>
      </div>
    
</asp:Content>
