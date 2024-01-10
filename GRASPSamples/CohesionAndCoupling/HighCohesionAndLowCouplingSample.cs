using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GRASPSamples.CohesionAndCoupling
{

  // aracı her zaman interface'dir
  public interface IEmailService
  {
    void Send();
  }

  public class TurkcellEmailService: IEmailService
  {
    public void Send()
    {
      Console.WriteLine("Turkcell Email atıldı");
    }
  }

  public class VodafoneEmailService : IEmailService
  {
    public void Send()
    {
      Console.WriteLine("Vodafone Email atıldı");
    }
  }


  public interface IDiscountService
  {
    void ApplyPromationCode();
  }

  public class CouponDiscountService: IDiscountService
  {
    public void ApplyPromationCode()
    {
      Console.WriteLine("Promosyon Kod oluştu");
    }
  }

  public interface IRepository
  {
    void Save();
  }

  public class OrderRepository: IRepository
  {
    public void Save()
    {
      Console.WriteLine("Sipariş kaydedildi");
    }
  }

  public interface IBasketService
  {
    void Clear();
  }

  public class SessionBasketService: IBasketService // (SQLBasketService,RedisBasketService,MemcacheBaseketService,MongoBasketService)
  {
    public void Clear()
    {
      Console.WriteLine("Sepet temizlendi");
    }
  }

  public interface IBillService
  {
    void Generate();
  }

  public class OrderBillService: IBillService
  {
    public void Generate()
    {
      Console.WriteLine("Fatura Oluştu");
    }
  }


  public class HighCohesionAndLowCouplingSample
  {
    // kodu güncellemek istemiyorum bu kullanım yanlış bir örnek
    // private IEmailService emailService = new TurkcellEmailService();

    private IEmailService emailService;
    private IDiscountService discountService;
    private IRepository repository;
    private IBasketService basketService;
    private IBillService billService;

    public HighCohesionAndLowCouplingSample(IEmailService emailService, IDiscountService discountService, IRepository repository, IBasketService basketService, IBillService billService)
    {
      this.emailService = emailService;
      this.discountService = discountService;
      this.basketService = basketService;
      this.billService = billService;
      this.repository = repository;
    }

    public void SubmitOrder()
    {
      this.discountService.ApplyPromationCode();
      this.repository.Save();
      this.emailService.Send();
      this.billService.Generate();
      this.basketService.Clear();
     
    }
  }
}
