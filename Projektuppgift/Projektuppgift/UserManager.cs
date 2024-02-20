using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Projektuppgift
{
    internal class UserManager
    {
        private readonly List<User> users = new List<User>();
        private readonly string usernamePrompt = "användarnamn";
        private readonly string passwordPrompt = "lösenord";
        private readonly string firstnamePrompt = "förnamn";
        private readonly string lastnamePrompt = "efternamn";

        public void RegisterUser()
        {
            string username = ValidateUsername(GetUserInput(usernamePrompt));
            string password = ValidatePassword(GetUserInput(passwordPrompt));
            string firstname = ValidateName(GetUserInput(firstnamePrompt));
            string lastname = ValidateName(GetUserInput(lastnamePrompt));
            users.Add(new User(username, GenerateHashPassword(password), firstname, lastname));
            Console.WriteLine();
            Typewriter.TypewriterEffect($"{username} med lösenordet {password} registrerad!");
            Console.WriteLine();
        }

        public User LoginUser()
        {
            string username = GetUserInput("användarnamn");
            string password = GetUserInput("lösenord");
            return VerifyPassword(username, password);
        }

        private string GetUserInput(string prompt)
        {
            Typewriter.TypewriterEffect($"Var god och ange ditt {prompt}: ", false);
            return Console.ReadLine();
        }

        private string ValidateUsername(string username)
        {
            do
            {
                if (string.IsNullOrWhiteSpace(username))
                {
                    Typewriter.TypewriterEffect("Illegalt namnargument. Ange ett giltigt namn.");
                }
                else if (users.Any(user => user.GetUsername() == username))
                {
                    Typewriter.TypewriterEffect("Användarnamnet finns redan registrerat. Ange ett annat namn.");
                }
                else
                {
                    return username;
                }
            } while (true);
        }

        private string ValidatePassword(string password)
        {
            do
            {
                if (string.IsNullOrWhiteSpace(password))
                {
                    Typewriter.TypewriterEffect("Illegalt lösenord. Ange ett giltigt lösenord.");
                }
                else
                {
                    return password;
                }
            } while (true);
        }

        private string ValidateName(string name)
        {
            do
            {
                if (string.IsNullOrWhiteSpace(name) || !name.All(char.IsLetter))
                {
                    Typewriter.TypewriterEffect($"Illegalt {name}. Ange ett giltigt {name}.");
                }
                else
                {
                    return name;
                }
            } while (true);
        }

        public User VerifyUsername(string username)
        {
            User user = users.FirstOrDefault(u => u.GetUsername() == username);
            if (user == null)
            {
                Console.WriteLine();
                Typewriter.TypewriterEffect("Ogiltigt användarnamn.");
            }
            return user;
        }

        public User VerifyPassword(string username, string password)
        {
            User user = users.FirstOrDefault(u => u.GetUsername() == username && u.PasswordMatch(password));
            if (user == null)
            {
                Console.WriteLine();
                Typewriter.TypewriterEffect("Ogiltigt lösenord.");
            }
            return user;
        }

        public void SaveUsers()
        {
            FileManager.SaveContent(users);
        }

        public void LoadUsers()
        {
            users.Clear();
            users.AddRange(FileManager.LoadFromFile(Path.Combine(Directory.GetCurrentDirectory(), "Users/users.json")));
        }
    }
}