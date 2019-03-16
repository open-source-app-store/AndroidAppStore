<%@ Page Title="" Language="C#" MasterPageFile="~/ClientStore/ClientStore.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="Bonrix_App_Store.ClientStore.ContactUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-bar">
        <div class="page-title-breadcrumb">
            <div class=" pull-left">
                <div class="page-title" runat="server" id="divTitle">Contact Us</div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-sm-12">
            <div class="borderBox light bordered">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="contact-map">
                            <%--<iframe src="https://www.google.com/maps/d/embed?mid=1sjINSNbiZfu6iyy2pPSha2O4GD4&amp;hl=en_US" width="640" height="480"></iframe>--%>
                            <iframe src="https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d14686.990707989695!2d72.5586445!3d23.033035!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0x5684709b937537f6!2sBonrix+Software+Systems!5e0!3m2!1sen!2sin!4v1552108977910" width="640" height="480"></iframe>
                        </div>
                    </div>
                </div>
                <div class="row m-t-50 m-b-30">
                    <div class="col-md-10 col-md-offset-1">
                        <div class="row">
                            <!-- Contact form -->

                            <!-- end col -->
                            <div class="col-sm-4 col-sm-offset-1">
                                <div class="contact-box">
                                    <div class="contact-detail">
                                        <i class="fa fa-map-marker"></i>
                                        <span>Bonrix Software Systems
                                            <br />
                                            A - 801, Samudra Complex, Near Classic Gold Hotel, Off C. G. Road, Ahmedabad, Gujarat 380006,India
                                        </span>
                                    </div>
                                    <div class="contact-detail">
                                        <i class="fa fa-mobile"></i>
                                        <span>
                                            <a href="#">(+91)94260 45500</a>
                                        </span>
                                    </div>
                                    <div class="contact-detail">
                                        <i class="fa fa-mobile"></i>
                                        <span>
                                            <a href="#">(+91)94290 45500</a>
                                        </span>
                                    </div>
                                    <div class="contact-detail">
                                        <i class="fa fa-envelope"></i>
                                        <span>
                                            <a href="#">bonrix@gmail.com</a>
                                        </span>
                                    </div>
                                    <div class="contact-detail">
                                        <i class="fa fa-envelope"></i>
                                        <span>
                                            <a href="#">info@bonrix.net</a>
                                        </span>
                                    </div>
                                     <div class="contact-detail">
                                        <i class="fa fa-skype"></i>
                                        <span>
                                            <a href="#">bonrix_sms</a>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-4 col-sm-offset-1">
                                <div class="contact-box">
                                    <div class="contact-detail">
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                    </div>
                                    <div class="contact-detail">
                                        <i class="fa fa-globe"></i>
                                        <span>
                                            <a href="http://www.bonrix.in">www.bonrix.in</a>
                                        </span>
                                    </div>
                                    <div class="contact-detail">
                                        <i class="fa fa-globe"></i>
                                        <span>
                                            <a href="http://www.bonrix.net">www.bonrix.net</a>
                                        </span>
                                    </div>
                                    <div class="contact-detail">
                                        <i class="fa fa-globe"></i>
                                        <span>
                                            <a href="http://www.bonrix.co.in">www.bonrix.co.in</a>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <!-- end col -->
                        </div>
                    </div>
                </div>
                <!-- end row -->
            </div>
        </div>
    </div>
</asp:Content>
