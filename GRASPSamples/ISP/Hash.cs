using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRASPSamples.ISP
{
  public class Hash : IEncrypt
  {
    // Dummy Code
    //public string Decrypt(string text)
    //{
    //  throw new NotImplementedException();
    //}

    public string Encrypt(string text, string salt)
    {
      //string salt = BCrypt.Net.BCrypt.GenerateSalt();
      Console.WriteLine($"Salt {salt}");
      string hashedPassword = BCrypt.Net.BCrypt.HashPassword(text, salt);

      Console.WriteLine("HashedPassword :" + hashedPassword);

      Console.WriteLine("verify :" + BCrypt.Net.BCrypt.Verify(text, hashedPassword));

      // userManager.VeriyPassword(dto.password);

      return hashedPassword;
    }
  }
}
