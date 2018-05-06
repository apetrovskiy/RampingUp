<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label runat="server" ID="resultLabel" /><br />
            <asp:Button runat="server" ID="triggerButton" Text="Click Me" OnClick="triggerButton_Click" />
        </div>
    </form>
</body>
</html>
