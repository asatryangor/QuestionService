using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AuthService.Utils
{
    public class CryptoHelper
    {
        private const string Salt = "!09@#BMSTU87$%6";

        public static string Encrypt(string plain)
        {
            using (var cryptoProvider = SHA256.Create())
            {
                var chiper = Encoding.Unicode.GetBytes(plain + Salt);
                return string.Join(string.Empty, cryptoProvider.ComputeHash(chiper).Select(x => x.ToString("X")));
            }
        }
    }
}
