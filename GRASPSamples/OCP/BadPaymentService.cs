using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRASPSamples.OCP
{
  public class BadPaymentService
  {
    private string paymentType;

    public BadPaymentService()
    {

    }
    public BadPaymentService(string paymentType)
    {
      this.paymentType = paymentType;
    }

    public void Pay(decimal amount)
    {
      if(paymentType == "Kredi Kart")
      {
        Console.WriteLine("Kredi kartı ile Ödeme yapıldı");
      }
      else if(paymentType == "Nakit" || paymentType == null)
      {
        Console.WriteLine("Nakit ile Ödeme yapıldı");
      }

      
    }
  }
}
