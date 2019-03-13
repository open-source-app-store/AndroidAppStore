<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Bonrix_App_Store.ClientStore.Login1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <!-- google font -->
    <link href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700" rel="stylesheet" type="text/css" />
    <!-- icons -->
    <link href="../assets/fonts/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/fonts/material-design-icons/material-icon.css" rel="stylesheet" type="text/css" />
    <!-- bootstrap -->
    <link href="../assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <!-- style -->
    <link rel="stylesheet" href="../assets/css/pages/extra_pages.css" />
    <!-- favicon -->
    <link rel="shortcut icon" href="http://radixtouch.in/templates/admin/smart/source/assets/img/favicon.ico" />

    <!-- start js include path -->
    <script src="../assets/plugins/jquery/jquery.min.js"></script>
    <script src="../assets/js/pages/extra-pages/login_pages.js"></script>
    <!-- end js include path -->
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-title">
            <h1>App Store Login</h1>
        </div>
        <div class="login-form text-center">
            <div class="toggle">
                <i class="fa fa-user-plus"></i>
            </div>
            <div class="form formLogin">
                <h2>Login to your account</h2>
                <div>
                    <asp:TextBox ID="txtuser_name" runat="server" type="text" placeholder="UserName"></asp:TextBox>
                    <asp:TextBox ID="txtpassword" runat="server" type="password" placeholder="Password"></asp:TextBox>                    

                    <asp:Button ID="btnlogin" runat="server" BackColor="#33b5e5" ForeColor="White" Text="Login" OnClick="OnLogin" />                    
                    <asp:Label ID="lblWarning" runat="server" Text="" ForeColor="#CC0000" Font-Bold="True"></asp:Label>                    
                </div>
            </div>            
        </div>
    </form>
</body>
</html>


