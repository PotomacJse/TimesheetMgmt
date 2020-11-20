<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeePanelMaster.Master" AutoEventWireup="true" CodeBehind="ViewTimesheetInEmpPanel.aspx.cs" Inherits="TimeSheetManagement.ViewTimesheetInEmpPanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text="Date"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server" TextMode="Date"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="Show" OnClick="Button1_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:GridView ID="GridView1" runat="server"  Width="1295px" 
            
             OnRowUpdating="GridView1_RowUpdating" 
            OnRowDeleting="GridView1_RowDeleting"
            OnRowEditing="GridView1_RowEditing"
            OnRowCancelingEdit="GridView1_RowCancelingEdit"
            OnRowSelecting="GridView1_RowSelecting"
            DataKeyNames="Project_Name, Task_ID"  AutoGenerateColumns="False">
            

            <AlternatingRowStyle BackColor="White" />
           
            
            <Columns>
                <asp:TemplateField HeaderText ="Project Name">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("Project_Name") %>'></asp:Label>
                    </ItemTemplate>
                    
                </asp:TemplateField>

                <asp:TemplateField HeaderText ="Task ID">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("Task_ID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText ="Task Description">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("Task_Desc") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Textbox ID="TextBoxTaskDesc" runat="server" Text='<%# Bind("Task_Desc") %>'></asp:Textbox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText ="Effort">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("Efforts") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Textbox ID="TextBoxEfforts" runat="server" Text='<%# Bind("Efforts") %>'></asp:Textbox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:CommandField ShowDeleteButton="true" ControlStyle-CssClass="btn btn-danger" HeaderText="Remove Record" >
                    <ControlStyle CssClass="btn btn-danger"></ControlStyle>
                </asp:CommandField>

                <asp:CommandField ShowEditButton="true" ControlStyle-CssClass="btn btn-primary" HeaderText="Edit Record" >
                    <ControlStyle CssClass="btn btn-primary"></ControlStyle>    
                </asp:CommandField>


           </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
    </p>
    <p>
    </p>
</asp:Content>
