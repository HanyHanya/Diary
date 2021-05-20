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
        public RelayCommand AddCommand { get; set; }
        public AddTaskViewModel(AddTaskWindow ThisWindow)
        {
            AddCommand = new RelayCommand(o =>
            {
                var uow = UnitOfWorkSingleton.Instance;
                //uow.Tasks.Create(new Model.PrimaryModels.Task(1, "Сделать бд кошкомальчиков", DateTime.Now, "Кошкомальчики лучшие", Status.Started, user));
                uow.SaveChanges();
                ThisWindow.Close();
            });
        }
    }
}
