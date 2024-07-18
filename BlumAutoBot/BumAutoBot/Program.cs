using System.Collections.Generic;
using System.Threading.Tasks;
using System;

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
                    int choice = help.choice_platform();

                    await requests.GetBalanceAsync(authorizationToken, choice);

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
                        if (results[i] == "успех.")
                            Console.ForegroundColor = ConsoleColor.Green;
                        else
                            Console.ForegroundColor = ConsoleColor.Red;

                        Console.WriteLine($"Результат итерации {i + 1}: {results[i]}\n");
                        Console.ResetColor();
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    Console.ResetColor();
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