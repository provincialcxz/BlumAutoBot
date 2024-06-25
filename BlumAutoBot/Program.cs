namespace BlumBot
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Helper help = new Helper();
            Requests requests = new Requests();

            string authorizationToken = help.GetAuthorizationToken();

            while (true)
            {
                try
                {
                    int choice = help.platform();
                    int repetitions = help.replay();
                    int points = help.scores();

                    List<Task<string>> tasks = new List<Task<string>>();

                    for (int i = 0; i < repetitions; i++)
                    {
                        tasks.Add(requests.MakeRequestsAsync(authorizationToken, points, i + 1, choice));
                    }

                    string[] results = await Task.WhenAll(tasks);

                    for (int i = 0; i < results.Length; i++)
                    {
                        Console.WriteLine($"Результат итерации {i + 1}:\n{results[i]}\n");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }

                Console.WriteLine("Еще разок? (yes/no): ");
                string runAgain = Console.ReadLine().ToLower();
                if (runAgain != "yes" && runAgain != "y")
                {
                    break;
                }
            }
        }
    }
}