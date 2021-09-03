<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Result.aspx.cs" Inherits="CacheDemo.Result" %>
<%@ OutputCache Duration="300" VaryByParam="key" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="output" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
