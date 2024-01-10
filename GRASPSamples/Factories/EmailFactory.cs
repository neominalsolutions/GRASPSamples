using GRASPSamples.CohesionAndCoupling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRASPSamples.Factories
{
  public class EmailTypes
  {
    public const string TurkcellProvider = "Turkcell";
    public const string VodaphoneProvider = "Vodafone";

  }

  /// <summary>
  /// Factory Method
  /// </summary>
  public class EmailFactory
  {
    string emailProvider;
    public EmailFactory(string emailProvider)
    {
      this.emailProvider = emailProvider;
    }

    public IEmailService Instance()
    {
      IEmailService emailService = null;

      switch (emailProvider)
      {
        case EmailTypes.TurkcellProvider:
          emailService = new TurkcellEmailService();
          break;
        case EmailTypes.VodaphoneProvider:
          emailService = new VodafoneEmailService();
          break;
      }

      return emailService;
    }

  }
}
