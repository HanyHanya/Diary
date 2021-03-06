using Diary.Core;
using Diary.MVVM.Model.PrimaryModels;
using Diary.MVVM.Model.UnitOfWork;
using Diary.MVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Diary.MVVM.ViewModel
{
    class AddTaskViewModel : ObservableObject
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = Convert.ToString(value); OnPropertyChanged(); }
        }
        private DateTime? endTime;
        public DateTime? EndTime {
            get { return endTime; }
            set 
            { 
                if(value < DateTime.Now)
                {
                    MessageBox.Show("Выберите корректную дату окончания");
                }
                else
                {
                    endTime = value;
                    OnPropertyChanged();
                }                
            }
        }
        private string note;
        public string Note {
            get { return note; }
            set { note = value; OnPropertyChanged(); } 
        }


        public Action CloseAction { get; set; }

        public RelayCommand AddCommand { get; set; }
        public AddTaskViewModel(User user, MonthControlViewModel monthControlViewModel = null)
        {
            AddCommand = new RelayCommand(o =>
            {
                try
                {
                    var uow = UnitOfWorkSingleton.Instance;
                    uow.Tasks.Create(new Model.PrimaryModels.Task(Name, EndTime, Note, Status.Started, user));
                    uow.SaveChanges();
                    monthControlViewModel.LoadTasksAndEvents();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            });
            
        }
    }
}
