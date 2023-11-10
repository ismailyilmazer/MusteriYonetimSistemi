# MusteriYonetimSistemi

.Net 7 Web API ile müşteri yönetim sistemi oluşturulmuştur.
JWT (JSON Web Token) kullanılarak kimlik doğrulama ve yetkilendirme mekanizmasını uygulanmıştır.
Kimliği doğrulanan ve yetkisi olan  kullanıcılar müşterileri listeleyip görebilir.
Bütün kullanıcılar kayıt işlemini gerçekleştirebilir.

Model Katmanında Entityler , Data Acces katmanında ise veritabanı ile bağlantı kurulmuştur.
Otorizasyon AuthController ile sağlanmıştır. Kullanıcı adınızı ve passwordünüzü girdiğinizde size cevap olarak
bir token gönderilir ve bu token kullanılarak veritabanına kayıtlı olan bütün müşteriler listelenebilir. Ek olarak Api'yi  test etmek için Postman kullanılmıştır.
