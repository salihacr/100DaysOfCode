Referans : https://www.gencayyildiz.com/blog/asp-net-coreda-hangfire-kutuphanesi-ile-zamanlanmis-gorevler-olusturma/ Gençay hocama selamlar..

Background Jobs Nedir?
Arka plan işleri olarak nitelendirilen Background Jobs aslında zamanlanmış görevlerin ta kendisidir. Bazen uygulamalarımızın ana thread dışında bir task işlemesi yahut senaryo gereği belli aralıklarla belli işlemlerin gerçekleştirilmesi gerekebilmektedir. İşte bu tarz ihtiyaçlara istinaden gerçekleştirilen zamanlanmış görevleri background jobs diyerek tarif etmekteyiz.

Hangfire’ın Avantajları Nelerdir?
Oldukça kolay kullanıma ve yönetilebilirliğe sahiptir.
Hangfire, veritabanı ile otomatik entegrasyon sağladığı için tanımlanan işlere ait tüm kayıtları fiziksel olarak tutmaktadır. Dolayısıyla bir iş tam teferruatıyla tamamlanmadan geçilmeyecek, süreçteki olası hatalarla karşılaşılma durumunda iş tekrardan çalıştırılacak ve işe dair son noktayı koymaksızın bu süreç böyle devam edecektir. Dolayısıyla fiziksel kayıt söz konusu olduğundan dolayı iş güvenliği hat safhada sunulmaktadır.


Jobs
Sürece dahil olan tüm işlemleri durumlarıyla birlikte takip edebildiğimiz sekmedir;
Enqueued, sıradaki işleri
Scheduled, ileri tarihe ayarlanmış işleri
Processing, o anda işlemde olan/çalışan işleri
Succeeded, başarılı bir şekilde tamamlanmış işleri
Failed, başarısız olmuş işleri
Deleted, silinmiş işleri
Awaiting, sırasını bekleyen işleri
gösterir.

Retries
Tanımlanmış işlerden olası hatalar sonucu tekrara düşenleri gördüğümüz sekmedir. Bir işin kaçıncı kez tekrara girdiği görülebilir. Varsayılan olarak tekrar sayısı 10’dur.
Recurring Jobs
Tekrarlı tanımlanmış işlerin görüldüğü sekmedir. Her ne kadar ayarlanmış tekrar söz konusu olsada Trigger ile istenildiği an tetiklenebilir.
Servers
Kullanılan Hangfire sunucularını görebildiğimiz sekmedir.
Görev Oluşturma
Hangfire ile dört farklı aksiyonda görev oluşturulabilmektedir. Şimdi gelin bu aksiyonları tek tek inceleyelim;

Fire-And-Forget Jobs
İş tanımlanır ve hemen ardından bir kereye mahsus tetiklenir.
1
Hangfire.BackgroundJob.Enqueue(() => Console.WriteLine("Fire-And-Forget Jobs tetiklendi"));


Recurring Jobs
Belirlenen CRON zamanlamasına göre tekrarlanan işler tanımlanır.
1
Hangfire.RecurringJob.AddOrUpdate(() => Console.WriteLine("Recurring jobs tetiklendi!"), Hangfire.Cron.MinuteInterval(1));
Delayed Jobs
Oluşturulduktan belirli bir zaman sonra sadece bir seferliğine tetiklenecek olan görevler tanımlanır.
1
Hangfire.BackgroundJob.Schedule(() => Console.WriteLine("Delayed jobs tetiklendi!"), TimeSpan.FromSeconds(10));
Örneğin, yukarıdaki kod bloğundaki görev register edildikten 10 saniye sonra tetiklenecektir.
Asp.NET Core’da Hangfire Kütüphanesi İle Zamanlanmış Görevler Oluşturma

Continuations
Birbiriyle ilişkili işlerin olduğu durumlarda alınan aksiyondur. Bir jobun tetiklenebilmesi için bir öncekinin tamamlanması gerekmektedir.