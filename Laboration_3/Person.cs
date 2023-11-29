using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Laboration_3
{
    
    internal class Person
    {
        private string _gender;
        private Gender gender;
        private Tuple<int, int, int> dateOfBirth;
        private Hair hair;
        private string eyeColor;

        public Person(Gender gender, Tuple <int, int, int> dateOfBirth, Hair hair, string eyeColor)
        {
            if (hair.HairLength < 0)
            {
                throw new ArgumentException("Hårlängden kan inte vara negativ!");
            }


            this.gender = gender;
            this.dateOfBirth = dateOfBirth;
            this.hair = hair;
            this.eyeColor = eyeColor;
            
        }
        public Gender getGender()
        { 
            return this.gender;
        }
        public Tuple<int, int, int> getdateOfBirth()
        {
            return this.dateOfBirth;
        }
        public Hair getHair() 
        {
            return hair;
        }
        public string getEyeColor()
        {
            return eyeColor;
        }
    }
}
