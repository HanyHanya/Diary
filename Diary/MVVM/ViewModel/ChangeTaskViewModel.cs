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
    class ChangeTaskViewModel : ObservableObject
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = Convert.ToString(value); OnPropertyChanged(); }
        }
        private DateTime? endTime;
        public DateTime? EndTime
        {
            get { return endTime; }
            set { endTime = value; OnPropertyChanged(); }
        }
        private string note;
        public string Note
        {
            get { return note; }
            set { note = value; OnPropertyChanged(); }
        }


        public Action CloseAction { get; set; }

        public RelayCommand SaveCommand { get; set; }
        public RelayCommand DelCommand { get; set; }
        public ChangeTaskViewModel(Model.PrimaryModels.Task task, MonthControlViewModel monthControlViewModel)
        {
            Name = task.Name;
            EndTime = task.EndTime;
            note = task.Notes;
            SaveCommand = new RelayCommand(o =>
            {
                var uow = UnitOfWorkSingleton.Instance;
                uow.SaveChanges();
                monthControlViewModel.LoadTasksAndEvents();
            });
            DelCommand = new RelayCommand(o =>
            {
                var uow = UnitOfWorkSingleton.Instance;
                uow.Tasks.Delete(task.Id);
                monthControlViewModel.LoadTasksAndEvents();
                uow.SaveChanges();
            });
        }
    }
}

