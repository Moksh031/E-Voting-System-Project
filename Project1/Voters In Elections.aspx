<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Voters In Elections.aspx.cs" Inherits="Project1.Voters_In_Elections" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Voters In Election Page"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Username"></asp:Label>
&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label4" runat="server" Text="Candidates In Thier Area"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList1" runat="server" Width="188px">
            </asp:DropDownList>
        </div>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Check Vote" />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="View Elections" />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="View Candidates" />
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Cast Vote" />
            <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Winner" />
        </p>
        <p>
            <asp:Label ID="Label3" runat="server"></asp:Label>
        </p>
        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
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
