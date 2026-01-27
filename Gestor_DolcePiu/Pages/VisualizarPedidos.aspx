<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Pedidos.Master" AutoEventWireup="true" CodeBehind="VisualizarPedidos.aspx.cs" Inherits="Gestor_DolcePiu.Pages.VisualizarPedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Aca va el contenido de Visualizar Pedidos
     <div class="container-fluid">
         <div class="row">
             <div class="col">
                 <asp:GridView ID="gdvPedidos" runat="server" CssClass="table" DataKeyNames="Id" AutoGenerateColumns="false"
                     OnSelectedIndexChanged="gdvPedidos_SelectedIndexChanged" AllowPaging="True" PageSize="5">
                     <Columns>
                         <asp:BoundField DataField="Id" HeaderText="Numero de Pedido" />
                         <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                         <asp:BoundField DataField="Estado" HeaderText="Estado" />
                         <asp:CommandField HeaderText="Visualizar Factura" ShowSelectButton="true" SelectText="Ver" />
                     </Columns>
                 </asp:GridView>
             </div>

             <div class="col">
                 <%if (clickeado)
                     {  %>
                 <div>
                     <ul class="list-group list-group-flush">
                         <li class="list-group-item active">Factura Nº:
                             <asp:Label ID="lblFactura" runat="server" Text=""></asp:Label></li>
                         <li class="list-group-item">Cliente:
                             <asp:Label ID="lblCliente" runat="server" Text=""></asp:Label></li>
                         <li class="list-group-item">Fecha:
                             <asp:Label ID="lblFecha" runat="server" Text=""></asp:Label></li>
                         <li class="list-group-item">Pago:
                             <asp:Label ID="lblPago" runat="server" Text=""></asp:Label></li>
                         <li class="list-group-item">Total:
                             <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label></li>
                     </ul>
                 </div>
                 <div style="height:400px; overflow-y:auto;">
                     <asp:GridView ID="gdvDetallesPedido" runat="server" CssClass="table table-success table-striped-columns" DataKeyNames="Id" AutoGenerateColumns="false">
                         <Columns>
                             <asp:BoundField DataField="Id" HeaderText="Codigo prod." />
                             <asp:BoundField DataField="Nombre" HeaderText="Producto" />
                             <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                             <asp:BoundField DataField="Precio" HeaderText="Precio Unitario" />
                         </Columns>
                     </asp:GridView>
                 </div>
                 <% } %>
             </div>
         </div>
     </div>
</asp:Content>
