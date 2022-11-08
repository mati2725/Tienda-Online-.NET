﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GestionCategoria.aspx.cs" Inherits="Tp_Integrador___Grupo3.GestionCategoria" %>

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
            text-decoration: underline;
            font-size:xx-large;
        }
        .auto-style5 {
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <table style="width:100%">
            <tr>
                <td style="width:15%; text-align:center">
                    <asp:Button ID="Button2" runat="server" Text="Todas las categorias" OnClick="Button2_Click" />
                </td>
                <td style="width:65%">
                    <asp:TextBox ID="TextBox2" runat="server" Width="80%"></asp:TextBox>
                    <asp:Button ID="Button3" runat="server" Text="Buscar" OnClick="Button3_Click" />
                </td>
                <td>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/GestionMenu.aspx">Administrar página</asp:HyperLink>
                </td>
                <td>
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/IniciarSesion.aspx">Cerrar Sesión</asp:HyperLink>
                </td>
            </tr>

            </table>
<div>
            <h1 class="auto-style3">GESTIÓN DE CATEGORÍAS</h1>
        </div>
        Buscar categoría:
        <asp:TextBox ID="txtBuscar" runat="server"></asp:TextBox>
        <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" />
        <br />
        <asp:GridView ID="grdCategoria" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Height="146px" Width="307px" OnRowCancelingEdit="grdCategoria_RowCancelingEdit" OnRowEditing="grdCategoria_RowEditing" OnRowUpdating="grdCategoria_RowUpdating" AutoGenerateDeleteButton="True" OnRowDeleting="grdCategoria_RowDeleting" AllowPaging="True" OnPageIndexChanging="grdCategoria_PageIndexChanging" ShowHeaderWhenEmpty="True">
            <Columns>
                <asp:TemplateField HeaderText="Id Categoria">
                    <EditItemTemplate>
                        <asp:Label ID="lblIdCategoria" runat="server" Text='<%# Bind("IdCategoria_Cat") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblIdCategoria" runat="server" Text='<%# Bind("IdCategoria_Cat") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Nombre">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtNombreCategoria" runat="server" Text='<%# Bind("Nombre_Cat") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombreCategoria">*Completar</asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblNombreCategoria" runat="server" Text='<%# Bind("Nombre_Cat") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
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
        <p>
            <asp:Label ID="lblMensaje" runat="server"></asp:Label>
        </p>
        <p class="auto-style4">
            <strong>Agregar Categoria:</strong></p>
        <p>
            Nombre Categoria:
            <asp:TextBox ID="txtNuevaCategoria" runat="server" ValidationGroup="Nuevo"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNuevaCategoria" ErrorMessage="*Completar" ValidationGroup="Nuevo"></asp:RequiredFieldValidator>
        </p>
        <p>
            <strong>
            <asp:Button ID="Button1" runat="server" CssClass="auto-style5" Text="Guardar Categoria " OnClick="btnAgregarCategoria_Click" ValidationGroup="Nuevo" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            </strong>
            <asp:Label ID="lblNuevaCategoria" runat="server"></asp:Label>
        </p>
    </form>
    <p>
        &nbsp;</p>
</body>
</html>