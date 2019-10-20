using Newtonsoft.Json;
using System;
using System.Security.Cryptography;
using System.Text;
using Trading.Entities.Definitions;

namespace Trading.Operations.Implementation.KuCoin
{
    public class KuCoinAuthorization : BaseAuthorization
    {
        public string TimeStamp { get; set; }
        public string PassPhrase { get; set; }
        public string Secret { get; set; }

        public KuCoinAuthorization(string key) : base(key) { }

        public KuCoinAuthorization(string key, string passphrase) : base(key)
        {
            PassPhrase = passphrase;
        }

        public KuCoinAuthorization(string key, string passphrase, string timeStamp) : base(key)
        {
            PassPhrase = passphrase;
            TimeStamp = timeStamp;
        }

        internal string GetSign(string url, string method, object body = null)
        {
            string sign = TimeStamp + method + url + ((body == null) ? "" : JsonConvert.SerializeObject(body));

            using (HMACSHA256 sha = new HMACSHA256(Encoding.UTF8.GetBytes(Secret)))
            {
                return Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(sign)));
            }
        }
    }
}
