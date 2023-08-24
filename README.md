Merhaba,

Bu projemde, öğrendiklerimi kullanarak yapabileceklerimi test etmek, yeni şeyler öğrenmek, kendimi geliştirmek ve yapabileceklerimi gösterebilmesi için ortaya koyduğum bir proje oldu.

Projenin Frontend dosyaları;
https://github.com/Yoakest/SafakTicaretAngular

Onion Architecture ile Tasarım;
  Projeyi, Onion Architecture prensipleri doğrultusunda tasarladım. Bu yaklaşım, uygulamanın katmanlarını mantıklı bir şekilde düzenlerken, dışarıdan gelebilecek etkilere karşı da koruma sağlar. Temelde iç içe geçmiş katmanlardan oluşan bir yapı oluşturarak, bağımlılıkların yönetimini kolaylaştırır ve sürdürülebilir bir kod tabanı oluşturur.

SignalR ile Bilgi İletimi;
  SignalR, gerçek zamanlı iletişim sağlamak için kullandığınız bir kütüphanedir. Bu projede SignalR'i kullanarak kullanıcılara gerçek zamanlı bilgi akışı sağladım. Örneğin, bir kullanıcı yeni bir sipariş tamamlandığında, moderatörler hemen bu güncellemeleri alır. Bu, kullanıcı deneyimini canlandırır ve etkileşimi artırır.

Log Sistemi ile İşlem Kayıtları;
  Projede log sistemi kullanarak, yapılan işlemler hakkında detaylı kayıtlar tutuyorum. Bu kayıtlar, sistemin performansını, hataları ve işlem geçmişini izlememe yardımcı olur. Loglar aynı zamanda sorun giderme ve analiz süreçlerinde de son derece faydalıdır.

CQRS Pattern ile İstek İşlemleri;
  CQRS (Command Query Responsibility Segregation) deseni sayesinde, okuma ve yazma işlemlerini ayrı ayrı ele alabiliyorum. Bu yaklaşım, uygulamanın daha ölçeklenebilir ve optimize edilebilir olmasını sağladı.

Role ile Yetki Sistemi;
  Projede rol tabanlı yetki sistemi kullanarak, farklı kullanıcı gruplarına farklı yetkiler atayabiliyorum. Bu sayede, kullanıcılar sadece kendi yetkilerine uygun işlemleri gerçekleştirebiliyorlar. Bu, güvenliği artırdı ve veri gizliliğini kordu. Adminler, moderatörler ve kullanıcılar gibi farklı roller farklı yetkilere sahip olabilir. Ayrıca istediğiniz yeni farklı özellikteki rolleri oluşturabililrsiniz.



<img src="https://github.com/Yoakest/SafakTicaretApi/blob/main/Promo-images/st-1.png" width="45%"></img>

Projenin Temel Özellikleri:

1. Üyelik ve Güvenlik:
Kullanıcılar, güvenli bir şekilde üye olabilir ve giriş yapabilirler. Şifrelerini unuttuklarında ise "Şifremi Unuttum" özelliği ile yeni bir şifre alabilirler.

<img src="https://github.com/Yoakest/SafakTicaretApi/blob/main/Promo-images/st-2.png" width="45%"></img>
<img src="https://github.com/Yoakest/SafakTicaretApi/blob/main/Promo-images/st-10.png" width="45%"></img>

3. Alışveriş Sepeti:
Kullanıcılar, istedikleri ürünleri kolayca sepetlerine ekleyebilir, düzenleyebilir ve alışverişlerini sorunsuz bir şekilde tamamlayabilirler.

<img src="https://github.com/Yoakest/SafakTicaretApi/blob/main/Promo-images/st-13.png" width="45%"></img>

5. Moderatör Yetenekleri:
Moderatörler, yeni ürünleri sisteme ekleyebilir ve ürünlere görseller ekleyebilirler. Aynı zamanda, kullanıcıların gerçekleştirdiği siparişleri takip edebilir ve siparişleri tamamlayabilirler. Ürün stoklarını QR kodlar aracılığıyla güncelleyebilmeleri de büyük bir kolaylık sağlıyor.

<img src="https://github.com/Yoakest/SafakTicaretApi/blob/main/Promo-images/st-4.png" width="45%"></img>
<img src="https://github.com/Yoakest/SafakTicaretApi/blob/main/Promo-images/st-6.png" width="45%"></img>
<img src="https://github.com/Yoakest/SafakTicaretApi/blob/main/Promo-images/st-5.png" width="45%"></img>
<img src="https://github.com/Yoakest/SafakTicaretApi/blob/main/Promo-images/st-3.png" width="45%"></img>
<img src="https://github.com/Yoakest/SafakTicaretApi/blob/main/Promo-images/st-11.png" width="45%"></img>


6. Admin Kontrolü:
Adminler, farklı roller oluşturabilir ve bu rolleri kullanıcı profillerine atayabilirler. Bu sayede sistemdeki kullanıcıların yetkilendirilmesi ve yönetimi daha esnek hale getirilir.

<img src="https://github.com/Yoakest/SafakTicaretApi/blob/main/Promo-images/st-9.png" width="45%"></img>
<img src="https://github.com/Yoakest/SafakTicaretApi/blob/main/Promo-images/st-8.png" width="45%"></img>
<img src="https://github.com/Yoakest/SafakTicaretApi/blob/main/Promo-images/st-7.png" width="45%"></img>


Teknolojik Altyapı:
Projeyi, backend tarafında ASP.NET ve C# programlama dili kullanarak geliştirdim. Veritabanı olarak MSSQL tercih ettim, veritabanı AWS RDS ücretsiz olarak kullanıyorum. Frontend tarafında ise Angular ve TypeScript teknolojileri ile arayüz oluşturdum.

Projem, hem kullanıcıların hem de yöneticilerin ihtiyaçlarını karşılayan kapsamlı bir çözüm sunmayı hedeflediği için benim için büyük bir gurur kaynağı. Kullanıcı dostu arayüzü, güvenlik önlemleri ve yönetici yetenekleri ile alışveriş deneyimini daha kolay ve keyifli hale getirmeyi amaçlayan bu projem, e-ticaret sektöründe önemli bir boşluğu doldurmayı hedefliyor.

Eğer projem hakkında daha fazla bilgi edinmek veya bir görüşme ayarlamak isterseniz, lütfen benimle iletişime geçmekten çekinmeyin.

Saygılarımla,
Şafak Tomrukcu
safaktomrukcu@gmail.com
