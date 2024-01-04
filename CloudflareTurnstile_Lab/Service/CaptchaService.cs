using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
namespace CloudflareTurnstile_Lab.Service
{
    public class CaptchaService
    {
        private const string TurnstileApiUrl = "https://challenges.cloudflare.com/turnstile/v0/siteverify";
        private const string GoogleApiUrl = "https://www.google.com/recaptcha/api/siteverify";
        private const string SecretKey = "0x4AAAAAAAPGUrrFG4ALflWVh9tZEg81oqI";
        private const string GoogleSecretKey = "6Lc6OkUpAAAAAHMKFAR_3c-jDcacAvTCfeReQHAK";

        public bool ValidateTurnstileToken(string token, string userIpAddress)
        {
            string formattedTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            string jsonData = @"{
                'success': true,
                'error-codes': [],
                'challenge_ts': '" + formattedTime + @"',
                'hostname': 'localhost',
                'secret': '" + SecretKey + @"',
                'response': '" + token + @"',
                'remoteip': '" + userIpAddress + @"'
            }";
            jsonData = jsonData.Replace("'", "\"");
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                Content = new StringContent(jsonData, Encoding.UTF8, "application/json"),
                RequestUri = new Uri(TurnstileApiUrl)
            };
            HttpClient client = new HttpClient();
            var response = client.SendAsync(request).Result;
            response.EnsureSuccessStatusCode();  //若WebAPI回應非200，直接進到Exception
            var apiResult = response.Content.ReadAsStringAsync().Result;
            return true;
        }
        public bool ValidatGoogleToken(string token, string userIpAddress)
        {
            string jsonData = @"{
                'secret': '" + GoogleSecretKey + @"',
                'response': '" + token + @"',
                'remoteip': '" + userIpAddress + @"'
            }";
            jsonData = jsonData.Replace("'", "\"");
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                Content = new StringContent(jsonData, Encoding.UTF8, "application/json"),
                RequestUri = new Uri(GoogleApiUrl)
            };
            HttpClient client = new HttpClient();
            var response = client.SendAsync(request).Result;
            response.EnsureSuccessStatusCode();  //若WebAPI回應非200，直接進到Exception
            var apiResult = response.Content.ReadAsStringAsync().Result;
            return true;
        }

        public class TurnstileValidationResult
        {
            public bool success { get; set; }
            // Add other properties as needed
        }
    }
}
