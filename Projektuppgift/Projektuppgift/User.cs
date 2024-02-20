using System;
using System.Security.Cryptography;
using System.Text;

namespace Projektuppgift
{
    internal class User
    {
        private string username;
        private string passwordHash; // Store hashed password
        private string firstname;
        private string lastname;
        private Diaries diaries;

        public User(string username, string password, string firstname, string lastname)
        {
            this.username = username;
            this.passwordHash = HashPassword(password); // Store hashed password
            this.firstname = firstname;
            this.lastname = lastname;
            this.diaries = new Diaries();
        }

        public string GetFirstname()
        {
            return this.firstname;
        }

        public string GetLastname()
        {
            return this.lastname;
        }

        public string GetUsername()
        {
            return this.username;
        }

        private string GetPasswordHash()
        {
            return this.passwordHash; // Return hashed password
        }

        public User GetUser()
        {
            return this;
        }

        public Diaries GetDiaries()
        {
            return this.diaries;
        }

        public bool CheckPassword(string password)
        {
            // Hash the input password and compare with stored hash
            return PasswordMatch(password);
        }

        private bool PasswordMatch(string password)
        {
            // Hash the input password and compare with stored hash
            return HashPassword(password) == GetPasswordHash();
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}