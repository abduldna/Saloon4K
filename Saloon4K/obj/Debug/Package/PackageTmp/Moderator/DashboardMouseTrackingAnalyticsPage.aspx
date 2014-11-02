<%@ Page Title="Salons Analytics" Language="C#" MasterPageFile="~/Moderator/Moderator.Master"
    AutoEventWireup="true" CodeBehind="DashboardMouseTrackingAnalyticsPage.aspx.cs"
    Inherits="Saloon4K.Moderator.DashboardMouseTrackingAnalyticsPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .chartControls div select
        {
            width: 175px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cmsBody" runat="server">
    <div class="row">
        <div class="col-md-12">
            <ol class="breadcrumb">
                <li><a href="javascript:void(0);" class="active" title="Dashboard">Dashboard</a></li>
            </ol>
        </div>
    </div>
    <div class="row">
        <div class="block">
            <ul class="nav nav-tabs">
                <li ><a id="A1" href="~/Moderator/Home.aspx" runat="server">Calender</a></li>
                <li><a id="A2" href="~/Moderator/DashboardUsersAnalytics.aspx" runat="server">Users
                    Analytics</a></li>
                <li><a id="A3" href="~/Moderator/DashboardSalonsAnalyticsPage.aspx" runat="server">Salons
                    Analytics</a></li>
                <li><a id="A4" href="~/Moderator/DashboardDealsAnalyticsPage.aspx" runat="server">Deals
                    Analytics</a></li>
                <li><a id="A5" href="~/Moderator/DashboardNewsLettersAnalytics.aspx" runat="server">
                    Newsletters Analytics</a></li>
                <li class="active"><a id="A6" href="~/Moderator/DashboardMouseTrackingAnalyticsPage.aspx" runat="server">
                    Mouse Tracking Analytics</a></li>
            </ul>
            <div class="content tab-content">
                <div class="col-md-10">
                    <div id="calendar">
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="block">
                        <div class="header">
                            <h2>
                                Users Like Adds</h2>
                        </div>
                        <div class="content controls">
                            <div class="form-row">
                                <div id="divMessage" runat="server" visible="False">
                                </div>
                                <div class="divControl">
                                    <label>
                                        Country</label>
                                    <asp:DropDownList runat="server" ID="ddlCountry" OnSelectedIndexChanged="ddlChartType_SelectedIndexChanged"
                                        CssClass="width225" AutoPostBack="True">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div role="grid" class="dataTables_wrapper">
                                <asp:UpdatePanel runat="server" ID="upUser">
                                    <ContentTemplate>
                                        <table class="table table-bordered table-striped dataTable">
                                            <thead>
                                                <tr>
                                                    <th>
                                                        Image
                                                    </th>
                                                    <th>
                                                        Alignment
                                                    </th>
                                                    <th>
                                                        Page
                                                    </th>
                                                    <th>
                                                        Country
                                                    </th>
                                                    <th>
                                                        Count Users
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater runat="server" ID="rptAdds">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td>
                                                                <asp:Image runat="server" ID="imgImage" ImageUrl='<%# ConfigurationManager.AppSettings["SiteUrl"]+"Uploads/Adds/"+Eval("Image1") %>'
                                                                    Style="width: 100px; height: 100px;" />
                                                            </td>
                                                            <td>
                                                                <%# Eval("Alignment1") %>
                                                            </td>
                                                            <td>
                                                                <%# Eval("PageName")%>
                                                            </td>
                                                            <td>
                                                                <%# Eval("Country")%>
                                                            </td>
                                                            <td>
                                                                <%# Eval("Count")%>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                        </table>
                                        <div class="dataTables_info" id="DataTables_Table_2_info">
                                            Showing 1 to 5 of 10 entries</div>
                                        <div class="dataTables_paginate paging_full_numbers" id="DataTables_Table_2_paginate">
                                            <a class="first paginate_button paginate_button_disabled" tabindex="0" id="DataTables_Table_2_first">
                                                First</a><a class="previous paginate_button paginate_button_disabled" tabindex="0"
                                                    id="DataTables_Table_2_previous">Previous</a><span><a class="paginate_active" tabindex="0">1</a><a
                                                        class="paginate_button" tabindex="0">2</a></span><a class="next paginate_button"
                                                            tabindex="0" id="DataTables_Table_2_next">Next</a><a class="last paginate_button"
                                                                tabindex="0" id="DataTables_Table_2_last">Last</a></div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
