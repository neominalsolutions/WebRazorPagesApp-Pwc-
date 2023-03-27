var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(); // Razor Pages uygulamas� oldu�u i�in RazorPages service eklenmi�.

var app = builder.Build(); // uygulama build edilmi�

// WebApplicationBuilder service var uygulamas� bu service aya�a kald�r�r. 
// bus service i�erisine proje tipine g�re farkl� hizmetler eklenebilir.

// Use ile g�rd���m�z her�ey ara yaz�l�m middleware uygulama �zellikleri middleware vas�tas� ile kazand�r�yoruz.

// Configure the HTTP request pipeline.
// app.Environment test ortam� m� development ortam�m� production ortam� oldu�u yakalamam�z� sa�lar.
if (!app.Environment.IsDevelopment()) // canl� ortam i�in
{
  app.UseExceptionHandler("/Error"); // hatalar error sayfas�na y�nlendirilmi�
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts(); // header �zerinden veri ta��may� daha g�venli hale getirmek i�in HsTs protokol kullan�ls�n.
}


// her bir request bazl� s�re� tekrar tekrar i�liyor.
// uygulma https ayar� ile gelen http isteklerini https y�nlendirmi�
app.UseHttpsRedirection();
// uygulamadaki static dosyalar� g�venli bir �ekilde uygulama dizine ta��m��.
// www root dosyas� public bir dosya bu dosya sadece deploy ediliyor. uygulama publish edilirken t�m dll'ler wwwroot dosyas� alt�nda �al��abilir bir ��kt� haline d�n���yor.
app.UseStaticFiles();

// uygulamadaki sayfalar aras�ndaki route ge�i�ini sa�lamak ama�l� kullan�lan bir middleware
// home => pages/home.chtml y�nlendir tarz� klas�r bazl� bir y�nlendirme sistemi mevcut bu sistem ile sayflara aras�nda ge�i� yap�l�yor.
app.UseRouting();

app.UseAuthentication(); // Cookie Based Authentication, JWT Authentication ile oturum a��l��lar�n� y�netme servicisini aya�a kald�r�dk.

// uygulamam�zdaki yetkiler [Authorize] attribute ile bir kayana�a eri�im yetkimiz olup olmad���n� s�rece dahil eden service. Role Based, Policy Based, Claim Based Authorization Yap�lar� var.
app.UseAuthorization();

app.MapRazorPages(); // Route ile gelen pathleri uygulmadaki pages'lere y�nlendir.

app.Run(); // uygulamay� aya�a kald�r. Not Run dan sonra yaz�lan herhangi bir middleware �al��maz. // next ile s�re� devam etmiyor.
