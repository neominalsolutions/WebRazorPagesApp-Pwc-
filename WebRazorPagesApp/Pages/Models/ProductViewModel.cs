namespace WebRazorPagesApp.Pages.Models
{
  // veri tabanından sorgulanıp arayüze yansıtışacak olan nesneler view model, api tarafında ise dto isminde kullanılacaklar.
  // modelleri yani arayüze taşınacak olan modelleri models klasörü altına yazıyoruz.
  public class ProductViewModel
  {
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }

  }

  // In Memory db görevi gördük.
  public static class ProductService
  {

    public static List<ProductViewModel> GetProducts()
    {

      var plist = new List<ProductViewModel>();
      plist.Add(new ProductViewModel { Name = "P1", Price = 10, Stock = 20 });
      plist.Add(new ProductViewModel { Name = "P2", Price = 20, Stock = 30 });
      plist.Add(new ProductViewModel { Name = "P3", Price = 15, Stock = 14 });

      return plist;

    }

  }

}
