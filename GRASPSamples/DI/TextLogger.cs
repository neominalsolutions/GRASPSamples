using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRASPSamples.DI
{
  public class TextLogger: ILogger
  {
    public void Log()
    {
      Console.WriteLine("Text Logger");
    }
  }
}
