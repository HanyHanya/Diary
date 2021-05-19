using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Diary.MVVM.Model
{
    public partial class ApplicationContext : DbContext
    {
        public ApplicationContext()
            : base("name=ApplicationContext")
        {
        }

        public virtual DbSet<CONTACT> CONTACT { get; set; }
        public virtual DbSet<EVENT> EVENT { get; set; }
        public virtual DbSet<EVENT_TYPE> EVENT_TYPE { get; set; }
        public virtual DbSet<REPEAT> REPEAT { get; set; }
        public virtual DbSet<STATUS> STATUS { get; set; }
        public virtual DbSet<TASK> TASK { get; set; }
        public virtual DbSet<USER> USER { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EVENT_TYPE>()
                .HasMany(e => e.EVENT)
                .WithOptional(e => e.EVENT_TYPE1)
                .HasForeignKey(e => e.EVENT_TYPE);

            modelBuilder.Entity<REPEAT>()
                .HasMany(e => e.EVENT)
                .WithOptional(e => e.REPEAT1)
                .HasForeignKey(e => e.REPEAT);

            modelBuilder.Entity<STATUS>()
                .HasMany(e => e.EVENT)
                .WithOptional(e => e.STATUS1)
                .HasForeignKey(e => e.STATUS);

            modelBuilder.Entity<STATUS>()
                .HasMany(e => e.TASK)
                .WithOptional(e => e.STATUS1)
                .HasForeignKey(e => e.STATUS);
        }
    }
}
