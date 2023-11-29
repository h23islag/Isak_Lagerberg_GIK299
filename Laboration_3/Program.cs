namespace Laboration_3
{
    internal class Program
    {
        private static Tuple<int, int, int> dateOfBirth;
        private static Gender gender = Gender.Male;
        private static int birthYear;
        private static int birthMonth;
        private static int birthDay;
        private static Hair hair;
        private static string eyeColor;
        static void Main(string[] args)
        {
            birthYear = 2002;
            birthMonth = 4;
            birthDay = 19;
            dateOfBirth =  new Tuple<int, int, int>(birthYear, birthMonth, birthDay);
            hair = new Hair();
            hair.HairLength = 3;
            hair.HairColor = "Yellow";
            eyeColor = "Green";
            Person person = new Person(gender, dateOfBirth,hair, eyeColor);

            Console.WriteLine("The persons gender is: " + person.getGender().ToString());
            Console.WriteLine("The persons date of birth is: {0}-{1}-{2}", person.getdateOfBirth().Item1, person.getdateOfBirth().Item2, person.getdateOfBirth().Item3);
            Console.WriteLine("The persons hair length is: " + person.getHair().HairLength + "cm");
            Console.WriteLine("The persons hair color is: " + person.getHair().HairColor);
            Console.WriteLine("The persons eye color is: " + person.getEyeColor());

        }
    }
}