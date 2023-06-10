
Hangfire Nedir

Hangfire, arkada asenkron olarak çalışan, yani kullanıcıyı bekletmeyen (Background job) olarak tanımladığımız işler için kullanılan bir tooldur. Mutlaka bir depolama alanına, yani DB’ye ihtiyaç duyar. Depolama alanı olarak, birçok veritabanını destekler (SQL Server, MSMQ, Redis) gibi. Genellikle Time Schedule şeklinde tekrarlayan belli zaman aralıkları ile çalışan işlerde kullanılsalar da, birçok farklı kullanım şekilleri vardır.

Hangfire Job Çeşitleri
1.	Fire & Forget: Bir kez ve anında çalışacak olan job çeşididir.
2.	Delayed: Belirtilen sürenin sonunda bir defaya mahsus çalışacak olan job çeşididir.
3.	Recurring: Recursive olarak devamlı çalışacak olan job çeşididir.
4.	Continuations: Daha önceden tanımlanmış olan job’ın (scheduled) başarılı şekilde çalışması durumunda çalışacak olan job çeşididir.

Kurulum
Nuget package’tan Hangfire ‘ı aratıp kurabilirsiniz ya da 

dotnet add package Hangfire komutu ile ekleyebilirsiniz

Kullanım
Yapacağımız iş için bir class oluşturuyoruz.

 ![Ekran görüntüsü 2023-06-10 141101](https://github.com/AbdurrahmanVarol/TurkcellGelecegeYazanlarBootcamp/assets/96303254/6cfd5f39-c965-442a-ad35-f1932842e07d)

Daha sonra program.cs içerisine AddHangfire servisini ekliyoruz.
AddHangfire servisinin konfigürasyonuna hangfire’ın kullanacağı veri tabanının  connection stringini ve 
RecurringJob class’ının AdOrUpdate metoduna generic parametre olarak oluşturduğumuz iş sınıfını ekliyoruz.

 ![Ekran görüntüsü 2023-06-10 141447](https://github.com/AbdurrahmanVarol/TurkcellGelecegeYazanlarBootcamp/assets/96303254/946ea816-dc99-48e2-87e2-dca1acc546a0)
 

Hangfire dasgborad’ına erişebilmek için UseHangfireDashboard middleware’ını eklemeliyiz

 ![Ekran görüntüsü 2023-06-10 141130](https://github.com/AbdurrahmanVarol/TurkcellGelecegeYazanlarBootcamp/assets/96303254/16b34744-a575-495d-8a04-ee193daa3496)


Programı çalıştırıp anadizin /hangfire/recurring adresine girdiğimiz zaman hangfire dashboard’unu görebilirsiniz
 
![Ekran görüntüsü 2023-06-10 140428](https://github.com/AbdurrahmanVarol/TurkcellGelecegeYazanlarBootcamp/assets/96303254/0dd5feff-e57c-400c-b762-5e145da42d41)

