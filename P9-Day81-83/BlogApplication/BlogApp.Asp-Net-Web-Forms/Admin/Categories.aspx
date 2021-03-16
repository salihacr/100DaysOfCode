<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="BlogApp.Asp_Net_Web_Forms.Admin.Categories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BlankContent" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.5.2/css/bootstrap.css" />
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.23/css/dataTables.bootstrap4.min.css" />
    <ol class="breadcrumb mb-4">
        <li class="breadcrumb-item active">Dashboard/Kategoriler</li>
    </ol>
    <div class="card mb-4">
        <div class="card-header">
            <i class="fas fa-table mr-1"></i>
            Kategoriler
        </div>
        <div class="card-body">
            <div class="table">
                <form id="categoryForm" method="post">
                    <div class="col-md-12">
                        <div class="form-group">
                            <label>Kategori</label>
                            <input type="text" id="categoryName" class="form-control mb-2" />
                            <input type="button" class="btn btn-primary" value="KAYDET" id="btnSubmit" onclick="save()" />
                        </div>
                    </div>
                    <hr />
                    <div class="col-md-12">
                        <h4>Tüm Kategoriler</h4>
                        <table id="tbl" class="table table-striped table-bordered" style="width: 100%">
                            <thead>
                                <tr>
                                    <th>Id</th>
                                    <th>Kategori</th>
                                    <th>İşlemler</th>
                                </tr>
                            </thead>
                            <tbody>
                                <div class="alert alert-warning" id="alert" role="alert" style="display: none;">
                                    Listede kategori bulunamadı.
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
    <!-- Bootstrap core JavaScript-->
    <script src="../Content/js/bootstrap/jquery-3.4.1.min.js"></script>
    <script src="../Content/js/bootstrap/bootstrap.min.js"></script>
    <script src="../Content/js/bootstrap/popper.min.js"></script>

    <script src="https://cdn.datatables.net/1.10.23/js/jquery.dataTables.min.js"></script>

    <script>
        $(document).ready(function () {
            GetData();
        });
        //In url write your page name like"CRUD.aspx" and Webmethod name "InsertData".
        //Write jQuery Ajax to call WebMethod(InsertData)
        function save() {
            if ($("#btnSubmit").val() == "KAYDET") {
                $.ajax({
                    url: 'Categories.aspx/AddCategory',
                    type: 'post',
                    contentType: 'application/json;charset=utf-8',
                    dataType: 'json',
                    data: "{categoryName:'" + $("#categoryName").val() + "'}",
                    success: function () {
                        toastr.success("Kategori başarı ile eklendi.");
                        GetData();
                    },
                    error: function (e) {
                        toastr.error("Veri kayıt hatası.");
                    }
                });
            }
            else {
                $.ajax({
                    url: 'Categories.aspx/Update',
                    type: 'post',
                    contentType: 'application/json;charset=utf-8',
                    dataType: 'json',
                    data: "{categoryId:'" + idd + "',categoryName:'" + $("#categoryName").val() + "'}",
                    success: function () {
                        toastr.success("Kategori başarı ile güncellendi.");
                        $("#btnSubmit").val("KAYDET");
                        GetData();
                    },
                    error: function () {
                        toastr.error("Veri güncelleme hatası.");
                    }

                });
            }
            $('#categoryName').val("");

        }
        //Retreive Record
        function GetData() {
            $.ajax({
                url: 'Categories.aspx/GetAll',
                type: 'post',
                contentType: 'application/json;charset=utf-8',
                dataType: 'json',
                data: "{}",
                success: function (_data) {
                    if (_data.d.length > 0) {
                        _data = JSON.parse(_data.d);
                        $("#tbl").find("tr:gt(0)").remove();
                        for (var i = 0; i < _data.length; i++) {
                            $("#tbl").append('<tr><td>' + _data[i].CategoryId + '</td>' + '<td>' + _data[i].CategoryName + '</td><td><input type="button" class="btn btn-danger mr-2" id="btndelete" value="Delete" onclick="DeleteData('
                                + _data[i].CategoryId + ')" /><input type="button" id="btnedit" value="Edit" class="btn btn-warning ml-2" onclick="EditData(' + _data[i].CategoryId + ')" /></td>  </tr>');
                        }
                        $("#alert").hide();
                    }
                    else {
                        $("#alert").show();
                    }
                },
                error: function () {
                    toastr.error("Veri getirilemedi.");
                }
            });

        }
        //Edit Record 
        function EditData(categoryId) {
            $.ajax({
                url: 'Categories.aspx/Edit',
                type: 'post',
                contentType: 'application/json;charset=utf-8',
                dataType: 'json',
                data: "{categoryId : '" + categoryId + "'}",
                success: function (_dt) {
                    _dt = JSON.parse(_dt.d);
                    $("#categoryName").val(_dt[0].CategoryName);

                    $("#btnSubmit").val("DÜZENLE");
                    idd = categoryId;
                },
                error: function () {
                    toastr.error("Düzenleme hatası.");
                }
            });
        }
        //Delete Record
        function DeleteData(categoryId) {
            $.ajax({
                url: 'Categories.aspx/Delete',
                type: 'post',
                contentType: 'application/json;charset=utf-8',
                dataType: 'json',
                data: "{categoryId : '" + categoryId + "'}",
                success: function () {
                    toastr.success("Veri başarıyla silindi.");
                    $("#tbl").find("tr:gt(0)").remove();
                    GetData();
                },
                error: function () {
                    toastr.error("Veri silme hatası.");
                }
            });
        }
    </script>
</asp:Content>
