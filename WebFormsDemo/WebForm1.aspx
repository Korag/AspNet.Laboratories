<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebFormsDemo.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="margin-top: 10px">
        <tr>
            <td class="font-weight-bold">Url:</td>
            <td>
                <asp:TextBox CssClass="form-control" ID="txtUrl" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button CssClass="btn btn-success" ID="btnGetRss" runat="server" Text="Get Feed" OnClick="btnGetRss_Click" />
            </td>
        </tr>
    </table>

    <div class="container">
        <div class="row">
            <asp:Repeater ID="Repeater1" runat="server"
                ItemType="WebFormsDemo.Model.RssItem">
                <ItemTemplate>
                        <div class="col-sm-6 col-lg-6 col-md-6">
                            <h3><%# Item.Title %></h3>
                            <span><%# Item.PubDate %></span>
                            <p><%# Item.Description%></p>

                            <%--    <p><%# Eval("Description")%></p>--%>

                            <%--2 kolumny i fajnie ostylowac button i input w jednym wierszu--%>
                        </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>

</asp:Content>
