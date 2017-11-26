<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReportEdit.aspx.cs" Inherits="ReportEdit" Title="Untitled Page" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <style type="text/css">
        .style1
        {
            width: 634px;
            padding-right:5px;
        }
      
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

            <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                            <ContentTemplate>
    <table width="730" border="0" cellspacing="0" cellpadding="0">
    <tr>
     <td align="right" style=" padding-top:10px;"><a href="http://njchodae.net"><img src="images/logo.jpg" width="110" height="42" border="0" /></a></td>
    </tr>
    <tr>
      <td><img src="images/title_edit.gif" width="730" height="30" /></td>
    </tr>
    <tr><td align="left" style="padding-top:20px;"><table width="730"  border="0" cellspacing="0" cellpadding="0" >
    <tr><td width="70" class="ContentBox4" style="border-top: 1px solid #ccc;" align="center">순장</td><td class="ContentBox"  style="border-top: 1px solid #ccc;" width="100" align="center"><asp:Label ID="Label1" runat="server" Text=""></asp:Label></td>
    <td width="70" class="ContentBox4" style="border-top: 1px solid #ccc;"align="center">권찰</td><td class="ContentBox" style="border-top: 1px solid #ccc;" width="100" align="center">
       <asp:Label ID="Label2" runat="server" Text=""> </asp:Label>&nbsp;</td>
        <td align="right" class="style2">
         <a href="Default.aspx">   <img src="images/bttn_list.gif" border="0" style="width: 141px; height: 25px" /></a></td>
          <td align="right" width="90">    
                                        <asp:ImageButton ID="btn_save2" runat="server" ImageUrl="~/images/bttn_save.gif" 
                                            onclick="btn_save_Click" /> </td>    </tr> </table>
    </td></tr>
    <tr><td style="padding-top:20px; padding-bottom:20px;">
    <table  width="730" border="0" cellspacing="0" cellpadding="0" class="tableHeader">
    <tr ><td width="120" class="reportHeader" align="center">순모임 일시</td><td class="ContentBox" align="left">
                                        <asp:TextBox ID="TextBox1" runat="server" class="inputArea" Height="22px" 
                                            Width="133px"></asp:TextBox>
                                        <cc1:CalendarExtender ID="TextBox1_CalendarExtender" runat="server" 
                                            Enabled="True" TargetControlID="TextBox1">
                                        </cc1:CalendarExtender>
                                        </td><td width="80" class="reportHeader">인도자</td><td width="200" class="ContentBox" >
        <asp:TextBox ID="txtleader" runat="server" CssClass="inputArea" Height="22px" Width="162px"></asp:TextBox>
  

        </td>
    
    </tr>
    
      <tr><td width="120" class="reportHeader" align="center">순모임 장소</td><td class="ContentBox" >
          <asp:TextBox ID="txtLocation" runat="server" CssClass="inputArea" Height="22px" Width="301px"></asp:TextBox>
          </td><td width="80" class="reportHeader">기도자</td><td width="200" class="ContentBox" >
          <asp:TextBox ID="txtprayer" runat="server" CssClass="inputArea" Height="21px" Width="190px"></asp:TextBox>
          </td>
     <tr><td width="120" class="reportHeader" align="center">새가족</td><td class="ContentBox"  >
         <asp:TextBox ID="txtnewmember" runat="server" 
                  CssClass="inputArea"
                  Width="301px"></asp:TextBox></td><td width="80" class="reportHeader">참석가정수</td><td width="200" class="ContentBox" >
          <asp:TextBox ID="txtattfamily" runat="server" CssClass="inputArea" Height="19px" 
              Width="38px"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="TextBox2_FilteredTextBoxExtender" 
                                            runat="server" Enabled="True" TargetControlID="txtattfamily" FilterType="Numbers">
                                        </cc1:FilteredTextBoxExtender>
                                      
          </td>
    </tr>
    
    <tr><td width="120" class="reportHeader" align="center">사역신청</td><td class="ContentBox" colspan="3" >
        <asp:TextBox ID="txtrequest" runat="server"    CssClass="inputArea"
                  Width="550px"></asp:TextBox>
    </tr>
    
    </table></td></tr>

    <tr><td class="ContentBox3" align="left" ><span style="padding-left:10px;">순원 사항</span>
            
            
            
            
            
        </asp:ListView>
        </td></tr>
    <tr><td>
    <table width = "730px" class="mGrid">
    <thead>
    <tr>
    <th >NO</th>
    <th>이름</th>
    <th>출석</th>
    <th>불참사유/특이사항</th>
    <th>주일출석 특이사항</th>
    </tr>
    </thead>
    <tbody>
     <asp:ListView ID="ListView1" runat="server" ItemPlaceholderID="itemplaceholder" DataKeyNames="ID" > 
       <LayoutTemplate>
        <asp:PlaceHolder ID="itemplaceholder" runat="server" />
    </LayoutTemplate>
       <ItemTemplate>
       <tr>
        <td class="StyleContext2"><%#Eval("ID")%></td>
        <td class="StyleContext2"> <%#Eval("MemberName")%></td>
        <td><asp:CheckBox ID="txt_attendence" runat="server" Checked ='<%#Eval("Attendence")%>'  /></td>
        <td><asp:TextBox ID ="txt_reason" runat="server" Text='<%#Eval("Reason")%>' CssClass="inputArea" /></td>
        <td><asp:TextBox ID ="txt_memo" runat="server" Text='<%#Eval("Memo")%>'  CssClass="inputArea" /></td>
       
       
       </tr>
       </ItemTemplate>
       </asp:ListView>
    </tbody>
    
    </table>
   
       
       
     
    <%--
        <cc2:BulkEditGridView ID="BulkEditGridView1" runat="server" AutoGenerateColumns="False"   CssClass="mGrid" 
                                    OnRowUpdating="BulkEditGridView1_RowUpdating" BulkEdit="False" 
                                    Width="730px" >
         <Columns>
                                <asp:BoundField DataField="No" HeaderText="No" ReadOnly="True" >
                                    <headerstyle wrap="False" />
                                    <itemstyle horizontalalign="Center"  Width="40px" CssClass="contextstyle2"/>
                                </asp:BoundField>
                                  
                                  <asp:BoundField DataField="MemberName" HeaderText="이름" ReadOnly="True" >
                                    <headerstyle wrap="False"  Width="130px" HorizontalAlign="Center"/>
                                    <ItemStyle horizontalalign="Left"  CssClass="StyleContext2"  />
                                </asp:BoundField>
                                  
                                  <asp:CheckBoxField DataField="Attendance" HeaderText="출석" >
                                  
                                      <HeaderStyle Width="40px" wrap="False" HorizontalAlign="Center" />
                                       <ItemStyle horizontalalign="Center"  />
                                  </asp:CheckBoxField>
                                  
                                <asp:TemplateField HeaderText="불참사유">
                                    <edititemtemplate>
                                    <asp:TextBox id="txtReson" runat="server" Text='<%# Bind("Reason") %>' Width="150px" CssClass="inputArea" ></asp:TextBox> 
                                    </edititemtemplate>
                                    <itemtemplate>
                                    <asp:Label id="Label2" runat="server" Text='<%# Bind("Reason") %>' Width="150px" ></asp:Label> 
                                        
                                    </itemtemplate>
                                    <headerstyle wrap="False" />
                                    <itemstyle horizontalalign="Left" width="150px" />
                                </asp:TemplateField>  
                                <asp:TemplateField HeaderText="특이 사항">
                                    <edititemtemplate>
                                    <asp:TextBox id="txtmemo" runat="server" Text='<%# Bind("Memo") %>' Width="200px" CssClass="inputArea"></asp:TextBox> 
                                    </edititemtemplate>
                                    <itemtemplate>
                                    <asp:Label id="Label1" runat="server" Text='<%# Bind("Memo") %>' Width="200px" ></asp:Label> 
                                    </itemtemplate>
                                    <headerstyle wrap="False" />
                                    <itemstyle horizontalalign="Left" width="180px" />
                                </asp:TemplateField>  
                            </Columns>
                         
                            
        </cc2:BulkEditGridView>  --%>
         <tr><td class="ContentBox2" align="left" ><span style="padding-left:10px;">특별 보고사항 (경조사,환자심방, 가정심방 요청 및 기도제목)</span></td></tr>
        <tr ><td class="ContentBox1">
              <asp:TextBox ID="txtmemo" runat="server" Height="100px" TextMode="MultiLine"  CssClass="inputArea"
                  Width="720px"></asp:TextBox>
        </td></tr>
       
                                   
          <tr><td style=" padding-top:5px;"><table  width="730" border="0" cellspacing="0" cellpadding="0">
                                    <tr><td class="style1">
                                        
                                        </td>
                                        <td class="style1" align="right" >
                                       
                                        <asp:ImageButton ID="btn_save" runat="server" ImageUrl="~/images/bttn_save.gif" 
                                            onclick="btn_save_Click" /></td></tr>
                                    
                                    </table>
                                        
                                      </td></tr>
            
    </td></tr>
  </table>
     </ContentTemplate>
                        </asp:UpdatePanel> 
      <asp:RequiredFieldValidator runat="server" ID="NReq"
            ControlToValidate="txtleader"
            Display="None"
            ErrorMessage="필수 기재 사항입니다. 입력해 주시길 바랍니다." />
                 
 <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1"
            ControlToValidate="txtLocation"
            Display="None"
            ErrorMessage="필수 기재 사항입니다. 입력해 주시길 바랍니다." />
    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RequiredFieldValidator1">
    </cc1:ValidatorCalloutExtender>
                <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="NReq">
                </cc1:ValidatorCalloutExtender>
           
</asp:Content>

