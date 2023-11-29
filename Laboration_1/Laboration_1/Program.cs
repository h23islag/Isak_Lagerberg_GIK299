
using System.Runtime.CompilerServices;

namespace Laboration_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> familyDict = new Dictionary<string, int>();
            List<string> members = new List<string>();

            Console.WriteLine("Ange antal familjemedlemar:");
            int numbOfMembers = int.Parse(Console.ReadLine());
            int combinedAge = 0;

            for (int i = 0; i < numbOfMembers; i++)
            {
                Console.WriteLine("Ange familjemedlemens namn:");
                string memberName = Console.ReadLine();
                Console.WriteLine("Ange " + memberName + "s ålder:");
                int memberAge = int.Parse(Console.ReadLine());
                familyDict.Add(memberName, memberAge);
                members.Add(memberName);
            }

            for (int i = 0; i < numbOfMembers; i++)
            {
                Console.WriteLine(members[i] + " är " + familyDict[members[i]] + " gammal.");
                combinedAge = combinedAge + familyDict[members[i]];
            }
            Console.WriteLine("Den genomsnittliga ålder är: " + (combinedAge / numbOfMembers));
        }
    }
}