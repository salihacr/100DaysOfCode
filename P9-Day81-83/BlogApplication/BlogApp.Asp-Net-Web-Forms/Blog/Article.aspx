<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Blog.Master" AutoEventWireup="true" CodeBehind="Article.aspx.cs" Inherits="BlogApp.Asp_Net_Web_Forms.Blog.Article" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BlankContent" runat="server">
    <!-- Page Header -->
    <header class="masthead" style="background-image: url('../Content/img/post-bg.jpg')">
        <div class="overlay"></div>
        <div class="container">
            <div class="row">
                <div class="col-lg-8 col-md-10 mx-auto">
                    <div class="post-heading">
                        <h1 id="blogName"></h1>
                        <h2 class="subheading" id="category"></h2>
                        <span style="display: inline;" class="meta" id="releaseDate"></span>| <b style="display: inline;" class="meta" id="author"></b>
                    </div>
                </div>
            </div>
        </div>
    </header>

    <!-- Post Content -->
    <article>
        <div class="container">
            <div class="row">
                <div class="col-lg-8 col-md-10 mx-auto" id="blogContent">
                </div>
            </div>
            <section id="comment">
                <form id="categoryForm" method="post">
                    <div class="col-lg-8 col-md-10 mx-auto">
                        <div class="form-group">
                            <label>İsim*</label>
                            <input type="text" id="commenter" name="commenter" required class="form-control" /><br />
                            <label>Yorum*</label>
                            <textarea id="commentText" name="commentArea" required class="form-control" rows="4"></textarea>
                        </div>
                        <input type="button" class="btn btn-primary" value="Yorum Gönder" id="btnSubmit" onclick="save()" />
                    </div>
                </form>
            </section>
            <hr />
            <div class="col-lg-8 col-md-10 mx-auto">

                <h6>Yorumlar</h6>
                <section id="comments">
                </section>
            </div>
        </div>

    </article>


    <script src="../Content/js/bootstrap/jquery-3.4.1.min.js"></script>
    <script>
        $(document).ready(function () {
            GetData();
            //GetComments();
        });

        // get comments ekle isapproved false gelsin
        function GetData() {
            const blogUrl = "<%=Request.QueryString["blog"]%>";
            $.ajax({
                url: "Article.aspx/GetBlogByUrl",
                method: "post",
                contentType: "application/json",
                data: "{url : '" + blogUrl + "'}",
                dataType: 'json',
                type: 'POST',
                success: function (data) {
                    console.log(data.d);
                    let myData = JSON.parse(data.d);
                    for (var i = 0; i < myData.length; i++) {
                        if (myData[i].IsApproved == true) {
                            $("#comments").append(
                                "<label class='text-danger'>" + myData[i].Commenter + "</label> <br/><small>" + myData[i].CommentText + "</small><hr/> "
                            );
                        }
                    }
                    $('#blogName').html(myData.BlogName);
                    $('#category').html(myData[0].CategoryName);
                    $('#author').html(myData[0].Username);
                    $('#releaseDate').insertBefore(myData[0].CreationDate);
                    $('#blogContent').html(myData[0].BlogContent);
                },
                error: function () {
                    toastr.error("Blog getirilirken hata meydana geldi.");
                }
            });
        }
        function save() {
            const blogUrl = "<%=Request.QueryString["blog"]%>";
            let obj = "{comment:'" + $("#commentText").val() + "', commenter:'" + $("#commenter").val() + "', blogUrl:'" + blogUrl + "'}";
            $.ajax({
                url: 'Article.aspx/AddComment',
                type: 'post',
                contentType: 'application/json;charset=utf-8',
                dataType: 'json',
                data: obj,
                success: function () {
                    toastr.success("Yorumunuz onay için gönderildi.");
                    $("#comments").html("");
                    GetData();
                },
                error: function (e) {
                    toastr.error("Yorum kayıt hatası.");
                }
            });
        }

    </script>
</asp:Content>
