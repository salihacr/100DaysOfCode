## Linear Search (Doğrusal Arama)
<hr>
<li>Sırasız Liste

Aranan değer listenin içinde baştan başlayarak sırayla aranır.<br>

Aranan Değer Bulunursa En İyi Durum => 1, En Kötü Durum => n<br>

Aranan Değer Bulunmassa En İyi Durum => n , En Kötü Durum => n<br>

<li>Sıralı Liste

Aranan değer listenin içinde baştan başlayarak sırayla aranır. Ek olarak aranan sayı kendisinden sonraki büyük elemandan önce bulunmadıysa listenin devamı aranmaz.<br>

Aranan Değer Bulunursa En İyi Durum => 1, En Kötü Durum => n<br>

Aranan Değer Bulunmassa En İyi Durum => <b>1</b> , En Kötü Durum n 

## Binary Search (İkili Arama)
<hr>

Sıralı arama yapmaz. Sıralı listelerde çok avantajlı çalışır.<br>

Binary Search aramaya ortadan başlar. Eğer aradığı değer ortadaki değerden büyük ise bir sonraki arama adımı ortadaki değerin sağ tarafı yani büyük sayıların olduğu tarafta yapar. Aynı mantık tüm yönler (sağ(büyük), sol(küçük)) için geçerlidir. <br>

Binary Search böl ve fethet mantığı ile çalışır.<br>

En İyi Durum => 1, En Kötü Durum => log(n) dir.<br>

Bu yazı kapsamında diziler üzerinde ikili arama işleminin nasıl yapıldığı anlatılacaktır. Ancak algoritma, diziler dışında çok farklı veri yapıları ve veri kaynakları için de kullanılabilir. Algoritmanın her durumda çalışması aşağıdaki şekildedir.

Problemde aranacak uzayın tam orta noktasına bak
Şayet aranan değer bulunduysa bit
Şayet bakılan değer aranan değerden büyükse arama işlemini problem uzayının küçük elamanlarında devam ettir.
Şayet bakılan değer arana değerden küçükse arama işlemini problem uzayının büyük elemanlarında devam ettir.
Şayet bakılan aralık 1 veya daha küçükse aranan değer bulunamadı olarak bitir.
Yukarıdaki müsvedde kod (pseudo code) ele alındığında problem her seferinde aranan sayıya göre ortadan ikiye bölünmektedir. Bu anlamda problemin log2(n) adımda çözülmesi beklenir. Burada logaritmik fonksiyonların üssel fonksiyonların tersi olduğu ve her adımda problemi iki parçaya böldüğümüzü hatırlayınız.

Arama algoritmasının bir dizi üzerinde başarılı çalışması için dizinin sıralı olması gerekir. Yukarıdaki koddan anlaşılacağı üzere ortadaki elemana bakıldığında, aranan sayı ya bakılan sayıdan büyük ya da küçüktür. Dolayısıyla algoritmamız, ya bakılan sayıdan küçük olan sayılar arasında arama yapacak ya da büyük olan sayılar arasında arama yapacaktır.

### [Dr. Şadi Evren Şeker](http://bilgisayarkavramlari.com/2009/12/21/ikili-arama-algoritmasi-binary-search-algorithm/)


## Selection Sort (Seçmeli Sıralama Algoritması)
<hr>

Dizideki en küçük elemanı bul, bu elemanı dizinin ilk (yer olarak) elemanıyla yer değiştir.
<br><li>Daha sonra ikinci en küçük elemanı bul ve bu
elemanı dizinin ikinci elemanıyla yer değiştir. 
<br><li>Bu işlemi dizinin tüm elemanları sıralanıncaya kadar
sonraki elemanlarla tekrar et.
<br><li>Elemanların seçilerek uygun yerlerine konulması ile
gerçekleştirilen bir sıralamadır. <br>

Her Durumda zaman karmaşıklığı n^2 dir.<br>

## Bubble Sort (Kabarcık Sıralama Algoritması)
<hr>

<li>Dizinin elemanları üzerinden ilk elemandan
başlayarak ve her geçişte sadece yan yana
bulunan iki eleman arasında sıralama yapılır.
<br><li>Dizinin başından sonuna kadar tüm elemanlar bir
kez işleme tabi tutulduğunda dizinin son elemanı
(küçükten büyüğe sıralandığında) en büyük eleman
haline gelecektir. 
<br><li>Bir sonraki tarama ise bu en sağdaki eleman
dışarıda bırakılarak gerçekleştirilmektedir. 

1. ilk iki sayıyı al.
2. aldığın iki sayıyı karşılaştır.
3. küçük olanı yaz diğerini aklında tut.
4. dizinin sonuna geldiysen aklındaki sayıyı diziye yazarak bitir.
5. dizinin sonu değilse yeni bir sayı al.
6. 2.adıma geri dön.

Aşağıdaki sayıları kabarcık sıralaması
algoritmasına uygun olarak sıralayalım. { 5,8,3,10,6,1,4 }

1. adım : 5,3,8,6,1,4,10
2. adım: 3,5,6,1,4,8,10
3. adım: 3,5,1,4,6,8,10
4. adım: 3,1,4,5,6,8,10
5. adım:1,3,4,5,6,8,10
6. adım:1,3,4,5,6,8,10