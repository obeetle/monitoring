using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebApplication2.Models
{
    public class Markers
    {
        [HiddenInput(DisplayValue = false)]
        public int id { set; get; }
        [Required]
        public string name { set; get; }
        [Required]
        public float x { set; get; }
        [Required]
        public float y { set; get; }
    }
}