<%@ Page Title="" Language="C#" MasterPageFile="~/Store/Store.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Bonrix_App_Store.Store.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="page-bar">
        <%--<asp:ImageButton ID="ImageButton1" runat="server"  class="pull-right m-b-10"  ImageUrl="~/Images/android.png" />--%>
        <div class="page-title-breadcrumb">
            <div class=" pull-left">
                <div class="page-title" runat="server" id="divTitle">App Store</div>
            </div>
            <ol class="pull-right">     
               <a class="parent-item" id="dwnldlink" runat="server" title="Download Store APK" href="#"><img src="../Images/android.png" style="height:85px;"/></a>
            </ol>
        </div>
    </div>
    <div class="state-overview">
        <div class="row" id="DynamicDiv" runat="server">
            <%--<div class="col-xl-3 col-md-6 col-12">
                                <div class="info-box bg-b-green">
                                    <span class="info-box-icon push-bottom" ><i class="material-icons" Style="margin: 18px 10px 10px 10px">android</i></span>
                                    <div class="info-box-content">
                                        <span class="info-box-number">Bonrix Store</span>
                                        <span class="info-box-text">03/04/2019</span>                                        
                                        <span class="progress-description">355 Apps
                                        </span>
                                    </div>
                                    <!-- /.info-box-content -->
                                </div>
                                <!-- /.info-box -->
                            </div>--%>
        </div>
    </div>
</asp:Content>
