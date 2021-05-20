using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using Diary.MVVM.Model.PrimaryModels;

namespace Diary.MVVM.Model
{
    public partial class ApplicationContext : DbContext
    {
        public ApplicationContext()
            : base("name=ApplicationContext")
        {
        }

        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // ����� ������ ��������� Table ����� ������� ��� ��������� ����� ������
            //modelBuilder.Entity<Task>().ToTable("Tasks");
            //modelBuilder.Entity<Event>().ToTable("Events");
            
            // ��� �� ����� ����� ������ ��� ���������� ��� �������� ������������� �������� - ��������� �� ��������, ��� ������������ ��� ��� �������� � null, ��� ��������� ����� ��������

            /*
            modelBuilder.Entity<EventType>()
                .HasMany(e => e.EVENT)
                .WithOptional(e => e.EVENT_TYPE1)
                .HasForeignKey(e => e.EVENT_TYPE);

            modelBuilder.Entity<Repeat>()
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
                .HasForeignKey(e => e.STATUS);*/
        }
    }
}
