<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OurSuppliers.aspx.cs" Inherits="WebApp.OurSuppliers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="page-header">Our Supplier</h1>
    <div class="row">
        <div class="col-md-12">
            <asp:Repeater ID="SupplierRepeater" runat="server" DataSourceID="SupplierDataSource" ItemType="WestWindSystem.DataModels.SupplierProduct">
                <ItemTemplate>
                    <h3><%#  Item.CompanyName%></h3>
                    <p><%# Item.ContactName %></p>
                    <p><%# Item.Phone %></p>
                    <blockquote>
                        <asp:Repeater ID="ProductRepeater" runat="server"
                            DataSource="<%# Item.SupplierProductSummary %>" ItemType="WestWindSystem.DataModels.SupplierProductSummary">
                            <HeaderTemplate>
                                <table class="table table-hover table-condensed">
                            </HeaderTemplate>
                            <FooterTemplate>
                            </table>
                            </FooterTemplate>
                            <ItemTemplate>
                                <tr>
                                    <th><%# Item.CategoryName %></th>
                                    <th><%# Item.UnitPrice %></th>
                                    <th><%# Item.QuantityPerUnit %></th>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </blockquote>
                </ItemTemplate>
            </asp:Repeater>
            <asp:ObjectDataSource ID="SupplierDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ListSupplierProducts" TypeName="WestWindSystem.BLL.SupplierProductController"></asp:ObjectDataSource>
        </div>
    </div>
</asp:Content>
