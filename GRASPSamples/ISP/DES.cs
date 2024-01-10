using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRASPSamples.ISP
{
  public class DES : IEncrypt,IDecrypt
  {
    public string Decrypt(string text)
    {
      throw new NotImplementedException();
    }

    public string Encrypt(string text, string salt)
    {
      throw new NotImplementedException();
    }
  }
}
