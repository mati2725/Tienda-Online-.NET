<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MostrarCategorias.aspx.cs" Inherits="Tp_Integrador___Grupo3.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    </head>
<body>
    <form id="form1" runat="server">
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Categorias] WHERE ([Estado_Cat] = @Estado_Cat)">
            <SelectParameters>
                <asp:Parameter DefaultValue="True" Name="Estado_Cat" Type="Boolean" />
            </SelectParameters>
        </asp:SqlDataSource>
        <table style="width:100%">
            <tr>
                <td style="width:15%; text-align:center">
                    <asp:Button ID="Button3" runat="server" Height="26px" OnClick="Button3_Click" Text="Todos los productos" Width="182px" />
                    <br />
                    <asp:Button ID="Button1" runat="server" Text="Todas las categorias" OnClick="Button1_Click" Height="26px" Width="182px" />
                </td>
                <td style="width:65%">
                    <asp:TextBox ID="TextBox1" runat="server" Width="80%"></asp:TextBox>
                    <asp:Button ID="Button2" runat="server" Text="Buscar" OnClick="Button2_Click" />
                </td>
                <td>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Registrarse.aspx">Registrarse</asp:HyperLink>
                    <br />
                    <asp:Label ID="lblUsuario" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/IniciarSesion.aspx">Iniciar Sesión</asp:HyperLink>
                    <br />
                    <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/Usuario/Carrito.aspx">Carrito</asp:HyperLink>
                    <br />
                </td>
            </tr>
        </table>
        <h1 style="text-align: center; background-color: #00CC99; height: 35px; font-size: xx-large; color: #000000;">
            CATEGORÍAS</h1>
        <br />
        <div style="width:50%; margin: 0 auto;">
            <br />
            <br />
            <br />
            <asp:DataList ID="dlMarcas" runat="server" DataSourceID="SqlDataSource1" Width="100%"  CellPadding="10" ForeColor="#333333">
                <ItemTemplate>
                    <asp:Button ID="btnMarca" runat="server" Width="100%" style="text-align:center" CommandArgument='<%# Eval("IdCategoria_Cat") %>' Text='<%# Eval("Nombre_Cat") %>' Font-Size="30px"  Font-Bold="True" CommandName="EventoSeleccionar" OnCommand="btnMarca_Command" />
                </ItemTemplate>
                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            </asp:DataList>
        </div>
    </form>
</body>
</html>
