<%@ Page Title="Home" Language="C#" MasterPageFile="~/Moderator/Moderator.Master"
    AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Saloon4K.Moderator.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/jquery.bpopup.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="js/settings.js"></script>
    <script src="js/General.js" type="text/javascript"></script>
    <script src="js/plugins/fullcalendar/fullcalendar.js" type="text/javascript"></script>
    <style type="text/css">
        .fc-text-arrow
        {
            float: left;
            margin-top: 9px;
        }
        .ddl
        {
            margin-top: 8px;
            width: 170px !important;
        }
        .txt
        {
            margin-top: 8px;
            width: 170px !important;
            margin-left: 0 !important;
        }
        .list span
        {
            font-size: 13px;
            font-weight: bold;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            GetAllFeaturedDeals();
        });
        function GetAllFeaturedDeals() {
            var country = jQuery("#cmsBody_ddlCountry option:selected").val();
            jQuery.ajax({
                type: "POST",
                url: "http://localhost:64196/Moderator/Home.aspx/GetAllFeaturedDeals",
                data: "{'country':'" + country + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    $('#calendar').fullCalendar({
                        header: {
                            left: 'prev,next today',
                            center: 'title',
                            right: 'month,agendaWeek,agendaDay'
                        },
                        editable: true,
                        events: $.map(data.d, function (item) {
                            var event = new Object();
                            event.start = new Date(parseInt(item.AddedDate.substr(6)));
                            event.title = item.Name.toString().substr(0, 22);
                            event.id = item.DealId;
                            event.description = item.Description;
                            event.type = "FeaturedDeals";
                            return event;
                        })
                    });
                }
            });
        }

        function getSearchResult() {
            jQuery("#calendar").html("");
            var from = jQuery("#cmsBody_txtFrom").val();
            var to = jQuery("#cmsBody_txtTo").val();
            var country = jQuery("#cmsBody_ddlCountry option:selected").val();
            var e = document.getElementById("cmsBody_ddlType");
            var type = e.options[e.selectedIndex].value;
            if (type == "FeaturedDeals") {
                jQuery("#cmsBody_hfType").val("FeaturedDeals");
                jQuery.ajax({
                    type: "POST",
                    url: "http://localhost:64196/Moderator/Home.aspx/SearchFeaturedDeals",
                    data: "{'from':'" + from + "','to':'" + to + "','country':'" + country + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        $('#calendar').fullCalendar({
                            header: {
                                left: 'prev,next today',
                                center: 'title',
                                right: 'month,agendaWeek,agendaDay'
                            },
                            editable: true,
                            events: $.map(data.d, function (item) {
                                var event = new Object();
                                event.start = new Date(parseInt(item.AddedDate.substr(6)));
                                event.title = item.Name.toString().substr(0, 22);
                                event.id = item.DealId;
                                event.description = item.Description;
                                event.type = "FeaturedDeals";
                                return event;
                            })
                        });
                    }
                });
            }
            else if (type == "Deals") {
                jQuery("#cmsBody_hfType").val("Deals");
                jQuery.ajax({
                    type: "POST",
                    url: "http://localhost:64196/Moderator/Home.aspx/SearchDeals",
                    data: "{'from':'" + from + "','to':'" + to + "','country':'" + country + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        $('#calendar').fullCalendar({
                            header: {
                                left: 'prev,next today',
                                center: 'title',
                                right: 'month,agendaWeek,agendaDay'
                            },
                            editable: true,
                            events: $.map(data.d, function (item) {
                                var event = new Object();
                                event.start = new Date(parseInt(item.AddedDate.substr(6)));
                                event.title = item.Name.toString().substr(0, 22);
                                event.id = item.DealId;
                                event.description = item.Description;
                                event.type = "Deals";
                                return event;
                            })
                        });
                    }
                });
            }
            else if (type == "Salons") {
                jQuery("#cmsBody_hfType").val("Salons");
                jQuery.ajax({
                    type: "POST",
                    url: "http://localhost:64196/Moderator/Home.aspx/SearchSalons",
                    data: "{'from':'" + from + "','to':'" + to + "','country':'" + country + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        $('#calendar').fullCalendar({
                            header: {
                                left: 'prev,next today',
                                center: 'title',
                                right: 'month,agendaWeek,agendaDay'
                            },
                            editable: true,
                            events: $.map(data.d, function (item) {
                                var event = new Object();
                                event.start = new Date(parseInt(item.AddedDate.substr(6)));
                                event.title = item.Name.toString().substr(0, 22);
                                event.id = item.SalonId;
                                event.description = item.Description;
                                event.type = "Salons";
                                return event;
                            })
                        });
                    }
                });
            }
            else if (type == "Users") {
                jQuery("#cmsBody_hfType").val("Users");
                jQuery.ajax({
                    type: "POST",
                    url: "http://localhost:64196/Moderator/Home.aspx/SearchUsers",
                    data: "{'from':'" + from + "','to':'" + to + "','country':'" + country + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        $('#calendar').fullCalendar({
                            header: {
                                left: 'prev,next today',
                                center: 'title',
                                right: 'month,agendaWeek,agendaDay'
                            },
                            editable: true,
                            events: $.map(data.d, function (item) {
                                var event = new Object();
                                event.start = new Date(parseInt(item.AddedDate.substr(6)));
                                event.title = item.Firstname + " " + item.Lastname;
                                event.id = item.UserId;
                                event.description = item.About;
                                event.type = "Users";
                                return event;
                            })
                        });
                    }
                });
            }
        }

    </script>
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
                <li class="active"><a href="~/Moderator/Home.aspx" runat="server">Calender</a></li>
                <li><a href="~/Moderator/DashboardUsersAnalytics.aspx" runat="server">Users Analytics</a></li>
                <li><a href="~/Moderator/DashboardSalonsAnalyticsPage.aspx" runat="server">Salons Analytics</a></li>
                <li><a href="~/Moderator/DashboardDealsAnalyticsPage.aspx" runat="server">Deals Analytics</a></li>
                <li><a href="~/Moderator/DashboardNewsLettersAnalytics.aspx" runat="server">Newsletters
                    Analytics</a></li>
                <li><a href="~/Moderator/DashboardMouseTrackingAnalyticsPage.aspx" runat="server">
                    Mouse Tracking Analytics</a></li>
            </ul>
            <div class="content tab-content">
                <div class="col-md-10">
                    <div id="calendar">
                    </div>
                </div>
                <div class="col-md-2">
                    <div class="block block-transparent">
                        <div class="header">
                            <h2>
                                Search</h2>
                        </div>
                        <div class="list list-default">
                            <div class="col-md-9 divSearch mtop10">
                                <span>Country</span>
                                <asp:DropDownList runat="server" ID="ddlCountry" CssClass="form-control ddl" />
                            </div>
                            <div class="col-md-9 divSearch">
                                <span>Type</span>
                                <select class="form-control ddl" id="ddlType" runat="server">
                                    <option value="FeaturedDeals">Featured Deals</option>
                                    <option value="Deals">Deals</option>
                                    <option value="Salons">Salons</option>
                                    <option value="Users">Users</option>
                                </select>
                            </div>
                            <div class="col-md-9 divSearch mtop10">
                                <span>From</span>
                                <asp:TextBox runat="server" ID="txtFrom" CssClass="form-control datepicker txt"></asp:TextBox></div>
                            <div class="col-md-9 divSearch mtop10">
                                <span>To</span>
                                <asp:TextBox runat="server" ID="txtTo" CssClass="form-control datepicker txt"></asp:TextBox></div>
                        </div>
                        <div class="block block-transparent">
                            <div class="content np">
                                <a onclick="getSearchResult();" href="javascript:void(0);" class="btn btn-default btn-block btn-clean"
                                    style="margin: 15px 0 0 35px; width: 121px;">SEARCH</a>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="popEvent" style="display: none;">
                    This is event detail
                </div>
                <div id="popEvent1" style="display: none;" class="popUpSmall">
                    <asp:HiddenField runat="server" ID="hfItemId" Value="0" />
                    <div class="popUpSmallContent mtop70">
                        <span>Name:</span>
                        <label id="lblName">
                        </label>
                    </div>
                    <div class="popUpSmallContent">
                        <span>Description:</span>
                        <label id="lblDescription">
                        </label>
                    </div>
                    <div class="popUpSmallContent">
                        <span>Added Date:</span>
                        <label id="lblAddedDate">
                        </label>
                    </div>
                    <div class="popUpSmallContent" style="margin-top: 0; text-align: center;">
                        <asp:HiddenField runat="server" ID="hfType" Value="FeaturedDeals" />
                        <a id="lnkEdit" title="Edit" class="widget-icon widget-icon-large widget-icon-circle"
                            style="margin-left: -34px;"><span class="icon-pencil spanIcon"></span></a><a title="Delete"
                                id="lnkDelete" class="widget-icon widget-icon-large widget-icon-dark" style="margin-left: 18px;
                                margin-top: 70px;"><span class="icon-trash spanIcon"></span></a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
