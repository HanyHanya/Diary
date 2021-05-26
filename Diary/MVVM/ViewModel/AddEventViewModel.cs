﻿using Diary.Core;
using Diary.MVVM.Model.PrimaryModels;
using Diary.MVVM.Model.UnitOfWork;
using Diary.MVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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


        public RelayCommand AddCommand { get; set; }
        public RelayCommand AddContactCommand { get; set; }

        public AddEventViewModel(User user, MonthControlViewModel MonthVM = null)
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

            AddCommand = new RelayCommand(o =>
            {
                //try
                //{
                    var uow = UnitOfWorkSingleton.Instance;
                    uow.Events.Create(new Model.PrimaryModels.Event(Name, Start, End, Note, Status.InProcess, user, Contact, Repeat, Notification));
                    uow.SaveChanges(); //пытается создать нового юзера
                    MonthVM.LoadTasksAndEvents();
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}
            });
            AddContactCommand = new RelayCommand(o =>
            {
                try
                {
                    ContactListWindow taskWin = new ContactListWindow()
                    {
                        DataContext = new ContactListViewModel(user, this)
                    };
                    taskWin.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
        }
    }
}
