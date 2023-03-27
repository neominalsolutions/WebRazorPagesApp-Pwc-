using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebRazorPagesApp.Pages.Models;

namespace WebRazorPagesApp.Pages
{
  public class ProductListModel : PageModel
  {

    // public keyword sahip olan PageModel propertyler aray�zden direct olarak property isimine g�re eri�ilebilir.
    public List<ProductViewModel> Products = new List<ProductViewModel>();
    public int counter { get; set; } = 5;


    public void OnGet()
    {
      // sayfa ilk y�klendi�inde veri taban�ndan verileri oku i�lemi yapt�k
      this.Products = ProductService.GetProducts();
    }


    // Razor'a �zg� bir durum bunu yap�nca formdaki post i�lemleri sonucunda BindProperty olarak tan�mlanm�� nesne formdan g�nderilir.
    // Post i�lemlerinde BindProperty kullan�yoruz
    [BindProperty] 
    // unutursak bu de�er formdan null olarak gider.
    public ProductCreateInputModel ProductCreateInputModel { get; set; }
    public void OnPost()
    {
      // bana formdan g�nderilen veriyi burada yakal�yoruz.

      // veri taban�na kaydet.

      // forma g�nderilen de�erler e�er validasyon do�rulamadan ge�ti.
      if(ModelState.IsValid)
      {
        this.Products = ProductService.GetProducts();

        this.Products.Add(new ProductViewModel { Name = ProductCreateInputModel.Name, Price = ProductCreateInputModel.Price, Stock = ProductCreateInputModel.Stock });

        // formu temizlemek i�in
        // form ile �al���rken formda bir hata var m� form valid mi formdaki state de�erlerini silmek, de�i�tirmek, okumak vs gibi durumlar i�in kullan�l�r.
       
        // reset
        this.ProductCreateInputModel = new ProductCreateInputModel();
      }


     
    }
  }
}
