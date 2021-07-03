using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeloitteProject.Models
{
    public class OutputClass
    {
        [Name("# temp")]
        public dynamic temp { get; set; }
        [Name("rain_1h")]
        public dynamic rain_1h { get; set; }
        [Name("snow_1h")]
        public dynamic snow_1h { get; set; }
        [Name("clouds_all")]
        public dynamic clouds_all { get; set; }
        [Name("Prediction")]
        public dynamic Prediction { get; set; }
    }
}
