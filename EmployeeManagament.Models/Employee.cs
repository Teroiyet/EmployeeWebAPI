using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagament.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        [Required]
        [StringLength(100,MinimumLength =2)]

        public string FirstName { get; set; }
        [Required]

        public string LastName { get; set; }
        [Required]

        public string Email { get; set ; }
        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        public int DepartementID { get; set; }

        public string PhotoPath { get; set; }

    }

    public enum Gender
    {
        Male , Female

    }
     
}
