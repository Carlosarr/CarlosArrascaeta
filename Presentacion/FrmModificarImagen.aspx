<%@ Page Language="C#" MasterPageFile="~/MasterPageTallermaster.master" AutoEventWireup="true" CodeFile="FrmModificarImagen.aspx.cs" Inherits="FrmModificarImagen" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 661px; height: 194px">
        <tr>
            <td style="width: 1px">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Large" Width="81px"></asp:Label></td>
            <td align="center" style="width: 390px" valign="middle">
                <asp:FileUpload ID="FileUpload1" runat="server" Width="203px" />
                <asp:Button ID="btnCambiarFoto" runat="server" OnClick="btnCambiarFoto_Click" Text="Cambiar foto" />
                <asp:Button ID="btnAgregarfoto" runat="server" OnClick="btnAgregarfoto_Click" Text="Agregar Nueva" /></td>
            <td style="width: 9px">
            </td>
        </tr>
        <tr>
            <td style="width: 1px">
            </td>
            <td align="center" style="width: 390px" valign="middle">
                <asp:Button ID="btnEliminarFoto" runat="server" OnClick="btnEliminarFoto_Click" Text="Eliminar Foto" /></td>
            <td style="width: 9px">
            </td>
        </tr>
        <tr>
            <td style="width: 1px">
            </td>
            <td align="center" style="width: 390px" valign="middle">
                <asp:Image ID="imgfoto" runat="server" />
                <asp:Label ID="lblSinFoto" runat="server"></asp:Label></td>
            <td style="width: 9px">
            </td>
        </tr>
        <tr>
            <td style="width: 1px">
                <asp:Button ID="btnvolver" runat="server" OnClick="btnvolver_Click" Text="Volver" /></td>
            <td style="width: 390px">
                &nbsp; &nbsp;&nbsp;
                <asp:Label ID="lblError" runat="server" ForeColor="#C00000"></asp:Label></td>
            <td style="width: 9px">
            </td>
        </tr>
        <tr>
            <td style="height: 52px" colspan="3" rowspan="2">
                &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</td>
        </tr>
        <tr>
        </tr>
    </table>
</asp:Content>

