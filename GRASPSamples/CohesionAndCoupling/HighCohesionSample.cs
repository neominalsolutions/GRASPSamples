using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRASPSamples.Cohesion
{
 
  public class EmailService
  {
    public void Send()
    {
      Console.WriteLine("Email atıldı");
    }
  }

  public class DiscountService
  {
    public void ApplyPromationCode()
    {
      Console.WriteLine("Promosyon Kod oluştu");
    }
  }

  public class OrderRepository
  {
    public void Save()
    {
      Console.WriteLine("Sipariş kaydedildi");
    }
  }

  public class BasketService
  {
    public void Clear()
    {
      Console.WriteLine("Sepet temizlendi");
    }
  }

  public class BillService
  {
    public void Generate()
    {
      Console.WriteLine("Fatura Oluştu");
    }
  }

  // main class, main system

  public class HighCohesionSample // High Cohesion
  {
    // Facade
    // sub system
    //private EmailService emailService = new EmailService();
    //private DiscountService discountService = new DiscountService();
    //private OrderRepository orderRepo = new OrderRepository();
    //private BasketService basketService = new BasketService();
    //private BillService billService = new BillService();

    // Depedencies 5 farklı bağımlık var.
    // SRP => Single Responsibity
    private EmailService emailService;
    private DiscountService discountService;
    private OrderRepository orderRepo;
    private BasketService basketService;
    private BillService billService;

    public HighCohesionSample()
    {
      emailService = new EmailService();
      discountService = new DiscountService();
      orderRepo = new OrderRepository();
      basketService = new BasketService();
      billService = new BillService();
    }

    public void SubmitOrder()
    {
      discountService.ApplyPromationCode();
      orderRepo.Save();
      emailService.Send();
      basketService.Clear();
      billService.Generate();
    }
  }
}
