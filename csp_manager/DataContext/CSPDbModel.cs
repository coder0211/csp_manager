using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace csp_manager.DataContext
{
    public partial class CSPDbModel : DbContext
    {
        public CSPDbModel()
            : base("name=CSPDbModel")
        {
        }

        public virtual DbSet<invoice_details> invoice_details { get; set; }
        public virtual DbSet<invoices> invoices { get; set; }
        public virtual DbSet<plant_type> plant_type { get; set; }
        public virtual DbSet<plants> plants { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<users> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<invoices>()
                .HasMany(e => e.invoice_details)
                .WithRequired(e => e.invoices)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<plant_type>()
                .HasMany(e => e.plants)
                .WithRequired(e => e.plant_type)
                .HasForeignKey(e => e.plant_type_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<plants>()
                .HasMany(e => e.invoice_details)
                .WithRequired(e => e.plants)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<users>()
                .HasMany(e => e.invoices)
                .WithRequired(e => e.users)
                .WillCascadeOnDelete(false);
        }
    }
}
