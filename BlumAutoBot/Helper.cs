namespace BlumBot
{
    public class Helper
    {
        public int platform()
        {
            Console.WriteLine("Выберите платформу");
            Console.WriteLine("1 - iPhone (15.0)");
            Console.WriteLine("2 - iPhone (16.4)");
            Console.WriteLine("3 - Android (13)");
            Console.WriteLine("4 - Windows (10)");
            Console.WriteLine("5 - MacOS (13.4)");
            int choice = Int32.Parse(Console.ReadLine());

            return choice;
        }

        public int replay()
        {
            while (true)
            {
                Console.Write("Введите количество повторений: ");
                int repetitions = Int32.Parse(Console.ReadLine());

                if (repetitions < 1 || repetitions > 100)
                {
                    Console.WriteLine("Недопустимое количество повторений.");
                }
                else if (repetitions > 5)
                {
                    Console.WriteLine("Ты уверен? (y/n)");
                    string choice = Console.ReadLine().ToLower();
                    if (choice == "yes" || choice == "y")
                    {
                        return repetitions;
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    return repetitions;
                }
            }
        }

        public int scores()
        {
            while (true)
            {
                Console.Write("Введите баллы (рекомендуется от 200 до 280): ");
                string pointsInput = Console.ReadLine();
                int points;

                if (string.IsNullOrEmpty(pointsInput))
                {
                    Random random = new Random();
                    points = random.Next(260, 280);
                    Console.WriteLine($"Никакие баллы не введены. Использование случайных точек: {points}");
                    return points;
                }
                else if (!int.TryParse(pointsInput, out points) || points < 200 || points > 280)
                {
                    Console.WriteLine("Неверное значение баллов. Пожалуйста, введите число от 200 до 280.");
                    continue;
                }
                else
                {
                    return points;
                }
            }
        }

        public string GetAuthorizationToken()
        {
            Console.WriteLine("\r\n██████╗░██╗░░░░░██╗░░░██╗███╗░░░███╗  ░█████╗░██╗░░░██╗████████╗░█████╗░  ██████╗░░█████╗░████████╗\r\n██╔══██╗██║░░░░░██║░░░██║████╗░████║  ██╔══██╗██║░░░██║╚══██╔══╝██╔══██╗  ██╔══██╗██╔══██╗╚══██╔══╝\r\n██████╦╝██║░░░░░██║░░░██║██╔████╔██║  ███████║██║░░░██║░░░██║░░░██║░░██║  ██████╦╝██║░░██║░░░██║░░░\r\n██╔══██╗██║░░░░░██║░░░██║██║╚██╔╝██║  ██╔══██║██║░░░██║░░░██║░░░██║░░██║  ██╔══██╗██║░░██║░░░██║░░░\r\n██████╦╝███████╗╚██████╔╝██║░╚═╝░██║  ██║░░██║╚██████╔╝░░░██║░░░╚█████╔╝  ██████╦╝╚█████╔╝░░░██║░░░\r\n╚═════╝░╚══════╝░╚═════╝░╚═╝░░░░░╚═╝  ╚═╝░░╚═╝░╚═════╝░░░░╚═╝░░░░╚════╝░  ╚═════╝░░╚════╝░░░░╚═╝░░░" + "\r\n\n");
            while (true)
            {
                Console.Write("Введите токен авторизации: ");
                string token = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(token))
                {
                    Console.WriteLine("Токен не может быть пустым. Пожалуйста, введите действительный токен авторизации.");
                    continue;
                }

                if (!token.StartsWith("Bearer "))
                {
                    token = "Bearer " + token;
                }

                return token;
            }
        }
    }
}