## Decorator Pattern

### *Gençay Hocama Saygılarımla..*

Yazılım mimarilerinde temel esas, mümkün mertebe birbirlerinden soyutlanmış yapıların gevşek bağlılığı(loose coupling) sağlayarak ortaya koyduğu geliştirmeye dayanmaktadır. Bu geliştirme sürecinde var olan sınıflarımızdaki bir metodun niteliğini değiştirme ihtiyacı hissedildiği zaman bu ihtiyacı kodu bozmaksızın, dinamik bir şekilde giderebilmemiz gerekmektedir. İşte böyle bir durumda, kurulmuş düzeni bozmadan, mimarisel yapılanmanın temellerini oynatmadan bir metodun niteliğini genişletmek için Decorator tasarım deseninden faydalanabiliriz.

İlk olarak genel bir yanlış anlaşılmadan başlamak istiyorum. Decorator pattern’inin genellikle bir class’a yeni bir özellik/member/metot vs. eklemeye yaradığı düşünülmektedir. Halbuki Decorator pattern, hali hazırda var olan bir sınıfın mevcudiyetteki metodunun işlevini genişletmek için vardır.

Decorator pattern, bir class’a metot eklemek için değil, var olan bir sınıfın mevcudiyetteki metodunun işlevini genişletmek için kullanılan bir desendir.

Bu durumu içeriğimizin seyrinde masaya yatıracağımız senaryolar eşliğinde zaten örneklendireceğiz. Şimdi hangi durumlarda bu desene ihtiyaç duyduğumuzu daha da açalım.

Decorator Deseni Ne Zaman Kullanılır?
– Şuayip abi : Yazılım nedir müdür?
– Sokrates : Yazılım değişimdir Şuayipciğim…

Evet… Yazılım nedir? sorusuna verilebilecek en güzel cevap sanırım değişim olacaktır. Bir probleme sunulan çözümün, bazen kâh problemin değişmesinden bazen de kâh problemden öte ihtiyaçların değişmesinden dolayı sürekli güncellenmesi gerekebilmektedir. Hatta, her ne kadar iyi bir mimarisel tasarım gerçekleştirirsek gerçekleştirelim, yeni doğacak ihtiyaçlara binaen yapılması gerekecek olan değişiklikler bizleri yıldırabilecek seviyede olabilmekte ve hatta mimarisel yaklaşımlardan uzaklaştırıp, spagetti çözümlere bile sevkedebilmektedir.

Esasında bu durumun, doğal bir sürecin önüne geçilemeyen bir parçası olduğunun farkında olunması gerekir. İş hayatında geliştirilen yazılımların seyrini; ihtiyaçlar, şartlar, değişken durumlar ve son kullanıcıların beklentisi belirlediği süreci bu değişiklik olgusu her daim hayatımızın bir parçası olacaktır. Bizlere düşen bu olguyla karşılaştığımızda onu paniğe kapılmaksızın karşılayabilmek ve evrensel bir çözümle uygulamanın yeni ihtiyaçlara olan adaptasyonunu sağlayabilmektir.

Şimdi olayı biraz daha teknik boyuta indirgeyerek devam edelim. Geliştirilen yazılımlarda mevcut bir işlemi üstlenen sınıflar ve o sınıflar içerisinde operasyonları yürüten metotlar oluşturulduktan sonra ilgili metotların işlevselliğine dair olan beklentinin artması oldukça doğaldır. Süreçte metotların satır sayıları gittikçe uzayabilir, son halleri ilk hallerinden oldukça alakasız bir sorumluluğa doğru evrilebilir.

Genelde yazılımcılar, oluşturdukları tasarımlarına yeni eklemelerin gelmesiyle tek sorumluluk prensibine tamamen aykırı çözümler üretirler. Nihayetinde sistem artık yeni özellikler barındırmak ve var olan metotlarda işlevselliklerini daha da arttırmak isteyecektir. Böyle bir durumda çözüm olarak sistemin arayüzlerine yeni imzalar ekleyerek gelecek özellikleri karşılayabilmekte mümkündür lakin bu sefer de arayüzleri şişirmenin sonucunda arayüz ayrım prensibine aykırı hareket edilmiş olacaktır. Hem aynı arayüzden türeyen kimi nesneler için yeni özellikler istenirken, kimisi içinde istenmeyebilir. Bu durumda arayüzü genişletmek dummy code’a da sebebiyet verebilecektir, ihtimaldir.

İşte bu ahvalde sistemi bozmadan ve prensiplere aykırı olmadan mimarideki metotların niteliklerini arttırabilmek ve sistemi genişletebilmek için daha efektif bir stratejiye ihtiyaç vardır…

Hali hazırdaki bir sistemin genişlemesi gerektiği durumlarda Decorator deseni biçilmiş kaftandır.


## Strategy Design Pattern

Behavioral Patterns(Davranışsal Kalıplar) kategorisine giren Strategy Design Pattern üzerinde detaylı irdeleme gerçekleştirelim. Bir işlem için birden fazla farklı yöntemlerin uygulanabileceği durumlar mevcuttur. İşte bu tarz durumlarda hangi yöntemin uygulanacağını, hangisinin devreye sokulacağını Strategy Design Pattern ile gerçekleştirebiliyoruz.

C# Strategy Design Pattern(Strateji Tasarım Deseni)

Diyagramda da gördüğünüz gibi bir işlemi gerçekleştirebilmenin “StrategyA”, “StrategyB” ve “StrategyC” isimli üç adet yöntemi mevcuttur. İşlemimizi temsil eden Context sınıfı ise aşağı satırlardaki mantıkla Strategy Design Pattern’i uygulatma gereksinimi doğurmaktadır.

Context, işlemi hangi yöntemle yapacaksa gidip ilgili yöntem adına Context’te güncelleme gerçekleştirmek zorunda kalacak eğer tekrar değişiklik olacaksa tekrar Context içeriğiyle oynamamız gerekecektir. İşte bu durumda, her yöntemi temsil edecek olan, daha doğrusu her yönteme bir şablon, arayüz işlevi görecek olan Strategy arayüzü(interface ya da abstract class olabilir) tanımlanmıştır. Bu arayüz barındırdığı elemanlar olarak tüm görevleri stabilize etmekte ve miras durumunda kasıtlı implement gerçekleştirmekte ve Context sınıfı bu arayüz aracılığıyla işlemlerini gerçekleştirmektedir.

Bu tasarım deseninde temel odak noktamız, Context’in işlemin nasıl yapılacağıyla ilgisini kesmektir.


Kaynaklar

https://www.gencayyildiz.com/blog/c-decorator-design-patterndecorator-tasarim-deseni/

https://www.gencayyildiz.com/blog/c-strategy-design-patternstrateji-tasarim-deseni/