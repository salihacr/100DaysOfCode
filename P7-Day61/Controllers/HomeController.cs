using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mvc_Asp.NetCore.Models;

namespace Mvc_Asp.NetCore.Controllers
{
    public class HomeController : Controller
    {
        List<Book> books = new List<Book>();
        public async Task<IActionResult> Index()
        {

            // Controller'dan View e veri taşıma yöntemleri
            /*
                Model sınıfımıza ait bir veriyi açılır listeden (drop down list) seçeceksek bu listenin verisi için kullanabiliriz.
                Küçük ölçekli veriler.
                Kullanıcıya verilen uyarı mesajları.
                Örneğin kullanıcı kayıt olduktan sonra kullanıcıya gösterilen profil özeti ekranı.
             
             */
            ViewBag.Message = $"Bu mesaj ViewBag Aracılığıyla gelmektedir => {DateTime.Now.ToString()}";

            ViewData["Message2"] = $"Bu mesaj ViewData Aracılığıyla gelmektedir =>  {DateTime.Now.ToString()}";

            TempData["Message3"] = $"Bu mesaj TempData Aracılığıyla gelmektedir =>  {DateTime.Now.ToString()}";

            var data = GetCurrencies();



            // Controllerden View'e model gönderme
            // Get All metodu ile List gönderilir mantık açısından
            // Get By Id tarzı metotlar ile Düz model olarak göndermek yeterli olacaktır
            var newBooks = new List<Book>()
            {
                new Book()
                {
                    ID=Guid.NewGuid().ToString(),
                    BookName="Suç ve Ceza",
                    Author="Dostoyevski"
                },
                new Book()
                {
                    ID=Guid.NewGuid().ToString(),
                    BookName="Bilinmeyen bir kadının mektubu",
                    Author="Zweig"
                },
                new Book()
                {
                    ID=Guid.NewGuid().ToString(),
                    BookName="Bir noel Hikayesi",
                    Author="Charles Dickes"
                }
            };

            books.AddRange(newBooks);

            await Task.WhenAll(data);
            ViewData["CurrencyData"] = data;

            return View(books);
        }
        [HttpPost]
        public IActionResult Index(Book book)
        {
            if (ModelState.IsValid)
            {
                book.ID = Guid.NewGuid().ToString();
                book.BookName = "adsad";
                book.Author = "adsada";
                books.Add(book);
            }
            return View(book);
        }
        // Asenkron Metot ile Kurların Çekilmesi
        public async Task<string> GetCurrencies()
        {
            WebClient client = new WebClient();
            var exchange = await client.DownloadStringTaskAsync("https://www.tcmb.gov.tr/kurlar/today.xml");
            return exchange;
        }
    }
}
