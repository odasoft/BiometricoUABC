using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace FacialRecognition
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            //config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Person",
                routeTemplate: "api/recognition/person/{personid}",
                defaults: new { controller = "person", personid = RouteParameter.Optional }
                //constraints: new { personid= "/d+" }
            );
            
            /*
            config.Routes.MapHttpRoute(
                name: "Face",
                routeTemplate: "api/recognition/person/{personid}/face/{faceid}",
                defaults: new { controller = "face", faceid = RouteParameter.Optional }
                //constraints: new { personid= "/d+" }
            );
            */
            
            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().FirstOrDefault();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
