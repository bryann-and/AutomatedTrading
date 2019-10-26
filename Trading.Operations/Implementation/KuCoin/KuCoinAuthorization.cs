using Newtonsoft.Json;
using System;
using System.Security.Cryptography;
using System.Text;
using Trading.Entities.Definitions;

namespace Trading.Operations.Implementation.KuCoin
{
    public sealed class KuCoinAuthorization : IAuthorization
    {
        public string TimeStamp { get; set; }
        public string PassPhrase { get; set; }
        public string Secret { get; set; }
        public string Key { get; set; }

        public KuCoinAuthorization() { }

        internal string GetSign(string url, string method, object body = null)
        {
            string sign = TimeStamp + method + url + ((body == null) ? "" : JsonConvert.SerializeObject(body));

            using (HMACSHA256 sha = new HMACSHA256(Encoding.UTF8.GetBytes(Secret)))
            {
                return Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(sign)));
            }
        }

        public bool isValid()
        {
            return !string.IsNullOrWhiteSpace(TimeStamp) && !string.IsNullOrWhiteSpace(PassPhrase) && !string.IsNullOrWhiteSpace(Secret) && !string.IsNullOrWhiteSpace(Key);
        }
    }
}
