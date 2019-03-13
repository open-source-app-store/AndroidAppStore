<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Master.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Bonrix_App_Store.Admin.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function myFunction() {
            if (document.getElementById('divPassword').style.display == "block") {
                document.getElementById("divPassword").style.display = "none";
            }
            else {
                document.getElementById("divPassword").style.display = "block";
            }
        }
        function KeepOpen() {
            document.getElementById("PanelLoad").style.display = "none";
            $("#PanelAdd").toggle();
        }
        function ShowPanelAdd() {
            $("#PanelAdd").toggle('slow');
            $("#PanelLoad").toggle('slow');
        }
        function ShowModal(FolderName) {           
            $("#ContentPlaceHolder1_hiddenFolderName").val(FolderName);
            ShowPanelAdd();
        }
        function EditValue(FolderName,Name,Package,Version) {           

            $("#ContentPlaceHolder1_hiddenFolderName").val(FolderName);
            $("#ContentPlaceHolder1_txtName").val(Name);
            $("#ContentPlaceHolder1_txtPackageName").val(Package);
            $("#ContentPlaceHolder1_txtVersion").val(Version);
            $('#myModalEdit').modal('show');
        }
    </script>

    <%--  <div class="page-bar">
        <div class="page-title-breadcrumb">
            <div class=" pull-left">
                <div class="page-title">Dashboard</div>
            </div>
            <div class="breadcrumb page-breadcrumb pull-right">
                <button type="button" class="btn btn-circle btn-success" data-toggle="modal" data-target="#myModal"><i class="fa fa-plus"></i>Create Store</button>
            </div>
        </div>
    </div>--%>
    <div class="row" id="PanelAdd" style="display: none">
        <div class=" col-sm-12">
            <div class="card-box">
                <div class="card-head card-topline-lightblue">
                    <header>Upload Store APK</header>
                </div>
                <div class="card-body row">

                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="modal-body">
                                <asp:HiddenField ID="hiddenFolderName" runat="server" />
                                <div class="col-lg-6 p-t-20">
                                    <asp:FileUpload ID="FileUpload1" runat="server" accept=".apk" />
                                    <asp:RegularExpressionValidator ID="regexValidator" runat="server"
                                        ControlToValidate="FileUpload1"
                                        ErrorMessage="Only APK images are allowed"
                                        ValidationExpression="(.*\.([Aa][Pp][Kk])$)">
                                    </asp:RegularExpressionValidator>
                                </div>
                                <div class="col-lg-6 p-t-20" id="divSubmit" runat="server">
                                    <div class="profile-userbuttons">
                                        <asp:Button ID="btnUpload" runat="server" class="btn btn-circle blue btn-md" Text="Upload" OnClick="btnUpload_Click" />
                                        <button type="button" class="btn btn-circle btn-default" onclick="ShowPanelAdd();">Cancel</button>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnUpload" />
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
                    <header>App Store</header>
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
                                <%--<a  class="btn btn-info" data-toggle="modal" data-target="#myModal">Add New <i class="fa fa-plus"></i></a>--%>
                                <button type="button" class="btn btn-circle btn-success" data-toggle="modal" data-target="#myModal"><i class="fa fa-plus"></i>Create New Store</button>
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
                                            <th>Store Name</th>
                                            <th>Date/Time</th>
                                            <th>Action</th>
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
                                        <%--<asp:Label ID="lblpartner_id" runat="server" Text='<%# Container.DataItem.ToString() %>'></asp:Label>--%>
                                        <asp:Label ID="lblFolderName" runat="server" Text='<%# Eval("FolderName") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblDateTime" runat="server" Text='<%# Eval("DateTime") %>'></asp:Label>
                                        <%--<asp:Label ID="lbluser_name" runat="server" Text='<%# Container.DataItem.ToString() %>'></asp:Label>--%>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="lnkUpload" Text="Upload" runat="server" title="Upload Store APK" class="btn btn-primary btn-xs"><i class="fa fa-cloud-upload"></i>&nbsp;Upload</asp:LinkButton>
                                        <asp:LinkButton ID="lnkEdit" Text="Edit" runat="server" class="btn btn-primary btn-xs"><i class="fa fa-pencil"></i>&nbsp;Edit</asp:LinkButton>
                                        <asp:LinkButton ID="lnkDeleteAPK" Text="Delete" runat="server" title="Delete Store" class="btn btn-danger btn-xs" OnClientClick="return confirm('Are you sure want to Delete Store APK?');"><i class="fa fa-trash-o"></i>&nbsp;delete APK</asp:LinkButton>
                                        <asp:LinkButton ID="lnkDelete" Text="Delete" runat="server" title="Delete Store" class="btn btn-danger btn-xs" OnClientClick="return confirm('Are you sure want to Delete Full Store?');"><i class="fa fa-trash-o"></i>&nbsp;delete</asp:LinkButton>
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
        <div class="modal-dialog card card-topline-lightblue" style="width: auto;">
            <!-- Modal content-->
            <div class="modal-content ">
                <div class="modal-header">
                    <h4 class="modal-title">Create Store</h4>
                    <a class="t-close btn-color fa fa-times" data-dismiss="modal" href="javascript:;"></a>
                </div>
                <div class="modal-body">
                    <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                        <asp:TextBox ID="txtStoreName" runat="server" class="mdl-textfield__input"></asp:TextBox>
                        <label class="mdl-textfield__label">Store Name</label>
                    </div>
                    <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width" style="display: none;" id="divPassword">
                        <asp:TextBox ID="txtpassword" runat="server" class="mdl-textfield__input"></asp:TextBox>
                        <label class="mdl-textfield__label">Store Password</label>
                    </div>
                    <div class="col-lg-10 p-t-20">
                        <label class="mdl-switch mdl-js-switch mdl-js-ripple-effect">
                            <input type="checkbox" id="chkActive" class="mdl-switch__input" runat="server" onclick="myFunction()" />
                            <span class="mdl-switch__label">Create Password</span>
                        </label>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <div class="profile-userbuttons">
                                <asp:Button ID="btnSubmit" runat="server" class="btn btn-circle blue btn-md" Text="Submit" data-toggle="modal" data-target="#myModal" OnClick="btnSubmit_Click" />
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnSubmit" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>

    <div id="myModalEdit" class="modal fade" role="dialog">
        <div class="modal-dialog card card-topline-lightblue" style="width: auto;">
            <!-- Modal content-->
            <div class="modal-content ">
                <div class="modal-header">
                    <h4 class="modal-title">Create Store</h4>
                    <a class="t-close btn-color fa fa-times" data-dismiss="modal" href="javascript:;"></a>
                </div>
                <div class="modal-body">
                    <div class="col-lg-6 p-t-20">
                        <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                            <label class="mdl-label">APK Name</label>
                            <asp:TextBox ID="txtName" runat="server" class="mdl-textfield__input"></asp:TextBox>
                            
                        </div>
                    </div>
                    <div class="col-lg-6 p-t-20">
                        <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                            <label class="mdl-label">APK Package Name</label>
                            <asp:TextBox ID="txtPackageName" runat="server" class="mdl-textfield__input"></asp:TextBox>
                            
                        </div>
                    </div>
                    <div class="col-lg-6 p-t-20">
                        <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                            <label class="mdl-label">APK Version</label>
                            <asp:TextBox ID="txtVersion" runat="server" class="mdl-textfield__input"></asp:TextBox>
                            
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <div class="profile-userbuttons">
                                <asp:Button ID="btnEditSubmit" runat="server" class="btn btn-circle blue btn-md" Text="Submit" data-toggle="modal" data-target="#myModalEdit" OnClick="btnEditSubmit_Click" />
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
</asp:Content>
