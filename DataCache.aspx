<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataCache.aspx.cs" Inherits="CacheDemo.DataCache" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="cityCombo" runat="server" OnSelectedIndexChanged="cityCombo_SelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem>BLR</asp:ListItem>
                    <asp:ListItem>MYS</asp:ListItem>
                    <asp:ListItem>HYD</asp:ListItem>
                    <asp:ListItem>DEL</asp:ListItem>
            </asp:DropDownList>
            <fieldset>
                <legend>City Details</legend>
                <asp:Label ID="output" runat="server"></asp:Label>
            </fieldset>
        </div>
    </form>
</body>
</html>
