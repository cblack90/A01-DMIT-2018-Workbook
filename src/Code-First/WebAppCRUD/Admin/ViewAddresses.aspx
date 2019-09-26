<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewAddresses.aspx.cs" Inherits="WebAppCRUD.Admin.ViewAddresses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>View Addresses</h1>

    <asp:ListView ID="AddressListView" runat="server" DataSourceID="AddressDataSource" DataKeyNames="AddressID"
        InsertItemPosition="FirstItem" ItemType="WestWindSystem.Entities.Address">
        <LayoutTemplate>
            <table class="table table-hover table-condensed">
                <thead>
                    <tr>Address ID</tr>
                    <tr>Address</tr>
                    <tr>City</tr>
                    <tr>Region</tr>
                    <tr>PostalCode</tr>
                    <tr>Country</tr>
                </thead>
                <tbody>
                    <tr id="itemPlaceholder" runat="server"></tr>
                </tbody>
            </table>
        </LayoutTemplate>
        <InsertItemTemplate>
            <tr class="bg-success">
                <td>
                    <asp:LinkButton ID="AddAddress" runat="server" CssClass="btn btn-success glyphicon glyphicon-plus" CommandName="Insert">Add</asp:LinkButton>
                    <asp:LinkButton ID="CancelInsert" runat="server" CssClass="btn btn-default" CommandName="Cancel">Clear</asp:LinkButton>
                </td>
                <td>
                    <asp:TextBox ID="Address" runat="server" Text="<%# BindItem.Address1 %>" placeholder="Enter Address"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="City" runat="server" Text="<%# BindItem.City %>" placeholder="City"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="Retion" runat="server" Text="<%# BindItem.Region %>" placeholder="Region"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="PostalCode" runat="server" Text="<%# BindItem.PostalCode %>" placeholder="Postal Code"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="Country" runat="server" Text="<%# BindItem.Country %>" placeholder="Country"></asp:TextBox>
                </td>
            </tr>
        </InsertItemTemplate>

        <EditItemTemplate>
            <tr class="bg-info">
                <td>
                    <asp:LinkButton ID="UpdateAddress" runat="server" CssClass="btn btn-success glyphicon glyphicon-okay" CommandName="Update">Save</asp:LinkButton>
                    <asp:LinkButton ID="CancelUpdate" runat="server" CssClass="btn btn-default" CommandName="Cancel">Cancel</asp:LinkButton>
                </td>
                <td>
                    <asp:TextBox ID="Address" runat="server" Text="<%# BindItem.Address1 %>" placeholder="Enter Address"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="City" runat="server" Text="<%# BindItem.City %>" placeholder="City"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="Retion" runat="server" Text="<%# BindItem.Region %>" placeholder="Region"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="PostalCode" runat="server" Text="<%# BindItem.PostalCode %>" placeholder="Postal Code"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="Country" runat="server" Text="<%# BindItem.Country %>" placeholder="Country"></asp:TextBox>
                </td>
            </tr>
        </EditItemTemplate>
        
        <ItemTemplate>
            <tr>
                <td>
                    <asp:LinkButton ID="EditAddress" runat="server" CssClass="btn btn-info glyphicon glyphicon-pencil"
                        CommandName="Edit">Edit</asp:LinkButton>
                    <asp:LinkButton ID="Delete" runat="server" CssClass="btn btn-danger" OnClientClick="return confirm ('Are you sure you want to delete this Address?')"
                        CommandName="Delete">Delete</asp:LinkButton>
                </td>
                <td><%# Item.Address1 %></td>
                <td><%# Item.City %></td>
                <td><%# Item.Region %></td>
                <td><%# Item.PostalCode %></td>
                <td><%# Item.Country %></td>
            </tr>

        </ItemTemplate>
    </asp:ListView>
    <asp:ObjectDataSource ID="AddressDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ListAddresses" TypeName="WestWindSystem.BLL.CRUDController" DataObjectTypeName="WestWindSystem.Entities.Address" DeleteMethod="DeleteAddress" InsertMethod="AddAddress" UpdateMethod="UpdateAdddres"></asp:ObjectDataSource>
</asp:Content>
