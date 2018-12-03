namespace Homework8.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Item()
        {
            Bids = new HashSet<Bid>();
        }

        [Display(Name = "Item Id:")]
        public int ItemID { get; set; }

        [Required]
        [StringLength(32)]
        [Display(Name = "Item name: ")]
        public string ItemName { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "Description:")]
        public string ItemDescription { get; set; }

        [Display(Name = "Seller Id:")]
        public int SellerID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bid> Bids { get; set; }

        public virtual Seller Seller { get; set; }
    }
}
