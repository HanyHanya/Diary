using System;
using Diary.Core;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Diary.MVVM.ViewModel
{
    class MonthControlViewModel : ObservableObject
    {

        public RelayCommand AddTaskCommand { get; set; }
        //public ObservableCollection<EVENT>
        public MonthControlViewModel()
        {
            AddTaskCommand = new RelayCommand(o =>
            {
                new AddTaskWindow().ShowDialog();
            });
        }
    }
}
