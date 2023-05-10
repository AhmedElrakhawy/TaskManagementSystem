<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewTask.aspx.cs" Inherits="PresentationLayer.ViewTask" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <form>
        <div class="form-row">
            <div class="form-group col-md-6">
                <asp:Label ID="Label3" runat="server" Text="Task Name"></asp:Label>
                <asp:TextBox ID="TaskName" runat="server" class="form-control input-group-lg"></asp:TextBox>
            </div>
            <div class="form-group col-md-6">
                <asp:Label ID="Label8" runat="server" Text="Task Description"></asp:Label>
                <asp:TextBox ID="TaskDescription" runat="server" class="form-control input-group-lg"></asp:TextBox>
            </div>
        </div>

        <div class="form-row">
            <div class="form-group col-md-6">
                <asp:Label ID="Label9" runat="server" Text="Select Employee"></asp:Label>
                <asp:DropDownList ID="SelectedEmployee" runat="server" class="form-control dropdown-menu-xl-start"></asp:DropDownList>
                <br />
                <asp:Label ID="Label10" runat="server" Text="Select Project"></asp:Label>
                <asp:TextBox ID="TaskProject" runat="server" class="form-control input-group-lg"></asp:TextBox>

            </div>
            <div class="form-group col-md-6">
                <asp:Label ID="Label11" runat="server" Text="Select Task Status"></asp:Label>
                <asp:DropDownList ID="TaskStatus" runat="server" class="form-control dropdown-menu-xl-start">
                    <asp:ListItem Value="0">Non</asp:ListItem>
                    <asp:ListItem Value="1">Opened</asp:ListItem>
                    <asp:ListItem Value="2">Closed</asp:ListItem>
                </asp:DropDownList>
                <br />
            </div>
        </div>

    </form>
    <asp:Button ID="SaveBtn" runat="server" Text="Save" OnClick="SaveBtn_Click" CssClass="btn btn-primary" />
</asp:Content>
