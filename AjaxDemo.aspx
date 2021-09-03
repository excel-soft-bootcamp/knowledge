<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxDemo.aspx.cs" Inherits="CacheDemo.AjaxDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <script>
        function onStateChanged() {

            var stateCode = document.getElementById("stateCombo").value;
            //AJAX Code

            var httpReq = new XMLHttpRequest();
            httpReq.onreadystatechange = function () {

                if (httpReq.readyState == 4) {

                    if (httpReq.status == 200) {

                        cities = httpReq.responseText.split(",");
                        var cityCombo = document.getElementById("cityCombo");
                        cityCombo.innerText = "";
                        for (var i = 0; i < cities.length; i++) {

                            var option = document.createElement("option");
                            option.innerText = cities[i];
                            cityCombo.appendChild(option);

                        }
                    }

                }

            }
            httpReq.open("GET", "https://localhost:44344/GetCities.ashx?statecode=" + stateCode, true);
          
            httpReq.send();
        }


      </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           <p>States:<asp:DropDownList ID="stateCombo" runat="server"
               AutoPostBack="False" onchange="onStateChanged()" >
               <asp:ListItem>KA</asp:ListItem>
               <asp:ListItem>TN</asp:ListItem>
               <asp:ListItem>AP</asp:ListItem>
               <asp:ListItem>MH</asp:ListItem>
                     </asp:DropDownList></p> 
            <p>Cities:<asp:DropDownList ID="cityCombo" runat="server"></asp:DropDownList></p> 

        </div>
    </form>
</body>
</html>
