<%@ Page Title="" Language="C#" MasterPageFile="~/Store/Store.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Bonrix_App_Store.Store.Home" %>
<%@ MasterType VirtualPath="~/Store/Store.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function onShare(name, link, version, storename) {
            document.getElementById("fbLink").href = "https://facebook.com/sharer/sharer.php?text=APP Name: " + name + "%0A%0ADownload Link: " + link + "%0A%0AVersion: " + version + "%0A%0AStore Name: " + storename + "%0A%0APowered By http://www.myappstore.co.in";//https://facebook.com/sharer/sharer.php?u=http%3A%2F%2Fsharingbuttons.io
            document.getElementById("twLink").href = "https://twitter.com/intent/tweet/?text=APP Name: " + name + "%0A%0ADownload Link: " + link + "%0A%0AVersion: " + version + "%0A%0AStore Name: " + storename + "%0A%0APowered By http://www.myappstore.co.in";//https://twitter.com/intent/tweet/?text=Super%20fast%20and%20easy%20Social%20Media%20Sharing%20Buttons.%20No%20JavaScript.%20No%20tracking.&amp;url=http%3A%2F%2Fsharingbuttons.io
            document.getElementById("gpLink").href = "https://plus.google.com/share?text=APP Name: " + name + "%0A%0ADownload Link: " + link + "%0A%0AVersion: " + version + "%0A%0AStore Name: " + storename + "%0A%0APowered By http://www.myappstore.co.in";//https://plus.google.com/share?url=http%3A%2F%2Fsharingbuttons.io
            document.getElementById("mlLink").href = "mailto:?subject=APK Link&amp;body=APP Name: " + name + "%0A%0ADownload Link: " + link + "%0A%0AVersion: " + version + "%0A%0AStore Name: " + storename + "%0A%0APowered By http://www.myappstore.co.in"; //mailto:?subject=Super%20fast%20and%20easy%20Social%20Media%20Sharing%20Buttons.%20No%20JavaScript.%20No%20tracking.&amp;body=http%3A%2F%2Fsharingbuttons.io
            document.getElementById("waLink").href = "https://web.whatsapp.com/send?text=*APP Name:* " + name + "%0A%0A*Download Link:* " + link + "%0A%0A*Version:* " + version + "%0A%0A*Store Name:* " + storename + "%0A%0A*Powered By* http://www.myappstore.co.in"; //mailto:?subject=Super%20fast%20and%20easy%20Social%20Media%20Sharing%20Buttons.%20No%20JavaScript.%20No%20tracking.&amp;body=http%3A%2F%2Fsharingbuttons.io
            $("#myModalShare").modal('show');
        }

        function onSendSms(link) {
            if (link == "") {
                $("#ContentPlaceHolder1_hiddenText").val(link);
                $("#myModalSendSms").modal('hide');
            }
            else {
                $("#ContentPlaceHolder1_hiddenText").val(link);
                $("#myModalSendSms").modal('show');
            }

        }
    </script>

    <div class="page-bar">
        <%--<asp:ImageButton ID="ImageButton1" runat="server"  class="pull-right m-b-10"  ImageUrl="~/Images/android.png" />--%>
        <div class="page-title-breadcrumb">
            <div class=" pull-left">
                <div class="page-title" runat="server" id="divTitle">App Store</div>
            </div>
            <ol class="pull-right">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server" class="pull-left" style="padding-top: 25px">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkShareMain" Text="Share" runat="server" title="Share Store Link" OnClick="lnkShareMain_Click">&nbsp;<em class="btn btn-facebook waves-effect waves-light fa fa-share-alt"></em></asp:LinkButton>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkShareMain" />
                    </Triggers>
                </asp:UpdatePanel>

                <asp:UpdatePanel ID="UpdatePanel6" runat="server" class="pull-left" style="padding-top: 25px">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkSendSmsMain" Text="Send Sms" runat="server" title="Send Store Link Sms" OnClick="lnkSendSmsMain_Click">&nbsp;<em class="btn btn-facebook waves-effect waves-light fa fa-external-link"></em></asp:LinkButton>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkSendSmsMain" />
                    </Triggers>
                </asp:UpdatePanel>
                <a class="parent-item" id="dwnldlink" runat="server" title="Download Store APK" href="#">
                    <img src="../Images/android.png" style="height: 85px;" /></a>
            </ol>
        </div>
    </div>
    <div class="state-overview">
        <div class="row" id="DynamicDiv" runat="server"></div>
    </div>

     <div id="myModalShare" class="modal fade" role="dialog">
        <div class="modal-dialog card card-topline-primary" style="width: auto;">
            <!-- Modal content-->
            <div class="modal-content ">
                <div class="modal-header">
                    <h4 class="modal-title">Share Link</h4>
                    <a class="t-close btn-color fa fa-times" data-dismiss="modal" href="javascript:;"></a>
                </div>
                <div class="modal-body  center">
                    <!-- Sharingbutton Facebook -->
                    <a id="fbLink" class="resp-sharing-button__link" href="#" target="_blank" rel="noopener" aria-label="">
                        <div class="resp-sharing-button resp-sharing-button--facebook resp-sharing-button--small">
                            <div aria-hidden="true" class="resp-sharing-button__icon resp-sharing-button__icon--solidcircle">
                                <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24">
                                    <path d="M12 0C5.38 0 0 5.38 0 12s5.38 12 12 12 12-5.38 12-12S18.62 0 12 0zm3.6 11.5h-2.1v7h-3v-7h-2v-2h2V8.34c0-1.1.35-2.82 2.65-2.82h2.35v2.3h-1.4c-.25 0-.6.13-.6.66V9.5h2.34l-.24 2z" />
                                </svg>
                            </div>
                        </div>
                    </a>

                    <!-- Sharingbutton Twitter -->
                    <a id="twLink" class="resp-sharing-button__link" href="#" target="_blank" rel="noopener" aria-label="">
                        <div class="resp-sharing-button resp-sharing-button--twitter resp-sharing-button--small">
                            <div aria-hidden="true" class="resp-sharing-button__icon resp-sharing-button__icon--solidcircle">
                                <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24">
                                    <path d="M12 0C5.38 0 0 5.38 0 12s5.38 12 12 12 12-5.38 12-12S18.62 0 12 0zm5.26 9.38v.34c0 3.48-2.64 7.5-7.48 7.5-1.48 0-2.87-.44-4.03-1.2 1.37.17 2.77-.2 3.9-1.08-1.16-.02-2.13-.78-2.46-1.83.38.1.8.07 1.17-.03-1.2-.24-2.1-1.3-2.1-2.58v-.05c.35.2.75.32 1.18.33-.7-.47-1.17-1.28-1.17-2.2 0-.47.13-.92.36-1.3C7.94 8.85 9.88 9.9 12.06 10c-.04-.2-.06-.4-.06-.6 0-1.46 1.18-2.63 2.63-2.63.76 0 1.44.3 1.92.82.6-.12 1.95-.27 1.95-.27-.35.53-.72 1.66-1.24 2.04z" />
                                </svg>
                            </div>
                        </div>
                    </a>

                    <!-- Sharingbutton Google+ -->
                    <a id="gpLink" class="resp-sharing-button__link" href="#" target="_blank" rel="noopener" aria-label="">
                        <div class="resp-sharing-button resp-sharing-button--google resp-sharing-button--small">
                            <div aria-hidden="true" class="resp-sharing-button__icon resp-sharing-button__icon--solidcircle">
                                <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24">
                                    <path d="M12.65 8.6c-.02-.66-.3-1.3-.8-1.8S10.67 6 9.98 6c-.63 0-1.2.25-1.64.68-.45.44-.68 1.05-.66 1.7.02.68.3 1.32.8 1.8.96.97 2.6 1.04 3.5.14.45-.45.7-1.05.67-1.7zm-2.5 5.63c-2.14 0-3.96.95-3.96 2.1 0 1.12 1.8 2.08 3.94 2.08s3.98-.93 3.98-2.06c0-1.14-1.82-2.1-3.98-2.1z" />
                                    <path d="M12 0C5.38 0 0 5.38 0 12s5.38 12 12 12 12-5.38 12-12S18.62 0 12 0zm-1.84 19.4c-2.8 0-4.97-1.35-4.97-3.08s2.15-3.1 4.94-3.1c.84 0 1.6.14 2.28.36-.57-.4-1.25-.86-1.3-1.7-.26.06-.52.1-.8.1-.95 0-1.87-.38-2.57-1.08-.67-.68-1.06-1.55-1.1-2.48-.02-.94.32-1.8.96-2.45.65-.63 1.5-.93 2.4-.92V5h3.95v1h-1.53l.12.1c.67.67 1.06 1.55 1.1 2.48.02.93-.32 1.8-.97 2.45-.16.15-.33.3-.5.4-.2.6.05.8.83 1.33.9.6 2.1 1.42 2.1 3.56 0 1.73-2.17 3.1-4.96 3.1zM20 10h-2v2h-1v-2h-2V9h2V7h1v2h2v1z" />
                                </svg>
                            </div>
                        </div>
                    </a>

                    <!-- Sharingbutton E-Mail -->
                    <a id="mlLink" class="resp-sharing-button__link" href="#" target="_self" rel="noopener" aria-label="">
                        <div class="resp-sharing-button resp-sharing-button--email resp-sharing-button--small">
                            <div aria-hidden="true" class="resp-sharing-button__icon resp-sharing-button__icon--solidcircle">
                                <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24">
                                    <path d="M12 0C5.38 0 0 5.38 0 12s5.38 12 12 12 12-5.38 12-12S18.62 0 12 0zm8 16c0 1.1-.9 2-2 2H6c-1.1 0-2-.9-2-2V8c0-1.1.9-2 2-2h12c1.1 0 2 .9 2 2v8z" />
                                    <path d="M17.9 8.18c-.2-.2-.5-.24-.72-.07L12 12.38 6.82 8.1c-.22-.16-.53-.13-.7.08s-.15.53.06.7l3.62 2.97-3.57 2.23c-.23.14-.3.45-.15.7.1.14.25.22.42.22.1 0 .18-.02.27-.08l3.85-2.4 1.06.87c.1.04.2.1.32.1s.23-.06.32-.1l1.06-.9 3.86 2.4c.08.06.17.1.26.1.17 0 .33-.1.42-.25.15-.24.08-.55-.15-.7l-3.57-2.22 3.62-2.96c.2-.2.24-.5.07-.72z" />
                                </svg>
                            </div>
                        </div>
                    </a>
                    <!-- Sharingbutton E-Mail -->
                    <a id="waLink" class="resp-sharing-button__link" href="#" target="_self" rel="noopener" aria-label="">
                        <div class="resp-sharing-button resp-sharing-button--whatsapp resp-sharing-button--small">
                            <div aria-hidden="true" class="resp-sharing-button__icon resp-sharing-button__icon--solidcircle">
                                <img src="https://platform-cdn.sharethis.com/img/whatsapp.svg">
                            </div>
                        </div>
                    </a>
                </div>
            </div>
        </div>
    </div>

    <div id="myModalSendSms" class="modal fade" role="dialog">
        <div class="modal-dialog card card-topline-primary" style="width: auto;">
            <!-- Modal content-->
            <div class="modal-content ">
                <div class="modal-header">
                    <h4 class="modal-title">Send APK Link via Sms</h4>
                    <a class="t-close btn-color fa fa-times" data-dismiss="modal" href="javascript:;"></a>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <asp:HiddenField ID="hiddenText" runat="server" />
                        <label>Mobile Number</label>
                        <asp:TextBox ID="txtMobile" runat="server" Text="+91" class="mdl-textfield__input"></asp:TextBox>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <div class="profile-userbuttons">
                                <asp:Button ID="btnSendSms" runat="server" class="btn btn-circle blue btn-md" Text="Submit" OnClick="btnSendSms_Click" />
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnSendSms" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
