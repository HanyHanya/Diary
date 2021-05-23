using Diary.Core;
using Diary.MVVM.Model.PrimaryModels;
using Diary.MVVM.Model.UnitOfWork;
using Diary.MVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.MVVM.ViewModel
{
    class AddEventViewModel : ObservableObject
    {
        public string Name { get; set; }
        public string Note { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public Contact contact { get; set; }
        //public string ContactName { get; set; }
        public Status status { get; set; }
        public RepeatMode repeat { get; set; }
        public NotificationMode notification { get; set; }


        public RelayCommand AddCommand { get; set; }
        public RelayCommand AddContactCommand { get; set; }

        public AddEventViewModel(User user)
        {
            AddCommand = new RelayCommand(o =>
            {
                var uow = UnitOfWorkSingleton.Instance;
                uow.Events.Create(new Model.PrimaryModels.Event(Name, Start, End, Note, Status.InProcess, user, contact, RepeatMode.DoNotRepeat, NotificationMode.DoNotNotify));
                uow.SaveChanges();
                //ThisWindow.Close();
            });
            AddContactCommand = new RelayCommand(o =>
            {
                new ContactListWindow().ShowDialog();
            });
        }
    }
}
