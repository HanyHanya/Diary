using System;
using Diary.Core;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Diary.MVVM.Model.PrimaryModels;
using Diary.MVVM.Model.UnitOfWork;
using System.Windows;
using Diary.MVVM.View;

namespace Diary.MVVM.ViewModel
{
    class MonthControlViewModel : ObservableObject
    {
        public RelayCommand ChangeTaskCommand { get; set; }
        public RelayCommand ChangeDateCommand { get; set; }
        public Task SelectedEvent { get; set; }
        public Event Selected { get; set; }

        private bool status;
        public bool CheckStatus
        {
            get { return status; }
            set { status = value; OnPropertyChanged(); }
        }

        private DateTime selecteddate;

        public DateTime SelectedDate
        {
            get { return selecteddate; }
            set { selecteddate = value; OnPropertyChanged(); }
        }



        private User _user;
        public User User
        {
            get { return _user; }
            set { _user = value; }
        }

        public ObservableCollection<Task> List { get; set; }
        public ObservableCollection<Task> SortList { get; set; }
        public MonthControlViewModel(User user)
        {
            User = user;

            List = new ObservableCollection<Task>();
            SelectedDate = DateTime.Now;
            LoadTasksAndEvents();
            ChangeDateCommand = new RelayCommand(o =>
            {
                LoadTasksAndEvents();
            });
            ChangeTaskCommand = new RelayCommand(o =>
            {
                if( SelectedEvent is Event)
                {
                    Selected = SelectedEvent as Event;
                    CangeEventWindow addWindow = new CangeEventWindow()
                    {
                        DataContext = new ChangeEventViewModel(Selected, this, user)
                    };
                    addWindow.ShowDialog();
                    LoadTasksAndEvents();
                }
                else if (SelectedEvent is Task)
                {
                    CangeTaskWindow addWindow = new CangeTaskWindow()
                    {
                        DataContext = new ChangeTaskViewModel(SelectedEvent, this)
                    };
                    addWindow.ShowDialog();
                    LoadTasksAndEvents();
                }
                else if (SelectedEvent == null)
                {
                    MessageBox.Show("Выберите событие/задачу");
                }
                
            });
        }

        public Event ev { get; set; }
        public void LoadTasksAndEvents()
        {
            List.Clear();
            foreach (Task entry in UnitOfWorkSingleton.Instance.Tasks.List)
            {
                if (entry.UserName == User.UserName && entry.EndTime >= SelectedDate)
                {
                    if(entry is Event )
                    {
                        ev = entry as Event;
                        DateTime d = (DateTime)ev.StartTime;
                        if(d.Day <= SelectedDate.Day)
                        {
                            ev.Status = Status.InProcess;
                            List.Add(ev);
                        }
                    }
                    else
                    {
                        List.Add(entry);
                        if (entry.Status == MVVM.Model.PrimaryModels.Status.Finished)
                            CheckStatus = true;
                        else CheckStatus = false;
                    }                    
                }
            }
        }

    }
}
