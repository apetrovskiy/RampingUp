<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Meeting Room Booker</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 style="text-align: center;">
                Enter details and set a day to initiate an event.
            </h1>
        </div>
        <div style="text-align: center/">
            <table style="text-align: left; border-color: #000000;
              border-width: 2px; background-color: #fff99e;" cellspacing="0"
                cellpadding="8" rules="none" width="540">
                <tr>
                    <td valign="top">
                        Your Name:
                    </td>
                    <td valign="top">
                        <asp:TextBox ID="nameBox" runat="server" Width="160px" />
                        <asp:RequiredFieldValidator ID="validateName" runat="server"
                            ErrorMessage="You must enter a name."
                            ControlToValidate="nameBox" Display="None" />
                    </td>
                    <td valign="middle" rowspan="4">
                        <asp:Calendar ID="calendar" runat="server" BackColor="White" />
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        Event Name:
                    </td>
                    <td valign="top">
                        <asp:TextBox ID="eventBox" runat="server" Width="160px" />
                        <asp:RegularExpressionValidator ID="validateEvent" runat="server"
                            ErrorMessage="You must enter an event name."
                            ControlToValidate="eventBox" Display="None" />
                    </td>
                </tr>

                <tr>
                    <td valign="top">
                        Meeting Room:
                    </td>
                    <td valign="top">
                        <asp:DropDownList ID="roomList" runat="server" Width="160px">
                            <asp:ListItem Value="1">The Happy Room</asp:ListItem>
                            <asp:ListItem Value="2">The Angry Room</asp:ListItem>
                            <asp:ListItem Value="3">The Depressing Room</asp:ListItem>
                            <asp:ListItem Value="4">The Funked Out Room</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="validateRoom" runat="server"
                            ErrorMessage="You must select a room."
                            ControlToValidate="roomList" Display="None" />
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        Attendees:
                    </td>
                    <td valign="top">
                        <asp:ListBox ID="attendeeList" runat="server" Width="160px"
                            SelectionMode="Multiple" Rows="6">
                            <asp:ListItem Value="1">Bill Gates</asp:ListItem>
                            <asp:ListItem Value="2">Monica Lewinsky</asp:ListItem>
                            <asp:ListItem Value="3">Vincent Price</asp:ListItem>
                            <asp:ListItem Value="4">Vlad the Impaler</asp:ListItem>
                            <asp:ListItem Value="5">Iggy Pop</asp:ListItem>
                            <asp:ListItem Value="6">William Shakespeare</asp:ListItem>
                        </asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
