using Microsoft.VisualBasic.FileIO;
using System;
using System.Drawing;
using System.Net.Http.Headers;
using System.Reflection;
using System.Xml.Linq;

namespace Laboration_4
{
    internal static class Program
    {
        static void Main(string[] args)
        {

            List<Person> persons = new List<Person>();
            Gender gender;

            bool running = true;
            while(running)
            {
                Console.WriteLine("Var god och ange ett av följande alternativ:");
                Console.WriteLine("1. Lägg till person  \n2. Skriv ut tillagda personer \n3. Sök efter person \n4. Avsluta programmet");
                int userInput = Convert.ToInt32(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        AddPerson(persons);
                        break;
                    case 2:
                        ListPersons(persons);
                        break;
                    case 3:
                        Console.Write("Ange namnet på person som ska sökas upp: ");
                        string searchName = Console.ReadLine();
                        ListPerson(persons, searchName);
                        break;
                    case 4:
                        Console.WriteLine("Shutting down!");
                        running = false;
                        break;
                    default:
                        Console.WriteLine($"Kommandot, {userInput}, är ogiltigt"); // String interpolation
                        break;
                }
            }
        }

        public static void AddPerson(List<Person> persons)
        {
            Console.Write($"\nAnge ett av följande kön {Gender.Male}, {Gender.Female}, {Gender.Nonbinary} eller {Gender.Other}: ");
            string genderInput = ValidateGender(Console.ReadLine().ToLower());
            Console.Write("Ange ett namn på personen: ");
            string nameInput = ValidateName(Console.ReadLine());
            nameInput = nameInput.Substring(0, 1).ToUpper() + nameInput.Substring(1).ToLower();
            Console.Write($"Ange {nameInput} födelseår enligt ÅÅÅÅ: ");
            string birthYear = ValidateBirthYear(Console.ReadLine());
            Console.Write($"Ange {nameInput} födelsemånad enligt MM: ");
            string birthMonth = ValidateBirthMonth(Console.ReadLine());
            Console.Write($"Ange {nameInput} födelsedag enligt DD:");
            string birthDay = ValidateBirthDay(Console.ReadLine());
            Console.Write($"Ange {nameInput}s hårfärg: ");
            string hairColor = ValidateHairColor(Console.ReadLine());
            Console.Write($"Ange {nameInput}s hårlängd i cm: ");
            string hairLength = ValidateHairLength(Console.ReadLine());
            Console.Write($"Ange {nameInput}s ögonfärg: ");
            string eyeColorInput = Console.ReadLine();
            persons.Add(new Person(genderInput, nameInput, new Tuple<string, string, string>(birthYear, birthMonth, birthDay), new Hair(), hairColor, hairLength, eyeColorInput));
            Console.WriteLine($"{nameInput} lades till! \n");
            
        }

        public static void ListPerson(List<Person> persons, string name)
        {
            foreach(Person person in persons)
            {
                if(name == person.GetName())
                {
                    PrintInfo(person);
                }
            }

        }
        public static void ListPersons(List<Person> persons)
        {
            foreach(Person person in persons)
            {
                PrintInfo(person);
            }
        }

        public static void PrintInfo(Person person)
        {
            Console.WriteLine($"\nNamn: {person.GetName()} \nKön: {person.GetGender()} \nFödelsedag: {person.GetDateOfBirth()} \nHårfärg: {person.GetHair().GetHairColor()} \nHårlängd: {person.GetHair().GetHairLength()}cm \nÖgonfärg: {person.GetEyeColor()}\n");
        }

        public static string ValidateGender(string gender)
        {
            switch (gender)
            {
                case "male":
                    return gender;
                case "female":
                    return gender;
                case "nonbinary":
                    return gender;
                case "other":
                    return gender;
                default:
                    Console.Write("Illegalt könsargument. Ange ett giltigt kön: ");
                    gender = ValidateGender(Console.ReadLine().ToLower());
                    return gender;
            }
        }

