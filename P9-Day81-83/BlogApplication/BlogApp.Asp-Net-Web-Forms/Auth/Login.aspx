<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BlogApp.Asp_Net_Web_Forms.Auth.Login" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>

    <!-- Custom fonts for this template-->
    <link href="../Content/vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css" />
    <!-- Custom styles for this template-->
    <link href="../Content/css/sb-admin-2.min.css" rel="stylesheet" />
    <link
        href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i"
        rel="stylesheet" />
</head>

<body class="bg-gradient-primary">
    <form id="form1" runat="server">
        <div class="container">
            <!-- Outer Row -->
            <div class="row justify-content-center">
                <div class="col-xl-10 col-lg-12 col-md-9">
                    <div class="card o-hidden border-0 shadow-lg my-5">
                        <div class="card-body p-0">
                            <!-- Nested Row within Card Body -->
                            <div class="row">
                                <div class="col-lg-6 d-none d-lg-block bg-login-image"></div>
                                <div class="col-lg-6">
                                    <div class="p-5">
                                        <div class="text-center">
                                            <h1 class="h4 text-gray-900 mb-4">Welcome Back!</h1>
                                        </div>
                                        <form class="user">
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control form-control-user" ID="txtEmail"
                                                    PlaceHolder="Enter Email Address or Username" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <input type="password" id="txtPassword" class="form-control form-control-user"
                                                    placeholder="Password" runat="server">
                                            </div>
                                            <div class="form-group">
                                                <div class="custom-control custom-checkbox small">
                                                    <input type="checkbox" class="custom-control-input" id="customCheck">
                                                    <label class="custom-control-label" for="customCheck">
                                                        Remember
                                                    Me</label>
                                                </div>
                                            </div>
                                            <asp:Button ID="loginButton" OnClick="Login_Button_Click" CssClass="btn btn-primary btn-user btn-block"
                                                Text="Login" runat="server" />
                                            <hr>
                                        </form>
                                        <hr>
                                        <div class="text-center">
                                            <a class="small" href="forgot-password.html">Forgot Password?</a>
                                        </div>
                                        <div class="text-center">
                                            <a class="small" href="register.html">Create an Account!</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <!-- Bootstrap core JavaScript-->
    <script src="../Content/js/bootstrap/jquery-3.4.1.min.js"></script>
    <script src="../Content/js/bootstrap/bootstrap.min.js"></script>
    <script src="../Content/js/bootstrap/popper.min.js"></script>
</body>
</html>
