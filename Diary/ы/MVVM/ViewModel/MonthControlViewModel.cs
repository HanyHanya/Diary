using System;
using Diary.Core;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Diary.MVVM.Model.PrimaryModels;
using Diary.MVVM.Model.UnitOfWork;

namespace Diary.MVVM.ViewModel
{
    class MonthControlViewModel : ObservableObject
    {

        public RelayCommand AddTaskCommand { get; set; }
        public ObservableCollection<Task> List { get; set; }
        public MonthControlViewModel()
        {
            List = new ObservableCollection<Task>(UnitOfWorkSingleton.Instance.Tasks.List);
            foreach (Event entry in UnitOfWorkSingleton.Instance.Events.List)
            {
                List.Add(entry);
            }

            // Для демонстрации
            //var users = UnitOfWorkSingleton.Instance.Users.List.ToList();
            //var contacts = UnitOfWorkSingleton.Instance.Contacts.List.ToList();
            AddTaskCommand = new RelayCommand(o =>
            {
                new AddTaskWindow().ShowDialog();
            });
        }
    }
}
