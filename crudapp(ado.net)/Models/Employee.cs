using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace crudapp_ado.net_.Models
{
    public class Employee
    {
        public int id { get; set; }

        [Required]
        public string name { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public string age { get; set; }
        [Required]
        public int salary { get; set; }
        [Required]
        public string city { get; set; }

    }
}