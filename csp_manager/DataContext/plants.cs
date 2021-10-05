namespace csp_manager.DataContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class plants
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public plants()
        {
            invoice_details = new HashSet<invoice_details>();
        }

        [Key]
        public int plant_id { get; set; }

        [Required]
        [StringLength(50)]
        public string plant_name { get; set; }

        public int? plant_amount { get; set; }

        [StringLength(50)]
        public string plant_unit { get; set; }

        [Column(TypeName = "ntext")]
        public string plant_note { get; set; }

        public int? plant_price { get; set; }

        public int plant_type_id { get; set; }

        public DateTime plant_created_at { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<invoice_details> invoice_details { get; set; }

        public virtual plant_type plant_type { get; set; }
    }
}
