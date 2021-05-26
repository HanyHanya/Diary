using Diary.Core;
using Diary.MVVM.Model.PrimaryModels;
using Diary.MVVM.Model.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.MVVM.ViewModel
{
    class ChangeEventViewModel : ObservableObject
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

        public Event _event { get; set; }          

        public RelayCommand SaveCommand { get; set; }
        public RelayCommand DelCommand { get; set; }

        public ChangeEventViewModel(Diary.MVVM.Model.PrimaryModels.Event _SelectedEvent, MonthControlViewModel MonthVM)
        {
            Note = _SelectedEvent.Notes;
            Name = _SelectedEvent.Name;
            Start = _SelectedEvent.StartTime;
            End = _SelectedEvent.EndTime;
            Status = _SelectedEvent.Status;
            Repeat = _SelectedEvent.RepeatMode;
            notification = _SelectedEvent.NotificationMode;

            SaveCommand = new RelayCommand(o =>
            {
                var uow = UnitOfWorkSingleton.Instance;
                _event = uow.Events.GetElement(_SelectedEvent.Id);
                _event.Name = Name;
                _event.Notes = Note;
                _event.EndTime = End;
                _event.StartTime = Start;
                _event.Status = Status;
                _event.RepeatMode = Repeat;
                _event.NotificationMode = notification;
                uow.SaveChanges();
                MonthVM.LoadTasksAndEvents();
            });
            DelCommand = new RelayCommand(o =>
            {
                var uow = UnitOfWorkSingleton.Instance;
                uow.Events.Delete(_event.Id);
                MonthVM.LoadTasksAndEvents();
                uow.SaveChanges();
            });
        }
    }
}
