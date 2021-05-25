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
        public string Name { get; set; }
        public string Note { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }

        private Contact _contact;

        public Contact Contact
        {
            get { return _contact; }
            set { _contact = value; OnPropertyChanged(); }
        }

        //public string ContactName { get; set; }
        public Status status { get; set; }
        public RepeatMode repeat { get; set; }
        public NotificationMode notification { get; set; }


        public RelayCommand SaveCommand { get; set; }
        public RelayCommand DelCommand { get; set; }

        public ChangeEventViewModel(Diary.MVVM.Model.PrimaryModels.Event _event, MonthControlViewModel MonthVM)
        {
            SaveCommand = new RelayCommand(o =>
            {
                var uow = UnitOfWorkSingleton.Instance;
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
