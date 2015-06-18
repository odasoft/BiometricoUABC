using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FacialRecognition.Models;

namespace FacialRecognition.Models
{
    public class PersonModel
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string EyeColor { get; set; }
        public string EyeType { get; set; }
        public string FaceColor { get; set; }
        public string FaceShape { get; set; }
    }
}