using System;
using System.ComponentModel.DataAnnotations;

namespace MVCDemoApp.Models
{
    public class Employee
    {
        public int ID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string KnownAs { get; set; }

        [Required]
        public string Department { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public DateTime DateStart { get; set; }

        [Required]
        public DateTime DateEnd { get; set; }
    }
}