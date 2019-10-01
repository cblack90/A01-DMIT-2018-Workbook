<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OurSuppliers.aspx.cs" Inherits="WebApp.OurSuppliers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="page-header">Our Supplier</h1>
    <div class="row">
        <div class="col-md-12">

            <asp:ObjectDataSource ID="SupplierDataSource" runat="server"></asp:ObjectDataSource>
        </div>
    </div>
</asp:Content>
