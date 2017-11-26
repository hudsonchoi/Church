<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SearchPassword.aspx.cs" Inherits="SearchPassword" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   <style type="text/css">
            .input {
	border:  1px solid #b2b2b2;
	
	color:#333333;
}
        .style5
        {
           font-family: 맑은 고딕,돋움;
           font-size: 10pt;
           color : #333;
           width: 66px;
       }
          .style4
        {
        	font:9pt tahoma,u; color:Red; line-height:20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style=" padding-top:60px;">
<div class="header2">
  <div class="loginmain"> 
<table width="500" border="0" cellpadding="0" cellspacing ="0"  >
   <tr><td align="left" style="padding-left:76px; padding-top:23px;" class="style5">
         ID (이메일) 
   </td>
   <td align="left" style=" padding-left:5px; padding-top:23px;" >
       <asp:TextBox ID="txtemail" runat="server"   Width="200px" Text="" CssClass="input"></asp:TextBox>
     
       </td>
       </tr>
   <tr>  <td align="left" style="padding-left:76px; padding-top:5px;" class="style5">생년월일
          
   </td><td align="left"style=" padding-left:5px; padding-top:5px;" >
           <asp:TextBox ID="TextBox1" runat="server" class="input" Height="22px" 
                                            Width="133px"></asp:TextBox>
                                        <cc1:CalendarExtender ID="TextBox1_CalendarExtender" runat="server" 
                                            Enabled="True" TargetControlID="TextBox1">
                                        </cc1:CalendarExtender>&nbsp;</td>
     </tr>
   <tr><td align="left" style=" padding-left:140px; padding-top:12px;" colspan="2"> 
    
       
       <asp:ImageButton ID="ImageButton1" runat="server" 
           ImageUrl="~/images/bttn_sendpw.gif" onclick="ImageButton1_Click" />
       
       </td></tr>
       <tr><td align="left" style=" padding-left:80px; padding-top:10px;" colspan="2"> 
       <asp:Label ID="Label1" runat="server" Text="" CssClass="style4"></asp:Label>
       </td></tr>
   </table>
   <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1"
            ControlToValidate="txtemail"
            Display="None"
            ErrorMessage="필수 기재 사항입니다. 입력해 주시길 바랍니다." />
    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RequiredFieldValidator1">
    </cc1:ValidatorCalloutExtender>
   </div></div></div>
</asp:Content>

