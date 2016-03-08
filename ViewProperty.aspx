<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ViewProperty.aspx.cs" Inherits="ViewProperty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>View Property Details</h2>
             

                
    <p>
       
                   <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333" GridLines="None">
                       <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
                    <asp:BoundField DataField="location" HeaderText="Address" SortExpression="location" />
                    <asp:BoundField DataField="no_of_rooms" HeaderText="Rooms Available" SortExpression="no_of_rooms" />
                    <asp:BoundField DataField="price" HeaderText="Guided Price" SortExpression="price" />
                    <asp:BoundField DataField="host" HeaderText="Host" SortExpression="host" />
                    <asp:HyperLinkField NavigateUrl="../UserProfile.aspx?hostId={host}" HeaderText="Profile" Text="View Profile" />
                </Columns>
                       <EditRowStyle BackColor="#7C6F57" />
                       <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                       <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                       <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                       <RowStyle BackColor="#E3EAEB" />
                       <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                       <SortedAscendingCellStyle BackColor="#F8FAFA" />
                       <SortedAscendingHeaderStyle BackColor="#246B61" />
                       <SortedDescendingCellStyle BackColor="#D4DFE1" />
                       <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BedAndBreakfastDatabase %>" SelectCommand="SELECT [name], [location], [no_of_rooms], [no_of_guests], [price], [host] FROM [Property] WHERE ([id] = @id)">
            <SelectParameters>
                <asp:QueryStringParameter Name="id" DefaultValue="1" QueryStringField="propertyId" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
            </p>
    <p>
        <asp:Label ID="AddPicLabel" runat="server" Text="Add More Pictures" Visible="false"></asp:Label></p>
    <p>        
        <asp:FileUpload ID="FileUpload" CssClass="btn btn-default" style="display: inline-block" runat="server" Visible="false"/>
    <asp:Button ID="btnUpload" CssClass="btn btn-default" style="display: inline-block" runat="server" Text="Upload"
        OnClick="btnUpload_Click" Visible="false"/>
    <br />
    <asp:Label ID="lblMessage" runat="server" Text=""
        Font-Names="Arial"></asp:Label>
        
        <asp:PlaceHolder ID="Images" runat="server" Visible="false"></asp:PlaceHolder>
        <asp:Image ID="Image1" runat="server" Visible="false" /></p>


                <p>
                    <asp:Button ID="SearchResultBtn" class="btn btn-default" runat="server" Text="Back to Search" OnClick="Search_Result"/>
                <asp:Button class="btn btn-default" ID="ContactHostBtn" runat="server" Text="Contact Host" OnClick="Contact_Host"/>
                 <asp:Button ID="DoBookingBtn" class="btn btn-default" runat="server" Text="Request Booking" OnClick="Request_Booking" />
            </p>
</asp:Content>

