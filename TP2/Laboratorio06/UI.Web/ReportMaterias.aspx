<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportMaterias.aspx.cs" Inherits="UI.Web.ReportMaterias" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <div class="container">
        <div class="row mx-auto" align="center">

             <rsweb:ReportViewer ID="ReportViewer1" runat="server" BackColor="#99CCFF" ClientIDMode="AutoID" HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226" BorderColor="#000099" BorderStyle="Double" SizeToReportContent="True" Width="100%" DocumentMapWidth="100%" AsyncRendering="False">

            <LocalReport ReportPath="ReporteMaterias.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>

        </div>
    </div>
   
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="UI.Web.tp2_netDataSetTableAdapters.materiasTableAdapter" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" UpdateMethod="Update">
        <DeleteParameters>
            <asp:Parameter Name="Original_id_materia" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="desc_materia" Type="String" />
            <asp:Parameter Name="hs_semanales" Type="Int32" />
            <asp:Parameter Name="hs_totales" Type="Int32" />
            <asp:Parameter Name="id_plan" Type="Int32" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="desc_materia" Type="String" />
            <asp:Parameter Name="hs_semanales" Type="Int32" />
            <asp:Parameter Name="hs_totales" Type="Int32" />
            <asp:Parameter Name="id_plan" Type="Int32" />
            <asp:Parameter Name="Original_id_materia" Type="Int32" />
        </UpdateParameters>
    </asp:ObjectDataSource>
</asp:Content>
