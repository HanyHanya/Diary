using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diary.MVVM.Model.PrimaryModels
{
    [Table("Contacts")]
    public class Contact
    {

        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(20)]
        public string TelNum { get; set; }

        public string Notes { get; set; }

        public ICollection<Event> Events { get; set; }

        public User User { get; set; }
        public string UserName { get; set; }

        public Contact(int id, string name, string telNum, string notes, User user)
        {
            Id = id;
            Name = name;
            TelNum = telNum;
            Notes = notes;
            User = user;
        }

        public Contact()
        {

        }
    }
}
