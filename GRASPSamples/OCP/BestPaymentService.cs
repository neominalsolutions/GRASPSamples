using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRASPSamples.OCP
{
  public interface IPayment
  {
    void Pay(decimal amount);
  }

  // Subject Real Class
  public class CashPayment : IPayment
  {
    public void Pay(decimal amount)
    {
      Console.WriteLine("Nakit Ödeme");
    }
  }

  // Subject Real Class
  public class CreditCartPayment : IPayment
  {
    public void Pay(decimal amount)
    {
      Console.WriteLine("Kredi Kartı ile Ödeme");
    }
  }

  // Proxy Class
  public class BestPaymentService // Proxy Nesnesi
  {
    private IPayment payment;

    public BestPaymentService(IPayment payment)
    {
      this.payment = payment;
    }

    public void Pay(decimal amount)
    {
      // Proxy üzerinden ara işlemleri yap.
      // pay öncesindeki extra kontrol.
      this.payment.Pay(amount);
    }
  }
}
