using Newtonsoft.Json.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace BlumBot
{
    public class Requests
    {
        private static readonly Dictionary<int, Func<string, HttpClient>> PlatformMethods = new Dictionary<int, Func<string, HttpClient>>
        {
            { 1, ios15 },
            { 2, ios167 },
            { 3, ios1751 },
            { 4, ios18 },

            { 5, android12 },
            { 6, android13 },
            { 7, android14 },
            { 8, android15 },

            { 9, windows7 },
            { 10, windows10 },
            { 11, windows11 },

            { 12, macos145 },
            { 13, macos1367 },
            { 14, macos1275 },
            { 15, macos11710 },
            { 16, macos10157 }
        };

        private static HttpClient choiceplatform(string authorizationToken, int choice)
        {
            if (PlatformMethods.TryGetValue(choice, out var platformMethod))
            {
                return platformMethod(authorizationToken);
            }
            throw new ArgumentOutOfRangeException(nameof(choice), "Invalid choice value");
        }

        private static HttpClient CreateHttpClient(string authorizationToken, string userAgent, string secChUa = null, string secChUaMobile = null, string secChUaPlatform = null)
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Add("User-Agent", userAgent);
            client.DefaultRequestHeaders.Add("Accept", "application/json, text/plain, */*");
            client.DefaultRequestHeaders.Add("accept-language", "en-US,en;q=0.9");
            client.DefaultRequestHeaders.Add("authorization", authorizationToken);
            client.DefaultRequestHeaders.Add("origin", "https://telegram.blum.codes");
            client.DefaultRequestHeaders.Add("priority", "u=1, i");
            client.DefaultRequestHeaders.Add("sec-fetch-dest", "empty");
            client.DefaultRequestHeaders.Add("sec-fetch-mode", "cors");
            client.DefaultRequestHeaders.Add("sec-fetch-site", "same-site");

            if (!string.IsNullOrEmpty(secChUa)) client.DefaultRequestHeaders.Add("sec-ch-ua", secChUa);
            if (!string.IsNullOrEmpty(secChUaMobile)) client.DefaultRequestHeaders.Add("sec-ch-ua-mobile", secChUaMobile);
            if (!string.IsNullOrEmpty(secChUaPlatform)) client.DefaultRequestHeaders.Add("sec-ch-ua-platform", secChUaPlatform);

            return client;
        }

        private static HttpClient ios15(string authorizationToken)
        {
            return CreateHttpClient(authorizationToken, "Mozilla/5.0 (iPhone; CPU iPhone OS 15_0 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/15.0 Mobile/15E148 Safari/604.1");
        }

        private static HttpClient ios167(string authorizationToken)
        {
            return CreateHttpClient(authorizationToken, "Mozilla/5.0 (iPhone; CPU iPhone OS 16_7_8 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/16.7.8 Mobile/15E148 Safari/604.1");
        }

        private static HttpClient ios1751(string authorizationToken)
        {
            return CreateHttpClient(authorizationToken, "Mozilla/5.0 (iPhone; CPU iPhone OS 17_5_1 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/17.5.1 Mobile/15E148 Safari/604.1");
        }

        private static HttpClient ios18(string authorizationToken)
        {
            return CreateHttpClient(authorizationToken, "Mozilla/5.0 (iPhone; CPU iPhone OS 18_0 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/18.0 Mobile/15E148 Safari/604.1");
        }

        private static HttpClient android12(string authorizationToken)
        {
            return CreateHttpClient(authorizationToken, "Mozilla/5.0 (Linux; Android 12; SM-G998B) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Mobile Safari/537.36");
        }

        private static HttpClient android13(string authorizationToken)
        {
            return CreateHttpClient(authorizationToken, "Mozilla/5.0 (Linux; Android 13; SM-G998B) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Mobile Safari/537.36");
        }

        private static HttpClient android14(string authorizationToken)
        {
            return CreateHttpClient(authorizationToken, "Mozilla/5.0 (Linux; Android 14; SM-G998B) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Mobile Safari/537.36");
        }

        private static HttpClient android15(string authorizationToken)
        {
            return CreateHttpClient(authorizationToken, "Mozilla/5.0 (Linux; Android 15; SM-G998B) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Mobile Safari/537.36");
        }

        private static HttpClient windows7(string authorizationToken)
        {
            return CreateHttpClient(authorizationToken, "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Safari/537.36");
        }

        private static HttpClient windows10(string authorizationToken)
        {
            return CreateHttpClient(authorizationToken, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Safari/537.36");
        }

        private static HttpClient windows11(string authorizationToken)
        {
            return CreateHttpClient(authorizationToken, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/126.0.0.0 Safari/537.36 Edg/126.0.0.0",
                "\"Microsoft Edge\";v=\"126\", \"Chromium\";v=\"126\", \"Not.A/Brand\";v=\"8\", \"Microsoft Edge WebView2\";v=\"126\"", "?0", "\"Windows\"");
        }

        private static HttpClient macos145(string authorizationToken)
        {
            return CreateHttpClient(authorizationToken, "Mozilla/5.0 (Macintosh; Intel Mac OS X 14_5) AppleWebKit/537.36 (KHTML, like Gecko) Version/16.0 Safari/537.36");
        }

        private static HttpClient macos1367(string authorizationToken)
        {
            return CreateHttpClient(authorizationToken, "Mozilla/5.0 (Macintosh; Intel Mac OS X 13_6_7) AppleWebKit/537.36 (KHTML, like Gecko) Version/16.0 Safari/537.36");
        }

        private static HttpClient macos1275(string authorizationToken)
        {
            return CreateHttpClient(authorizationToken, "Mozilla/5.0 (Macintosh; Intel Mac OS X 12_7_5) AppleWebKit/537.36 (KHTML, like Gecko) Version/16.0 Safari/537.36");
        }

        private static HttpClient macos11710(string authorizationToken)
        {
            return CreateHttpClient(authorizationToken, "Mozilla/5.0 (Macintosh; Intel Mac OS X 11_7_10) AppleWebKit/537.36 (KHTML, like Gecko) Version/16.0 Safari/537.36");
        }

        private static HttpClient macos10157(string authorizationToken)
        {
            return CreateHttpClient(authorizationToken, "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Version/16.0 Safari/537.36");
        }

        public async Task<string> MakeRequestsAsync(string authorizationToken, int points, int iteration, int choice)
        {
            HttpClient client = choiceplatform(authorizationToken, choice);

            HttpResponseMessage response = await client.PostAsync("https://game-domain.blum.codes/api/v1/game/play", null);

            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    Console.WriteLine("Срок действия токенов истек. Пожалуйста, введите действительный токен авторизации.");
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Ошибка: {errorMessage}");
                }
                return $"Итерация {iteration} не удалась.";
            }

            string responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Ответ от /game/play (итерация {iteration}):");
            Console.WriteLine(responseContent);

            var json = JObject.Parse(responseContent);
            string gameId = json["gameId"].ToString();

            Console.WriteLine($"Итерация {iteration}: Ждите 32 секунды...");
            await Task.Delay(32000);

            client.DefaultRequestHeaders.Clear();
            client = choiceplatform(authorizationToken, choice);

            var payload = new
            {
                gameId = gameId,
                points = points
            };

            StringContent content = new StringContent(JObject.FromObject(payload).ToString(), Encoding.UTF8, "application/json");

            response = await client.PostAsync("https://game-domain.blum.codes/api/v1/game/claim", content);
            responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                string errorMessage = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Ошибка от /game/claim (Итерация {iteration}): {errorMessage}");
                return $"Итерация {iteration} не удалась.";
            }

            Console.WriteLine($"Ответ от /game/claim (Итерация {iteration}):");
            Console.WriteLine(responseContent);

            return $"Итерация {iteration} завершена успешно.";
        }
    }
}