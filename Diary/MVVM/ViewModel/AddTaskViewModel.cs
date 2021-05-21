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
    class AddTaskViewModel : ObservableObject
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }
        private DateTime? endTime;
        public DateTime? EndTime {
            get { return endTime; }
            set { endTime = value; OnPropertyChanged(); }
        }
        private string note;
        public string Note {
            get { return note; }
            set { note = value; OnPropertyChanged(); } 
        }

        public RelayCommand AddCommand { get; set; }
        public AddTaskViewModel(User user)
        {
            AddCommand = new RelayCommand(o =>
            {
                var uow = UnitOfWorkSingleton.Instance;
                uow.Tasks.Create(new Model.PrimaryModels.Task(Name, EndTime, Note, Status.Started, user));
                uow.SaveChanges();
                //ThisWindow.Close();
            });
        }
    }
}
