using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab09Web.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public bool IsTecsup { get; set; }
    }
}