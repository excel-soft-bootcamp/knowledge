<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="CacheDemo.Home" %>

<%@ Register src="Header.ascx" tagname="Header" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="output" runat="server"></asp:Label>
            <asp:TextBox ID="search" runat="server"></asp:TextBox>
            <asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" />
        </div>
        <uc1:Header ID="Header1" runat="server" />
    </form>
</body>
</html>
