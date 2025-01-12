using System.Security.Cryptography;
using System.Text;

namespace BudG.UI.Extentions
{
    public static class HashPasswordExtention
    {
        public static string ToHashSomeText(this string TextwantEncrypt)
        {
            //byte[] data = new byte[8];
            //data = Encoding.ASCII.GetBytes(TextwantEncrypt);
            //string result;

            //System.Security.Cryptography.SHA512 shaM = new System.Security.Cryptography.SHA512Managed();
            //result = Encoding.ASCII.GetString(shaM.ComputeHash(data));
            //return result;
            string result = "" ;
            if (!string.IsNullOrWhiteSpace(TextwantEncrypt))
            {
                byte[] data = Encoding.ASCII.GetBytes(TextwantEncrypt);
                
                using (SHA512 sha512 = SHA512.Create())
                {
                    result = Encoding.ASCII.GetString(sha512.ComputeHash(data));
                }
            }
            
            return result;
        }
    }
}
