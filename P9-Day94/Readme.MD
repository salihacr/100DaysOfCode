Reference : https://jasonwatmore.com/post/2020/07/06/aspnet-core-3-boilerplate-api-with-email-sign-up-verification-authentication-forgot-password#accounts-controller-cs


# *.NET Core 3.1 Boilerplate API Proje Yapısı*

Bu proje aşağıdaki klasörler halinde organize edilmiştir.

###  Controllers

Web API için endpointlerin tanımlandığı, http istekleri aracılığı ile istemci uygulamalarından, Web Servislere giriş noktasıdır.

###  Models

Response ve Requestlerin yapıldığı modellerin bulunduğu klasördür. 

### Services

Temel iş mantığı, doğrulama ve veri erişim katmanı kodlarını içerir.

### Entities

Veritabanında depolananan uygulama verilerini temsil eder. Entity Framework Core ile varlıklar arasındaki ilişkiler ve temel CRUD işlemleri sağlanır.

### Migrations

Varlık sınıflarımızın yapısının Veritabanına aktarılmasını sağlayan sınıftır. Üzerine güncelleme yapılabilme olanağı sağlar.

### Middleware 

Hata işleme ve jwt token doğrulama işlemlerini ele almak için middleware ler eklenmiştir.

### Helpers

Yardımcı kodların bulunduğu sınıftır.
