<%@ Page Title="" Language="C#" MasterPageFile="~/ClientStore/ClientStore.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Bonrix_App_Store.ClientStore.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function ShowPanelLoad() {
            $("#PanelLoad").toggle('slow');
        }

        function KeepOpen() {
            document.getElementById("PanelLoad").style.display = "none";
            $("#PanelAdd").toggle();
        }

        function ShowPanelAdd() {
            <%--if (btnValue == "upload") {
                var flag = '<%=Session["StoreUserName"] == null%>';
                if (flag.toLowerCase() == 'true') {
                    Notification("Login to Upload APP", "error");
                    return;
                }
            }--%>
            $("#PanelAdd").toggle('slow');
            ShowPanelLoad();
        }

        function ShowModal(ApkName, Name, Package, Version) {
            $("#ContentPlaceHolder1_hiddenEditApkName").val(ApkName);
            $("#ContentPlaceHolder1_txtEditName").val(Name);
            $("#ContentPlaceHolder1_txtEditPackage").val(Package);
            $("#ContentPlaceHolder1_txtEditVersion").val(Version);
            $("#myModal").modal('show');
        }

        function onCopy(link) {
            var fullLink = document.createElement('input');
            document.body.appendChild(fullLink);
            fullLink.value = link;
            fullLink.select();
            document.execCommand("copy", false);
            fullLink.remove();
            Notification('copied', 'success');
        }

        function onShare(name, link, version, storename) {
            document.getElementById("fbLink").href = "https://facebook.com/sharer/sharer.php?text=APP Name: " + name + "%0A%0ADownload Link: " + link + "%0A%0AVersion: " + version + "%0A%0AStore Name: " + storename + " ( http://" + storename.toLowerCase() + ".myappstore.co.in ) %0A%0APowered By http://www.myappstore.co.in";//https://facebook.com/sharer/sharer.php?u=http%3A%2F%2Fsharingbuttons.io
            document.getElementById("twLink").href = "https://twitter.com/intent/tweet/?text=APP Name: " + name + "%0A%0ADownload Link: " + link + "%0A%0AVersion: " + version + "%0A%0AStore Name: " + storename + " ( http://" + storename.toLowerCase() + ".myappstore.co.in ) %0A%0APowered By http://www.myappstore.co.in";//https://twitter.com/intent/tweet/?text=Super%20fast%20and%20easy%20Social%20Media%20Sharing%20Buttons.%20No%20JavaScript.%20No%20tracking.&amp;url=http%3A%2F%2Fsharingbuttons.io
            document.getElementById("gpLink").href = "https://plus.google.com/share?text=APP Name: " + name + "%0A%0ADownload Link: " + link + "%0A%0AVersion: " + version + "%0A%0AStore Name: " + storename + " ( http://" + storename.toLowerCase() + ".myappstore.co.in ) %0A%0APowered By http://www.myappstore.co.in";//https://plus.google.com/share?url=http%3A%2F%2Fsharingbuttons.io
            document.getElementById("mlLink").href = "mailto:?subject=APK Link&amp;body=APP Name: " + name + "%0A%0ADownload Link: " + link + "%0A%0AVersion: " + version + "%0A%0AStore Name: " + storename + " ( http://" + storename.toLowerCase() + ".myappstore.co.in ) %0A%0APowered By http://www.myappstore.co.in"; //mailto:?subject=Super%20fast%20and%20easy%20Social%20Media%20Sharing%20Buttons.%20No%20JavaScript.%20No%20tracking.&amp;body=http%3A%2F%2Fsharingbuttons.io
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
                <div class="page-title" runat="server" id="divTitle">Dashboard</div>
            </div>
            <ol class="pull-right">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server"  class="pull-left" style="padding-top: 25px">
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
                <a class="parent-item" id="dwnldlink" runat="server" title="Download Client Store APK" href="#">
                    <img src="../Images/android.png" style="height: 85px;" /></a>
            </ol>
        </div>
    </div>

    <div class="row" id="PanelAdd" style="display: none">
        <div class=" col-sm-12">
            <div class="card-box">
                <div class="card-head card-topline-lightblue">
                    <header>Upload APK</header>
                </div>
                <div class="card-body row">

                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="modal-body">
                                <div class="col-lg-6 p-t-20">
                                    <asp:FileUpload ID="FileUpload1" runat="server" accept=".apk" />
                                    <asp:RegularExpressionValidator ID="regexValidator" runat="server"
                                        ControlToValidate="FileUpload1"
                                        ErrorMessage="Only APK images are allowed"
                                        ValidationExpression="(.*\.([Aa][Pp][Kk])$)">
                                    </asp:RegularExpressionValidator>
                                </div>
                                <div class="col-lg-6 p-t-20">
                                    <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                        <label>APK Name</label>
                                        <asp:TextBox ID="txtName" runat="server" class="mdl-textfield__input"></asp:TextBox>                                        
                                    </div>
                                </div>
                                <div class="col-lg-6 p-t-20">
                                    <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                         <label>APK Package Name</label>
                                        <asp:TextBox ID="txtPackageName" runat="server" class="mdl-textfield__input"></asp:TextBox>
                                       
                                    </div>
                                </div>
                                <div class="col-lg-6 p-t-20">
                                    <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                        <label>APK Version</label>
                                        <asp:TextBox ID="txtVersion" runat="server" class="mdl-textfield__input"></asp:TextBox>                                        
                                    </div>
                                </div>
                                <%--<div class="col-lg-6 p-t-20" id="divUserName" visible="false" runat="server">
                                    <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                        <asp:TextBox ID="txtUserName" runat="server" class="mdl-textfield__input"></asp:TextBox>
                                        <label class="mdl-textfield__label">User Name</label>
                                    </div>
                                </div>
                                <div class="col-lg-6 p-t-20" id="divPassword" visible="false" runat="server">
                                    <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                        <asp:TextBox ID="txtPassWord" type="password" runat="server" class="mdl-textfield__input"></asp:TextBox>
                                        <label class="mdl-textfield__label">Password</label>
                                    </div>
                                </div>--%>


                                <div class="col-lg-6 p-t-20" id="divSubmit" runat="server">
                                    <div class="profile-userbuttons">
                                        <asp:Button ID="btnSubmit" runat="server" class="btn btn-circle blue btn-md" Text="Upload" OnClick="btnSubmit_Click" />
                                        <button type="button" class="btn btn-circle btn-default" onclick="ShowPanelAdd();">Cancel</button>
                                    </div>
                                </div>
                                <%--<div class="col-lg-6 p-t-20" id="divSubmit1" runat="server" visible="false">
                                    <div class="profile-userbuttons">
                                        <asp:Button ID="btnSubmit1" runat="server" class="btn btn-circle blue btn-md" Text="Upload" OnClick="btnSubmit1_Click" />
                                    </div>
                                </div>--%>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnSubmit" />
                            <%--<asp:PostBackTrigger ControlID="btnSubmit1" />--%>
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>

    <div class="row" id="PanelLoad">
        <div class="col-md-12">
            <div class="card-box">
                <div class="card-head card-topline-lightblue">
                    <%--<header>App Store</header>--%>
                    <div class="tools">
                        <a class="fa fa-repeat btn-color box-refresh" href="javascript:;"></a>
                        <a class="t-collapse btn-color fa fa-chevron-down" href="javascript:;"></a>
                        <a class="t-close btn-color fa fa-times" href="javascript:;"></a>
                    </div>
                </div>
                <div class="card-body ">
                    <div class="row">
                        <div class="col-md-6 col-sm-6 col-6">
                            <div class="btn-group">
                                <%--<button type="button" class="btn btn-circle btn-primary" onclick="ShowPanelAdd('upload');"><i class="fa fa-cloud-upload"></i>Upload APK</button>--%>
                                <%-- <button  runat="server" class="btn btn-circle blue btn-md " text="Upload" OnClientClick="btnUpload_Click"><i class="fa fa-cloud-upload"></i>Upload APK</button>--%>

                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                      
                                            <asp:LinkButton ID="btnUpload" Text="Upload APP" runat="server" class="btn btn-circle blue btn-md " title="Copy" OnClick="btnUpload_Click">&nbsp;<em class="fa fa-cloud-upload"></em>&nbsp;Upload APP</asp:LinkButton>
                                       
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnUpload" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                    <div class="table-scrollable">
                        <asp:Repeater ID="tableData" runat="server" OnItemCreated="tableData_ItemCreated">
                            <HeaderTemplate>
                                <table class="table table-striped table-bordered table-hover table-checkable order-column" style="overflow-x: auto" id="table_ad">
                                    <thead>
                                        <tr>
                                            <th>Image</th>
                                            <th>APK Name</th>
                                            <th>Date/Time</th>
                                            <th style="display: none;"></th>
                                            <th style="display: none;"></th>
                                            <th style="display: none;"></th>
                                            <th>Edit</th>
                                            <th>Download</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr class="odd gradeX">
                                    <td>
                                        <asp:Image ID="Image1" Height="100" Width="100" runat="server" ImageUrl='<%# Eval("ImageUrl") %>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>' class="btn btn-block"></asp:Label><br />
                                        <%--<a href='<%# ResolveUrl(Eval("DownloadUrl").ToString()) %>' id="A1" runat="server" title="Download" class="btn btn-xs deepPink-bgcolor btn-block">--%>
                                        <a href='<%# ResolveUrl(Eval("DownloadUrl").ToString()) %>' id="lnkCellDownload" runat="server" title="Download" class="btn deepPink btn-outline btn-block">

                                            <asp:Label ID="lblApkName" runat="server" Text='<%# Eval("ApkName") %>'></asp:Label><br />
                                            <asp:Label ID="lblAPKVersion" runat="server" Text='<%# "Version: "+ Eval("Version") %>'></asp:Label>&nbsp;
                                        </a>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblDateTime" runat="server" Text='<%# Eval("DateTime") %>'></asp:Label>
                                        <%--<asp:Label ID="lbluser_name" runat="server" Text='<%# Container.DataItem.ToString() %>'></asp:Label>--%>
                                    </td>
                                    <td style="display: none;">
                                        <asp:HiddenField ID="hiddenName" runat="server" Value='<%#Eval("Name")%>' Visible="False" />
                                    </td>
                                    <td style="display: none;">
                                        <asp:HiddenField ID="hiddenPackage" runat="server" Value='<%#Eval("Package")%>' Visible="False" />
                                    </td>
                                    <td style="display: none;">
                                        <asp:HiddenField ID="hiddenVersion" runat="server" Value='<%#Eval("Version")%>' Visible="False" />
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="lnkEdit" Text="Edit" runat="server" class="btn btn-primary btn-xs"><i class="fa fa-pencil"></i>&nbsp;Edit</asp:LinkButton>
                                    </td>
                                    <td>
                                        <a href='<%# ResolveUrl(Eval("DownloadUrl").ToString()) %>' id="lnkdownload" runat="server" class="btn btn-xs deepPink-bgcolor" title="Download">&nbsp;<em class="fa fa-download"></em></a>
                                        <asp:LinkButton ID="lnkCopy" Text="Copy" runat="server" title="Copy">&nbsp;<em class="btn btn-xs deepPink-bgcolor fa fa-copy"></em></asp:LinkButton>
                                        <asp:LinkButton ID="lnkShare" Text="Share" runat="server" title="Share">&nbsp;<em class="btn btn-xs deepPink-bgcolor fa fa-share-alt"></em></asp:LinkButton>
                                        <asp:LinkButton ID="lnkSendSms" Text="Send Sms" runat="server" title="Send Sms">&nbsp;<em class="btn btn-xs deepPink-bgcolor fa fa-external-link"></em></asp:LinkButton>
                                        <%-- <a href="#" id="lnkShare" runat="server" class="btn btn-xs deepPink-bgcolor" title="Share" onclick="onShare();">&nbsp;<em class="fa fa-share-alt"></em></a>--%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tbody>
                                        </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="myModal" class="modal fade" role="dialog">
        <div class="modal-dialog card card-topline-primary" style="width: auto;">
            <!-- Modal content-->
            <div class="modal-content ">
                <div class="modal-header">
                    <h4 class="modal-title">Edit APK Details</h4>
                    <a class="t-close btn-color fa fa-times" data-dismiss="modal" href="javascript:;"></a>
                </div>
                <div class="modal-body">
                    <asp:HiddenField ID="hiddenEditApkName" runat="server" />
                    <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width is-focused">
                        <label class="">APK Name</label>
                        <asp:TextBox ID="txtEditName" runat="server" class="mdl-textfield__input"></asp:TextBox>
                    </div>
                    <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                        <label class="">APK Package Name</label>
                        <asp:TextBox ID="txtEditPackage" runat="server" class="mdl-textfield__input"></asp:TextBox>

                    </div>
                    <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                        <label class="">APK Version</label>
                        <asp:TextBox ID="txtEditVersion" runat="server" class="mdl-textfield__input"></asp:TextBox>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <div class="profile-userbuttons">
                                <asp:Button ID="btnEditSubmit" runat="server" class="btn btn-circle blue btn-md" Text="Submit" data-toggle="modal" data-target="#myModal" OnClick="btnEditSubmit_Click" />
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnEditSubmit" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
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
