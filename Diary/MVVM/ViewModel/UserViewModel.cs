using Diary.Core;
using Diary.MVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.MVVM.ViewModel
{
    class UserViewModel : ObservableObject
    {
        public RelayCommand UserCommand { get; set; }

        public UserViewModel(UserWindow ThisWindow)
        {
            UserCommand = new RelayCommand(o =>
            {
                ThisWindow.Close();
            });
        }
    }
}
