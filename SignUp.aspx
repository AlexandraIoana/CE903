<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="SignUp.aspx.cs" Inherits="SignUp" %>

<%@ Register src="SignUpControl.ascx" tagname="SignUpControl" tagprefix="uc1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div>
            <table style="width:100%;">
                <tr>
                    <td>
                        <asp:Button ID="SignUpCustomer_btn" runat="server" Text="Sign Up as Customer" OnClick="SignUpTab_Click" CausesValidation="False" BackColor="Silver" />
                        <asp:Button ID="SignUpHost_btn" runat="server" Text="Sign Up as Host" OnClick="SignUpTab_Click" CausesValidation="False" BackColor="Silver"/>
                        <asp:MultiView ID="SignUpViews" runat="server">
                            <asp:View ID="view_customer" runat="server">
                                <uc1:SignUpControl ID="SignUpControl_Customer" runat="server" />
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Please complete all the fields before proceeding: " />
                                <asp:Button ID="registerCustomer" runat="server" Text="Sign Up" OnClick="registerCustomer_Click" />
                                <asp:Label ID="errorCustomer_msg" runat="server"></asp:Label>
                            </asp:View>
                            <asp:View ID="view_host" runat="server">
                                <uc1:SignUpControl ID="SignUpControl_Host" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="contactNumber" ErrorMessage="Contact number is required">*</asp:RequiredFieldValidator>        
                                <asp:Label ID="contactNumber_lbl" runat="server" Text="Contact number"></asp:Label>
                                <asp:TextBox ID="contactNumber" runat="server"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="contactNumber" Display="Dynamic" ErrorMessage="Contact number format example: 07987654321" ValidationExpression="^(\+44\s?7\d{3}|\(?07\d{3}\)?)\s?\d{3}\s?\d{3}$"></asp:RegularExpressionValidator>
                                <br />
                                <asp:ValidationSummary ID="ValidationSummary2" runat="server" HeaderText="Please complete all the fields before proceeding: " />
                                <asp:Button ID="registerHost" runat="server" Text="Sign Up" OnClick="registerHost_Click" />
                                <asp:Label ID="errorHost_msg" runat="server"></asp:Label>
                            </asp:View>
                        </asp:MultiView>
                    </td>
                </tr>
            </table>
    </div>
</asp:Content>

