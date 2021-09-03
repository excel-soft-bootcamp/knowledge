<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="CacheDemo.Header" %>
<%@ OutputCache Duration="500" VaryByParam="None" %>
<fieldset>
    <legend>Header Fragment</legend>
    <asp:Label ID ="output" runat="server"></asp:Label>
</fieldset>
