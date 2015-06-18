using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FacialRecognition.Models;

namespace FacialRecognition.BL
{
    public class Recognition
    {
        public static bool isEqual(PersonModel personAttributes, IEnumerable<PersonModel> persons)
        {
            Compare personsComp;
            for (int i = 0; i < persons.Count(); i++)
            {
                personsComp = new Compare(personAttributes, persons.ElementAt(i));
                if(personsComp.AgeEqual() && personsComp.EarsEqual() && personsComp.EyesEqual() && personsComp.HairEqual() && personsComp.MouthEqual() && personsComp.NameEqual() && personsComp.NoseEqual() && personsComp.ShapeEqual())
                    return true;
            }
            return false;
        }
    }
}