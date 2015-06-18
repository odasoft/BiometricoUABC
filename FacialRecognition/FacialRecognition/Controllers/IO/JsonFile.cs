using FacialRecognition.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FacialRecognition.Controllers.IO
{
    public class JsonFile
    {
        public static PersonModel[] Read()
        {
            string path = HttpContext.Current.Server.MapPath("~/Data/person.json");
            PersonModel[] p;
            System.Diagnostics.Debug.WriteLine(path);            
            
            using (StreamReader file = File.OpenText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                p = (PersonModel[])serializer.Deserialize(file, typeof(PersonModel[]));
            }
            return p;       
        }

        public static void Save(List<PersonModel> person)
        {
            string path = HttpContext.Current.Server.MapPath("~/Data/person.json");
            using(StreamWriter file = File.CreateText(@""+path))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, person);
            }
        }
    }
}