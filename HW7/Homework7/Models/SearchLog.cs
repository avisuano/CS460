namespace Homework7.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SearchLog
    {
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Search { get; set; }

        [Required]
        [StringLength(15)]
        public string SearchIP { get; set; }

        [Required]
        [StringLength(100)]
        public string SearchB { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
