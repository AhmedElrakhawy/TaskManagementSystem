<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateNewTask.aspx.cs" Inherits="PresentationLayer.CreateNewTask" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form>
        <div class="form-row">
            <div class="form-group col-md-6">
                <asp:Label ID="Label1" runat="server" Text="Task Name"></asp:Label>
                <asp:TextBox ID="TaskName" runat="server" class="form-control input-group-lg"></asp:TextBox>
            </div>
            <div class="form-group col-md-6">
                <asp:Label ID="Label7" runat="server" Text="Task Description"></asp:Label>
                <asp:TextBox ID="TaskDescription" runat="server" class="form-control input-group-lg"></asp:TextBox>
            </div>
        </div>

        <div class="form-row">
            <div class="form-group col-md-6">
                <asp:Label ID="Label4" runat="server" Text="Select Employee"></asp:Label>
                <asp:DropDownList ID="SelectedEmployee" runat="server" class="form-control dropdown-menu-xl-start"></asp:DropDownList>
                <br />
                <asp:Label ID="Label5" runat="server" Text="Select Project"></asp:Label>
                <asp:DropDownList ID="SelectedProject" runat="server" class="form-control dropdown-menu-xl-start"></asp:DropDownList>

            </div>
            <div class="form-group col-md-6">
                <asp:Label ID="Label6" runat="server" Text="Select Task Status"></asp:Label>
                <asp:DropDownList ID="TaskStatus" runat="server" class="form-control dropdown-menu-xl-start">
                    <asp:ListItem Value="0">Non</asp:ListItem>
                    <asp:ListItem Value="1">Opened</asp:ListItem>
                    <asp:ListItem Value="2">Closed</asp:ListItem>
                </asp:DropDownList>

            </div>
        </div>

    </form>
      <asp:Button ID="SaveBtn" runat="server" Text="Save" OnClick="SaveBtn_Click" CssClass="btn btn-primary" />
</asp:Content>
