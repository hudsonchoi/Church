<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchMemberID.aspx.cs" Inherits="SearchMemberID"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
<script language="javascript" type="text/javascript" src="datetimepicker.js"></script>
    <style type="text/css">
        .style1
        {
            width : 191px;
            background-image:url(images/member_bg.jpg);
            background-repeat:no-repeat ;
            height : 77px; 
            overflow :hidden;
        }
    </style>

</head>
<body style="margin:0;">
    <form id="form1" runat="server">
    <div class="style1">
   <table width="191" border="0" cellpadding="0" cellspacing="0" >
  <tr>
    <td style="padding-top: 25px; padding-left: 56px;"  valign="top">
        <asp:TextBox ID="tb_name" runat="server" Height="15px" Width="87px"></asp:TextBox>
      </td>
    <td rowspan="2" width="51" align="center" style="padding-top:15px">
        <asp:ImageButton ID="ImageButton1" runat="server"  Width="35px" Height="42px"
            ImageUrl="~/images/member_bttn.jpg" onclick="ImageButton1_Click" 
            TabIndex="2" />
                    </td>
  </tr>
  <tr>
    <td style="padding-top: 1px;padding-left: 56px;"  valign="top">
        <asp:TextBox ID="tb_birth" runat="server" Height="15px" Width="65px" Text="" 
            TabIndex="1"></asp:TextBox><a href="javascript:NewCal('tb_birth','MMDDYYYY',false,24)"><img src="images/cal.gif" width="16" height="16" border="0" alt="Pick a date" style="padding-left:3px;"></a> </td>
  </tr>
</table>
    </div>
    </form>
</body>
</html>
