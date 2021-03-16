<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="BlogApp.Asp_Net_Web_Forms.Admin.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BlankContent" runat="server">
    <ol class="breadcrumb mb-4">
        <li class="breadcrumb-item active">Dashboard/Profile</li>
    </ol>
    <div class="card mb-4">
        <div class="card-header">
            <i class="fas fa-table mr-1"></i>
            Profile Settings
        </div>
        <div class="card-body">
            <div class="table">
                <form id="formUser" method="post">
                    <div>
                        <label>Profil Resmi</label>
                        <asp:TextBox Style="display: none" ID="lblImage" runat="server"></asp:TextBox>
                        <img id="imgpreview" height="200" width="200" src="<%=lblImage.Text%>" style="border-width: 0px;" />
                        <asp:FileUpload ID="profileImage" runat="server" onchange="showpreview(this);" />
                    </div>
                    <div class="form-row">
                        <div class="col-md-6 mb-3">
                            <div class="form-group">
                                <label>Ad Soyad</label>
                                <asp:TextBox ID="txtName" CssClass="form-control" runat="server" placeholder="İsim Soyisim"
                                    required></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6 mb-3">
                            <div class="form-group">
                                <label>Kullanıcı Adı</label>
                                <input type="text" id="txtUsername" class="form-control" runat="server" placeholder="Kullanıcı Adı" required />
                            </div>
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label>E-Mail</label>
                                <input type="email" id="txtEmail" class="form-control" runat="server" placeholder="E-Mail Adres" required />
                            </div>
                        </div>
                        <div class="col-sm-3 mt-4">
                            <div class="form-check form-check-inline">
                                <label class="form-check-label" for="male">Male</label>
                                <input class="form-check-input" type="radio" name="radioGender" id="male" value="male" runat="server" />
                            </div>
                        </div>
                        <div class="col-sm-3 mt-4">
                            <div class="form-check form-check-inline">
                                <label class="form-check-label" for="female">Female</label>
                                <input class="form-check-input" type="radio" name="radioGender" id="female" value="female" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="col-md-6 mb-3">
                            <div class="form-group">
                                <label>Parola</label>
                                <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" placeholder="Parola"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6 mb-3">
                            <div class="form-group">
                                <label>Tekrar Parola</label>
                                <asp:TextBox ID="txtRepassword" CssClass="form-control" runat="server" placeholder="Parola Tekrar"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <asp:Button ID="updateProfile" OnClick="Update_Profile_Button_Click" CssClass="btn btn-primary mt-4" Text="Save" runat="server" />
                </form>
            </div>
        </div>
    </div>
    <script src="../Content/js/bootstrap/jquery-3.4.1.min.js"></script>
    <script>
        function showpreview(input) {

            if (input.files && input.files[0]) {

                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#imgpreview').css('visibility', 'visible');
                    $('#imgpreview').attr('src', e.target.result);
                    $('#imgpreview').fadeIn(650);
                }
                reader.readAsDataURL(input.files[0]);
            }

        }
    </script>
</asp:Content>
