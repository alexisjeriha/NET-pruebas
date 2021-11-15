<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportAlumnos.aspx.cs" Inherits="UI.Web.ReportAlumnos" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:Button ID="btnAll" runat="server" OnClick="btnAll_Click" Text="Todos" />
    <asp:Button ID="btnRegulares" runat="server" OnClick="btnRegulares_Click" Text="Regulares" />

    <asp:Button ID="btnAprobados" runat="server" OnClick="btnAprobados_Click" Text="Aprobados" />
    <asp:Button ID="btnLibres" runat="server" OnClick="btnLibres_Click" Text="Libres" />

    <div class="container">
        <div class="row mx-auto" align="center">
             <rsweb:ReportViewer ID="ReportViewer1" ZoomMode="PageWidth" runat="server" BackColor="#99CCFF" ClientIDMode="AutoID" HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226" BorderColor="#000099" BorderStyle="Double" SizeToReportContent="True" Width="100%" DocumentMapWidth="100%" AsyncRendering="False">
            <LocalReport ReportPath="ReporteAlumnos.rdlc">
        </LocalReport>
    </rsweb:ReportViewer>

        </div>
    </div>  
    
</asp:Content>
