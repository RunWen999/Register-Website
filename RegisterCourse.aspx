<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterCourse.aspx.cs" Inherits="lab6.RegisterCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

   <link href="<%= ResolveUrl("~/App_Themes/SiteStyles.css") %>" rel="stylesheet" type="text/css" />
</head>
<body>
    <h1>Algonquin College Course Registration</h1>
    <form id="form1" runat="server">
        <asp:Panel runat="server" ID="pnlSelection">
        <div>
            <label for="student-name">Student:</label>
            <asp:DropDownList ID="studentName" runat="server" CssClass="dropdown" OnSelectedIndexChanged="studentName_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Selected="True" Value="0">Select ... </asp:ListItem>
            </asp:DropDownList>

        </div>
        <div>
           <asp:RequiredFieldValidator ID="rfvProfession" runat="server" 
                ErrorMessage="Please select one"
                ForeColor="Red" ControlToValidate="studentName" 
                InitialValue="0" Display="Dynamic"></asp:RequiredFieldValidator>
	     </div>











        <p>Following courses are currently available for registration</p>
        <asp:Label ID="success" runat="server" ForeColor="Blue"></asp:Label>
        <br />
        <asp:Label ID="error" runat="server" CssClass ="emphsis"></asp:Label>
        <br />
        <asp:CheckBoxList ID="chklst" runat="server" />
        <br /><br />
        <asp:Button Class="button" ID="submitButton" Text="Save" runat="server" OnClick="submitClick"/>
        <br /><br />
        </asp:Panel>
    </form>
        
    </asp:Panel><br /><br />
     <div>
    <a href="AddStudent.aspx">Add Student</a>
     </div>
</body>
</html>
