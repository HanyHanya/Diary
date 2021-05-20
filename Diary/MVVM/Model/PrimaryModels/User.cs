using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diary.MVVM.Model.PrimaryModels
{
    [Table("Users")]
    public partial class User
    {
        [Key]
        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(15)]
        public string Password { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public byte[] Img { get; set; }

        public ICollection<Task> Tasks { get; set; }
        public ICollection<Event> Events { get; set; }
        public ICollection<Contact> Contacts { get; set; }

        public User()
        {
                
        }
        public User(string userName, string password, string name)
        {
            UserName = userName;
            Password = password;
            Name = name;
        }
    }
}
