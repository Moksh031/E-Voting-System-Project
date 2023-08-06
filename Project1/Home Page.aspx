<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home Page.aspx.cs" Inherits="Project1.WebForm6" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body{
            
            background-image:url('evote3.jpg');
            background-repeat:no-repeat;
            background-position:center;
            background-size:auto auto;
            background-color:rgb(222,99,83,100);
            height:100vh;
            zoom:1.1.1;
            margin:-5px;

        }
        #a{
            background-position:top;
            background-color:aqua;
            height:86px;
           
        }
        img{
            margin-top:10px;
            height:63px;
            width:150px;
        }
        #a1{
            width:82%;
        }
       
    </style>
</head>
<body >
    <form id="form1" runat="server">
        <div id="a">
            <div id="a1">
<marquee id="marquee" behavior="slide" direction="right" loop="1">  
<img src="logo1.png" /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

            <asp:Label ID="Label1" runat="server" Text="Home Page Of Evoting " Font-Bold="True" Font-Size="XX-Large" Font-Underline="True" ForeColor="Black"></asp:Label>
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<img src="logo1.png" /></div> </marquee></div><br /><br /><br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     <asp:LinkButton ID="LinkButton1" runat="server" Font-Underline="False" ForeColor="Black" OnClick="LinkButton1_Click" Font-Size="XX-Large" Font-Bold="True">Admin Login</asp:LinkButton>
        <br /><br />
        <br />
        <br />
        <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="LinkButton2" runat="server" Font-Underline="False" ForeColor="Black" OnClick="LinkButton2_Click" Font-Bold="True" Font-Size="XX-Large">Voters Login</asp:LinkButton>

        
&nbsp;
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
