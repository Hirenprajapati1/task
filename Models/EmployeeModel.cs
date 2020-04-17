using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace task1.Models
{
    public class EmployeeModel
    {

        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]

        public string EmployeeCode { get; set; }
        public string Gender { get; set; }

        public int Designation { get; set; }

        public int Department { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public int Salary { get; set; }


    }
}
