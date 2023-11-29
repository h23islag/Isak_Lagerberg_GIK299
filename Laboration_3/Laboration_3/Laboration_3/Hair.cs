using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboration_3
{
    public struct Hair
    {
        public Hair(string hairColor, int hairLength) 
        {
            HairColor = hairColor;
            HairLength = hairLength;
        }

        public string HairColor { get; set; }
        public int HairLength { get; set;}


    }
}
