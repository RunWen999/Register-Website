<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="lab6.Addstudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

   <link href="<%= ResolveUrl("~/App_Themes/SiteStyles.css") %>" rel="stylesheet" type="text/css" />
</head>
<body>
    <h1>Student</h1>
    <form id="form1" runat="server">
        
        <div>
            <label for="student-name">Student Name:</label>
            <asp:TextBox ID="studentName" runat="server" CssClass="input"></asp:TextBox>

            <div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                 ForeColor="Red" Display="Dynamic"
                 ControlToValidate="studentName" EnableClientScript="true">Required!</asp:RequiredFieldValidator>
	        </div>

            <br />
            <br />

            <label for="student-Type">Student Type  : </label>
            <asp:DropDownList ID="studentType" runat="server" CssClass="dropdown">
                <asp:ListItem Selected="True" Value="-1" TabIndex="0">Please Select One...</asp:ListItem>
                <asp:ListItem Text="Full Time" Value="1" TabIndex="1"></asp:ListItem>
                <asp:ListItem Text="Part Time" Value="2" TabIndex="2"></asp:ListItem>
                <asp:ListItem Text="Coop" Value="3" TabIndex="3"></asp:ListItem>
            </asp:DropDownList>
           <div>
           <asp:RequiredFieldValidator ID="rfvProfession" runat="server" 
                ErrorMessage="Please select one"
                ForeColor="Red" ControlToValidate="studentType" 
                InitialValue="-1" Display="Dynamic"></asp:RequiredFieldValidator>
	     </div>
        </div>
        <br />

            
        <asp:Panel runat="server" ID="pnlSelection">
        <asp:Button Class="button" ID="add" Text="Add" runat="server" />
        <br /><br />
       
        </asp:Panel>

    </form>
     <asp:Panel runat="server" ID="pnlTable" >
        <asp:Table ID="studentInfo" runat="server" CssClass="table"> 
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                <asp:TableHeaderCell>Name</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>

       
    </asp:Panel>
    <br /><br />
    <div>
    <a href="RegisterCourse.aspx">RegisterCourse</a>
</div>
</body>
</html>
