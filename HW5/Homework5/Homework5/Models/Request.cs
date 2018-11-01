using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Homework5.Models
{
    public class Request
    {
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
        [Display(Name = "Apartment Name")]
        public string Apt_Name { get; set; }

        [Required]
        [Display(Name = "Unit Number")]
        public int Unit { get; set; }

        [Required]
        [Display(Name = "Request for maintanence")]
        public string Req_Box { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date Requests")]
        public DateTime Req_Date { get; set; }

        public override string ToString()
        {
            return $"(base.ToString()): {FirstName} {LastName} {Phone} {Apt_Name} {Req_Box} {Req_Date}";
        }
    }
}