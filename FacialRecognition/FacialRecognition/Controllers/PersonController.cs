using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FacialRecognition.Models;
using FacialRecognition.Services;
using System.Collections;

namespace FacialRecognition.Controllers
{
    public class PersonController : ApiController
    {
        private PersonRepository personRepository;
        public PersonController() 
        {
            this.personRepository = new PersonRepository();
        }
        public PersonModel[] GetAllPersons() 
        {
            return this.personRepository.GetAllPersons();
        }

        public PersonModel[] GetAllPersonByAge(int age) 
        {
            PersonModel[] persons = GetAllPersons();
            List<PersonModel> list = new List<PersonModel>();
            if (persons == null)
                return null;
            foreach(PersonModel p in persons)
            {
                if(p.Age == age)
                {
                    list.Add(p);
                }
            }
            return list.ToArray();
        }

        public PersonModel GetPersonById(int personid)
        {
            PersonModel[] persons = GetAllPersons();
            if (persons == null)
                return null;
            var person = persons.FirstOrDefault((p) => p.PersonId == personid);
            return person;
        }

        public PersonModel[] GetPersonByAgeAndName(int age, string name)
        {
            PersonModel[] persons = GetAllPersons();
            List<PersonModel> list = new List<PersonModel>();
            if (persons == null)
                return null;
            foreach (PersonModel p in persons)
            {
                if (p.Age == age && p.Name.Equals(name))
                {
                    list.Add(p);
                }
            }
            return list.ToArray();
        }

        public PersonModel[] GetPersonByAgeAndEyeColors(int age, string eyecolor)
        {
            PersonModel[] persons = GetAllPersons();
            List<PersonModel> list = new List<PersonModel>();
            if (persons == null)
                return null;
            foreach (PersonModel p in persons)
            {
                if (p.Age == age && p.EyeColor.Equals(eyecolor))
                {                    
                    list.Add(p);
                }
            }
            return list.ToArray();
        }

        public PersonModel[] GetPersonByAgeAndEyeColorsAndEyeType(int age, string eyecolor, string eyetype)
        {
            PersonModel[] persons = GetAllPersons();
            List<PersonModel> list = new List<PersonModel>();
            if (persons == null)
                return null;
            foreach (PersonModel p in persons)
            {
                if (p.Age == age && p.EyeColor.Equals(eyecolor) && p.EyeType.Equals(eyetype))
                {
                    list.Add(p);
                }
            }
            return list.ToArray();
        }

        public PersonModel[] GetPersonByAgeAndEyeColorsAndEyeTypeAmdFaceColor(int age, string eyecolor, string eyetype, string facecolor)
        {
            PersonModel[] persons = GetAllPersons();
            List<PersonModel> list = new List<PersonModel>();
            if (persons == null)
                return null;
            foreach (PersonModel p in persons)
            {
                if (p.Age == age && p.EyeColor.Equals(eyecolor) && p.EyeType.Equals(eyetype) && p.FaceColor.Equals(facecolor))
                {
                    list.Add(p);
                }
            }
            return list.ToArray();
        }

        public PersonModel[] GetPersonByAgeAndEyeColorsAndEyeTypeAmdFaceColorAndFaceShape(int age, string eyecolor, string eyetype, string facecolor, string faceshape)
        {
            PersonModel[] persons = GetAllPersons();
            List<PersonModel> list = new List<PersonModel>();
            if (persons == null)
                return null;
            foreach (PersonModel p in persons)
            {
                if (p.Age == age && p.EyeColor.Equals(eyecolor) && p.EyeType.Equals(eyetype) && p.FaceColor.Equals(facecolor) && p.FaceShape.Equals(faceshape))
                {
                    list.Add(p);
                }
            }
            return list.ToArray();
        }

        public PersonModel[] GetPersonEyeColorsAndEyeTypeAmdFaceColorAndFaceShape(string eyecolor, string eyetype, string facecolor, string faceshape)
        {
            PersonModel[] persons = GetAllPersons();
            List<PersonModel> list = new List<PersonModel>();
            if (persons == null)
                return null;
            foreach (PersonModel p in persons)
            {
                if (p.EyeColor.Equals(eyecolor) && p.EyeType.Equals(eyetype) && p.FaceColor.Equals(facecolor) && p.FaceShape.Equals(faceshape))
                {
                    list.Add(p);
                }
            }
            return list.ToArray();
        }

        public PersonModel GetPersonByAgeById(int age, int personid)
        {
            PersonModel[] persons = GetAllPersons();
            List<PersonModel> list = new List<PersonModel>();
            if (persons == null)
                return null;
            foreach (PersonModel p in persons)
            {
                if (p.Age == age)
                {
                    list.Add(p);
                }
            }
            var person = list.ToArray().FirstOrDefault((p) => p.PersonId == personid);
            return person;
        }

        public HttpResponseMessage Post(PersonModel person) 
        {
            //System.Diagnostics.Debug.WriteLine("Llego hasta aqui yei");

            this.personRepository.SavePerson(person);
            var response = Request.CreateResponse<PersonModel>(System.Net.HttpStatusCode.Created, person);
            return response;
        }
    }
}
