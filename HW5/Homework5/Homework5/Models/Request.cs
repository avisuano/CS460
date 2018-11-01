using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Homework5.Models
{
    /// <summary>
    /// Request object for maintenance requests
    /// </summary>
    public class Request
    {
        /// <summary>
        /// Primary key, automatically generated
        /// </summary>
        [Required]
        public int ID { get; set; }

        /// <summary>
        /// First name of the individual requesting maintenance
        /// </summary>
        [Required]
        [StringLength(64)]
        [Display(Name = "First Name: ")]
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of the individual requesting maintenance
        /// </summary>
        [Required]
        [StringLength(64)]
        [Display(Name = "Last Name: ")]
        public string LastName { get; set; }

        /// <summary>
        /// Phone number of the individual requesting maintenance
        /// </summary>
        [Required]
        [StringLength(10)]
        [Display(Name = "Phone Number: ")]
        public string Phone { get; set; }

        /// <summary>
        /// Name of the apartment in need of maintenance
        /// </summary>
        [Required]
        [StringLength(64)]
        [Display(Name = "Apartment Name: ")]
        public string Apt_Name { get; set; }

        /// <summary>
        /// Specific room/area in need of maintenance
        /// </summary>
        [Required]
        [Display(Name = "Unit Number: ")]
        public int Unit { get; set; }

        /// <summary>
        /// Brief summary of what needs repaired
        /// </summary>
        [Required]
        [Display(Name = "Request: ")]
        public string Req_Box { get; set; }

        /// <summary>
        /// Date request was submitted
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Request:")]
        public DateTime Req_Date { get; set; }

        /// <summary>
        /// Override for the ToString method to output this model
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"(base.ToString()): {FirstName} {LastName} Phone = {Phone} Apt_Name = {Apt_Name} Req_Box = {Req_Box}";
        }
    }
}