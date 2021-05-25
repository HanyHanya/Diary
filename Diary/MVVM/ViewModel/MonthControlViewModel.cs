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
        public Task SelectedEvent { get; set; }
        public Event Selected { get; set; }

        private User _user;
        public User User
        {
            get { return _user; }
            set { _user = value; }
        }

        //через SelectedTask перепрыгнуть к окну ChangeTask/ChangeEvent в зависимости от типа, там изменпить, изменения сохранить. Вопрос только как команду запустить.
        //докинуть так же удаление

        public ObservableCollection<Task> List { get; set; }
        public MonthControlViewModel(User user)
        {
            User = user;

            List = new ObservableCollection<Task>();
            foreach (Task entry in UnitOfWorkSingleton.Instance.Tasks.List)
            {
                if (entry.UserName == user.UserName)
                {
                    List.Add(entry);
                }
            }
            foreach (Event entry in UnitOfWorkSingleton.Instance.Events.List)
            {
                if(entry.UserName == user.UserName)
                {
                    List.Add(entry);
                }
            }

            ChangeTaskCommand = new RelayCommand(o =>
            {
                if( SelectedEvent is Event)
                {
                    Selected = SelectedEvent as Event;
                    CangeEventWindow addWindow = new CangeEventWindow()
                    {
                        DataContext = new ChangeEventViewModel(Selected, this)
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

        public void LoadTasksAndEvents()
        {
            List.Clear();
            foreach (Task entry in UnitOfWorkSingleton.Instance.Tasks.List)
            {
                if (entry.UserName == User.UserName)
                {
                    List.Add(entry);
                }
            }
            foreach (Event entry in UnitOfWorkSingleton.Instance.Events.List)
            {
                if (entry.UserName == User.UserName)
                {
                    List.Add(entry);
                }
            }
        }
    }
}
