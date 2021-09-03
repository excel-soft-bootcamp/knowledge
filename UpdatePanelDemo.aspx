<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdatePanelDemo.aspx.cs" Inherits="CacheDemo.UpdatePanelDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                  <div>
           <p>States:<asp:DropDownList ID="stateCombo" runat="server"
               AutoPostBack="True" OnSelectedIndexChanged="stateCombo_SelectedIndexChanged"  >
               <asp:ListItem>KA</asp:ListItem>
               <asp:ListItem>TN</asp:ListItem>
               <asp:ListItem>AP</asp:ListItem>
               <asp:ListItem>MH</asp:ListItem>
                     </asp:DropDownList></p> 
            <p>Cities:<asp:DropDownList ID="cityCombo" runat="server"></asp:DropDownList></p> 

        </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        
    </form>
</body>
</html>
