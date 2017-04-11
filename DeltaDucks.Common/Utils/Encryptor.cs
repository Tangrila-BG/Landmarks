namespace DeltaDucks.Common.Utils
{
    using System;
    using System.Security.Cryptography;
    using System.Web.Security;

    public class Encryptor
    {
        private const int saltLength = 32;

        public string CreateSalt()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[saltLength];
            rng.GetBytes(buff);

            return Convert.ToBase64String(buff);
        }

        public string CreatePasswordHash(string pwd, string salt)
        {
            string pwdAndSalt = String.Concat(pwd, salt);
            string hashedPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(pwdAndSalt, "sha1");

            return hashedPwd;
        }
    }
}
