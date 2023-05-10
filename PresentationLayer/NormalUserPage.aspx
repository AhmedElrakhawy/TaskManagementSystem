<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NormalUserPage.aspx.cs" Inherits="PresentationLayer.NormalUserPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .notification {
            background-color: #555;
            color: white;
            text-decoration: none;
            padding: 15px 26px;
            position: relative;
            display: inline-block;
            border-radius: 2px;
            height: 52px;
        }

            .notification:hover {
                background: red;
            }

            .notification .badge {
                position: absolute;
                top: -10px;
                right: -10px;
                padding: 5px 10px;
                border-radius: 50%;
                background: red;
                color: white;
            }
    </style>

    <br />
    <div class=" align-content-center">
 <asp:HyperLink ID="NewTasks" runat="server" CssClass="notification"> 
        <span>
            New Tasks
        </span>
        <span class="badge">
            <asp:Label ID="NewTasksCounter" runat="server" Text="0"></asp:Label>
        </span>

    </asp:HyperLink>

        
    <asp:HyperLink ID="OldTasks" runat="server" CssClass="notification"> 
        <span>
            Old Tasks
        </span>
        <span class="badge">
            <asp:Label ID="OldTasksCounter" runat="server" Text="0"></asp:Label>
        </span>

    </asp:HyperLink>

        <asp:Button ID="ViewALl" runat="server" CssClass="btn btn-primary" Text="View ALl" OnClick="ViewALl_Click" />
        </div>
</asp:Content>

