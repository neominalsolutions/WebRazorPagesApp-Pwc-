using DataAnnotationsExtensions;
using System.ComponentModel.DataAnnotations;

namespace WebRazorPagesApp.Pages.Models
{
  // Formdan gönderilecek değerler için ise input model kullanırız. apida dto ismini vericez.
  // ürün olurturmak için kullanılan input model

  // Data Annotations (Input olan değerlerde validayon yönetimi)
  public class ProductCreateInputModel
  {
    [Required(ErrorMessage = "Name alanı boş geçilemez")]
    public string Name { get; set; }

    [Min(10, ErrorMessage = "Fiyat 10 TL den düşük girilemez")]
    public decimal Price { get; set; }

    [Max(20, ErrorMessage ="En falza 20 adet stok girilebilir")]
    public int Stock { get; set; }


  }
}
