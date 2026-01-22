<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Pedidos.Master" AutoEventWireup="true" CodeBehind="VisualizarPedidos.aspx.cs" Inherits="Gestor_DolcePiu.Pages.VisualizarPedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Aca va el contenido de Visualizar Pedidos
     <div>
     <asp:GridView ID="gdvPedidos" runat="server" CssClass="table" DataKeyNames="Id" AutoGenerateColumns="false"
         OnSelectedIndexChanged="gdvPedidos_SelectedIndexChanged" AllowPaging="True" PageSize="5">
         <Columns>
             <asp:BoundField DataField="Id" HeaderText="Numero de Pedido" />      
             <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
             <asp:BoundField DataField="Estado" HeaderText="Estado" />
             <asp:CommandField HeaderText="Visualizar Factura" ShowSelectButton="true" SelectText="Ver"/>
         </Columns>
     </asp:GridView>
 </div>
</asp:Content>
