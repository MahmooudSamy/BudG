using System.Text;

namespace BudG.UI.Extentions
{
    public static class HashPasswordExtention
    {
        public static string ToHashSomeText(this string TextwantEncrypt)
        {
            byte[] data = new byte[8];
            data = Encoding.ASCII.GetBytes(TextwantEncrypt);
            string result;

            System.Security.Cryptography.SHA512 shaM = new System.Security.Cryptography.SHA512Managed();
            result = Encoding.ASCII.GetString(shaM.ComputeHash(data));
            return result;
        }
    }
}
