# Memnuniyet Anketi Projesi README

Bu MVC projesi, bir çalışan  memnuniyet anketi uygulamasını yönetmek için kullanılan temel CRUD operasyonlarını içerir.
Bu MVC projesi, kişilerin ve anket sorularının yönetimini sağlayan bir memnuniyet anketi uygulamasını içerir. 
Proje, CRUD operasyonları kullanarak kişileri eklemenizi, güncellemenizi, silmenizi ve anket sorularını yönetmenizi sağlar.

## Proje Yapısı

- **Controllers:** MVC'nin Controller sınıflarını içerir. Örneğin, `PersonController` ve `SurveyController` gibi.
- **Models:** MVC'nin Model sınıflarını içerir. `Person` ve `Survey` gibi modeller burada yer alır.
- **Views:** MVC'nin View dosyalarını içerir. HTML ve Razor kodları içerir ve kullanıcı arayüzünü temsil eder.

## Veritabanı

Projede, kişiler, sorular ve cevaplar için veritabanı tabloları bulunmaktadır. Bu tablolar, Entity Framework kullanılarak oluşturulmuştur.

## CRUD Operasyonları

### Kişi (Person) İşlemleri

- **Kişi Listesi Görüntüleme:**
  - URL: `/Person/Index`
  - Tüm kişilerin listesini görüntüler.

- **Kişi Ekleme:**
  - URL: `/Person/Create`
  - Yeni bir kişi ekler.

- **Kişi Güncelleme:**
  - URL: `/Person/Edit/{id}`
  - Belirli bir kişinin bilgilerini günceller.

- **Kişi Silme:**
  - URL: `/Person/Delete/{id}`
  - Belirli bir kişiyi siler.


## Proje Başlatma

1. Projeyi bilgisayarınıza indirin.
2. Visual Studio veya başka bir geliştirme ortamında projeyi açın.
3. Projeyi derleyin ve çalıştırın.
4. Tarayıcınızda `https://localhost:5001` adresine giderek uygulamayı kullanmaya başlayın.

## Notlar

- Proje, Entity Framework kullanarak bir SQL veritabanını kullanır. Veritabanı bağlantı ayarlarını `appsettings.json` dosyasından kontrol edebilirsiniz.
- Bu README dosyası, projenin temel özelliklerini anlatmak içindir. Daha fazla detay ve geliştirmeler projenin gereksinimlerine göre eklenmelidir.
- Geliştirme sürecinde herhangi bir sorunla karşılaşırsanız, [GitHub Issues](https://github.com/KullaniciAdi/ProjeAdi/issues) bölümünden yardım isteyebilirsiniz.
- C:\Users\busranur.tosun\Downloads\WhatsApp Video 2024-01-08 at 09.26.38.mp4
- 
