<%@ Page Language="C#" MasterPageFile="~/MasterPageTallermaster.master" AutoEventWireup="true" CodeFile="FrmCupones.aspx.cs" Inherits="FrmCupones" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 690px; height: 154px">
        <tr>
            <td style="width: 155px">
            </td>
            <td style="width: 60px">
            </td>
            <td style="width: 175px">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 155px">
            </td>
            <td style="width: 60px">
                <asp:Label ID="lblNumero" runat="server" Text="Numero"></asp:Label></td>
            <td style="width: 175px">
                <asp:TextBox ID="txtNumero" runat="server" OnTextChanged="txtNumero_TextChanged" AutoPostBack="True"></asp:TextBox></td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 155px; height: 26px">
            </td>
            <td style="width: 60px; height: 26px">
                <asp:Label ID="lblCICliente" runat="server" Text="C.I Cliente"></asp:Label></td>
            <td style="width: 175px; height: 26px">
                <asp:DropDownList ID="drpCiCliente" runat="server" Width="158px">
                </asp:DropDownList></td>
            <td style="height: 26px">
            </td>
        </tr>
        <tr>
            <td style="width: 155px">
            </td>
            <td style="width: 60px">
                <asp:Label ID="lblFecha" runat="server" Text="Fecha"></asp:Label></td>
            <td style="width: 175px">
                <asp:TextBox ID="txtFecha" runat="server"></asp:TextBox></td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 155px">
            </td>
            <td style="width: 60px">
                <asp:Label ID="lblValor" runat="server" Text="Valor"></asp:Label></td>
            <td style="width: 175px">
                <asp:TextBox ID="txtValor" runat="server"></asp:TextBox></td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 155px">
            </td>
            <td style="width: 60px">
            </td>
            <td style="width: 175px">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 155px">
            </td>
            <td align="center" colspan="2">
                <asp:Button ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" Text="Agregar" />
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" /></td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 155px">
            </td>
            <td align="center" colspan="2">
                <asp:Button ID="BtnXml" runat="server" OnClick="BtnXml_Click" Text="Exportar a XML"
                    Width="100px" /></td>
            <td>
            </td>
        </tr>
        <tr>
            <td id="lblError" align="center" colspan="4" style="height: 21px">
                <asp:Label ID="lblerror" runat="server" ForeColor="#C00000"></asp:Label></td>
        </tr>
    </table>
</asp:Content>

