namespace SecretApp
{
    internal class Program
    {
        static string[] userNames = { "Pelle", "Stina", "Ali" };
        static string[] userPasswords = { "1234", "abcd", "qwerty" };

        static async Task Main(string[] args)
        {
            string[] choices = { "Logga in", "Lägg till användare", "Ändra Lösenord", "Avsluta" };
            int selektedIndex = 0;

            bool runtask = true;
            while (runtask == true)
            {
                Console.Clear();
                Console.WriteLine("Välkommen, vad vill du göra?");
                for (int i = 0; i < choices.Length; i++)
                {
                    if (i == selektedIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.WriteLine($"->{choices[i]}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"  {choices[i]}");
                    }
                }
                ConsoleKey key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        selektedIndex = (selektedIndex == 0) ? choices.Length - 1 : selektedIndex - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        selektedIndex = (selektedIndex == choices.Length - 1) ? 0 : selektedIndex + 1;
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        runtask = false;
                        switch (choices[selektedIndex])
                        {
                            case "Logga in":
                                ShowUsers();
                                break;
                            case "Lägg till användare":
                                AddUser();
                                break;
                            case "Ändra lösenord":
                                ChangePassword();
                                break;
                            case "Avsluta":
                                EndApplication();
                                break;
                        }
                        break;
                }

            }
        }

        static void AddUser()
        {
            Console.WriteLine("Hello from AddUser()");
        }

        static void ChangePassword()
        {

        }

        static void ShowUsers()
        {
            int namesIndex = 0;

            bool runsecondtask = true;
            while (runsecondtask == true)
            {
                Console.Clear();
                Console.WriteLine("Vem är du?");
                for (int i = 0; i < userNames.Length; i++)
                {
                    if (i == namesIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.WriteLine($"->{userNames[i]}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"  {userNames[i]}");
                    }
                }
                ConsoleKey key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        namesIndex = (namesIndex == 0) ? userNames.Length - 1 : namesIndex - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        namesIndex = (namesIndex == userNames.Length - 1) ? 0 : namesIndex + 1;
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        runsecondtask = false;
                        break;
                }
            }
        }

        static void EnterPassword()
        {
            
        }
            static void EndApplication()
            {
            Console.WriteLine("Closing application");
            Thread.Sleep(2000);
            }
        
    }
}
