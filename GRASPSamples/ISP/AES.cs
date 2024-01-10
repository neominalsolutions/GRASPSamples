using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRASPSamples.ISP
{
  // Simetrik Şifreleme Algoritması, Vektor, Key
  public class AES : ICrypto
  {
    public string Decrypt(string text)
    {
      return "merhaba";
    }

    public string Encrypt(string text,string salt)
    {
      return "srwxzcxzc-.dsfdsf34";
    }
  }
}
