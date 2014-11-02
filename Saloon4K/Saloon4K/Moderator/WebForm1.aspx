<%@ Page Title="" Language="C#" MasterPageFile="~/Moderator/Moderator.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Saloon4K.Moderator.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/jquery.bpopup.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="js/settings.js"></script>
    <script src="js/General.js" type="text/javascript"></script>
    <script src="js/plugins/fullcalendar/fullcalendar.js" type="text/javascript"></script>
    <style type="text/css">
        .fc-text-arrow
        {
            float: left;
            margin-top: 7px;
        }
    </style>
   <script type="text/javascript">
       $(document).ready(function () {
           var e = new Date;
           var t = e.getDate();
           var n = e.getMonth();
           var r = e.getFullYear();
           $("#external-events .external-event").each(function () {
               var e = {
                   title: $.trim($(this).text())
               };
               $(this).data("eventObject", e);
               $(this).draggable({
                   zIndex: 999,
                   revert: true,
                   revertDuration: 0
               });
           });
           var i = $("#calendar").fullCalendar({
               header: {
                   left: "prev,next today",
                   center: "title",
                   right: "month,agendaWeek,agendaDay"
               },
               editable: true,
               events: [{
                   title: "All Day Event",
                   start: new Date(r, n, 1)
               }, {
                   title: "Long Event",
                   start: new Date(r, n, t - 5),
                   end: new Date(r, n, t - 2)
               }, {
                   id: 999,
                   title: "Repeating Event",
                   start: new Date(r, n, t - 3, 16, 0),
                   allDay: false
               }, {
                   id: 999,
                   title: "Repeating Event",
                   start: new Date(r, n, t + 4, 16, 0),
                   allDay: false
               }, {
                   title: "Meeting",
                   start: new Date(r, n, t, 10, 30),
                   allDay: false
               }, {
                   title: "Lunch",
                   start: new Date(r, n, t, 12, 0),
                   end: new Date(r, n, t, 14, 0),
                   allDay: false
               }, {
                   title: "Birthday Party",
                   start: new Date(r, n, t + 1, 19, 0),
                   end: new Date(r, n, t + 1, 22, 30),
                   allDay: false
               }, {
                   title: "Click for Google",
                   start: new Date(r, n, 28),
                   end: new Date(r, n, 29),
                   url: "http://google.com/"
               }],
               droppable: true,
               selectable: true,
               selectHelper: true,
               select: function () {
               }
           });
       });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cmsBody" runat="server">
    <div class="row">
        <div class="col-md-12">
            <ol class="breadcrumb">
                <li><a href="javascript:void(0);" class="active">Home</a></li>
            </ol>
        </div>
    </div>
    <div class="row">
        <div class="col-md-10">
            <div id="calendar">
            </div>
        </div>
        <div class="col-md-2">
            <div class="block block-transparent">
                <div class="header">
                    <h2>
                        External events</h2>
                </div>
                <div class="content np">
                    <div class="list list-default" id="external-events">
                        <a href="#" class="list-item external-event">
                            <div class="list-text">
                                Lorem ipsum dolor</div>
                        </a><a href="#" class="list-item external-event">
                            <div class="list-text">
                                Nam a nisi et nisi</div>
                        </a><a href="#" class="list-item external-event">
                            <div class="list-text">
                                Donec tristique eu</div>
                        </a><a href="#" class="list-item external-event">
                            <div class="list-text">
                                Vestibulum cursus</div>
                        </a><a href="#" class="list-item external-event">
                            <div class="list-text">
                                Etiam euismod</div>
                        </a><a href="#" class="list-item external-event">
                            <div class="list-text">
                                Sed pharetra dolor</div>
                        </a>
                    </div>
                </div>
            </div>
            <div class="block block-transparent">
                <div class="content np">
                    <div class="checkbox">
                        <label>
                            <input type="checkbox" id="drop-remove" />
                            Remove after drop</label>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="popEvent" style="display: none;">
        This is event detail;
    </div>
    <div id="popEvent1" style="display: none;">
        This is event detail by the admin user;
    </div>
</asp:Content>
