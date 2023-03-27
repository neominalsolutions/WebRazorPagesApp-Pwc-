using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebRazorPagesApp.Pages
{
  public class IndexModel : PageModel
  {
    // uygulama logicleri, db bağlantıları, formdan gönderilen veriler vs burada tanımlanır ve arayüze burdan bir model olarak aktarılır.
    // her bir sayfa ya ait bir class dosyası oluşur. 


    private readonly ILogger<IndexModel> _logger;

    // class ayağa kalkarken hangi gereksinimlere, servislere ihtiyaç duyuyorsa constructor üzerinden göndeririz.
    public IndexModel(ILogger<IndexModel> logger)
    {
      _logger = logger;
    }

    // sayfanın ilk load olurken çalışan method onGet onLoad (Sayfa ilk HttpGet) isteği aldığında
    public void OnGet()
    {
      // sayfa açılışında arayüzde göstereceğimiz değerleri verileri burada oluştururuz.
      // veri tabanı bağlantı sorgu veri çekme yeri burası

    }

    public void OnPost()
    {
      // formdan gönderilen istekleri yakalamamız için kullanılan bir teknik. OnGet sayfa açılışı için OnPost ise Formdan veri göndermek için kullanılır.
    }
  }
}