using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboration_4
{
    public struct Hair
    {
        private string hairColor = "";
        private string hairLength = "";
        public Hair(string hairColor, string hairLength)
        {
            SetHairColor(hairColor);
            SetHairLength(hairLength);
        }

        public void SetHairColor(string hairColor) 
        { 
            this.hairColor = hairColor;
        }

        public void SetHairLength(string hairLength)
        {
            this.hairLength = hairLength;
        }

        public string GetHairColor()
        {
            return hairColor;
        }
        public string GetHairLength()
        {
            return hairLength;
        }

    }
}
