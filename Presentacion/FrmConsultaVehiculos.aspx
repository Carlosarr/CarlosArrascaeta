<%@ Page Language="C#" MasterPageFile="~/MasterPageTallermaster.master" AutoEventWireup="true" CodeFile="FrmConsultaVehiculos.aspx.cs" Inherits="FrmConsultaVehiculos" Title="Untitled Page" %>

<%@ Register Src="UserControlVehiculos.ascx" TagName="UserControlVehiculos" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 362px; height: 184px">
        <tr>
            <td style="width: 52px; height: 21px">
            </td>
            <td style="width: 91px; height: 21px">
                <asp:Label ID="lblVehiculo" runat="server" Text="Vehiculo"></asp:Label></td>
            <td rowspan="1" style="width: 74px">
                <asp:DropDownList ID="drpVehiculo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpVehiculo_SelectedIndexChanged"
                    Width="121px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 52px; height: 21px">
            </td>
            <td style="width: 91px; height: 21px">
            </td>
            <td rowspan="3" style="width: 74px">
                <uc1:UserControlVehiculos ID="UserControlVehiculos1" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="width: 52px">
            </td>
            <td style="width: 91px">
            </td>
        </tr>
        <tr>
            <td style="width: 52px">
            </td>
            <td style="width: 91px">
            </td>
        </tr>
    </table>
</asp:Content>

