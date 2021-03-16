using System;
using System.Data.SqlClient;
using BlogApp.Asp_Net_Web_Forms.Helpers;

namespace BlogApp.Asp_Net_Web_Forms.SeedDatabase
{
    public static class SeedDb
    {
        static SqlConnection connection = MyConnection.GetConnection();
        static Helpers.Auth authManager = new Helpers.Auth();
        public static void Seed()
        {
            string users = "Insert Users(UserId, FullName, Email, Username, Image, Gender, Password, RoleName)" +
                " Values" +
                "('u1','Admin Admin','admin@blog.com','admin','no-image','male','" + authManager.CreatePasswordHash("admin") + "','Admin')";

            string categories = "Insert Categories(CategoryName)" +
                " Values" +
                "('Yazılım')," +
                "('Programlama')," +
                "('Yapay Zeka')," +
                "('Veritabanı')," +
                "('Asp.Net Core')";

            string blogs = "Insert Blogs(BlogId, BlogName, BlogURL, BlogContent, HeaderImage, CreationDate, BlogCategoryId, BlogUserId)" +
                " Values" +
                "('blog1','1.Blog','blog1','<h1>1. Blog Icerik</h1> <br/> <p>1. Blogun içeriği, lorem ipsum...</p>','no-image','" + DateTime.Now.ToShortDateString().ToString() + "','1','u1')," +
                "('blog2','2.Blog','blog2','<h1>2. Blog Icerik</h1> <br/> <p>2. Blogun içeriği, lorem ipsum...</p>','no-image','" + DateTime.Now.ToShortDateString().ToString() + "','2','u1')," +
                "('blog3','3.Blog','blog3','<h1>3. Blog Icerik</h1> <br/> <p>3. Blogun içeriği, lorem ipsum...</p>','no-image','" + DateTime.Now.ToShortDateString().ToString() + "','3','u1')";


            string comments = "Insert Comments(CommentText, Commenter, IsApproved, BlogId)" +
                " Values" +
                "('Erto Beştaşa Geçelim','Sinan Engin','true','blog1')," +
                "('Haydaaa','Rasim Ozan Kütahyalı','true','blog1')," +
                "('Bakın Beyler','Ahmet Çakar','true','blog1')," +
                "('Hocam beni tebrik eder misin ?','Abdulkerim Durmaz','true','blog1')," +
                "('Sinan Engin in instagram adresi sinanengin.','Ertem Şener','true','blog2')," +
                "('Benim fikrim beni ilgilendirmez.','Sinan Engin','true','blog2')," +
                "('Ya Sertaç yeter be kardeşim, baba büyüksün yakıyosun baba.','Sinan Engin','true','blog3')," +
                "('Ya Mevlüt yeter telefonu kıracam ya.','Sinan Engin','true','blog3')," +
                "('Dinçer kardeşime selamlar.','Sinan Engin','true','blog3')" +
                "";


            if (!HasData("Users"))
            {
                Insert(users);
            }
            if (!HasData("Categories"))
            {
                Insert(categories);
            }
            if (!HasData("Blogs"))
            {
                Insert(blogs);
            }
            if (!HasData("Comments"))
            {
                Insert(comments);
            }
        }
        public static void Insert(string query)
        {
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
        public static bool HasData(string tableName)
        {
            using (SqlCommand cmd = new SqlCommand("Select Count(*) From " + tableName + "", connection))
            {
                connection.Open();
                object result = cmd.ExecuteScalar();
                connection.Close();
                if (result.ToString() == "0")
                {
                    return false;
                }
            }
            return true;
        }
    }
}