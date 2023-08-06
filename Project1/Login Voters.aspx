<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login Voters.aspx.cs" Inherits="Project1.Login_Voters" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label3" runat="server" Text="Voters Login Page"></asp:Label>
            <br />
            <br />
            <br />
        <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
        <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" ></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Sign In" />
            <br />
            <br />
            <asp:Label ID="Label4" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
