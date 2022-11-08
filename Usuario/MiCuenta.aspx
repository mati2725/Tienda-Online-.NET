<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MiCuenta.aspx.cs" Inherits="Tp_Integrador___Grupo3.MiCuenta1" %>

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
        .auto-style5 {
            font-weight: bold;
        }
        .auto-style6 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <table style="width:100%">
            <tr>
                <td style="width:15%; text-align:center">
                    <asp:Button ID="Button6" runat="server" Height="26px" OnClick="Button6_Click" Text="Todos los productos" Width="182px" />
                    <br />
                    <asp:Button ID="Button1" runat="server" Text="Todas las categorias" OnClick="Button1_Click" />
                </td>
                <td style="width:65%">
                    <asp:TextBox ID="TextBox1" runat="server" Width="74%"></asp:TextBox>
                    <asp:Button ID="Button2" runat="server" Text="Buscar" OnClick="Button2_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblUsuario" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Usuario/Carrito.aspx">Carrito</asp:HyperLink>
                </td>
                <td>
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Usuario/MiCuenta.aspx">Mi Cuenta</asp:HyperLink>
                </td>
            </tr>
        </table>


                <h1 class="auto-style3">MI CUENTA</h1>
                    <p class="auto-style6">
                        <strong>
                        <asp:Button ID="Button3" runat="server" BorderWidth="2px" CssClass="auto-style5" Height="33px" Text="Historial de compras" Width="193px" OnClick="Button3_Click" />
                        </strong>
        </p>
        <p class="auto-style6">
                        <strong>
                        <asp:Button ID="Button4" runat="server" BorderStyle="Solid" BorderWidth="2px" CssClass="auto-style5" Height="33px" Text="Configuración" Width="139px" OnClick="Button4_Click" />
                        </strong>
        </p>
        <p class="auto-style6">
                        <strong>
                        <asp:Button ID="Button5" runat="server" BorderWidth="2px" CssClass="auto-style5" Height="32px" Text="Cerrar Sesión " Width="134px" OnClick="Button5_Click" />
                        </strong>
                    </p>
    </form>
</body>
</html>
