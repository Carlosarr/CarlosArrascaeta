<%@ Page Language="C#" MasterPageFile="~/MasterPageTallermaster.master" AutoEventWireup="true" CodeFile="FrmTrabajos.aspx.cs" Inherits="FrmTrabajos" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 568px; height: 221px">
        <tr>
            <td style="width: 102px; height: 13px">
            </td>
            <td style="width: 5px; height: 13px">
            </td>
            <td style="width: 50px; height: 13px">
            </td>
            <td style="width: 37px; height: 13px">
            </td>
        </tr>
        <tr>
            <td style="width: 102px; height: 1px">
            </td>
            <td style="width: 5px; height: 1px">
                <asp:Label ID="lblCodigo" runat="server" Text="Codigo"></asp:Label></td>
            <td style="width: 50px; height: 1px">
                <asp:TextBox ID="txtCodigo" runat="server" AutoPostBack="True" OnTextChanged="txtCodigo_TextChanged"></asp:TextBox></td>
            <td style="width: 37px; height: 1px">
            </td>
        </tr>
        <tr>
            <td style="width: 102px; height: 10px">
            </td>
            <td style="width: 5px; height: 10px">
                <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion"></asp:Label></td>
            <td style="width: 50px; height: 10px">
                <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox></td>
            <td style="width: 37px; height: 10px">
            </td>
        </tr>
        <tr>
            <td style="width: 102px; height: 1px">
            </td>
            <td style="width: 5px; height: 1px">
                <asp:Label ID="lblMecanico" runat="server" Text="Mecanico"></asp:Label></td>
            <td style="width: 50px; height: 1px">
                <asp:DropDownList ID="drpMecanico" runat="server" Width="155px">
                </asp:DropDownList></td>
            <td style="width: 37px; height: 1px">
            </td>
        </tr>
        <tr>
            <td style="width: 102px; height: 21px">
            </td>
            <td align="center" colspan="2" style="height: 21px">
                <asp:Button ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" Text="Agregar" /><asp:Button
                    ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
                <asp:Button ID="btnMofdificar" runat="server" Text="Modificar" OnClick="btnMofdificar_Click" /></td>
            <td style="width: 37px; height: 21px">
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4" style="height: 21px">
                <asp:Label ID="lblError" runat="server" ForeColor="#C00000"></asp:Label></td>
        </tr>
    </table>
</asp:Content>

