<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="730" border="0" cellspacing="0" cellpadding="0">
    <tr>
     <td align="right" style=" padding-top:25px;"><a href="http://njchodae.net"><img src="images/church_logo.gif" width="128" height="35" border="0" /></a></td>
    </tr>
    <tr>
      <td><img src="images/title_list.gif" width="730" height="30" border="0" /></td>
    </tr>
    <tr>
         <td style="padding-top:15px;" align="right">
         
         <table width="730" border="0" cellspacing="0" cellpadding="0">
    <tr><td> </td><td>
        <asp:ImageButton ID="ImageButton2" runat="server" 
            ImageUrl="~/images/bttn_logout.gif" onclick="ImageButton2_Click" />
        &nbsp;
       
        <asp:ImageButton ID="ImageButton1" runat="server" 
            ImageUrl="~/images/bttn_pw.gif" onclick="ImageButton1_Click" />&nbsp;<asp:ImageButton 
            ID="ImageButton3" runat="server" ImageUrl="~/images/bttn_write.gif" 
            onclick="ImageButton3_Click" />
        </a></td>
         </tr></table>
         </td>
    </tr>
    <tr>
      <td style="padding-top:15px;">
      
    
       
        <table width="750" border="0" cellspacing="0" cellpadding="0">
        <tr >
          <td  class="ListHeaderstyle" width="100" align="center"> 순</td>
          <td class="ListHeaderstyle" width="1"><img src="images/bg_list_bar.gif" width="1" height="30" border="0" /></td>
          <td class="ListHeaderstyle"align="center">작성 일자</td>
          <td class="ListHeaderstyle" width="1"><img src="images/bg_list_bar.gif" width="1" height="30" border="0" /></td>
          <td class="ListHeaderstyle" align="center">모임 일자</td>
          <td class="ListHeaderstyle" width="1"><img src="images/bg_list_bar.gif" width="1" height="30" border="0" /></td>
          <td class="ListHeaderstyle" width="200"align="center">순모임 장소</td>
          <td class="ListHeaderstyle" width="1"><img src="images/bg_list_bar.gif" width="1" height="30" border="0" /></td>
          <td class="ListHeaderstyle" width="75"align="center">재적인원</td>
          <td class="ListHeaderstyle" width="1"><img src="images/bg_list_bar.gif" width="1" height="30" border="0" /></td>
           <td class="ListHeaderstyle" width="75"align="center">출석인원</td>
           
           <td class="ListHeaderstyle" width="1"><img src="images/bg_list_bar.gif" width="1" height="30" border="0" /></td>
           <td class="ListHeaderstyle" width="75"align="center">출석가정</td>
           <td class="ListHeaderstyle" width="1"><img src="images/bg_list_bar.gif" width="1" height="30" border="0" /></td>
          <td class="ListHeaderstyle" width="100"align="center">인도자</td>
           <td class="ListHeaderstyle" width="1"><img src="images/bg_list_bar.gif" width="1" height="30" border="0" /></td>
          
        </tr>  
        
        <asp:Repeater ID="Repeater1" runat="server">
      
       <ItemTemplate>
        <tr>
              <td class="ContentList" colspan="2"align="center"><a href="ReportEdit.aspx?ReportID=<%# Eval("ID") %>"><%# Eval("CellName")%></a></td>
              <td class="ContentList"colspan="2"align="center"><%# Eval("Regdate")%>&nbsp;</td>
              <td class="ContentList"colspan="2"align="center"><%# Eval("CellDate")%>&nbsp;</td>
              <td class="ContentList"colspan="2"align="center"><%# Eval("Cellplace")%>&nbsp;</td>
              <td class="ContentList"colspan="2"align="center"><%# Eval("MemberNo") %>&nbsp;</td>
              <td class="ContentList"colspan="2"align="center"><%# Eval("Attendance") %>&nbsp;</td> 
              <td class="ContentList"colspan="2"align="center"><%# Eval("AttenFamily") %>&nbsp;</td>
              <td class="ContentList"colspan="2"align="center"><%# Eval("Leader") %>&nbsp;</td>  
              </td>
            </tr>  
        </ItemTemplate>
      
      
      </asp:Repeater>
          </table>
        </td>
    </tr>
  </table>

</asp:Content>

