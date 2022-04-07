//using Amazon.SecretsManager;
//using Amazon.SecretsManager.Extensions.Caching;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Threading.Tasks;

//namespace INTEX2.Models
//{
//    public class SecretsUserClass : IDisposable
//    {
//        private readonly IAmazonSecretsManager secretsManager;
//        private readonly SecretsManagerCache cache;

//        public SecretsUserClass()
//        {
//            this.secretsManager = new AmazonSecretsManagerClient();
//            this.cache = new SecretsManagerCache(this.secretsManager);
//        }

//        public void Dispose()
//        {
//            this.secretsManager.Dispose();
//            this.cache.Dispose();
//        }

//        public async Task<NetworkCredential> GetNetworkCredential(string secretId)
//        {
//            var sec = await this.cache.GetSecretString(secretId);
//            var jo = Newtonsoft.Json.Linq.JObject.Parse(sec);
//            return new NetworkCredential(
//                connectionstring: jo["ConString"].ToObject<string>());
//        }
//    }
//}
