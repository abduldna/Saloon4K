<%@ Page Title="Add Management" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AddManagement.aspx.cs" Inherits="Saloon4K.AddManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/smart_wizard.css" rel="stylesheet" type="text/css" />
    <script src="js/Wizard.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#step1").show('slow');
            $("#ancstep1").addClass("stepActive");
            $("#body_txtStartDate").datepicker();
            $("#body_txtEndDate").datepicker();
            $("#body_txtStartDateRightAdd").datepicker();
            $("#body_txtEndDateRightAdd").datepicker();
        });        
        function btnSelected(id) {
            RemoveSelectPageActiveClass();
            $("#" + id).addClass("btnPageActive");
            $("#<%= hfPageName.ClientID %>").val("");
            $("#<%= hfPageName.ClientID %>").val($("#" + id).val());
            return false;
        }

        function validateSelectPage() {
            if ($("#<%= hfPageName.ClientID %>").val() == "") {
                alert("Please select a page.");
                return false;
            } else {
                $("#ancstep2").addClass("stepActive");
                $("#step1").hide('slow');
                $("#step2").show('slow');
                return false;
            }
        }

        function validateUserPage() {
            if ($('#body_cbPublic').attr('checked') || $('#body_cbSecured').attr('checked')) {
                $("#ancstep3").addClass("stepActive");
                $("#step2").hide('slow');
                $("#step3").show('slow');
                return false;

            } else {
                alert("Please select a page.");
                return false;
            }
        }
        function countryFlag(id) {
            RemoveCountryFlagClass();
            $("#" + id).addClass("btnCountryFlagActive");
            $("#<%= hfCountryFlag.ClientID %>").val("");
            $("#<%= hfCountryFlag.ClientID %>").val($("#" + id).attr("title"));
            return false;
        }

        function validateCountryPage() {
            if ($("#<%= hfCountryFlag.ClientID %>").val() == "") {
                alert("Please select a country flag.");
                return false;
            } else {
                $("#ancstep4").addClass("stepActive");
                $("#step3").hide('slow');
                $("#step4").show('slow');
                if ($("#<%= hfPageName.ClientID %>").val() == "DIRECTORY" || $("#<%= hfPageName.ClientID %>").val() == "POP UP") {
                    $("#template1").hide();
                    $("#template2").show();
                } else {
                    $("#template2").hide();
                    $("#template1").show();
                }
                return false;
            }
        }
        function ShowDivNewsletter() {
            $('#divBannerAdd').bPopup({
                onOpen: function () {
                },
                onClose: function () {
                }
            });
            $('#<%=upBannerAdd.ClientID %>').parent().appendTo($("form:first"));
            return false;
        }
        function ShowRigtAdd(id) {
            $("#body_hfPositionOfImage").val(id);
            $('#divRightAdd').bPopup({
                onOpen: function () {
                },
                onClose: function () {
                }
            });
            $('#<%=upRightAdd.ClientID %>').parent().appendTo($("form:first"));
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="content">
        <div class="homecontent">
            <div id="divMessage" runat="server" visible="False" style="width: 97%;">
            </div>
            <div class="row1container" style="width: 100%;">
                <div id="wizard">
                    <ul class="ulTabs">
                        <li><a href="javascript:void(0);" id="ancstep1" onclick="step1();">
                            <label>
                                1</label>
                            <span>Select Page<br />
                            </span></a></li>
                        <li><a href="javascript:void(0);" id="ancstep2" onclick="step2();">
                            <label>
                                2</label>
                            <span>Select Users<br />
                            </span></a></li>
                        <li><a href="javascript:void(0);" id="ancstep3" onclick="step3();">
                            <label>
                                3</label>
                            <span>Select Country<br />
                            </span></a></li>
                        <li><a href="javascript:void(0);" id="ancstep4" onclick="step4();">
                            <label>
                                4</label>
                            <span>Manage Add<br />
                            </span></a></li>
                    </ul>
                    <div id="step1" class="tabArea">
                        <div class="selectButton">
                            <asp:HiddenField runat="server" ID="hfPageName" Value="" />
                            <asp:Button runat="server" ID="btnHome" Text="HOME" OnClientClick="return btnSelected(this.id);" />
                            <asp:Button runat="server" ID="btnDeals" Text="DEALS" OnClientClick="return btnSelected(this.id);" />
                            <asp:Button runat="server" ID="btnDirectory" Text="DIRECTORY" OnClientClick="return btnSelected(this.id);" />
                            <asp:Button runat="server" ID="btnMySalon4k" Text="My SALON 4K" OnClientClick="return btnSelected(this.id);" />
                            <asp:Button runat="server" ID="btnAboutUs" Text="ABOUT US" OnClientClick="return btnSelected(this.id);" />
                            <asp:Button runat="server" ID="btnContactUs" Text="CONTACT US" OnClientClick="return btnSelected(this.id);" />
                            <asp:Button runat="server" ID="btnPopup" Text="POP UP" OnClientClick="return btnSelected(this.id);" />
                        </div>
                        <div class="wizardButtons">
                            <asp:Button runat="server" ID="btnNextPage" Text="NEXT" ValidationGroup="Add" Style="margin-left: -17px;"
                                OnClientClick="return validateSelectPage();" />
                        </div>
                    </div>
                    <div id="step2" class="tabArea">
                        <div class="wizardUsers">
                            <asp:CheckBox runat="server" ID="cbPublic" Text="PUBLIC" />
                            <asp:CheckBox runat="server" ID="cbSecured" Text="SECURED" />
                        </div>
                        <div class="wizardButtons">
                            <asp:Button runat="server" ID="btnNextUser" Text="NEXT" ValidationGroup="Add" Style="margin-left: -17px;"
                                OnClientClick="return validateUserPage();" />
                        </div>
                    </div>
                    <div id="step3" class="tabArea">
                        <div class="divCountryFlags">
                            <asp:HiddenField runat="server" ID="hfCountryFlag" Value="" />
                            <asp:ImageButton runat="server" ID="btnUae" ImageUrl="images/UAEButterfly.png" OnClientClick="return countryFlag(this.id);"
                                ToolTip="UnitedArabEmirates" />
                            <asp:ImageButton ID="btnKuwait" runat="server" ImageUrl="images/KuwaitButterfly.png"
                                ToolTip="Kuwait" OnClientClick="return countryFlag(this.id);" />
                            <asp:ImageButton ID="btnSaudiArabia" runat="server" ImageUrl="images/SaudiArabia.png"
                                ToolTip="SaudiArabia" OnClientClick="return countryFlag(this.id);" />
                        </div>
                        <div class="wizardButtons" style="margin-top: -55px;">
                            <asp:Button runat="server" ID="btnNextCountry" Text="NEXT" ValidationGroup="Add"
                                Style="margin-left: -17px;" OnClientClick="return validateCountryPage();" />
                        </div>
                    </div>
                    <div id="step4" class="tabArea">
                        <div id="template1" style="display: none;">
                            <asp:ImageButton runat="server" ID="imgSliderAdd" ImageUrl="images/banner1.jpg" Style="width: 970px;
                                cursor: pointer;" OnClientClick="return ShowDivNewsletter();" />
                            <asp:ImageButton runat="server" ID="RightAdd" ImageUrl="images/neutrogena.jpg" ClientIDMode="Static"
                                CssClass="smallAdd" OnClientClick="return ShowRigtAdd(this.id);" Style="float: right !important;" />
                        </div>
                        <div id="template2" style="display: none;">
                            <asp:ImageButton runat="server" ID="imgSliderAdd1" ImageUrl="images/banner1.jpg"
                                Style="width: 970px; cursor: pointer;" OnClientClick="return ShowDivNewsletter();" />
                            <asp:ImageButton runat="server" ID="LeftAdd1" ImageUrl="images/mpu1.jpg" CssClass="smallAdd"
                                ClientIDMode="Static" OnClientClick="return ShowRigtAdd(this.id);" />
                            <asp:ImageButton runat="server" ID="LeftAdd2" ImageUrl="images/mpu3.jpg" CssClass="smallAdd"
                                OnClientClick="return ShowRigtAdd(this.id);" ClientIDMode="Static" />
                            <asp:ImageButton runat="server" ID="LeftAdd3" ImageUrl="images/mpu4.jpg" CssClass="smallAdd"
                                OnClientClick="return ShowRigtAdd(this.id);" ClientIDMode="Static" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="divBannerAdd" class="popUpNewsletter" style="display: none; height: 400px;">
            <asp:UpdatePanel runat="server" ID="upBannerAdd">
                <ContentTemplate>
                    <h3>
                        Advertisement Details</h3>
                    <div class="mtop10">
                        <div class="addImageDiv mleft120">
                            <span>Image 1:</span>
                            <asp:FileUpload runat="server" ID="fuImage1" CssClass="floatLeft" />
                        </div>
                    </div>
                    <div class="mtop10">
                        <div class="addImageDiv mleft120">
                            <span>Image 2:</span>
                            <asp:FileUpload runat="server" ID="fuImage2" CssClass="floatLeft" />
                        </div>
                    </div>
                    <div class="mtop10">
                        <div class="addImageDiv mleft120">
                            <span>Image 3:</span>
                            <asp:FileUpload runat="server" ID="fuImage3" CssClass="floatLeft" />
                        </div>
                    </div>
                    <div class="mleft120" style="margin-top: 30px;">
                        <span>Start Date:</span>
                        <asp:TextBox runat="server" ID="txtStartDate"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="rftxtStartDate" ControlToValidate="txtStartDate"
                            Display="Dynamic" CssClass="addError" ErrorMessage="Required" ValidationGroup="Add"> 
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="mtop10 mleft120">
                        <span>End Date:</span>
                        <asp:TextBox runat="server" ID="txtEndDate"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="rftxtEndDate" ControlToValidate="txtEndDate"
                            Display="Dynamic" CssClass="addError" ErrorMessage="Required" ValidationGroup="Add"> 
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="mtop10 mleft120">
                        <span>&nbsp;</span>
                        <asp:Button runat="server" ID="btnBannerAdd" Text="SUBMIT" CssClass="btnNewsletter"
                            ValidationGroup="Add" OnClick="btnBannerAdd_Click" />
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnBannerAdd" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
        <div id="divRightAdd" class="popUpNewsletter" style="display: none; height: 400px;">
            <asp:UpdatePanel runat="server" ID="upRightAdd">
                <ContentTemplate>
                    <asp:HiddenField runat="server" ID="hfPositionOfImage" Value="0" />
                    <h3>
                        Advertisement Details</h3>
                    <div class="mtop10">
                        <div class="addImageDiv mleft120">
                            <span>Image:</span>
                            <asp:FileUpload runat="server" ID="fuSingle" CssClass="floatLeft" />
                        </div>
                    </div>
                    <div class="mleft120" style="margin-top: 30px;">
                        <span>Start Date:</span>
                        <asp:TextBox runat="server" ID="txtStartDateRightAdd"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="futxtStartDateRightAdd" ControlToValidate="txtStartDateRightAdd"
                            Display="Dynamic" CssClass="addError" ErrorMessage="Required" ValidationGroup="RightAdd"> 
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="mtop10 mleft120">
                        <span>End Date:</span>
                        <asp:TextBox runat="server" ID="txtEndDateRightAdd"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="rftxtEndDateRightAdd" ControlToValidate="txtEndDateRightAdd"
                            Display="Dynamic" CssClass="addError" ErrorMessage="Required" ValidationGroup="RightAdd"> 
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="mtop10 mleft120">
                        <span>&nbsp;</span>
                        <asp:Button runat="server" ID="btnRightAdd" Text="SUBMIT" CssClass="btnNewsletter"
                            ValidationGroup="RightAdd" OnClick="btnRightAdd_Click" />
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnRightAdd" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
