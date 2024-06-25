using Newtonsoft.Json.Linq;
using System.Text;

namespace BlumBot
{
    public class Requests
    {
        private static HttpClient choiceplatform(string authorizationToken, int choice)
        {
            HttpClient result = new HttpClient();

            switch(choice) 
            {
                case 1:
                    result = iphone_old(authorizationToken);
                    break;
                case 2:
                    result = iphone_new(authorizationToken);
                    break;
                case 3:
                    result = android(authorizationToken);
                    break;
                case 4:
                    result = windows(authorizationToken);
                    break;
                case 5:
                    result = macos(authorizationToken);
                    break;
            }

            return result;
        }

        public static HttpClient iphone_old(string authorizationToken)
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (iPhone; CPU iPhone OS 15_0 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/15.0 Mobile/15E148 Safari/604.1");
            client.DefaultRequestHeaders.Add("Accept", "application/json, text/plain, */*");
            client.DefaultRequestHeaders.Add("accept-language", "en-US,en;q=0.9");
            client.DefaultRequestHeaders.Add("authorization", authorizationToken);
            client.DefaultRequestHeaders.Add("origin", "https://telegram.blum.codes");
            client.DefaultRequestHeaders.Add("priority", "u=1, i");
            client.DefaultRequestHeaders.Add("sec-fetch-dest", "empty");
            client.DefaultRequestHeaders.Add("sec-fetch-mode", "cors");
            client.DefaultRequestHeaders.Add("sec-fetch-site", "same-site");

            return client;
        }

        public static HttpClient iphone_new(string authorizationToken)
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (iPhone; CPU iPhone OS 16_4 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/16.4 Mobile/15E148 Safari/604.1");
            client.DefaultRequestHeaders.Add("Accept", "application/json, text/plain, */*");
            client.DefaultRequestHeaders.Add("accept-language", "en-US,en;q=0.9");
            client.DefaultRequestHeaders.Add("authorization", authorizationToken);
            client.DefaultRequestHeaders.Add("origin", "https://telegram.blum.codes");
            client.DefaultRequestHeaders.Add("priority", "u=1, i");
            client.DefaultRequestHeaders.Add("sec-fetch-dest", "empty");
            client.DefaultRequestHeaders.Add("sec-fetch-mode", "cors");
            client.DefaultRequestHeaders.Add("sec-fetch-site", "same-site");

            return client;
        }

        public static HttpClient android(string authorizationToken) 
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Linux; Android 13; SM-G998B) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Mobile Safari/537.36");
            client.DefaultRequestHeaders.Add("Accept", "application/json, text/plain, */*");
            client.DefaultRequestHeaders.Add("accept-language", "en-US,en;q=0.9");
            client.DefaultRequestHeaders.Add("authorization", authorizationToken);
            client.DefaultRequestHeaders.Add("origin", "https://telegram.blum.codes");
            client.DefaultRequestHeaders.Add("priority", "u=1, i");
            client.DefaultRequestHeaders.Add("sec-fetch-dest", "empty");
            client.DefaultRequestHeaders.Add("sec-fetch-mode", "cors");
            client.DefaultRequestHeaders.Add("sec-fetch-site", "same-site");

            return client;
        }

        public static HttpClient windows(string authorizationToken) 
        { 
            var client = new HttpClient();

            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/126.0.0.0 Safari/537.36 Edg/126.0.0.0");
            client.DefaultRequestHeaders.Add("Accept", "application/json, text/plain, */*");
            client.DefaultRequestHeaders.Add("accept-language", "en-US,en;q=0.9");
            client.DefaultRequestHeaders.Add("authorization", authorizationToken);
            client.DefaultRequestHeaders.Add("origin", "https://telegram.blum.codes");
            client.DefaultRequestHeaders.Add("priority", "u=1, i");
            client.DefaultRequestHeaders.Add("sec-ch-ua", "\"Microsoft Edge\";v=\"126\", \"Chromium\";v=\"126\", \"Not.A/Brand\";v=\"8\", \"Microsoft Edge WebView2\";v=\"126\"");
            client.DefaultRequestHeaders.Add("sec-ch-ua-mobile", "?0");
            client.DefaultRequestHeaders.Add("sec-ch-ua-platform", "\"Windows\"");
            client.DefaultRequestHeaders.Add("sec-fetch-dest", "empty");
            client.DefaultRequestHeaders.Add("sec-fetch-mode", "cors");
            client.DefaultRequestHeaders.Add("sec-fetch-site", "same-site");

            return client;
        }

        public static HttpClient macos(string authorizationToken) 
        { 
            var client = new HttpClient();

            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Macintosh; Intel Mac OS X 13_4) AppleWebKit/537.36 (KHTML, like Gecko) Version/16.0 Safari/537.36");
            client.DefaultRequestHeaders.Add("Accept", "application/json, text/plain, */*");
            client.DefaultRequestHeaders.Add("accept-language", "en-US,en;q=0.9");
            client.DefaultRequestHeaders.Add("authorization", authorizationToken);
            client.DefaultRequestHeaders.Add("origin", "https://telegram.blum.codes");
            client.DefaultRequestHeaders.Add("priority", "u=1, i");
            client.DefaultRequestHeaders.Add("sec-fetch-dest", "empty");
            client.DefaultRequestHeaders.Add("sec-fetch-mode", "cors");
            client.DefaultRequestHeaders.Add("sec-fetch-site", "same-site");

            return client;
        }

        public async Task<string> MakeRequestsAsync(string authorizationToken, int points, int iteration, int choice)
        {
            HttpClient client = new HttpClient();
            
            client = choiceplatform(authorizationToken, choice);

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