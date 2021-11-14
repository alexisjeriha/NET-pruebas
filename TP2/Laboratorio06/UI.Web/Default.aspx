<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UI.Web.Default" %>

<%@ Register src="UserControl.ascx" tagname="UserControl" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

    <style type="text/css">
h1 {text-align: center}
h2 {text-align: right}
h3 {text-align: right}
    </style>
    <h3 style="font-family: calibri">
           
                <uc1:UserControl ID="UserControl1" runat="server" />

        </h3>

</asp:Content>
