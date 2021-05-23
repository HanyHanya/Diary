﻿using System;
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
        public Task SelectedEvent { get; set; }
        public ObservableCollection<Task> List { get; set; }
        public MonthControlViewModel(User user)
        {
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

            // Для демонстрации
            //var users = UnitOfWorkSingleton.Instance.Users.List.ToList();
            //var contacts = UnitOfWorkSingleton.Instance.Contacts.List.ToList();
            AddTaskCommand = new RelayCommand(o =>
            {
                AddTaskWindow addWindow = new AddTaskWindow()
                {
                    DataContext = new AddTaskViewModel(user)
                };
                addWindow.ShowDialog();
                List.Clear();
                foreach (Task entry in UnitOfWorkSingleton.Instance.Tasks.List)
                {
                    if (entry.UserName == user.UserName)
                    {
                        List.Add(entry);
                    }
                }
                foreach (Event entry in UnitOfWorkSingleton.Instance.Events.List)
                {
                    if (entry.UserName == user.UserName)
                    {
                        List.Add(entry);
                    }
                }
            });
        }
    }
}
