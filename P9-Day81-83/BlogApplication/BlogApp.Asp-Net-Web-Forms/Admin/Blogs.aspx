<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="Blogs.aspx.cs" Inherits="BlogApp.Asp_Net_Web_Forms.Admin.Blogs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BlankContent" runat="server">
    <ol class="breadcrumb mb-4">
        <li class="breadcrumb-item active">Dashboard/Bloglar</li>
    </ol>
    <a href="AddBlog.aspx" class="btn btn-success mb-4">Yeni Blog</a>
    <div class="card mb-4">
        <div class="card-header">
            <i class="fas fa-table mr-1"></i>
            Blog Listesi
        </div>
        <div class="card-body">
            <div class="table">
                <table id="tbl" class="table table-striped table-hover table-bordered">
                    <thead>
                        <tr>
                            <th>Blog Adı</th>
                            <th>Blog Url</th>
                            <th>Yayınlanma Tarihi</th>
                            <th>İşlemler</th>
                        </tr>
                    </thead>
                    <tbody>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
        <script src="../Content/js/toastr.min.js"></script>
    <!-- Bootstrap core JavaScript-->
    <script src="../Content/js/bootstrap/jquery-3.4.1.min.js"></script>
    <script src="../Content/js/bootstrap/bootstrap.min.js"></script>
    <script src="../Content/js/bootstrap/popper.min.js"></script>
    <script>
        $(document).ready(function () {
            GetBlogList();
        });
        function GetBlogList() {
            $.ajax({
                url: 'Blogs.aspx/GetBlogList',
                type: 'post',
                contentType: 'application/json;charset=utf-8',
                dataType: 'json',
                data: "{}",
                success: function (_data) {
                    _data = JSON.parse(_data.d);
                    $("#tbl").find("tr:gt(0)").remove();
                    for (var i = 0; i < _data.length; i++) {
                        $("#tbl").append(tableRow2(_data, i));
                    }
                },
                error: function () {
                    toastr.error("Bloglar listelenirken hata oluştu.");
                }
            });
        }
        function tableRow(data, index) {
            var data = ""
                + "<tr>"
                + "<td>" + data[index].BlogName + "</td>"
                + "<td>" + data[index].BlogURL + "</td>"
                + "<td>" + data[index].CreationDate + "</td>"
                + "<td>"
                + "<button type='button' class='btn btn-danger mr-2' id='btndelete' onclick='Delete(" + data[index].BlogId + ")'> <i class='fa fa-trash'></i></button> "
                + "<a class='btn btn-warning mr-2' id='btnEdit' href='/Admin/EditBlog.aspx?blogId=" + data[index].BlogId + "'><i class='fa fa-edit'></i></a>"
                + "</td>"
                + "</tr>";
            return data;
        }
        function tableRow2(data, index) {
            var data = `
                <tr>
                <td>${data[index].BlogName}</td>
                <td>${data[index].BlogURL}</td>
                <td>${data[index].CreationDate}</td>
                <td>
                <button type="button" class="btn btn-danger mr-2" id="btnDeleteBlog" onclick="Delete('${data[index].BlogId}')"><i class="fa fa-trash"></i></button>
                <a class="btn btn-warning mr-2" id="btnEditBlog" href="/Admin/EditBlog.aspx?blogId=${data[index].BlogId}"><i class="fa fa-edit"></i></a>
                </td>
                </tr>`;
            return data;
        }
        //Delete Record
        function Delete(blogId) {
            $.ajax({
                url: 'Blogs.aspx/Delete',
                type: 'post',
                contentType: 'application/json;charset=utf-8',
                dataType: 'json',
                data: "{blogId : '" + blogId + "'}",
                success: function () {
                    toastr.success("Blog başarıyla silindi.");
                    GetBlogList();
                },
                error: function () {
                    toastr.error("Blog silinirken hata oluştu.");
                }
            });
        }
    </script>
</asp:Content>
