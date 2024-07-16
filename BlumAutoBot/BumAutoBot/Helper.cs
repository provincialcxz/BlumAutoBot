using System;

namespace BlumBot
{
    public class Helper
    {
        public int choice_platform()
        {
            int choice = platform();
            int version = 0;

            switch (choice)
            {
                case 1:
                    version = version_iphone();
                    break;
                case 2:
                    version = version_android();
                    break;
                case 3:
                    version = version_windows();
                    break;
                case 4:
                    version = version_macos();
                    break;
            }
            return version;
        }

        private int platform()
        {
            while (true)
            {
                Console.WriteLine("Выберите платформу которую используете для игры:");
                Console.WriteLine("1 - iPhone");
                Console.WriteLine("2 - Android");
                Console.WriteLine("3 - Windows PC");
                Console.WriteLine("4 - MacOS");
                int choice = Int32.Parse(Console.ReadLine());
                if (choice >= 1 && choice <= 4)
                    return choice;
                else
                    Console.WriteLine("Вы ввели не правильное значение!");
            }
        }

        private int version_iphone()
        {
            while (true)
            {
                Console.WriteLine("Выберите версию вашего устройства:");
                Console.WriteLine("1 - IOS 15");
                Console.WriteLine("2 - IOS 16");
                Console.WriteLine("3 - IOS 17");
                Console.WriteLine("4 - IOS 18");
                int choice = Int32.Parse(Console.ReadLine());
                if (choice >= 1 && choice <= 4)
                    return choice;
                else
                    Console.WriteLine("Вы ввели не правильное значение!");
            }
        }

        private int version_android()
        {
            while (true)
            {
                Console.WriteLine("Выберите версию вашего устройства:");
                Console.WriteLine("1 - Android 12 (Snow Cone)");
                Console.WriteLine("2 - Android 13 (Tiramisu)");
                Console.WriteLine("3 - Android 14 (Upside Down Cake)");
                Console.WriteLine("4 - Android 15 (Vanilla Ice Cream)");
                int choice = Int32.Parse(Console.ReadLine());
                if (choice >= 1 && choice <= 4)
                    return choice;
                else
                    Console.WriteLine("Вы ввели не правильное значение!");
            }
        }

        private int version_windows()
        {
            while (true)
            {
                Console.WriteLine("Выберите версию вашего устройства:");
                Console.WriteLine("1 - Windows 7");
                Console.WriteLine("2 - Windows 10");
                Console.WriteLine("3 - Windows 11");
                int choice = Int32.Parse(Console.ReadLine());
                if (choice >= 1 && choice <= 3)
                    return choice;
                else
                    Console.WriteLine("Вы ввели не правильное значение!");
            }
        }

        private int version_macos()
        {
            while (true)
            {
                Console.WriteLine("Выберите версию вашего устройства:");
                Console.WriteLine("1 - MacOS 14.5 (Sonoma)");
                Console.WriteLine("2 - MacOS 13.6.7 (Ventura)");
                Console.WriteLine("3 - MacOS 12.7.5 (Monterey)");
                Console.WriteLine("4 - MacOS 11.7.10 (Big Sur)");
                Console.WriteLine("5 - MacOS 10.15.7 (Catalina)");
                int choice = Int32.Parse(Console.ReadLine());
                if (choice >= 1 && choice <= 5)
                    return choice;
                else
                    Console.WriteLine("Вы ввели не правильное значение!");
            }
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
            Console.WriteLine("\r\n██████╗░██╗░░░░░██╗░░░██╗███╗░░░███╗\r\n██╔══██╗██║░░░░░██║░░░██║████╗░████║\r\n██████╦╝██║░░░░░██║░░░██║██╔████╔██║\r\n██╔══██╗██║░░░░░██║░░░██║██║╚██╔╝██║\r\n██████╦╝███████╗╚██████╔╝██║░╚═╝░██║\r\n╚═════╝░╚══════╝░╚═════╝░╚═╝░░░░░╚═╝\r\n" + "\r");
            Console.WriteLine("Development by provincialcxz\n\n");
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