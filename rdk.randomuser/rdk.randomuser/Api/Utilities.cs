using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace rdk.randomuser.Api
{
    internal class Utilities
    {
        public static string GetMD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

        public static string GetUtcTimestamp()
        {
            return DateTime.UtcNow.ToString("yyyyMMddHHmmss");
        }


        public static async Task<string> GetRequest(string url)
        {
            HttpClient myClient = new HttpClient();
            myClient.BaseAddress = new Uri(url);
            myClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await myClient.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
