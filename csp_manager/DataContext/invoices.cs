namespace csp_manager.DataContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class invoices
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public invoices()
        {
            invoice_details = new HashSet<invoice_details>();
        }

        [Key]
        public int invoice_id { get; set; }

        public int user_id { get; set; }

        [Required]
        [StringLength(50)]
        public string customer_name { get; set; }

        [Required]
        [StringLength(50)]
        public string customer_phone_number { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string customer_address { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string invoice_note { get; set; }

        public DateTime invoice_created_at { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<invoice_details> invoice_details { get; set; }

        public virtual users users { get; set; }
    }
}
