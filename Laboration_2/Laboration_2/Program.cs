
using System.Data;
using System.Runtime.CompilerServices;

namespace Laboration_1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, int> familyDict = new Dictionary<string, int>();
            List<string> members = new List<string>();

            bool running = true;
            do
            {
                Console.WriteLine("Var god och ange ett av följande alternativ:");
                Console.WriteLine("1. Lägg till familjemedlemmar  \n2. Skriv ut tillagda familjemedlemmar \n3. Skriv ut summan av de tillagda familjemedlemarna \n4. Skriv ut medelåldern för de tillagda familjemedlemmarna \n5. Avsluta programmet");
                int userInput = Convert.ToInt32(Console.ReadLine());
                switch (userInput)
                {
                    case 1:
                        Console.WriteLine("Ange antal familjemedlemars ska läggas till:");
                        addMember(int.Parse(Console.ReadLine()), familyDict, members);
                        break;
                    case 2:
                        printMembers(familyDict, members);
                        break;
                    case 3:
                        printSumAge(members, familyDict);
                        break;
                    case 4:
                        printAverageAge(members, familyDict);
                        break;
                    case 5:
                        running = false;
                        break;
                }
            }
            while (running);
        }

        public static void addMember(int numbOfMembers, Dictionary<string, int> familyDict, List<string> members)
        {
            for (int i = 0; i < numbOfMembers; i++)
            {
                Console.WriteLine("Ange familjemedlemens namn:");
                string memberName = Console.ReadLine();
                Console.WriteLine("Ange " + memberName + "s ålder:");
                int memberAge = int.Parse(Console.ReadLine());
                familyDict.Add(memberName, memberAge);
                members.Add(memberName);
            }
        }

        public static void printMembers(Dictionary<string, int> familyDict, List<string> members)
        {
            if(members.Count <= 0)
            {
                Console.WriteLine("Familjemedlemmar saknas. Var god och lägg till en eller flera familjemedlemmar!");
                return;
            }
            for (int i = 0; i < members.Count; i++)
            {
                Console.WriteLine(members[i] + " är " + familyDict[members[i]] + "år gammal.");
            }
        }

        public static void printSumAge(List<string> members, Dictionary<string, int> familyDict)
        {
            if (members.Count <= 0)
            {
                Console.WriteLine("Familjemedlemmar saknas. Var god och lägg till en eller flera familjemedlemmar!");
                return;
            }
            int ageSum = 0;
            for(int i = 0; i < members.Count; i++) 
            {
                ageSum = ageSum + familyDict[members[i]];
            }
            Console.WriteLine("Summan av tillagda familjemedlemmar är: " + ageSum + "år");
        }
        
        public static void printAverageAge(List<string> members, Dictionary<string, int> familyDict)
        {
            if(members.Count <= 0)
            {
                Console.WriteLine("Familjemedlemmar saknas. Var god och lägg till en eller flera familjemedlemmar!");
                return;
            }
            int ageSum = 0;
            for (int i = 0; i < members.Count; i++)
            {
                ageSum = ageSum + familyDict[members[i]];
            }
            Console.WriteLine("Den genomsnittliga ålder är: " + (ageSum / members.Count) + "år");
        }
    }
}