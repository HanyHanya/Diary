using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diary.MVVM.Model.PrimaryModels
{
    [Table("Events")]
    public class Event : Task
    {
       
        public DateTime? StartTime { get; set; }

        public int? ContactId { get; set; }

        public Contact Contact { get; set; }

        public RepeatMode RepeatMode { get; set; }
        public NotificationMode NotificationMode { get; set; }

        public Event()
        {

        }
        public Event(string name, DateTime? startTime, DateTime? endTime, string notes, Status status, User user,  Contact contact, RepeatMode repeatMode, NotificationMode notificationMode) : base( name, endTime, notes, status, user)
        {
            StartTime = startTime;
            Contact = contact;
            RepeatMode = repeatMode;
            NotificationMode = notificationMode;
        }
    }
}
