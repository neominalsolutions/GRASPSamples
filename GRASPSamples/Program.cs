using GRASPSamples.Cohesion;
using GRASPSamples.CohesionAndCoupling;
using GRASPSamples.DI;
using GRASPSamples.Factories;
using GRASPSamples.ISP;
using GRASPSamples.LSP;
using GRASPSamples.OCP;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Authentication.ExtendedProtection;

// Cohesion (Uyumluluk) => objects sorumluluklarının başka sınıflara dağıtılmaması, ve objects'e gereksiz kendi işi dışında bir sorumluluk verilmemesidir.  Kaliteli kod için Yüksek Uyumluluk (High Cohesion)

// Coupling (Bağımlılık) => sınıfların başka sınıflara olan bağlılıkların ayarlanması. Tight Coupling => Sıkı Sıkıya bağımlılık. Kaliteli kod için Loose Coupling önemli.

/*

#region Cohesion



HighCohesionSample bestOrderService = new HighCohesionSample();
bestOrderService.SubmitOrder();

#endregion


#region Coupling

Console.WriteLine("Email gönderil servisi seçiniz");
string serviceName = Console.ReadLine();
//IEmailService emailService;
IDiscountService discountService = new CouponDiscountService();
IRepository repo = new GRASPSamples.CohesionAndCoupling.OrderRepository();
IBasketService basketService = new SessionBasketService();
IBillService billService = new OrderBillService();

EmailFactory emailFactory = new EmailFactory(emailProvider: serviceName);
var emailService = emailFactory.Instance();

//if(serviceName == "Turkcell")
//{
//  emailService = new TurkcellEmailService();
//}
//else
//{
//  emailService = new VodafoneEmailService();
//}


HighCohesionAndLowCouplingSample highCohesionAndLowCouplingSample = new HighCohesionAndLowCouplingSample(emailService, discountService, repo, basketService, billService);
highCohesionAndLowCouplingSample.SubmitOrder();

#endregion


#region DI

LogManager lg = new LogManager(new TextLogger()); // Constructor Injection
lg.LogText(); // Null Referance Exception

LogManager lg2 = new LogManager();
lg2.DbLog(new DbLogger()); // Method Injection

LogManager lg3 = new LogManager(new TextLogger(), new DbLogger());
lg3.TextAndDbLog();

// Yanlış bir tip gönderme ihtimalim yok
BestLogManager logManager = new BestLogManager(new TextLogger());
logManager.Log();

var loggers = new List<ILogger>();
loggers.Add(new TextLogger());
loggers.Add(new DbLogger());

BestLogManager logManager2 = new BestLogManager(loggers);
logManager2.Log();

#endregion 

*/

#region ISP

// Salt,HashedPassword (Register olurken salt generate edilir, hashde parola üzerinden salt değeri ile tuzlanarak hashlenir.)
// User1 => p@ssword1 => user2 => p@assword1
// $2b$10$wXGSuVsd1wOb6WLJE5RIK. (User Based Salt)

// $2b$10$awIf4hKmE0nEwISkgYu5l.NaYf7keizK3Z7RR6pf.Zi0/keK3EJGO

//  $2b$10$IrDnATXaofV8PFUw57KEwu

// $2b$10$rqT/Ua91gpcWwqGs4FLtz.bcecfdK2rLJOeO9EtykwoBYugUOOoNa

Hash hash = new Hash();
hash.Encrypt("P@assword1", "$2b$10$wXGSuVsd1wOb6WLJE5RIK.");

// $2b$10$wXGSuVsd1wOb6WLJE5RIK.hEn.uivrxrnch4a2UQAhheF9Gk.P9MW
// $2b$10$wXGSuVsd1wOb6WLJE5RIK.hEn.uivrxrnch4a2UQAhheF9Gk.P9MW

// p@ssword1 =>  $2b$10$rqT/Ua91gpcWwqGs4FLtz.bcecfdK2rLJOeO9EtykwoBYugUOOoNa => Dictionary Attack

#endregion


#region OCP

BadPaymentService p = new BadPaymentService(paymentType: "Kredi Kartı");
p.Pay(500);

BestPaymentService bestPayment = new BestPaymentService(new CashPayment());
bestPayment.Pay(500);


#endregion

#region Liskov 

BestSquare sq = new BestSquare();
//sq.Width = 10;
//sq.Height = 25;
sq.Corner = 15;
sq.GetArea();

Rectangle r = new Rectangle();
r.Width = 10;
r.Height = 20;
r.GetArea();

#endregion


#region IoC

var services = new ServiceCollection(); // IoC Container servisleri register ettiğimiz yer
services.AddTransient<IEmailService, TurkcellEmailService>();
// IEmailService için bana TurkcellEmailService üret.

var provider = services.BuildServiceProvider(); // service sağlayıcıya provider diyourz. Service instancelarını providerdan okuyoruz.

// instance IoC dan okuduk.
var emailService = provider.GetRequiredService<IEmailService>(); // resolve
emailService.Send();


#endregion