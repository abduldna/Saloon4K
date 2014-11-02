<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Saloon4K.Moderator.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="icon" type="image/ico" href="http://localhost:64196/Moderator" />
    <link href="css/stylesheets.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/plugins/jquery/jquery.min.js"></script>
    <script type="text/javascript" src="js/plugins/jquery/jquery-ui.min.js"></script>
    <script type="text/javascript" src="js/plugins/jquery/jquery-migrate.min.js"></script>
    <script type="text/javascript" src="js/plugins/jquery/globalize.js"></script>
    <script type="text/javascript" src="js/plugins/bootstrap/bootstrap.min.js"></script>
    <script type="text/javascript" src="js/plugins/uniform/jquery.uniform.min.js"></script>
    <script type="text/javascript" src="js/js.js"></script>
    <script type="text/javascript" src="js/settings.js"></script>
</head>
<body class="wall-num11">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="container">
        <div class="login-block">
            <div class="block block-transparent">
                <div class="head">
                    <div class="user">
                        <div class="info user-change">
                            <img src="img/example/user/adminUser1.png" class="img-circle img-thumbnail" alt="dmitry_b" />
                            <div class="user-change-button">
                                <span class="icon-off"></span>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="content controls npt">
                    <asp:UpdatePanel runat="server" ID="upLoginAdmin">
                        <ContentTemplate>
                            <asp:Panel runat="server" DefaultButton="btnLogin">
                                <div id="divMessage" runat="server" visible="False" style="padding: 5px; margin-left: 6px;">
                                </div>
                                <div class="form-row">
                                    <div class="col-md-12">
                                        <div class="input-group">
                                            <div class="input-group-addon">
                                                <span class="icon-user"></span>
                                            </div>
                                            <asp:TextBox runat="server" ID="txtUsername" CssClass="form-control txtlogin" Placeholder="Login"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ID="rftxtUsername" ControlToValidate="txtUsername"
                                                Display="Dynamic" CssClass="erorlogin" ValidationGroup="Login" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="col-md-12">
                                        <div class="input-group">
                                            <div class="input-group-addon divPwd">
                                                <span class="icon-key"></span>
                                            </div>
                                            <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control txtlogin" Placeholder="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ID="rftxtPassword" ControlToValidate="txtPassword"
                                                Display="Dynamic" CssClass="erorlogin" ValidationGroup="Login" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="col-md-6">
                                    </div>
                                    <div class="col-md-6">
                                        <asp:LinkButton runat="server" ID="btnLogin" ValidationGroup="Login" CssClass="btn btn-default btn-block btn-clean"
                                            OnClick="btnLogin_Click" Style="margin-left: -12px;">LOGIN</asp:LinkButton>
                                    </div>
                                </div>
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
