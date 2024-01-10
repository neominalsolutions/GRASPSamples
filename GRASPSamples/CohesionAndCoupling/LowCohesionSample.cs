using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRASPSamples.Cohesion
{
  public class Cart // sepet sınıfı
  {
    public List<CartLine> Lines { get; set; } = new List<CartLine>();
    public decimal Total { get
      {
        return Lines.Sum(x => x.ListPrice * x.Quantity);
      } 
    }

  }

  public class CartLine
  {
    public decimal ListPrice { get; set; } // 50.5
    public decimal Quantity { get; set; } // 3

    public string? ProductName { get; set; }

  }

  public class OrderInformation
  {
    public string CustomerName { get; set; }
    public string Address { get; set; }

    public string PromationCode { get; set; }

  }

  /// <summary>
  /// Sipariş alma isteği geldi
  /// promosyon kodu varsa indirim yap
  /// sipariş sonraksı sipariş veren müşteriye mail at
  /// Sipariş sonrası fatura oluştur.
  /// </summary>
  public class LowCohesionSample
  {
    // Sipariş alma sorumluluğu dışında bu sınıfın, promosyon koda göre indirim sorumluluğu, mail atma sorumluluğu, fatura oluşturma sorumluluğu gibi ek sorumlulukları var. Low Cohesion (Düşük Uyumluluk) => Refactor maaliyeti çıkar.

    public void SubmitOrder(Cart cart, OrderInformation orderInformation)
    {
      // Sepet bilgilerini okuyup, order nesnesine dönüştürüp veri tabanına kayıt
      // promosyon kodundan indirim algoritması
      // kargo sürecini başlatması
      // kullanıcıya sipariş numarası ile mail atması
      // fatura oluşturması
      ApplyPromationCode(orderInformation.PromationCode);
      TransformAsOrder(cart);
      SendOrderSubmittedEmail(orderInformation.CustomerName);
      GenerateBill(orderInformation.CustomerName);
      ClearBasket(cart);

    }

    private void TransformAsOrder(Cart cart)
    {
      Console.WriteLine($"Sepet bilgileri siparişe dönüştürüldü. Veri tabanına kayıt at");
    }

    private void ClearBasket(Cart cart)
    {
      Console.WriteLine($"Sepet Session bilgileri tamizlendi");
    }

    private void ApplyPromationCode(string promationCode)
    {
      Console.WriteLine($"{promationCode} üzerinden indirim yapıld");
    }

    private void GenerateBill(string customerName)
    {
      Console.WriteLine($"{customerName} için fatura oluştu");
    }

    private void SendOrderSubmittedEmail(string customerName)
    {
      Console.WriteLine($"{customerName} için mail atıldı");
    }

  }
}
