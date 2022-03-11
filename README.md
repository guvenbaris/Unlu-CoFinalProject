
# Unlu&Co Ve Patika.dev Final Projesi

## Ürün Katalog Projesi
Bu proje temel olarak üç ana projenin birleşmesinden oluşmaktadır. 
Bunlar;
* WebAPI
* BlazorUI 
* Consumer

## İçindekiler 
  * [1.Domain](#domain)
  * [2.Application](#application)
  * [3.Infrastructure](#infrastructure)
  * [4.Persistence](#persistence)
  * [5.WebAPI](#webapi)
  * [6.BlazorUI](#blazorui)
  * [7.Consumer](#consumer)
  * [8.Tests](#tests)
    * [8.1.Unit Test](#unittest)
    * [8.2.Entegrasyon Test](#entegrasyontest)
  * [9.Proje Çalıştırılması](#proje-run)
  

Bu projede [Onion Architecture](https://www.gencayyildiz.com/blog/nedir-bu-onion-architecture-tam-teferruatli-inceleyelim/) 
katmanlı mimarisi kullanıldı. Bu mimari temel olarak dört kısımdan oluşmaktadır.
Projenin klasör yapılanması aşağıdaki gibidir. 

![Folder Structure](https://raw.githubusercontent.com/guvenbaris/NetCorePatikasi/guvenbaris/NetCorePatikasi/folder.jpg)

## Domain

Uygulamamızın database tablolarına karşılık gelen classları oluşturduğumuz katmandır.
Entity framework code-first yaklaşımı kullanılmıştır. Class'ları yani Entity'leri 
oluşturup daha sonra database kısmına aktarılmıştır. 

**Domain Class Library**

![domain](https://raw.githubusercontent.com/guvenbaris/NetCorePatikasi/guvenbaris/NetCorePatikasi/Domain.jpg)

## Application
Bu katman da soyutlama işlemleri yapılmaktadır. Uygulamanın geneline hitap edecek tüm nesneler 
bu katmanda tanımlanır. WebAPI'ye gelen istekler bu katmanda karşılanır ve database işlemlerinin
yapılması için bir sonra ki katmana gönderilir.

**Application Class Library**

![application](https://raw.githubusercontent.com/guvenbaris/NetCorePatikasi/guvenbaris/NetCorePatikasi/Application.jpg)

*Interfaces*  : Soyutlama işlemlerini yaptığımız kısımdır.  
*Services*   : WebAPI den gelen requestlere karşılık verdiğimiz kısımdır. İş kuralları da denilmektedir.
*ViewModels* : Entitylerimizi kullanıcıya gereksiz kısımları göstermemek için oluşturduğumuz ara nesnelerdir.  
*DependencyContainers* : Application katmanının bağımlılık çözümleyici kısmıdır. WebAPI ye eklenmesi gerekir.

## Infrastructure
Database'e erişimi olan tek katmandır. Database erişim bu katman üzerinden sağlanır. 
Application katmanında tanımladığımız soyut kavramlar(Interfaces) bu katman da 
karşılıklarını oluştururuz. 

![infrastructure](https://raw.githubusercontent.com/guvenbaris/NetCorePatikasi/guvenbaris/NetCorePatikasi/Insrastructure.jpg)

*Contexts* : Database de ki tablolarımız ile Entity'lerimiz arasında ki ilişkiyi ve hangi 
database kullanılacağını belirtiyoruz. Entity Framework package kullanılmıştır.  
*DependencyContainers* : Infrastructure katmanının bağımlılık çözümleyici kısmıdır. WebAPI ye eklenmesi gerekir.  
*Migrations* : Entity Framework code-first yaklaşımı uygulandığından, Entity Framework'ün entitylerimize 
göre oluşturduğu database tablolarını oluşturması için konfigürasyon nesnelerinin olduğu kısımdır.  
*Repositories* : Application k(atmanın da ki Interfaces'ların karşılıklarının olduğu kısımdır. 
*UnitOfWorks* : [Unit Of Work](https://www.c-sharpcorner.com/UploadFile/b1df45/unit-of-work-in-repository-pattern/#:~:text=Unit%20of%20Work%20is%20the,update%2Fdelete%20and%20so%20on.) design pattern, Repository nesnelerini tek bir yerden 
yönetilebilmesini sağlamak amacıyla kullanılmıştır.

## Persistence
Sisteme eklenecek dış/external yapılanmalar bu katmanda dahil edilir. 

![persistence](https://raw.githubusercontent.com/guvenbaris/NetCorePatikasi/guvenbaris/NetCorePatikasi/Persistence.jpg)

*DependencyContainers* : Infrastructure katmanının bağımlılık çözümleyici kısmıdır. WebAPI ye eklenmesi gerekir.  
*Services* Dışa bağımlılık kuracağımız service'ler burada tanımlanır. 
RabbitMQ kuyruk yapısı ve mail servisleri tanımlanmıştır.

## WebAPI
Uygulamamıza gelen kullanıcının isteklerini karşıladığımız ve bunlara gerekli cevabı 
döndüğümüz arayüzdür. WebAPI sunum katmanının içerisinde yer alır. WebAPI'yi istenilen başka her
hangi bir uygulamaya da servis edebiliriz.

![WebApi](https://raw.githubusercontent.com/guvenbaris/NetCorePatikasi/guvenbaris/NetCorePatikasi/WebAPI.jpg)

*Controller*  : Yapılan isteğin türüne göre HTTP verblerinden(Get,Put,Delete,Post) uygun olan fonksiyonun içeriği çalışacaktır. 
Çalışan bu kısım istekte bulunan clienta(isteği atan) response döndürecektir.  
*Middlewares* : Custom Excepstion Middleware yazılmıştır. Request gelip response dönene kadar 
herhangi bir hata olması durumunda hata loglanacak ve de kullanıcı kısmına daha okunabilir hata yansıtmamızı sağlayacaktır.

## BlazorUI
Kullanıcı ya görsel olarak sunum yaptığımız katmandır. Kullanıcının görsel arayüz deki hareketlerini
WebAPI ye aktararak yapılması gereken işlemin yapılmasını sağlamaktır.

![BlazorUI](https://raw.githubusercontent.com/guvenbaris/NetCorePatikasi/guvenbaris/NetCorePatikasi/BlazorUI.jpg)

*Components* : Sayfalarda kullanmak istenilen parçalar olarak tanımlanabilir. Tanımlanan
component birden fazla sayfa da kullanılabilir. Bu da kod tekrarını önlememizi ve SPA(Single Page Application)
yapabilmemizi sağlamaktadır.

## Consumer
Console uygulamasıdır. RabbitMQ service'nin kuyruğa eklediği emailleri okuyup gönderilmesi 
gereken mail adresine gönderme işlemini yapmaktadır.

## Tests 
Temel de iki test projemiz bulunmaktadır.Bunlar;

* Unit Test
* Entegrasyon Test

<h3 id="unittest">Unit Test </h3>

Unit Test, bir sistemde mantıksal olarak izole edilebilecek en küçük kod parçası olan bir birimi test etmenin bir yoludur.
CategoryService ve de CategoryRepository class'larının methodlarına  Unit Test yazılmıştır.

![UnitTest](https://raw.githubusercontent.com/guvenbaris/NetCorePatikasi/guvenbaris/NetCorePatikasi/UnitTest.jpg)

*CategoryTest*   : CategoryService ve CategoryRepository 'nin
methodlarına yazdığımız test classlarıdır.  
*DateGenerator*  : Database olarak InMemory database kullanmak için gerekli ayarlamalar ve de test methodlarında 
kullanmamız için gerekli veri deposu tanımlanmıştır.

<h3 id="entegrasyontest">Entegrasyon Test </h3>

Yazılım geliştirme uzmanlarının birim test sırasında ayrı ayrı test ettikleri bileşenler 
birbirine entegre edildikleri zaman hataya sebep olabilirler.
Entegrasyon testi, sistemin bu farklı bileşenlerinin(birimlerinin) 
birlikte doğru çalışıp çalışmadıklarını test etmeyi amaçlar.

![EntegrasyonTest](https://raw.githubusercontent.com/guvenbaris/NetCorePatikasi/guvenbaris/NetCorePatikasi/entegrasyon.jpg)

*CategoryController* : WebAPI CategoryController'ın methodlarının(Get,Post,Put,Delete) testleri yazılmıştır. Request isteği 
gönderildiğin de API dönmesi gereken response 'un kotrolü yapılıyor.

*Common*  : WebAPI konfigürasyonları yapulmıştır. 


<h1 id ="proje-run">Proje Çalıştırılması</h1>

Projeyi çalıştırmak için Multiple Startup'ı seçmemiz gerekiyor Solution Properties'lerinden.
Burada WebAPI,Consumer,BlazorUI sırası ile start verilmelidir.

Projeye start verilmelidir. Kullanıcı arayüzünde işlemler yapabilmesi için kullanıcının login
olması gerekmektedir. Register olunabilir daha sonra tekrardan login olması gerekir. 
Sol tarafta ki Navigation sayesinde sayfalar arasında gezinilebilir.

**Navigation Menuler**

**Ana Sayfa** 

Ürünlerin listelenmesi ürünlerin kategorilere göre filtrelenmesi özellikleri bulunmaktadır.

**Hesap Detayı** 

Kullanıcı girişinden sonra sayfa aktif olur. Kullanıcı daha önce yaptığı teklifleri 
güncelleyebilir ya da geri çekebilir. Kullanıcının sahip olduğu ürünlere gelen teklifleri 
görebilir. Bu ürünlere gelen teklifleri onaylayabilir ya da reddedebilir.

**Ürünlerim** 

Kullanıcını ürünlerinin listelendiği ve de ürün durumunu güncelleyebildiği sayfadır.

**Satın Al**

Kullanıcının ürün satın alabildiği veya teklif verebildiği sayfadır.
