using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Projektuppgift
{
    internal class MenuManager
    {
        private UserManager manager = new();
        private int SECS = 1000;
        public User LoginMenu()
        {
            if (Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Users")))
            {
                Typewriter.TypewriterEffect("Loading users...");
                Thread.Sleep(SECS);
                manager.LoadUsers();
                Typewriter.TypewriterEffect("Fetched users!");
                Console.Clear();

            }
            while (true)
            {
                Console.WriteLine();
                Typewriter.TypewriterEffect("*Loginmeny*");
                Console.WriteLine();
                Typewriter.TypewriterEffect("Var god och ange ett av följande alternativ:");
                Console.WriteLine();
                Typewriter.TypewriterEffect("1. Logga in");
                Typewriter.TypewriterEffect("2. Registrera konto");
                Typewriter.TypewriterEffect("3. Avsluta programmet");
                Console.WriteLine();
                Typewriter.TypewriterEffect("Ange ett alt: ", false);

                string userInput = Console.ReadLine();


                Console.WriteLine();

                switch (userInput)
                {
                    case "1":
                        User user = manager.LoginUser();
                        if (user != null)
                        {
                            Console.WriteLine();
                            Typewriter.TypewriterEffect("Loggar in...");
                            Thread.Sleep(SECS);
                            Console.Clear();
                            return user;
                        }
                        Thread.Sleep(SECS);
                        Console.Clear();
                        break;
                    case "2":
                        manager.RegisterUser();
                        Thread.Sleep(SECS);
                        Console.Clear();
                        break;
                    case "3":
                        Typewriter.TypewriterEffect("Stänger ned...");
                        Thread.Sleep(SECS);
                        return null;
                    default:
                        Typewriter.TypewriterEffect($"Kommandot, {userInput}, är ogiltigt"); // String interpolation
                        Thread.Sleep(SECS);
                        Console.Clear();
                        break;
                }
            }
        }
        public void DiaryMenu(User user)
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine();
                Typewriter.TypewriterEffect("*Dagboksmeny*");
                Console.WriteLine();
                Typewriter.TypewriterEffect("Var god och ange ett av följande alternativ:");
                Console.WriteLine();
                Typewriter.TypewriterEffect("1. Skapa ny dagbok");
                Typewriter.TypewriterEffect("2. Editera dagboks inlägg");
                Typewriter.TypewriterEffect("3. Radera dagbok");
                Typewriter.TypewriterEffect("4. Spara och avsluta programmet");
                Console.WriteLine();
                Typewriter.TypewriterEffect("Ange ett alt: ", false);
                int userInput = Convert.ToInt32(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        user.GetDiaries().CreateDiary(user);
                        Thread.Sleep(SECS);
                        Console.Clear();
                        break;
                    case 2:
                        if (user.GetDiaries().GetDiaryList().Count == 0)
                        {
                            Typewriter.TypewriterEffect($"Det finns ingen dagbok kopplat till användarnamnet: {user.GetUsername()}");
                            Console.WriteLine();
                            break;
                        }
                        Console.WriteLine();
                        Typewriter.TypewriterEffect("Vilken av följande dagböcker vill du editera: ");
                        Console.WriteLine();
                        user.GetDiaries().ListDiaries();
                        Console.WriteLine();
                        Typewriter.TypewriterEffect("Ange dagbokens titel: ", false);
                        string input = Console.ReadLine();
                        if (user.GetDiaries().GetDiaryList().Any(item => item.GetTitle() == input))
                        {
                            Thread.Sleep(SECS);
                            Console.Clear();
                            PostMenu(user, input);
                            break;
                        }
                        Typewriter.TypewriterEffect("Ogiltigt alternativ!");
                        Thread.Sleep(SECS);
                        Console.Clear();
                        break;
                    case 3:
                        if (user.GetDiaries().GetDiaryList().Count == 0)
                        {
                            Console.WriteLine();
                            Typewriter.TypewriterEffect($"Det finns ingen dagbok kopplat till användarnamnet: {user.GetUsername()}");
                            Console.WriteLine();
                            Thread.Sleep(SECS);
                            Console.Clear();
                            break;
                        }
                        Typewriter.TypewriterEffect("Vilken dagbok skulle du vilja ta bort: ");
                        user.GetDiaries().ListDiaries();
                        Console.WriteLine();
                        Typewriter.TypewriterEffect("Ange ett alt: ", false);
                        user.GetDiaries().RemoveDiary(Console.ReadLine());
                        Console.WriteLine();
                        Typewriter.TypewriterEffect("Raderar dagbok...");
                        Thread.Sleep(SECS);
                        Typewriter.TypewriterEffect("Dagbok borttagen!");
                        Thread.Sleep(SECS);
                        Console.Clear();
                        break;
                    case 4:
                        manager.SaveUsers();
                        Typewriter.TypewriterEffect("Stänger ned...");
                        Thread.Sleep(SECS);
                        running = false;
                        break;
                    default:
                        Console.WriteLine();
                        Typewriter.TypewriterEffect("Ogiltigt alternativ"); // String interpolation
                        Thread.Sleep(SECS);
                        Console.Clear();
                        break;
                }
            }
        }
        public void PostMenu(User user, string diaryTitle)
        {
            bool running = true;
            do
            {
                Console.WriteLine();
                Typewriter.TypewriterEffect("*Inläggsmeny*");
                Console.WriteLine();
                Typewriter.TypewriterEffect("Var god och ange ett av följande alternativ:");
                Console.WriteLine();
                Typewriter.TypewriterEffect("1. Skapa nytt inlägg");
                Typewriter.TypewriterEffect("2. Editera inlägg");
                Typewriter.TypewriterEffect("3. Radera inlägg");
                Typewriter.TypewriterEffect("4. Gå tillbaka");
                Console.WriteLine();
                Typewriter.TypewriterEffect("Ange ett alt: ", false);
                int userInput = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (userInput)
                {
                    case 1:
                        user.GetDiaries().GetDiary(diaryTitle).CreatePost(user);
                        Thread.Sleep(SECS);
                        Console.Clear();
                        break;
                    case 2:
                        if (user.GetDiaries().GetDiary(diaryTitle).GetPosts().Count == 0)
                        {
                            Console.WriteLine();
                            Typewriter.TypewriterEffect($"Det finns inget inlägg kopplat till dagboken: {user.GetDiaries().GetDiary(diaryTitle).GetTitle()}");
                            Thread.Sleep(SECS);
                            Console.Clear();
                            break;
                        }
                        Typewriter.TypewriterEffect("Vilket av följande inlägg vill du editera: ");
                        Console.WriteLine();
                        foreach (Post post in user.GetDiaries().GetDiary(diaryTitle).GetPosts())
                        {
                            Typewriter.TypewriterEffect("* " + post.GetTitle());
                        }
                        Console.WriteLine();
                        Typewriter.TypewriterEffect("Ange inläggets titel: ", false);
                        string input = Console.ReadLine();
                        if (user.GetDiaries().GetDiary(diaryTitle).GetPost(input) == null)
                        {
                            Typewriter.TypewriterEffect("Illegalt inläggstitel. Var god och försök igen på nytt!");
                            Thread.Sleep(SECS);
                            Console.Clear();
                            break;

                        }
                        Console.WriteLine();
                        Typewriter.TypewriterEffect("Hämtar inlägg...");
                        Thread.Sleep(SECS);
                        Console.Clear();
                        user.GetDiaries().GetDiary(diaryTitle).GetPost(input).EditPost();
                        Console.WriteLine();
                        bool response = false;
                        do
                        {
                            Typewriter.TypewriterEffect("Klicka 'spacebar' för att återgå till menyn!");
                            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                            if (keyInfo.Key == ConsoleKey.Spacebar)
                            {
                                response = true;
                            }
                        } while (!response);
                        Console.Clear();
                        break;

                    case 3:
                        if (user.GetDiaries().GetDiary(diaryTitle).GetPosts().Count == 0)
                        {
                            Console.WriteLine();
                            Typewriter.TypewriterEffect($"Det finns inget inlägg kopplat till användarnamnet: {user.GetUsername()}");
                            Console.WriteLine();
                            break;
                        }
                        Typewriter.TypewriterEffect("Vilket inlägg skulle du vilja ta bort: ");
                        Console.WriteLine();
                        foreach (Post post in user.GetDiaries().GetDiary(diaryTitle).GetPosts())
                        {
                            Typewriter.TypewriterEffect("* " + post.GetTitle());
                        }
                        Console.WriteLine();
                        Typewriter.TypewriterEffect("Ange ett alt: ", false);
                        user.GetDiaries().GetDiary(diaryTitle).RemovePost(Console.ReadLine());
                        Console.WriteLine();
                        Typewriter.TypewriterEffect("Raderar inlägg...");
                        Thread.Sleep(SECS);
                        Console.WriteLine();
                        Typewriter.TypewriterEffect("Inlägg borttaget!");
                        Thread.Sleep(SECS);
                        Console.Clear();

                        break;
                    case 4:
                        Thread.Sleep(SECS);
                        Console.Clear();
                        DiaryMenu(user);
                        return;
                    default:
                        Typewriter.TypewriterEffect($"Kommandot \"{userInput}\" är ogiltigt"); // String interpolation
                        Thread.Sleep(SECS);
                        Console.Clear();
                        break;
                }
            } while (running is true);
        }
    }
}
