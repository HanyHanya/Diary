using Diary.Core;
using Diary.MVVM.Model.PrimaryModels;
using Diary.MVVM.Model.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
                if (value >= DateTime.Now.Date)
                {
                    start = value;
                    OnPropertyChanged();
                }
                else
                {
                    MessageBox.Show("Выберите корректную дату начала");
                }
            }
        }
        private DateTime? starttime;
        public DateTime? StartTime
        {
            get
            {
                return starttime;
            }
            set
            {
                starttime = value; OnPropertyChanged();
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
                if (value >= Start)
                {
                    end = value;
                    OnPropertyChanged();
                }
                else
                {
                    MessageBox.Show("Выберите корректную дату окончания");
                }
            }
        }
        private DateTime? endtime;
        public DateTime? EndTime
        {
            get
            {
                return endtime;
            }
            set
            {
                endtime = value; OnPropertyChanged();
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


        private List<RepeatMode> repeatList;
        public List<RepeatMode> RepeatList
        {
            get
            {
                return repeatList;
            }
            set
            {
                repeatList = value; OnPropertyChanged();
            }
        }
        private List<NotificationMode> notificationList;
        public List<NotificationMode> NotificationList
        {
            get
            {
                return notificationList;
            }
            set
            {
                notificationList = value; OnPropertyChanged();
            }
        }

        public Event _event { get; set; }          

        public RelayCommand SaveCommand { get; set; }
        public RelayCommand DelCommand { get; set; }
        public RelayCommand AddContactCommand { get; set; }

        public ChangeEventViewModel(Diary.MVVM.Model.PrimaryModels.Event _SelectedEvent, MonthControlViewModel MonthVM, User user)
        {
            RepeatList = new List<RepeatMode>();
            RepeatList.Add(RepeatMode.DoNotRepeat);
            RepeatList.Add(RepeatMode.RepeatDaily);
            RepeatList.Add(RepeatMode.RepeatMonthly);
            RepeatList.Add(RepeatMode.RepeatTwiceAWeek);
            RepeatList.Add(RepeatMode.RepeatWeekly);

            NotificationList = new List<NotificationMode>();
            NotificationList.Add(NotificationMode.DoNotNotify);
            NotificationList.Add(NotificationMode.NotifyDayBefore);
            NotificationList.Add(NotificationMode.NotifyHourBefore);
            NotificationList.Add(NotificationMode.NotifyThreeDaysBefore);
            NotificationList.Add(NotificationMode.NotifyThreeHoursBefore);

            var uow = UnitOfWorkSingleton.Instance;

            Note = _SelectedEvent.Notes;
            Name = _SelectedEvent.Name;
            Start = _SelectedEvent.StartTime;
            StartTime = _SelectedEvent.StartTime;
            End = _SelectedEvent.EndTime;
            EndTime = _SelectedEvent.EndTime;
            Status = _SelectedEvent.Status;
            Repeat = _SelectedEvent.RepeatMode;
            Notification = _SelectedEvent.NotificationMode;
            Contact = uow.Contacts.GetElement(_SelectedEvent.ContactId);
            
            _event = uow.Events.GetElement(_SelectedEvent.Id);

            SaveCommand = new RelayCommand(o =>
            {
                try
                {                    
                    _event.Name = Name;
                    _event.Notes = Note;
                    _event.EndTime = ChangeTime((DateTime)End, (DateTime)EndTime);
                    _event.StartTime = ChangeTime((DateTime)Start, (DateTime)StartTime);
                    _event.Status = Status;
                    _event.RepeatMode = Repeat;
                    _event.NotificationMode = Notification;
                    _event.ContactId = Contact?.Id;
                    uow.SaveChanges();
                    MonthVM.LoadTasksAndEvents();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            });
            DelCommand = new RelayCommand(o =>
            {
                try
                {
                    //var uow = UnitOfWorkSingleton.Instance;
                    uow.Events.Delete(_event.Id);
                    uow.SaveChanges();
                    MonthVM.LoadTasksAndEvents();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }                
            }); 
            AddContactCommand = new RelayCommand(o =>
            {
                try
                {
                    ContactListWindow taskWin = new ContactListWindow()
                    {
                        DataContext = new ContactListViewModel(user,null, this)
                    };
                    taskWin.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
        }

        public static DateTime? ChangeTime(DateTime date, DateTime time)
        {
            return new DateTime(
                date.Year,
                date.Month,
                date.Day,
                time.Hour,
                time.Minute,
                time.Second,
                time.Millisecond,
                date.Kind);
        }
    }
}
