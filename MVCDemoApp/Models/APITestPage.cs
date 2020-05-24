using System;
using System.ComponentModel.DataAnnotations;

namespace MVCDemoApp.Models
{
    public class APITest
    {
        public DateTime Date { get; set; }

        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Department { get; set; }
    }
}
