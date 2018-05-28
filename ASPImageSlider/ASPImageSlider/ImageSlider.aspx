<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ImageSlider.aspx.cs" Inherits="ASPImageSlider.ImageSlider" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick"></asp:Timer>

            <asp:Image ID="Image1" Height="300" Width="700" runat="server" />
            <br/>
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br/>
            <asp:Button ID="Button1" runat="server" Text="Stop Slideshow" OnClick="Button1_Click" />
        </ContentTemplate>
    </asp:UpdatePanel>

    
</asp:Content>
