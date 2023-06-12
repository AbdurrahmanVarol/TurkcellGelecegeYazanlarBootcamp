PKCE Flow nedir

public client uygulamaları (yerel veya mobil) uygulama kullanıcılarının kimliğini doğrulamak için özel olarak tasarlanmış bir OpenId Connect akışıdır.

PKCE, Proof Key for Code Exchange'in kısaltmasıdır.

PKCE public client’ların secret key olmadan authenticate olmaları için geliştirilmiştir.


Auth0’ın yapılandırılması

Callback URL’ inin yapılandırılması

callback URL kullanıcılar authenticate olduktan sonra Auth0’ın yönlendirmesini istdiğin url dir.
Eğer düzenlemezsen, kullanıcı login olduktan sonra uygulamana yönlendirilemez.

 ![1](https://github.com/AbdurrahmanVarol/TurkcellGelecegeYazanlarBootcamp/assets/96303254/cf4799f4-3b1e-4cc9-a0fd-661f6ac1e2e9)

Logout URL’inin yapılandırılması

Logout URL kullanıcılar çıkış yaptıktan sonra Auth0’ın yönlendirmesini istdiğin url dir.
Eğer düzenlemezsen, kullanıcı çıkış yapamaz ve bir hata ile karşılaşabilirsin.

 ![2](https://github.com/AbdurrahmanVarol/TurkcellGelecegeYazanlarBootcamp/assets/96303254/3fc4c6bf-fbb7-4e58-95dc-893bc5ec5d0d)


Kurulum

Nuget package’tan Auth0.AspNetCore.Authentication’ı aratıp kurabilirsiniz 
 ![3](https://github.com/AbdurrahmanVarol/TurkcellGelecegeYazanlarBootcamp/assets/96303254/1731d876-3fb8-4d2f-8193-ab68eb520c7f)

Ya da package manager console’a Install-Package Auth0.AspNetCore.Authentication komutunu yazarak kurabilirsiniz.
Program.cs yapılandırması

Not: UseAuthentication ve UseAuthorization middleware’larının kullanıldığından emin ol.
![4](https://github.com/AbdurrahmanVarol/TurkcellGelecegeYazanlarBootcamp/assets/96303254/11733e1a-26f9-4bd0-ae84-10e0d337ee3a)
![5](https://github.com/AbdurrahmanVarol/TurkcellGelecegeYazanlarBootcamp/assets/96303254/93b37a98-981c-4286-a5ad-fbfda8145a43) 

Login işlemi

Controller’inize Login adında bir action ekleyin.
LoginAuthenticationPropertiesBuilder ile propertyleriniz ayarladıktan sonra 
HttpContext.ChallengeAsync’a ilk parametre olarak Auth0Constants.AuthenticationScheme’yı,
İkinci parametre olarak oluşturduğunuz property i veriniz

Logout işlemi

Controller’inize Logout adında bir action ekleyin.
LoginAuthenticationPropertiesBuilder ile propertyleriniz ayarladıktan sonra 
HttpContext. SignOutAsync ilk parametre olarak Auth0Constants.AuthenticationScheme’yı,
İkinci parametre olarak oluşturduğunuz property i veriniz

![6](https://github.com/AbdurrahmanVarol/TurkcellGelecegeYazanlarBootcamp/assets/96303254/dd16620c-14e0-4e2c-a339-9c7b5c2d243f)


 


