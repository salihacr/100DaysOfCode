using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EntityFramework
{

    public class Product
    {
        // otomatik key olarak tanımlamasını istersek bir kolonun
        // ya sadece Id deriz property ye yada classnameId deriz bu sayede otomatik key olarak belirlenir ef tarafından

        // data annoation ile propertylere ek özellikler ekleyebiliriz
        // string alanlar otomatik olarak nullable olarak gelir
        // num tipi değişkenler ise zorunlu olarak not null olarak işaretlenir bunun önüne geçmek için değişken tanımının ardına ? eklenir örn. int?
        public Guid ProductId { get; set; }
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        public decimal? Price { get; set; }

    }
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }




    // One To Many iliski

    // bir kullanıcının birden çok adresi olması

    public class User
    {
        // çoklama ilişkisinde constructor metot içinde objenin new ile üretilmesi lazım yoksa null referans hatası alırız
        public User()
        {
            Addresses = new List<Address>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        // bire çok ilişki kısmı
        public List<Address> Addresses { get; set; }

        // birebir ilişki kısmı
        public Customer Customer { get; set; }
    }


    public class Address
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        // bire çok ilişki kısmı
        public User User { get; set; }
        public int? UserId { get; set; }
    }

    // One To One ilişki

    public class Customer
    {
        public int CustomerId { get; set; }

        public string FullName { get; set; }

        public User User { get; set; }
        public int? UserId { get; set; }

    }



    // many to many relation

    public class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }

        public List<BlogComment> BlogComments { get; set; }
    }

    public class Comment
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        public string Commenter { get; set; }
        public List<BlogComment> BlogComments { get; set; }

    }

    public class BlogComment
    {
        public Blog Blog { get; set; }
        public int BlogId { get; set; }

        public Comment Comment { get; set; }
        public int CommentId { get; set; }
    }



    // Entity Frameworkun DB Context sınıfı 
    public class SalihContext : DbContext
    {

        // sql sorgularını görmek için loglama yapalım
        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        // veritabanı oluşturulurken çalışır
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);



            string connection = @"Server =SALIH; Database=learn-ef-db; Trusted_Connection = True";
            optionsBuilder
                .UseLoggerFactory(MyLoggerFactory)
                .UseSqlServer(connection);
            //optionsBuilder.usePostgreSql();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // many to many relation with fluent api

            modelBuilder.Entity<BlogComment>()
                .HasKey(t => new { t.BlogId, t.CommentId });

            modelBuilder.Entity<BlogComment>()
                .HasOne(bc => bc.Blog)
                .WithMany(b => b.BlogComments)
                .HasForeignKey(bc => bc.BlogId);

            modelBuilder.Entity<BlogComment>()
               .HasOne(bc => bc.Comment)
               .WithMany(c => c.BlogComments)
               .HasForeignKey(bc => bc.CommentId);
        }

        // tabloları (sınıfları) tanıtıyoruz
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Comment> Comments { get; set; }


        // Veritabanını ef code first ile oluşturmak için migration oluşturmak gerekir

        // Package manager console üzerinden gereken komut =>  add-migration MigrationIsmi
        // migration oluşturulduktan sonra veritabanına aktarmak için gereken komut => Update-Database
    }

    class Program
    {
        static void Main(string[] args)
        {

            // tel1 id => 38822136-29d5-4f09-30ef-08d8d65ed34a




            Console.ReadKey();
        }

        public static void InsertManyToMany()
        {
            using (var db = new SalihContext())
            {
                var blogs = new List<Blog>(){
                    new Blog(){Name="b1", Content="test blog1"},
                    new Blog(){Name="b2", Content="test blog2"},
                    new Blog(){Name="b3", Content="test blog3"}
                };

                db.Blogs.AddRange(blogs);
                db.SaveChanges();

                var comments = new List<Comment>()
                {
                    new Comment(){CommentText="test yorum1", Commenter="salih"},
                    new Comment(){CommentText="test yorum2", Commenter="salih1"},
                    new Comment(){CommentText="test yorum3", Commenter="salih2"},
                    new Comment(){CommentText="test yorum4", Commenter="salih3"},
                    new Comment(){CommentText="test yorum5", Commenter="salih4"},
                    new Comment(){CommentText="test yorum6", Commenter="salih5"},
                    new Comment(){CommentText="test yorum7", Commenter="salih5"},
                    new Comment(){CommentText="test yorum8", Commenter="salih7"}
                };

                db.Comments.AddRange(comments);
                db.SaveChanges();


            }
        }

        static void InsertUsers()
        {
            var users = new List<User>()
            {
                new User(){Username="Salih", Email="salih@kral.com"},
                new User(){Username="Harun", Email="harun@kral.com"},
                new User(){Username="Hikmet", Email="hikmet@kral.com"}
            };

            using (var db = new SalihContext())
            {
                db.Users.AddRange(users);
                db.SaveChanges();
            }
        }

        static void InsertAddresses()
        {
            var addresses = new List<Address>()
            {
                new Address(){FullName="Adres1",Title="Ev",Body="Gebze", UserId=1},
                new Address(){FullName="Adres1-2",Title="iş",Body="işgebze", UserId=1},
                new Address(){FullName="Adres2",Title="Ev",Body="Gebze-ev", UserId=2},
                new Address(){FullName="Adres2-2",Title="iş",Body="Gebze-iş", UserId=2},
                new Address(){FullName="Adres3",Title="Ev",Body="Gebze-ev", UserId=3}
            };

            using (var db = new SalihContext())
            {
                db.Addresses.AddRange(addresses);
                db.SaveChanges();
            }
        }


        static void DeleteProduct(string name)
        {
            using (var db = new SalihContext())
            {
                var p = db.Products.FirstOrDefault(i => i.Name == name);

                if (p != null)
                {
                    db.Remove(p);
                    db.SaveChanges();

                    Console.WriteLine("Kayıt silindi");


                    // 2. yöntem select olmadan çalışır direk siler


                    /*
                        var p1 = new Product() { Name = "Tel1" };
                        //db.Products.Remove(p1);
                        // veya
                        db.Entry(p1).State = EntityState.Deleted;
                        db.SaveChanges();
                    */
                }

            }
        }

        static void UpdateProduct(string id)
        {
            using (var db = new SalihContext())
            {

                // change tracking
                var p = db.Products.Where(i => i.ProductId.ToString() == id).FirstOrDefault();
                if (p != null)
                {
                    p.Price *= 1.2m;

                    db.SaveChanges();

                    Console.WriteLine("güncelleme yapıldı");
                }
            }
        }
        static void UpdateByName(string name)
        {

            // 2. yöntem
            using (var db = new SalihContext())
            {
                var entity = new Product() { Name = name };
                db.Products.Attach(entity);
                entity.Price = 1999;

                db.SaveChanges();


                Console.WriteLine("güncelleme yapıldı");
            }
        }

        static void GetProductByName(string name)
        {
            using (var db = new SalihContext())
            {
                var product = db
                    .Products
                    .Where(product =>
                        product.Name == name
                    )
                    .FirstOrDefault();


                Console.WriteLine(product.ProductId + " " + product.Name + " " + product.Price);

            }
        }
        static void GetAllProducts()
        {
            using (var db = new SalihContext())
            {
                var products = db
                    .Products
                    .Select(product =>
                        new
                        {
                            product.Name,
                            product.Price
                        })
                    .ToList();

                foreach (var p in products)
                {
                    Console.WriteLine(p.Name + " " + p.Price);
                }
            }
        }

        static void AddProduct()
        {
            // Veri ekleme

            using (var db = new SalihContext())
            {
                var product = new Product { Name = "PC", Price = 2000 };


                db.Products.Add(product);

                db.SaveChanges();

                Console.WriteLine("Veri eklendi");
            }
        }

        static void AddProducts()
        {
            // Çoklu veri ekleme
            using (var db = new SalihContext())
            {
                var products = new List<Product>
                {
                    new Product {Name="Tel1", Price=200},
                    new Product {Name="Tel2", Price=300},
                    new Product {Name="Tel3", Price=400},
                    new Product {Name="Tel4", Price=500}
                };

                //foreach (var p in products)
                //{
                //    db.Products.Add(p);
                //}

                // veya direk AddRange ile

                db.Products.AddRange(products);
                db.SaveChanges();
                Console.WriteLine("Veriler eklendi");
            }
        }
    }
}
