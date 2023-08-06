<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="View Votes.aspx.cs" Inherits="Project1.WebForm5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Text="View Elections/Voters/Winner"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server"></asp:Label>
        </div>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Elections" />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Voters" />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Candidate" />
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Winner" />
        <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Clear" />
    </form>
</body>
</html>
