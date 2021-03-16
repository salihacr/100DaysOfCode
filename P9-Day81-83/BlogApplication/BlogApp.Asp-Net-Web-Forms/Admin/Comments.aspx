<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="Comments.aspx.cs" Inherits="BlogApp.Asp_Net_Web_Forms.Admin.Comments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BlankContent" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.5.2/css/bootstrap.css" />
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.23/css/dataTables.bootstrap4.min.css" />
    <ol class="breadcrumb mb-4">
        <li class="breadcrumb-item active">Dashboard/Yorumlar</li>
    </ol>
    <div class="card mb-4">
        <div class="card-header">
            <i class="fas fa-table mr-1"></i>
            Yorumlar
        </div>
        <div class="card-body">
            <div class="table">
                <form id="categoryForm" method="post">
                    <div class="col-md-12" id="editArea" style="display: none;">
                        <div class="form-group">
                            <div class="form-check">
                                <input type="checkbox" class="form-check-input" id="isApproved">
                                <label class="form-check-label" for="isApproved">Onaylandı mı ?</label>
                            </div>
                        </div>
                        <div class="form-group">
                            <input type="button" class="btn btn-primary" value="KAYDET" id="btnSubmit" onclick="save()" />
                        </div>
                    </div>
                    <hr />
                    <div class="col-md-12">
                        <h4>Tüm Yorumlar</h4>
                        <table id="tbl" class="table table-striped table-bordered" style="width: 100%">
                            <thead>
                                <tr>
                                    <th>Id</th>
                                    <th>Yorum</th>
                                    <th>Yorumcu</th>
                                    <th>Blog</th>
                                    <th>Onay</th>
                                    <th>İşlemler</th>
                                </tr>
                            </thead>
                            <tbody>
                                <div class="alert alert-warning" id="alert" role="alert" style="display: none;">
                                    Listede yorum bulunamadı.
                                </div>
                            </tbody>
                        </table>
                    </div>
                    <hr />
                </form>
            </div>
        </div>
    </div>
        <script src="../Content/js/toastr.min.js"></script>
    <script src="../Content/js/bootstrap/jquery-3.4.1.min.js"></script>
    <script src="../Content/js/bootstrap/bootstrap.min.js"></script>
    <script src="../Content/js/bootstrap/popper.min.js"></script>

    <script>
        $(document).ready(function () {
            GetData();
        });
        //Edit Record 
        function EditData(commentId) {
            $.ajax({
                url: 'Comments.aspx/Edit',
                type: 'post',
                contentType: 'application/json;charset=utf-8',
                dataType: 'json',
                data: "{commentId : '" + commentId + "'}",
                success: function (_dt) {
                    _dt = JSON.parse(_dt.d);
                    if (_dt[0].IsApproved) {
                        $("#isApproved").prop("checked", true);
                    } else {
                        $("#isApproved").prop("checked", false);
                    }
                },
                error: function () {
                    alert('edit error !!');
                }
            });
        }
        async function Update(commentId) {
            await EditData(commentId);
            setTimeout(() => {
                var isApproved = $("#isApproved").is(":checked") == true ? 'true' : 'false';
                const obj = "{commentId:'" + commentId + "', isApproved:'" + isApproved + "'}";
                $.ajax({ // son kısım
                    url: 'Comments.aspx/Update',
                    type: 'post',
                    contentType: 'application/json;charset=utf-8',
                    dataType: 'json',
                    data: obj,
                    success: function () {
                        toastr.success("Yorum onayı güncellendi.");
                        GetData();
                    },
                    error: function () {
                        toastr.error("Bir hata oluştu.");
                    }

                });
            }, 100)
        }
        //Retreive Record
        function GetData() {

            $.ajax({
                url: 'Comments.aspx/GetAll',
                type: 'post',
                contentType: 'application/json;charset=utf-8',
                dataType: 'json',
                data: "{}",
                success: function (_data) {
                    if (_data.d.length > 0) {
                        _data = JSON.parse(_data.d);
                        $("#tbl").find("tr:gt(0)").remove();

                        for (var i = 0; i < _data.length; i++) {
                            $("#tbl").append(tableRow(_data, i));
                        }
                        $("#alert").hide();
                    }
                    else {
                        $("#alert").show();
                    }
                },
                error: function () {
                    toastr.error("Veriler getirilemedi.");
                }
            });

        }
        function tableRow(data, index) {
            var isApproved = data[index].IsApproved;
            var approvedIcon = isApproved == true ? "<i class='fa fa-check'></i>" : "<i class='fa fa-times'></i>"
            var data = ""
                + "<tr>"
                + "<td>" + data[index].CommentId + "</td>"
                + "<td>" + data[index].CommentText + "</td>"
                + "<td>" + data[index].Commenter + "</td>"
                + "<td>" + data[index].BlogName + "</td>"
                + "<td>" + approvedIcon + "</td> "
                + "<td>"
                + "<button type='button' class='btn btn-danger mr-2' id='btndelete' onclick='DeleteData(" + data[index].CommentId + ")'> <i class='fa fa-trash'></i> </button> "
                + "<button type='button' class='btn btn-warning mr-2' id='btnEdit' value='Edit' onclick='Update(" + data[index].CommentId + ")'><i class='fa fa-edit'></i></button>"
                + "</td>"
                + "</tr>";
            return data;
        }
        //Delete Record
        function DeleteData(commentId) {
            $.ajax({
                url: 'Comments.aspx/Delete',
                type: 'post',
                contentType: 'application/json;charset=utf-8',
                dataType: 'json',
                data: "{commentId : '" + commentId + "'}",
                success: function () {
                    toastr.success("Yorum silindi.");
                    $("#tbl").find("tr:gt(0)").remove();
                    GetData();
                },
                error: function () {
                    toastr.error("Veri silinemedi.");
                }
            });
        }
    </script>
</asp:Content>
