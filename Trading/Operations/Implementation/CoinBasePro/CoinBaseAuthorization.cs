using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using Trading.Entities.Definitions;

namespace Trading.Operations.Implementation.CoinBasePro
{
    public sealed class CoinBaseAuthorization : IAuthorization
    {
        public string Key { get; set; }

        public string Secret { get; set; }

        public string PassPhrase { get; set; }

        public string TimeStamp { get; set; }

        /// <summary>
        /// Verifica se a autorização esta corretamente preenchida
        /// </summary>
        /// <returns> Um <see cref="bool" /> dizendo se esta tudo correto</returns>
        public bool isValid()
        {
            return !string.IsNullOrWhiteSpace(Key) && !string.IsNullOrWhiteSpace(Secret) && !string.IsNullOrWhiteSpace(PassPhrase) && !string.IsNullOrWhiteSpace(TimeStamp);
        }

        internal string GetSign(string url, HttpMethod method, string body)
        {
            string sign = TimeStamp + method.Method.ToUpper() + url +  body;

            using (HMACSHA256 sha = new HMACSHA256(Convert.FromBase64String(Secret)))
            {
                return Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(sign)));
            }
        }
    }
}
