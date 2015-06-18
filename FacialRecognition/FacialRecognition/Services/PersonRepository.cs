using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FacialRecognition.Models;
using FacialRecognition.Controllers.IO;

namespace FacialRecognition.Services
{
    public class PersonRepository
    {
        //PersonModel[] persons = JsonFile.Read();
        PersonModel[] persons;
        public PersonRepository() 
        {
            persons = JsonFile.Read();
        }

        public PersonModel[] GetAllPersons() 
        {            
            return persons;
        }

        public bool SavePerson(PersonModel person) 
        {
            var currentData = persons.ToList();            
            person.PersonId = currentData.Count;
            currentData.Add(person);
            JsonFile.Save(currentData);
            return true;
        }
    }
}