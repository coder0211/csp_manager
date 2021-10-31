namespace csp_manager.DataContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class invoice_details
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int invoice_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int plant_id { get; set; }

        public int plant_amount { get; set; }

        public int plant_price { get; set; }

        public virtual invoices invoices { get; set; }

        public virtual plants plants { get; set; }
    }
}
