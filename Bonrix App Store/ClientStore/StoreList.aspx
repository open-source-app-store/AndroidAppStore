<%@ Page Title="" Language="C#" MasterPageFile="~/ClientStore/ClientStore.Master" AutoEventWireup="true" CodeBehind="StoreList.aspx.cs" Inherits="Bonrix_App_Store.ClientStore.StoreList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            var parentul = $('#lnkStoreList').parents('ul');
            $(parentul).parents('ul').eq(0).children('li').removeClass('nav-item active');
            $('#lnkStoreList').parents('ul').eq(0).children('li').removeClass('nav-item active');
            $('#lnkStoreList').parents('li').addClass('active');
            $('#lnkStore').click();
        });

        function ShowPanelLoad() {
            $("#PanelLoad").toggle('slow');
        }

        function KeepOpen() {
            document.getElementById("PanelLoad").style.display = "none";
            $("#PanelAdd").toggle();
        }

        function ShowPanelAdd() {
            $("#PanelAdd").toggle('slow');
            ShowPanelLoad();
        }
    </script>

    <div class="page-bar">
        <div class="page-title-breadcrumb">
            <div class=" pull-left">
                <div class="page-title" runat="server" id="divTitle">App Store List</div>
            </div>
            <ol class="breadcrumb page-breadcrumb pull-right">
                <li><i class="fa fa-download"></i>&nbsp;<a class="parent-item" id="dwnldlink" runat="server" href="#">Download Store APK</a>&nbsp;
                </li>
            </ol>
        </div>
    </div>


    <%--<div class="row" id="PanelAdd" style="display: none">
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
                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                </div>

                                <div class="col-lg-6 p-t-20" id="divSubmit" runat="server">
                                    <div class="profile-userbuttons">
                                        <asp:Button ID="btnSubmit" runat="server" class="btn btn-circle blue btn-md" Text="Upload" OnClick="btnSubmit_Click" />
                                    </div>
                                </div>                               
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnSubmit" />                            
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>--%>

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
                                <%--<a  class="btn btn-info" data-toggle="modal" data-target="#myModal">Add New <i class="fa fa-plus"></i></a>--%>
                                <%--<button type="button" class="btn btn-circle btn-primary" data-toggle="modal" data-target="#myModal"><i class="fa fa-cloud-upload"></i>Upload APK</button>--%>
                                <%-- <button type="button" class="btn btn-circle btn-primary" onclick="ShowPanelAdd();"><i class="fa fa-cloud-upload"></i>Upload APK</button>--%>
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
                                            <th>Delete</th>
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
                                        <asp:Label ID="lblName" runat="server" Text='<%# "Name: "+ Eval("Name") %>'></asp:Label><br />
                                        <asp:Label ID="lblApkName" runat="server" Text='<%# Eval("ApkName") %>'></asp:Label><br />
                                        <asp:Label ID="lblAPKVersion" runat="server" Text='<%# "Version: "+ Eval("Version") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblDateTime" runat="server" Text='<%# Eval("DateTime") %>'></asp:Label>
                                        <%--<asp:Label ID="lbluser_name" runat="server" Text='<%# Container.DataItem.ToString() %>'></asp:Label>--%>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="lnkDelete" Text="Delete" runat="server" OnClientClick="return confirm('Do you want to delete this row?');"><i class="btn btn-danger fa fa-trash-o" ></i></asp:LinkButton>
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
</asp:Content>
