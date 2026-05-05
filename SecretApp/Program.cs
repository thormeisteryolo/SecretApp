
namespace SecretApp
{
    internal class Program
    {
        static string[] userNames = { "Pelle", "Stina", "Ali" };
        static string[] userPasswords = { "1234", "abcd", "qwerty" };
        static int userSelected = 0;
        static int Tries = 0;
        static bool Logged = false;
        static void Main(string[] args)
        {
            Menu();
        }
        static void Menu()
        {
            Tries = 0;
            string[] choices = { "Logga in", "Lägg till användare", "Ta bort användare", "Ändra Lösenord", "Avsluta" };
            int selektedIndex = 0;

            bool runtask = true;
            while (runtask == true)
            {
                Console.CursorVisible = false;
                Console.Clear();
                if (Logged == true)
                {
                    Console.WriteLine($"Hej {userNames[userSelected]}");
                }
                else {
                    Console.WriteLine("Hej");
                }
                    
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
                            case "Ta bort användare":
                                RemoveUser();
                                break;
                            case "Ändra Lösenord":
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
            Console.Write("Namn: ");
            string name = Console.ReadLine();
            Console.Write("Lösenord: ");
            string password = Console.ReadLine();
            Console.Clear();
            string[] tempNames = new string[userNames.Length + 1];
            string[] tempPasswords = new string[userPasswords.Length + 1];
            int j = userNames.Length;
            for (int i = 0; i < userNames.Length; i++)
            {
                tempNames[i] = userNames[i];
                tempPasswords[i] = userPasswords[i];
            }
            tempNames[j] = name;
            tempPasswords[j] = password;

            userNames = tempNames;
            userPasswords = tempPasswords;

            Menu();

        }
        static void RemoveUser()
        {
            Console.Clear();
           if (Logged == false)
            {
                Console.WriteLine("Du är inte inloggad.");
                Thread.Sleep(2000);
                Menu();
            }


            Console.Write("Namn: ");
            string name = Console.ReadLine();
            if (userNames.Contains(name) == false || userNames[userSelected] != name)
            {
                Console.WriteLine("Felaktikt namn");
                Thread.Sleep(2000);
                RemoveUser();
            }
            Console.Write("Lösenord: ");
            string password = Console.ReadLine();
            if (userPasswords.Contains(password) == false)
            {
                Console.WriteLine("Felaktigt lösenord");
                Thread.Sleep(2000);
                RemoveUser();
            }
            Console.Clear();
            
            string[] tempNames = new string[userNames.Length];
            string[] tempPasswords = new string[userPasswords.Length];
            int j = 0;
            for (int i = 0; i < tempNames.Length - 1;)
            {
                if (userNames[i] == name)
                {
                    j++;
                }
                
                tempNames[i] = userNames[j];
                tempPasswords[i] = userPasswords[j];
                j++;
                i++;
            }
            userNames = tempNames;
            userPasswords = tempPasswords;
            Logged = false;
            Menu();
        }
        static void ChangePassword()
        {
            Console.Clear();
            if (Logged == false) {
                Console.WriteLine("Du är inte inloggad");
                Thread.Sleep(2000);
                Menu();
            }
            Console.Write("Namn: ");
            string name = Console.ReadLine();
            if (name != userNames[userSelected])
            {
                Console.WriteLine("Felaktigt namn.");
                Thread.Sleep(2000);
                ChangePassword();
            }
            Console.Write("Lösenord: ");
            string password = Console.ReadLine();
            if (password != userPasswords[userSelected])
            {
                Console.WriteLine("Felaktigt lösenord.");
                Thread.Sleep(2000);
                ChangePassword();
            }
            Console.Clear();
            Console.Write("Nytt lösenord: ");
            string newPassword = Console.ReadLine();

            userPasswords[userSelected] = newPassword;
            Logged = false;
            Menu();
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
                        userSelected = namesIndex;
                        runsecondtask = false;
                        EnterPassword();
                        break;
                }
            }
        }

        static void EnterPassword()
        {
            Console.CursorVisible = true;
            Console.Clear();
            Console.WriteLine("Enter password");

            string password = Console.ReadLine();
            if (password == userPasswords[userSelected])
            {
                Console.Clear();
                Console.Write($"Välkomen {userNames[userSelected]}");
                Logged = true;
                Thread.Sleep(2000);
                Menu();
            }
            else
            {
                if (Tries < 3)
                {
                    Console.Clear();
                    Console.WriteLine("Felaktigt lösenord");
                    Thread.Sleep(1000);
                    Tries++;
                    EnterPassword();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("För många inloggningsförsök har gjorts, går tillbaka till menyn.");
                    Thread.Sleep(3000);
                    Menu();
                }
            }
        }
        static void EndApplication()
        {
            Console.WriteLine("Closing application");
            Thread.Sleep(2000);
        }

    }
}
