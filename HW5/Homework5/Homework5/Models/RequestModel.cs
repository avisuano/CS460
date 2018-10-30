using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Homework5.Models
{
    public class RequestModel
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [StringLength(64)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(64)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [Required]
        [StringLength(64)]
        [Display(Name = "Apartment Building")]
        public string Apt_Name { get; set; }

        [Required]
        [Display(Name = "Apartment Number")]
        public int Unit { get; set; }

        [Required]
        [Display(Name = "Request Explanation")]
        public string Request { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date Request was Submitted")]
        public DateTime Req_Date { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}: {FirstName} {LastName} {Phone} {Apt_Name} {Unit} {Request} {Req_Date}";
        }
    }
}