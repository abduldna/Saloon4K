<%@ Page Title="Users Analytics" Language="C#" MasterPageFile="~/Moderator/Moderator.Master"
    AutoEventWireup="true" CodeBehind="DashboardNewsLettersAnalytics.aspx.cs" Inherits="Saloon4K.Moderator.DashboardNewsLettersAnalytics" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                <li><a href="~/Moderator/Home.aspx" runat="server">Calender</a></li>
                <li><a href="~/Moderator/DashboardUsersAnalytics.aspx" runat="server">Users Analytics</a></li>
                <li><a href="~/Moderator/DashboardSalonsAnalyticsPage.aspx" runat="server">Salons Analytics</a></li>
                <li><a href="~/Moderator/DashboardDealsAnalyticsPage.aspx" runat="server">Deals Analytics</a></li>
                <li class="active"><a href="~/Moderator/DashboardNewsLettersAnalytics.aspx" runat="server">
                    Newsletters Analytics</a></li>
                <li><a href="~/Moderator/DashboardMouseTrackingAnalyticsPage.aspx" runat="server">Mouse
                    Tracking Analytics</a></li>
            </ul>
            <div class="content tab-content">
                <div class="col-md-12">
                    <div class="content controls">
                        <div class="form-row">
                            <asp:UpdatePanel ID="upMonths" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <div class="chartControls marginTop25">
                                        <div>
                                            <span>Chart Type:</span>
                                            <asp:DropDownList ID="ddlChartType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlChartType_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                        <div>
                                            <span>Country:</span>
                                            <asp:DropDownList runat="server" ID="ddlCountry" />
                                        </div>
                                        <div>
                                            <span>Month:</span>
                                            <asp:DropDownList ID="ddlMonth" runat="server">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="01">January</asp:ListItem>
                                                <asp:ListItem Value="02">February</asp:ListItem>
                                                <asp:ListItem Value="03">March</asp:ListItem>
                                                <asp:ListItem Value="04">April</asp:ListItem>
                                                <asp:ListItem Value="05">May</asp:ListItem>
                                                <asp:ListItem Value="06">June</asp:ListItem>
                                                <asp:ListItem Value="07">July</asp:ListItem>
                                                <asp:ListItem Value="08">August</asp:ListItem>
                                                <asp:ListItem Value="09">September</asp:ListItem>
                                                <asp:ListItem Value="10">October</asp:ListItem>
                                                <asp:ListItem Value="11">November</asp:ListItem>
                                                <asp:ListItem Value="12">December</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div>
                                            <asp:Button runat="server" ID="btnSearch" OnClick="btnSearch_Click" Text="SEARCH"
                                                Style="width: 85px !important; height: 30px; margin-left: 44px;" />
                                        </div>
                                    </div>
                                    <div class="chartArea" id="divChart" runat="server">
                                        <asp:Chart ID="ChartNewslettersHistory" runat="server" Width="1150px" Height="500px"
                                            BackColor="Transparent">
                                            <Series>
                                                <asp:Series Name="History" ChartType="Line" BorderWidth="2" Color="#3B8EED" MarkerColor="White"
                                                    MarkerStyle="Circle" MarkerSize="12" IsValueShownAsLabel="True" LabelForeColor="White">
                                                </asp:Series>
                                            </Series>
                                            <ChartAreas>
                                                <asp:ChartArea Name="ChartArea1" BackColor="Transparent">
                                                    <AxisX LineColor="#CBCACB">
                                                        <MajorGrid LineWidth="1" Interval="Auto" LineDashStyle="DashDotDot" LineColor="#9BA4A1" />
                                                    </AxisX>
                                                    <AxisY LineColor="#CBCACB">
                                                        <MajorGrid LineWidth="1" Interval="Auto" LineDashStyle="DashDotDot" LineColor="#9BA4A1" />
                                                    </AxisY>
                                                </asp:ChartArea>
                                            </ChartAreas>
                                            <Legends>
                                                <asp:Legend Name="StartDate" Docking="Right" ForeColor="White" BackColor="Transparent">
                                                </asp:Legend>
                                            </Legends>
                                        </asp:Chart>
                                    </div>
                                    <div id="divMessage" runat="server" visible="False" style="padding: 3px; clear: both;
                                        margin-top: 45px;">
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
