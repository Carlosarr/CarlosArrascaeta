<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserControlVehiculos.ascx.cs" Inherits="UserControlVehiculos" %>
<table style="width: 257px; height: 61px">
    <tr>
        <td style="width: 55px">
        </td>
        <td style="width: 3px">
        </td>
        <td style="width: 96px">
        </td>
    </tr>
    <tr>
        <td style="width: 55px">
            &nbsp;<asp:Label ID="lblMatricula" runat="server" Text="Matricula"></asp:Label></td>
        <td style="width: 3px">
            <asp:TextBox ID="txtMatricula" runat="server" AutoPostBack="True" OnTextChanged="txtMatricula_TextChanged"></asp:TextBox></td>
        <td style="width: 96px">
        </td>
    </tr>
    <tr>
        <td style="width: 55px">
            <asp:Label ID="lblMarca" runat="server" Text="Marca"></asp:Label></td>
        <td style="width: 3px">
            <asp:TextBox ID="txtMarca" runat="server"></asp:TextBox>
        </td>
        <td style="width: 96px">
        </td>
    </tr>
    <tr>
        <td style="width: 55px">
            <asp:Label ID="lblcliente" runat="server" Text="Cliente"></asp:Label></td>
        <td style="width: 3px">
            <asp:TextBox ID="txtCliente" runat="server"></asp:TextBox></td>
        <td style="width: 96px">
        </td>
    </tr>
    <tr>
        <td style="width: 55px">
            <asp:Label ID="Modelo" runat="server" Text="Modelo"></asp:Label></td>
        <td style="width: 3px">
            <asp:TextBox ID="txtModelo" runat="server"></asp:TextBox></td>
        <td style="width: 96px">
        </td>
    </tr>
    <tr>
        <td style="width: 55px">
            <asp:Label ID="lblAño" runat="server" Text="Año"></asp:Label>
        </td>
        <td style="width: 3px">
            <asp:TextBox ID="txtAño" runat="server"></asp:TextBox></td>
        <td style="width: 96px">
        </td>
    </tr>
    <tr>
        <td align="center" colspan="3" valign="top">
            <asp:GridView ID="grdFotos" runat="server" BackColor="White" BorderColor="#336666"
                BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" AutoGenerateColumns="False" Width="173px">
                <RowStyle BackColor="White" ForeColor="#333333" />
                <FooterStyle BackColor="White" ForeColor="#333333" />
                <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                <Columns>
                    <asp:ImageField DataImageUrlField="DireccionFotos" HeaderText="FOTOS">
                    </asp:ImageField>
                </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>
