# BankAutomation - Mini bir bankacılık operasyonu 
#### *Projede kullanılan teknoloji ve kütüphaneler*
- JWT Authentication
- RabbitMQ
- MsSql
- HMACSHA512 şifreleme algoritması 
- AutoMapper
- CQRS
- MediatR
- Generic Repository pattern
- UnitOfWork pattern

### Postman Api dökümantasyonuna burdan ulaşabilirsiniz. [Tıklayınız](https://documenter.getpostman.com/view/15763755/2s8ZDU4Nzn) 

### Üye 
- Kullanıcı ilgili bilgileri doldurup kayıt olabiliyor.
- Kullanıcı Email ve Pasword ile sisteme giriş yapabiliyor.
- Kullanıcı silme ve Güncelleme işlemleri yapılabilir.
- Kullanıcıların Rol bazlı yetkilerine göre işlemler.
- Tüm Kullanıcı listeleme ve Id bazlı listeleme.

### Role
- Admin ve User olmak üzere iki rolumüz var.
- Admin kullanıcıların bakiyelerine block koyabilir.
- Admin kullanıcıların paralarını güncelleyebilir.
- Admin siteye başka adminler ekleyebilir.
- Admin yapılmış olan transfer işlemlerini listeleyebilir.
- User hesap oluşturabilir ve hesaplarını listeleyebilir.
- User başka bir kullanıcıya para gönderebilir.
- User kendi hesapları arasında para transfer işlemi yapabilir.


### Hesap
- Bir kullanıcı bir veya birden fazla Hesap oluşturabilir.
- Kullanıcı hesapları arasında para transfer işlemi yapabilir.
- Tüm hesapları listeleme ve Id bazlı listelem.

### İşlemler 
- Kullanıcalar girdikleri hesap numaralarına istedikleri kadar para aktarabiliyor. 
- Gönderilen hesaptan para eksiliyor alıcı hesapta gelen bakiye kadar güncelleniyor.
- Para gönderme işleminden sonra RabbitMq kuyruk sitemine bir event fırlatılıp para gönderen kişiye bilgilendime mail gidiyor.
- Admin olan kullanıcı Hesapları silme ve güncelleyebilir.
- Tüm işlemler listeleme ve Id bazlı listeleme.
- Gönderen kulanıcı veya alıcı kulanıcı ID si ile tüm islemler listelenebilir.
- Gönderen hesap veya alıcı hesap ID si ile tüm işlemler listelebilir.

## Projenin Kurulumu
 - Projeyi aşagıdaki adresden biligisayarınıza klonlayabilirsiniz
 ````
 https://github.com/GuvenBoydak/BankAutomation.git
 ````
- Proje’yi Bank.API appsettings.json  içerisindeki `` "ConnectionStrings": {
    "SqlServer": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Bank;Integrated Security=True;"
  }`` baglantı adresini kendi database ayaralarınıza göre değiştirmelisiniz.
 - Proje'yi ``Bank.RabbitMQConsumer`` tarafından başlatmanız durumunda RabbitMq tarafına gönderilen eventları yakalayıp mail gönderme işlemi yapılır.
 - Bunun için Program.cs içerisindeki `` factory.Uri = new Uri("ilgili rabbitmq amps instance bilgisi"); `` ilgili rabbitmq amps instance bilgisini değiştirebilirsiniz.
 - Ayrıca MailService içerisindeki ``smtp.Credentials = new NetworkCredential("EmailAdresBilgisi",
            "ŞifreBilgisi"); `` ve `` MailMessage mail = new MailMessage("EmailAdresBilgisi", userTransactionDto.User.Email); `` kısımlarını bildirebilirsiniz.

