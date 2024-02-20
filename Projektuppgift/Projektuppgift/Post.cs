using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Projektuppgift
{
    internal class Post
    {
        private string title;
        private string text;
        private string owner;
        private readonly DateTime published;
        private DateTime lastUpdated;

        public Post()
        {
            this.title = "";
            this.text = "";
            this.owner = "";
            this.published = DateTime.Now.Date;
            this.lastUpdated = DateTime.Now.Date;
    }

        public void SetTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine();
                Typewriter.TypewriterEffect("Illegalt titelargument. Ange en giltig titel: ");
                SetTitle(Console.ReadLine());
                return;
            }
            if (!title.Any(Char.IsLetter) && !title.Any(Char.IsNumber))
            {
                Console.WriteLine();
                Typewriter.TypewriterEffect("Illegalt titelargument. Ange en giltig titel: ");
                SetTitle(Console.ReadLine());
                return;
            }
            this.title = title;
        }

        public void SetText(string text)
        {
            this.text = text;
        }

        public void SetOwner(string owner)
        {
            this.owner = owner;
        }

        public string GetTitle()
        {
            if (string.IsNullOrEmpty(this.title))
            {
                throw new Exception("Titel is null");
            }
            return this.title;
        }

        public string GetText()
        {
            if (string.IsNullOrWhiteSpace(this.title))
            {
                throw new Exception("Titel is null");
            }
            return this.text;
        }

        public string GetOwner()
        {
            if (string.IsNullOrEmpty(this.owner))
            {
                throw new Exception("No owner set");
            }
            return this.owner;
        }

        public DateTime GetPublishedDate()
        {
            return this.published;
        }

        public DateTime GetUpdatedDate()
        {
            return this.lastUpdated;
        }

        public void UpdateDate()
        {
            this.lastUpdated = DateTime.Now.Date;
        }
        public void PrintInfo()
        {
            Typewriter.TypewriterEffect(this.title);
            Typewriter.TypewriterEffect($"Ägare: {this.owner}, Senast updaterad: {this.lastUpdated:yyyy/mm/dd}, Publicerad: {published:yyyy/mm/dd}");
        }
        public void PrintContent()
        {
            if (string.IsNullOrWhiteSpace(this.text))
            {
                Typewriter.TypewriterEffect(this.title);
                Typewriter.TypewriterEffect($"Ägare: {this.owner}, Senast updaterad: {this.lastUpdated:yyyy/mm/dd)}, Publicerad: {published:yyyy/mm/dd}");
            }
            else
            {
                Typewriter.TypewriterEffect(this.title);
                Typewriter.TypewriterEffect($"Ägare: {this.owner}, Senast updaterad: {this.lastUpdated:yyyy/mm/dd)}, Publicerad: {published:yyyy/mm/dd}");
                Typewriter.TypewriterEffect(this.text);
            }
        }

        public void EditPost()
        {
            // ConsoleKeyInfo klassen låter oss, vid ett senare skede, identifiera vad för tangent som tröcks ned.
            ConsoleKeyInfo keyInfo;
            string text = this.text;
            // Lägger till tidigare skriven text där varje ändelse \n tolkas som en ny rad
            List<string> rows = new List<string>(this.text.Split('\n'));
            string message = "Skriv ditt inlägg här (Klicka 'End' för att spara och avsluta):";
            // Genererar en padding som texten förhåller sig till
            int padding = (Console.WindowWidth - message.Length) / 2;
            Typewriter.TypewriterEffect(message);

            // Beräknar det maximala antalet rader baserat på konsolfönstrets höjd
            int maxRows = Console.WindowHeight - Console.CursorTop - 1;

            Typewriter.TypewriterEffect($"Ägare: {this.owner}, Senast updaterad: {this.lastUpdated:yyyy/mm/dd)}, Publicerad: {published:yyyy/mm/dd}");
            // Visar tidigare innehåll i konsolen
            for (int i = 0; i < rows.Count; i++)
            {
                Typewriter.TypewriterEffect(rows[i], i < rows.Count - 1, padding);
            }
            Console.SetCursorPosition(padding + rows[rows.Count - 1].Length, Console.CursorTop); // Placerar markören på given position

            do
            {
                // Låter oss identifiera vad för tangent som tröcks ned. 
                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Backspace || keyInfo.Key == ConsoleKey.Delete)
                {
                    // Kontrollerar om det sista elementet i radlistan har en längd som är större än 0.
                    if (rows[rows.Count - 1].Length > 0)
                    {
                        rows[rows.Count - 1] = rows[rows.Count - 1].Remove(rows[rows.Count - 1].Length - 1, 1);

                        // Move the cursor back and clear the character
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        Console.Write(" ");
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    }
                    else if (rows.Count > 1)
                    {
                        rows.RemoveAt(rows.Count - 1);

                        // Flyttar markören till den tidigare radens sista skrivna karaktär
                        Console.SetCursorPosition(padding + rows[rows.Count - 1].Length, Console.CursorTop - 1);
                    }
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    // Lägger till en ny rad om maximala antalet rader inte är uppnått
                    if (rows.Count < maxRows)
                    {
                        rows.Add("");
                        Console.SetCursorPosition(padding, Console.CursorTop + 1);
                    }
                }
                else
                {
                    // Kontrollerar ifall padding överskrids om ytterligare en karaktär läggs till
                    if (rows[rows.Count - 1].Length < Console.WindowWidth - 2 * padding - 1)
                    {
                        rows[rows.Count - 1] += keyInfo.KeyChar;
                        Console.Write(keyInfo.KeyChar);
                    }
                }

            } while (keyInfo.Key != ConsoleKey.End);

            // Kombinerar raderna till en individuell sträng med ny line \n för varje rad ändelse
            text = string.Join("\n", rows);

            this.SetText(text);
        }
    }
}
