<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manage Voters.aspx.cs" Inherits="Project1.WebForm4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text="Manage Voters"></asp:Label>
        <div>
        </div>
        <asp:Label ID="Label2" runat="server" Text="Username"></asp:Label>
&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <asp:Label ID="Label6" runat="server" Text="Password"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Full name"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox3" runat="server" OnTextChanged="TextBox3_TextChanged"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Address"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Voted or Not Voted"></asp:Label>
&nbsp;<asp:TextBox ID="TextBox5" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
&nbsp;<br />
        <asp:Label ID="Label7" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Font-Size="Large" OnClick="Button1_Click" Text="Add" />
&nbsp;
        <asp:Button ID="Button2" runat="server" Font-Size="Large" OnClick="Button2_Click" Text="Update" />
&nbsp;
        <asp:Button ID="Button3" runat="server" Font-Size="Large" OnClick="Button3_Click" Text="Delete" />
&nbsp;
        <asp:Button ID="Button4" runat="server" Font-Size="Large" OnClick="Button4_Click" Text="View" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button5" runat="server" Font-Size="Large" OnClick="Button5_Click" Text="View All" />
&nbsp;
        <asp:Button ID="Button6" runat="server" Font-Size="Large" OnClick="Button6_Click" Text="Clear" />
&nbsp;<asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SortedAscendingCellStyle BackColor="#EDF6F6" />
            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
            <SortedDescendingCellStyle BackColor="#D6DFDF" />
            <SortedDescendingHeaderStyle BackColor="#002876" />
        </asp:GridView>
    </form>
</body>
</html>
