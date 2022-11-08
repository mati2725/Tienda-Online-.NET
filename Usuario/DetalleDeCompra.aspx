<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetalleDeCompra.aspx.cs" Inherits="Tp_Integrador___Grupo3.DetalleDeCompra" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">


        .auto-style3 {
            font-size: xx-large;
            color: #000000;
            height: 35px;
            text-align: center;
            background-color: #00CC99;
        }
        .auto-style4 {
            margin-left: 575px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

                <table style="width:100%">
            <tr>
                <td style="width:15%; text-align:center">
                    <asp:Button ID="Button1" runat="server" Text="Todas las categorias" OnClick="Button1_Click" />
                </td>
                <td style="width:65%">
                    <asp:TextBox ID="TextBox1" runat="server" Width="80%"></asp:TextBox>
                    <asp:Button ID="Button2" runat="server" Text="Buscar" OnClick="Button2_Click" />
                </td>
                <td>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Usuario/Carrito.aspx">Carrito</asp:HyperLink>
                </td>
                <td>
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Usuario/MiCuenta.aspx">Mi Cuenta</asp:HyperLink>
                </td>
            </tr>

                </table>
                <h1 class="auto-style3">DETALLE DE LA COMPRA</h1>
                
                <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
                
            </form>
</body>
</html>
