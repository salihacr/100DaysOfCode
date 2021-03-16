<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Blog.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="BlogApp.Asp_Net_Web_Forms.Blog.Index" %>

<asp:Content ID="content1" ContentPlaceHolderID="BlankContent" runat="server">

    <!-- Page Header -->
    <header class="masthead" style="background-image: url('../Content/img/home-bg.jpg')">
        <div class="overlay"></div>
        <div class="container">
            <div class="row">
                <div class="col-lg-8 col-md-10 mx-auto">
                    <div class="site-heading">
                        <h1>Blog Uygulama </h1>
                        <span class="subheading">Asp.Net Tabanlı Blog Uygulaması</span>
                    </div>
                </div>
            </div>
        </div>
    </header>
    <!-- Main Content -->
    <div class="container">
        <div class="row">
            <div class="col-lg-8 col-md-10 mx-auto">
                <asp:Repeater ID="rptBlogs" runat="server">
                    <ItemTemplate>
                        <div class="post-preview">
                            <a href="Article.aspx?blog=<%#Eval("BlogURL") %>">
                                <h2 class="post-title"><%#Eval("BlogName") %>
                                </h2>
                                <h3 class="post-subtitle"><%#Eval("BlogURL") %>
                                </h3>
                            </a>
                            <p class="post-meta"><%#Eval("Username") %> | <%#Eval("CreationDate") %> </p>
                            <hr>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            Pagination
        </div>
    </div>
</asp:Content>
