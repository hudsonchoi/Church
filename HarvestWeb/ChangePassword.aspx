<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
            .input {
	border:  1px solid #b2b2b2;
	
	color:#333333;
}
        .style5
        {
            font-family: ¸¼Àº °íµñ,µ¸¿ò;
            font-size: 10pt;
            color : #333;
            width: 89px;
        }
          .style4
        {
        	font:9pt tahoma,u; color:Red; line-height:20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style=" padding-top:60px;">
<div class="header1">
  <div class="loginmain"> 
<table width="500" border="0" cellpadding="0" cellspacing ="0"  >
   <tr><td align="left" style="padding-left:76px; padding-top:23px;" class="style5">
         Old Password
   </td>
   <td align="left" style=" padding-left:5px; padding-top:23px;" >
       <asp:TextBox ID="txtoldpwd" runat="server" TextMode="Password"  Width="120px" Text="" CssClass="input"></asp:TextBox>
     
       </td>
       </tr>
   <tr>  <td align="left" style="padding-left:76px; padding-top:5px;" class="style5">New Password
          
   </td><td align="left"style=" padding-left:5px; padding-top:5px;" >
       <asp:TextBox ID="txtpwd" TextMode="Password"  runat="server" Width="120px" CssClass="input"></asp:TextBox>
       </td>
     </tr>
   <tr><td align="left" style=" padding-left:170px; padding-top:12px;" colspan="2"> 
      <asp:ImageButton ID="ImageButton2" runat="server" 
           ImageUrl="~/images/bttn_modify.gif" onclick="ImageButton2_Click" /> &nbsp;&nbsp;&nbsp; 
       <asp:ImageButton ID="ImageButton1" runat="server" 
           ImageUrl="~/images/bttn_back.gif" onclick="ImageButton1_Click" />
       
       </td></tr>
       <tr><td align="left" style=" padding-left:80px; padding-top:10px;" colspan="2"> 
       <asp:Label ID="Label1" runat="server" Text="" CssClass="style4"></asp:Label>
       </td></tr>
   </table></div></div></div>
</asp:Content>

