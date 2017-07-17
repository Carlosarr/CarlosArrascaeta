<%@ Page Language="C#" MasterPageFile="~/MasterPageTallermaster.master" AutoEventWireup="true" CodeFile="FrmConsultaMecanicos.aspx.cs" Inherits="FrmConsultaMecanicos" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 661px; height: 291px">
        <tr>
            <td style="width: 343px; height: 1px">
            </td>
            <td align="center" colspan="2" style="height: 1px">
                <asp:Label ID="Label1" runat="server" Text="Consultar por rango de fechas trabajos pendientes"
                    Width="322px"></asp:Label></td>
            <td style="width: 338px; height: 1px">
            </td>
        </tr>
        <tr>
            <td style="width: 343px">
            </td>
            <td align="center" style="width: 285px">
                &nbsp;<asp:Label ID="lblFecha1" runat="server" Text="Fecha 1"></asp:Label>
                <asp:TextBox ID="txtFecha1" runat="server" Width="92px"></asp:TextBox></td>
            <td align="center" style="width: 276px">
                <asp:Label ID="lblFecha2" runat="server" Text="Fecha 2"></asp:Label>
                <asp:TextBox ID="txtFecha2" runat="server" Width="107px"></asp:TextBox></td>
            <td style="width: 338px">
            </td>
        </tr>
        <tr>
            <td style="width: 343px">
            </td>
            <td align="center" colspan="2">
                <asp:Button ID="btnConsultar" runat="server" Text="Consultar" OnClick="btnConsultar_Click" /></td>
            <td style="width: 338px">
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4" style="height: 21px">
                <asp:Label ID="lblError" runat="server" ForeColor="#C00000"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 343px; height: 28px">
            </td>
            <td align="center" colspan="2" style="height: 28px">
                <asp:GridView ID="grdTrabajos" runat="server">
                </asp:GridView>
            </td>
            <td style="width: 338px; height: 28px">
            </td>
        </tr>
        <tr>
            <td style="width: 343px; height: 28px">
            </td>
            <td align="center" colspan="2" style="height: 28px">
            </td>
            <td style="width: 338px; height: 28px">
            </td>
        </tr>
    </table>
</asp:Content>

