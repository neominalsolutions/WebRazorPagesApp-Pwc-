var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(); // Razor Pages uygulamasý olduðu için RazorPages service eklenmiþ.

var app = builder.Build(); // uygulama build edilmiþ

// WebApplicationBuilder service var uygulamasý bu service ayaða kaldýrýr. 
// bus service içerisine proje tipine göre farklý hizmetler eklenebilir.

// Use ile gördüðümðz herþey ara yazýlým middleware uygulama özellikleri middleware vasýtasý ile kazandýrýyoruz.

// Configure the HTTP request pipeline.
// app.Environment test ortamý mý development ortamýmý production ortamý olduðu yakalamamýzý saðlar.
if (!app.Environment.IsDevelopment()) // canlý ortam için
{
  app.UseExceptionHandler("/Error"); // hatalar error sayfasýna yönlendirilmiþ
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts(); // header üzerinden veri taþýmayý daha güvenli hale getirmek için HsTs protokol kullanýlsýn.
}


// her bir request bazlý süreç tekrar tekrar iþliyor.
// uygulma https ayarý ile gelen http isteklerini https yönlendirmiþ
app.UseHttpsRedirection();
// uygulamadaki static dosyalarý güvenli bir þekilde uygulama dizine taþýmýþ.
// www root dosyasý public bir dosya bu dosya sadece deploy ediliyor. uygulama publish edilirken tüm dll'ler wwwroot dosyasý altýnda çalýþabilir bir çýktý haline dönüþüyor.
app.UseStaticFiles();

// uygulamadaki sayfalar arasýndaki route geçiþini saðlamak amaþlý kullanýlan bir middleware
// home => pages/home.chtml yönlendir tarzý klasör bazlý bir yönlendirme sistemi mevcut bu sistem ile sayflara arasýnda geçiþ yapýlýyor.
app.UseRouting();

app.UseAuthentication(); // Cookie Based Authentication, JWT Authentication ile oturum açýlýþlarýný yönetme servicisini ayaða kaldýrýdk.

// uygulamamýzdaki yetkiler [Authorize] attribute ile bir kayanaða eriþim yetkimiz olup olmadýðýný sürece dahil eden service. Role Based, Policy Based, Claim Based Authorization Yapýlarý var.
app.UseAuthorization();

app.MapRazorPages(); // Route ile gelen pathleri uygulmadaki pages'lere yönlendir.

app.Run(); // uygulamayý ayaða kaldýr. Not Run dan sonra yazýlan herhangi bir middleware çalýþmaz. // next ile süreç devam etmiyor.
