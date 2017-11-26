<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" Title="Untitled Page" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <style type="text/css">
        .style1
        {
            width: 120px;
        }
        .style2
        {
        	font:8pt tahoma,u;
        	color:#444444; 
        }
        .style3
        {
        	font:9pt tahoma,u; color:#444444; line-height:20px;
        }
        .style4
        {
        	font:9pt tahoma,u; color:Red; line-height:20px;
        }
            .input {
	border:  1px solid #b2b2b2;
	
	color:#333333;
}
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div style=" padding-top:60px;">
<div class="loginheader">
  <div class="loginmain"> 
<table width="500" border="0" cellpadding="0" cellspacing ="0"  >
   <tr><td align="left" style=" padding-left:76px; padding-top:23px;" class="style1">
       <asp:TextBox ID="txtUserid" runat="server" Width="120px" Text="" CssClass="input"></asp:TextBox>
       <cc1:TextBoxWatermarkExtender ID="txtUserid_TextBoxWatermarkExtender" 
           runat="server" Enabled="True" TargetControlID="txtUserid" WatermarkText="아이디">
       </cc1:TextBoxWatermarkExtender>
       </td>
       <td align="left" style="padding-left:10px; padding-top:23px;">
         <span class="style2">  <asp:CheckBox ID="CheckBox1" runat="server"  Text="아이디저장" /></span>
   </td></tr>
   <tr><td align="left"style=" padding-left:76px; padding-top:5px;" class="style1">
       <asp:TextBox ID="txtpwd" TextMode="Password"  runat="server" Width="120px" CssClass="input"></asp:TextBox>
       <cc1:TextBoxWatermarkExtender ID="txtpwd_TextBoxWatermarkExtender" 
           runat="server" Enabled="True" TargetControlID="txtpwd" WatermarkText="패스워드">
       </cc1:TextBoxWatermarkExtender>
       </td>
       <td align="left" style="padding-left:10px; padding-top:5px;">
           <asp:ImageButton ID="ImageButton1" runat="server" 
               ImageUrl="~/images/bttn_login.gif" onclick="ImageButton1_Click" />
   </td></tr>
   <tr><td align="left" style=" padding-left:80px; padding-top:10px;" colspan="2"><span class="style3"><a href="SearchPassword.aspx">비밀번호 찾기</a></span> </td></tr>
   <tr><td align="left" style=" padding-left:80px; padding-top:10px;" colspan="2"> 
       <asp:Label ID="Label1" runat="server" Text="" CssClass="style4"></asp:Label>
       </td></tr>
   </table></div></div></div>
</asp:Content>

