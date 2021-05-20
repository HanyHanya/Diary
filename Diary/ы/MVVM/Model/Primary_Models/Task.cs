using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diary.MVVM.Model.PrimaryModels
{
    [Table("Tasks")]
    public partial class Task
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
        public DateTime? EndTime { get; set; }
        public string Notes { get; set; }

        public Status Status { get; set; }

        public User User { get; set; }
        public string UserName { get; set; }

        public Task()
        {

        }
        public Task(int id, string name, DateTime? endTime, string notes, Status status, User user)
        {
            Name = name;
            Id = id;
            EndTime = endTime;
            Notes = notes;
            Status = status;
            User = user;
        }
    }
}
