<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GestionMenu.aspx.cs" Inherits="Tp_Integrador___Grupo3.GestionMenu" %>

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
            font-size: large;
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
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/GestionMenu.aspx">Administrar página</asp:HyperLink>
                </td>
                <td>
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/IniciarSesion.aspx">Cerrar Sesión</asp:HyperLink>
                </td>
            </tr>
        </table>
        <div style="text-align:center">
                <h1 class="auto-style3">GESTIÓN</h1>
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Gestion/GestionProductos.aspx" CssClass="auto-style4">Productos</asp:HyperLink>
            <br class="auto-style4" />
            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Gestion/GestionCategoria.aspx" CssClass="auto-style4">Categorías</asp:HyperLink>
            <br class="auto-style4" />
            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Gestion/GestionMarca.aspx" CssClass="auto-style4">Marcas</asp:HyperLink>
            <br class="auto-style4" />
            <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/Gestion/GestionUsuarios.aspx" CssClass="auto-style4">Usuarios</asp:HyperLink>
            <br />
                <h1 class="auto-style3">GESTIÓN<strong> REPORTES Y ESTADÍSTICAS</strong></h1>
            <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/Gestion/EstadisticasCategorias.aspx" CssClass="auto-style4">Ventas por Categoria</asp:HyperLink>
            <br class="auto-style4" />
            <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/Gestion/EstadisticasMarcas.aspx" CssClass="auto-style4">Ventas por Marca</asp:HyperLink>
            <br />
        </div>
    </form>
</body>
</html>