        public static string ValidateName(string name)
        {
            if (name == null)
            {
                Console.Write("Illegalt namnargument. Ange ett giltigt namn: ");
                name = ValidateName(Console.ReadLine());
            }

            else if (!name.All(Char.IsLetter))
            {
                Console.Write("Illegalt namnargument. Ange ett giltigt namn: ");
                name = ValidateName(Console.ReadLine());
            }
            return name;
        }

        public static string ValidateBirthYear(string date)
        {
            if (date == null)
            {
                Console.Write("Illegal födelseår. Ange ett giltigt datum: ");
                date = ValidateBirthYear(Console.ReadLine());
            }
            else if (date.Length != 4 || !date.All(Char.IsNumber))
            {
                Console.Write("Illegal födelseår. Ange ett giltigt datum: ");
                date = ValidateBirthYear(Console.ReadLine());
            }
            return date;
        }
        public static string ValidateBirthMonth(string date)
        {
            if (date == null)
            {
                Console.Write("Illegal födelsemånad. Ange ett giltigt datum: ");
                date = ValidateBirthMonth(Console.ReadLine());
            }
            else if (date.Length != 2 || !date.All(Char.IsNumber))
            {
                Console.Write("Illegal födelsemånad. Ange ett giltigt datum: ");
                date = ValidateBirthMonth(Console.ReadLine());
            }
            else if (Convert.ToInt32(date) < 1 || Convert.ToInt32(date) > 12)
            {
                Console.Write("Illegal födelsemånad. Ange ett giltigt datum: ");
                date = ValidateBirthMonth(Console.ReadLine());
            }
            return date;
        }
        public static string ValidateBirthDay(string date)
        {
            if (date == null)
            {
                Console.Write("Illegal födelsedag. Ange ett giltigt datum: ");
                date = ValidateBirthDay(Console.ReadLine());
            }
            else if (date.Length != 2 || !date.All(Char.IsNumber))
            {
                Console.Write("Illegal födelsedag. Ange ett giltigt datum: ");
                date = ValidateBirthDay(Console.ReadLine());
            }
            else if (Convert.ToInt32(date) > 31 || Convert.ToInt32(date) < 1)
            {
                Console.Write("Illegalt födelsedag. Ange ett giltigt datum: ");
                date = ValidateBirthDay(Console.ReadLine());
            }
            return date;
        }

        public static string ValidateHairLength(string hairLength)
        {

            if (hairLength == null)
            {
                Console.Write("Illegalt hårlängdsargument. Ange en giltig hårlängd: ");
                hairLength = ValidateHairLength(Console.ReadLine());
            }
            else if (!hairLength.All(Char.IsNumber))
            {
                Console.Write("Illeaglt hårlängdsargument");
                hairLength = ValidateHairLength(Console.ReadLine());
            }
            return hairLength;
        }
        
        public static string ValidateHairColor(string hairColor)
        {
            if (hairColor == null)
            {
                Console.Write("Illegalt hårfärgsargument. Ange en giltig hårfärg: ");
                hairColor = ValidateHairColor(Console.ReadLine());
            }
            else if (!hairColor.All(Char.IsLetter))
            {
                Console.Write("Illegalt hårfärgsargument. Ange en giltig hårfärg: ");
                hairColor = ValidateHairColor(Console.ReadLine());
            }
            return hairColor;
        }

        public static string ValidateEyeColor(string eyeColor)
        {
            if (eyeColor == null)
            {
                Console.Write("Illegal ögonfärg. Ange en giltig ögonfärg: ");
                eyeColor = ValidateEyeColor(Console.ReadLine());
            }

            else if (!eyeColor.All(Char.IsLetter))
            {
                Console.Write("Illegal ögonfärg. Ange en giltig ögonfärg: ");
                eyeColor = ValidateEyeColor(Console.ReadLine());
            }
            return eyeColor;
        }
    }
}
