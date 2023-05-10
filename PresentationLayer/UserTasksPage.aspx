<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserTasksPage.aspx.cs" Inherits="PresentationLayer.OldTasksPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" DataKeyNames="task_Id" CssClass="table table-responsive" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:CommandField ShowSelectButton="True"/>
        </Columns>
    </asp:GridView>
</asp:Content>
