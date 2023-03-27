using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebRazorPagesApp.Pages.Models;

namespace WebRazorPagesApp.Pages
{
  public class ProductListModel : PageModel
  {

    // public keyword sahip olan PageModel propertyler arayüzden direct olarak property isimine göre eriþilebilir.
    public List<ProductViewModel> Products = new List<ProductViewModel>();
    public int counter { get; set; } = 5;


    public void OnGet()
    {
      // sayfa ilk yüklendiðinde veri tabanýndan verileri oku iþlemi yaptýk
      this.Products = ProductService.GetProducts();
    }


    // Razor'a özgü bir durum bunu yapýnca formdaki post iþlemleri sonucunda BindProperty olarak tanýmlanmýþ nesne formdan gönderilir.
    // Post iþlemlerinde BindProperty kullanýyoruz
    [BindProperty] 
    // unutursak bu deðer formdan null olarak gider.
    public ProductCreateInputModel ProductCreateInputModel { get; set; }
    public void OnPost()
    {
      // bana formdan gönderilen veriyi burada yakalýyoruz.

      // veri tabanýna kaydet.

      // forma gönderilen deðerler eðer validasyon doðrulamadan geçti.
      if(ModelState.IsValid)
      {
        this.Products = ProductService.GetProducts();

        this.Products.Add(new ProductViewModel { Name = ProductCreateInputModel.Name, Price = ProductCreateInputModel.Price, Stock = ProductCreateInputModel.Stock });

        // formu temizlemek için
        // form ile çalýþýrken formda bir hata var mý form valid mi formdaki state deðerlerini silmek, deðiþtirmek, okumak vs gibi durumlar için kullanýlýr.
       
        // reset
        this.ProductCreateInputModel = new ProductCreateInputModel();
      }


     
    }
  }
}
