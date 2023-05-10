 <%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TasksTable.aspx.cs" Inherits="PresentationLayer.TasksTable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        <asp:ListItem Value="0">Non</asp:ListItem>
        <asp:ListItem Value="1">Opened</asp:ListItem>
        <asp:ListItem Value="2">Closed</asp:ListItem>
    </asp:DropDownList>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Search" />
    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Add New Task" />
    <asp:GridView ID="GridView1" runat="server" DataKeyNames="task_Id" CssClass="table table-responsive" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:CommandField ShowSelectButton="True"/>
        </Columns>
    </asp:GridView>
</asp:Content>
