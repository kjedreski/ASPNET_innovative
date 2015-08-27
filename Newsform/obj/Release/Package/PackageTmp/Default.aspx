<%@ Page Title="Newsletter" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Newsform.Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     
    <h1>Recipe Box </h1>
    <h3>Search</h3>
   <asp:Panel runat="server">
    <table>
        <tr><td><asp:Label ID="L_email" Text="E-Mail" runat="server"></asp:Label></td>
         <td><asp:TextBox ID="T_email" Text="" runat="server" ></asp:TextBox></td></tr>
         <tr><td><asp:Button ID="searchbtn" class="find"  Text="Search" runat="server"  OnClick="searchbtn_Click"   /></td></tr>
     </table>
    </asp:Panel>

    <asp:Label ID="output" runat="server"></asp:Label>    
    <div id="Update" runat="server">
        <br />
        <hr />
        <h3>Update</h3>
        <table>
            <tr>
                <td>   <asp:Label ID="Updt_Lab_email" Text="E-mail" runat="server"></asp:Label>      </td>
                <td>   <asp:TextBox ID="Updt_email" Text="" runat="server" ></asp:TextBox>   </td>

                 <td>   <asp:Label ID="Updt_Lab_city" Text="City" runat="server"></asp:Label>      </td>
                <td>   <asp:TextBox ID="Updt_city" Text="" runat="server" ></asp:TextBox>   </td>
            </tr><tr>
                <td>   <asp:Label ID="Updt_Lab_fname" Text="First Name" runat="server"></asp:Label>      </td>
                <td>   <asp:TextBox ID="Updt_fname" Text="" runat="server" ></asp:TextBox>   </td>    
                 
                <td>   <asp:Label ID="Updt_Lab_zip" Text="Zip" runat="server"></asp:Label>      </td>
                <td>   <asp:TextBox ID="Updt_zip" Text="" runat="server" ></asp:TextBox>   </td>                                                             
            </tr><tr>
                 <td>   <asp:Label ID="Updt_Lab_lname" Text="Last Name" runat="server"></asp:Label>      </td>
                 <td>   <asp:TextBox ID="Updt_lname" Text="" runat="server" ></asp:TextBox>   </td>

            </tr><tr>
                 <td>   <asp:Label ID="Updt_Lab_add" text="Address" runat="server"></asp:Label>  </td>
                 <td>   <asp:TextBox ID="Updt_add" Text="" runat="server" ></asp:TextBox>   </td>

              </tr>
            </table>
        <h5>Account Sites</h5>
        <asp:Panel ID="testPanel" runat="server">
        <table>
            <tr>
                   <td>
                    <asp:CheckBoxList ID="CheckBoxList1" runat="server">
                        <asp:ListItem Value="adamspeanutbutter" Text="Adam's Natural PB"></asp:ListItem>
                        <asp:ListItem Value="crisco" Text="Crisco"></asp:ListItem>
                        <asp:ListItem Value="crosseandblackwell" Text="Crosse & Blackwell"></asp:ListItem>
                           </asp:CheckBoxList>
                        </td>
                <td>
                      <asp:CheckBoxList ID="CheckBoxList2" runat="server">
                        <asp:ListItem Value="dickinsonsfamily" Text="Dickinson's"></asp:ListItem>
                        <asp:ListItem Value="dunkinathome" Text="Dunkin' At Home"></asp:ListItem>
                        <asp:ListItem Value="eaglebrand" Text="Eaglebrand"></asp:ListItem>
                        <asp:ListItem Value="Folgers" Text="Folger's"></asp:ListItem>
                                </asp:CheckBoxList>
                       </td>
                 <td style="width: 207px">
                      <asp:CheckBoxList ID="CheckBoxList3" runat="server">
                        <asp:ListItem Value="hungryjack" Text="Hungry Jack"></asp:ListItem>
                        <asp:ListItem Value="jif" Text="Jif"></asp:ListItem>
                        <asp:ListItem Value="laurascudderspeanutbutter" Text="Laura Scudder's"></asp:ListItem>
                        <asp:ListItem Value="magnoliabrand" Text="Magnolia"></asp:ListItem>
                                </asp:CheckBoxList>
                       </td>
            </tr>
            <tr>
                <td>
                     <asp:CheckBoxList ID="CheckBoxList4" runat="server">
                        <asp:ListItem Value="marthawhite" Text="Martha White"></asp:ListItem>
                        <asp:ListItem Value="medagliadoro" Text="Medaglia D'Oro"></asp:ListItem>
                        <asp:ListItem Value="Millstone" Text="Millstone"></asp:ListItem>
                                </asp:CheckBoxList>
                </td>
                 <td>
                     <asp:CheckBoxList ID="CheckBoxList5" runat="server">
                        <asp:ListItem Value="pillsburybaking" Text="Pillsbury Baking"></asp:ListItem>
                        <asp:ListItem Value="poweroffamilymeals" Text="Power of Family Meal's"></asp:ListItem>
                        <asp:ListItem Value="rwknudsenfamily" Text="R.W. Knudsen"></asp:ListItem>
                                </asp:CheckBoxList>
                </td>
                 <td style="width: 207px">
                     <asp:CheckBoxList ID="CheckBoxList6" runat="server">
                        <asp:ListItem Value="smuckers" Text="Smucker's"></asp:ListItem>
                         <asp:ListItem Value="whitelily" Text="White Lily"></asp:ListItem>
                                </asp:CheckBoxList>
                </td>
            </tr>
        </table>
            </asp:Panel>
        <asp:Button ID="Updt_btn" class="Update"  runat="server" Text="Update" OnClick="Updt_btn_Click" />
        <asp:Button ID="Dlt_btn"  class="Delete" runat="server" Text="Delete" OnClick="Dlt_btn_Click" />
    </div>
    
    <div id="dvMsg" class="notification" runat="server" visible="false">
        <asp:Label ID="lblMsg" runat="server"></asp:Label>
    </div>

</asp:Content>
