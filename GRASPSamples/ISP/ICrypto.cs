using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRASPSamples.ISP
{
  // Interface Seggragation yaptık
  public interface IEncrypt
  {
    string Encrypt(string text, string salt);
  }

  public interface IDecrypt
  {
    string Decrypt(string text);
  }

  public interface ICrypto:IEncrypt,IDecrypt
  {
    //string Encrypt(string text, string salt);
    //string Decrypt(string text);
  }
}
