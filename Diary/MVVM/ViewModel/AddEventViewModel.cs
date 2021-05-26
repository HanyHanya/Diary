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
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value; OnPropertyChanged();
            }
        }
        private string note;
        public string Note
        {
            get
            {
                return note;
            }
            set
            {
                note = value; OnPropertyChanged();
            }
        }
        private DateTime? start;
        public DateTime? Start
        {
            get
            {
                return start;
            }
            set
            {
                start = value; OnPropertyChanged();
            }
        }
        private DateTime? end;
        public DateTime? End
        {
            get
            {
                return end;
            }
            set
            {
                end = value; OnPropertyChanged();
            }
        }
        private Contact _contact;
        public Contact Contact
        {
            get { return _contact; }
            set { _contact = value; OnPropertyChanged(); }
        }
        private Status status;
        public Status Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value; OnPropertyChanged();
            }
        }
        private RepeatMode repeat;
        public RepeatMode Repeat
        {
            get
            {
                return repeat;
            }
            set
            {
                repeat = value; OnPropertyChanged();
            }
        }
        private NotificationMode notification;
        public NotificationMode Notification
        {
            get
            {
                return notification;
            }
            set
            {
                notification = value; OnPropertyChanged();
            }
        }


        public RelayCommand AddCommand { get; set; }
        public RelayCommand AddContactCommand { get; set; }

        public AddEventViewModel(User user, MonthControlViewModel MonthVM = null)
        {
            AddCommand = new RelayCommand(o =>
            {
                var uow = UnitOfWorkSingleton.Instance;
                uow.Events.Create(new Model.PrimaryModels.Event(Name, Start, End, Note, Status.InProcess, user, Contact, RepeatMode.DoNotRepeat, NotificationMode.DoNotNotify));
                uow.SaveChanges();
                MonthVM.LoadTasksAndEvents();
            });
            AddContactCommand = new RelayCommand(o =>
            {
                ContactListWindow taskWin = new ContactListWindow()
                {
                    DataContext = new ContactListViewModel(user, this)
                };
                taskWin.ShowDialog();
            });
        }
    }
}
