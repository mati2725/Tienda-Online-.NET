﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="Tp_Integrador___Grupo3.Usuario.Carrito" %>

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
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <table style="width:100%">
            <tr>
                <td style="width:15%; text-align:center">
                    <asp:Button ID="Button4" runat="server" Height="26px" OnClick="Button3_Click" Text="Todos los productos" Width="182px" />
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
                </td>
            </tr>
        </table>
        <div>
            <h1 class="auto-style3">CARRITO</h1>
            <asp:GridView ID="GridView1" runat="server" ForeColor="Black" AutoGenerateDeleteButton="True" OnRowDeleting="GridView1_RowDeleting">
            </asp:GridView>
            <br />
            <br />
            <br />
            Precio Total: $ <asp:Label ID="lblTotal" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button3" runat="server" Text="Confirmar Compra" OnClick="Button3_Click1" />
        &nbsp;<asp:Label ID="lblMensaje" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
