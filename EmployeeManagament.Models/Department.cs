using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeManagament.Models
{
   public class Department
    {
        [Key]
        public int DepartementID { get; set; }
        public string DepartementName { get; set; }
    }
}
