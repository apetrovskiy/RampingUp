<%@ Page Language="VB" AutoEventWireup="false" CodeFile="CurrencyConverter.aspx.vb" Inherits="CurrencyConverter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XTHML 1.1//EN"
"http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Currency Converter</title>
</head>
<body>
    <form runat="server">
        <div>
            Convert: &nbsp;
            <input type="text" id="US" runat="server"/>
            &nbsp; U.S. dollars to &nbsp;
            <select id="Currency" runat="server"></select>
            <br/><br/>
            <input type="submit" value="OK" id="Convert" runat="server"/>
            <input type="submit" value="Show Graph" id="ShowGraph" runat="server" />
            <br/><br/>
            <img id="Graph" src="" alt="Currency Graph" runat="server"/>
            <br/><br/>
            <p style="font-weight:bold" id="Result" runat="server"></p>
        </div>
    </form>
</body>
</html>
