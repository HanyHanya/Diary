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
            set
            {
                if (value < DateTime.Now)
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
        public string Note
        {
            get { return note; }
            set { note = value; OnPropertyChanged(); }
        }
        private bool status;
        public bool CheckStatus
        {
            get { return status; }
            set { status = value; OnPropertyChanged(); }
        }



        public Action CloseAction { get; set; }
        public Model.PrimaryModels.Task _task { get; set; }

        public RelayCommand SaveCommand { get; set; }
        public RelayCommand DelCommand { get; set; }
        public ChangeTaskViewModel(Model.PrimaryModels.Task task, MonthControlViewModel monthControlViewModel)
        {
            Name = task.Name;
            EndTime = task.EndTime;
            Note = task.Notes;
            if (task.Status == Status.Finished)
                CheckStatus = true;
            else CheckStatus = false;
            
            SaveCommand = new RelayCommand(o =>
            {
                try
                {
                    var uow = UnitOfWorkSingleton.Instance;
                    _task = uow.Tasks.GetElement(task.Id);
                    _task.Name = Name;
                    _task.EndTime = EndTime;
                    _task.Notes = Note;
                    if(CheckStatus)
                    {
                        _task.Status = Model.PrimaryModels.Status.Finished;
                    }
                    uow.SaveChanges();
                    monthControlViewModel.LoadTasksAndEvents();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
            DelCommand = new RelayCommand(o =>
            {
                try
                {
                    var uow = UnitOfWorkSingleton.Instance;
                    uow.Tasks.Delete(task.Id);
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

