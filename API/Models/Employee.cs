using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Employee Name Can't Empty, Try Again !")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Date Of Birth Can't Empty, Try Again !")]
        [DataType(DataType.Date)]
        public DateTime DateofBirth { get; set; }

        [Required(ErrorMessage = "Place Of Birth Can't Empty, Try Again !")]
        public string PlaceOfBirth { get; set; }

        [Required(ErrorMessage = "Hire Date Can't Empty, Try Again !")]
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }

        [Required(ErrorMessage = "Phone Number Can't Empty, Try Again")]
        public decimal PhoneNumber { get; set; }

        [Required(ErrorMessage = "Salary Can't Empty, Try Again !")]
        [Range(0, 9999999999.99)]
        public decimal Salary { get; set; }
    }
}
