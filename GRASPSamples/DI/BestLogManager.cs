using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRASPSamples.DI
{
  public class BestLogManager
  {
    // DIP (Dependency Inversion Principle, Bağımlılıkların tersine çevrilmesi prensibi)
    private ILogger logger; 
    private IReadOnlyList<ILogger> loggers;

    public BestLogManager(ILogger logger)
    {
      this.logger = logger;

    }

    public BestLogManager(IReadOnlyList<ILogger> loggers)
    {
      this.loggers = loggers;
    }

    public void Log()
    {
    

      if(this.loggers != null)
      {
        loggers.ToList().ForEach(logger =>
        {
          logger.Log();
        });
      }
      else
      {
        this.logger.Log();
      }
    }

    
  }
}
