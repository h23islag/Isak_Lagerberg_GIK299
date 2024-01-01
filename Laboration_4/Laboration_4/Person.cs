using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Laboration_4
{
    internal class Person
    {

        private Gender gender;
        private string name;
        private string dateOfBirth;
        private Hair hair;
        private string eyeColor;

        public Person(string gender, string name, Tuple<string, string, string> dateOfBirth, Hair hair, string hairColor, string hairLength, string eyeColor)
        {
            SetGender(gender);
            SetName(name);
            SetDateOfBirth(dateOfBirth);
            SetHair(hair, hairColor, hairLength);
            SetEyeColor(eyeColor);
        }
        public Gender GetGender()
        {
            return this.gender;
        }
        public string GetName() 
        {
            return this.name;
        }
        public string GetDateOfBirth()
        {
            return this.dateOfBirth;
        }
        public Hair GetHair()
        {
            return hair;
        }
        public string GetEyeColor()
        {
            return eyeColor;
        }
        public void SetGender(string gender)
        {
            switch(gender)
            {
                case "male":
                    this.gender = Gender.Male;
                    break;
                case "female":
                    this.gender = Gender.Female;
                    break;
                case "nonbinary":
                    this.gender = Gender.Nonbinary;
                    break;
                case "other":
                    this.gender = Gender.Other;
                    break;
            }
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public void SetDateOfBirth(Tuple<string, string, string> dateOfBirth)
        {
            this.dateOfBirth = $"{dateOfBirth.Item1}-{dateOfBirth.Item2}-{dateOfBirth.Item3}";
        }
        public void SetHair(Hair hair, string hairColor, string hairLength)
        {
            hairColor = hairColor.Substring(0, 1).ToUpper() + hairColor.Substring(1).ToLower();
            this.hair = hair;
            this.hair.SetHairColor(hairColor);
            this.hair.SetHairLength(hairLength);
        }
        public void SetEyeColor(string eyeColor)
        {
            eyeColor = eyeColor.Substring(0, 1).ToUpper() + eyeColor.Substring(1).ToLower();
            this.eyeColor = eyeColor;
        }


    }
}
