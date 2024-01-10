using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRASPSamples.DI
{
  public class LogManager
  {
    //TextLogger textLogger = new TextLogger();
    //DbLogger dbLogger = new DbLogger();
    TextLogger textLogger;
    DbLogger dbLogger;

    public LogManager()
    {
      
    }
   
    /// <summary>
    /// Constructor Injection
    /// </summary>
    /// <param name="textLogger"></param>
    public LogManager(TextLogger textLogger)
    {
      this.textLogger = textLogger;
    }

    public LogManager(DbLogger dbLogger)
    {
      this.dbLogger = dbLogger;
    }

    public LogManager(TextLogger textLogger, DbLogger dbLogger)
    {
      this.textLogger = textLogger;
      this.dbLogger = dbLogger;
    }

    public void LogText()
    {
      this.textLogger.Log();
    }

    public void LogDb()
    {
      this.dbLogger.Log();
    }

    // Log bağımlılığı method paramteresi oalrak gönderildi. Method Injection
    public void TextLog(TextLogger textLogger)
    {
      textLogger.Log();
     
    }

    public void DbLog(DbLogger dbLogger)
    {
      dbLogger.Log();
    }

    public void TextAndDbLog()
    {
      // Log CorrelationID => Veri tutarlılık ID, GUID, Aggregate
      this.textLogger.Log();
      this.dbLogger.Log();
    }

  

  }
}
