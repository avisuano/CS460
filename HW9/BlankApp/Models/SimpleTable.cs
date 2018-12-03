namespace BlankApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SimpleTable")]
    public partial class SimpleTable
    {
        public int ID { get; set; }

        [Required]
        [StringLength(32)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(32)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }
}
