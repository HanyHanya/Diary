using Diary.Core;
using Diary.MVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.MVVM.ViewModel
{
    class RegistrationViewModel : ObservableObject
    {

        public RelayCommand RegistraitionCommand { get; set; }
        public RelayCommand AutoriseCommand { get; set; }

        public RegistrationViewModel(RegistrationWindow ThisWindow)
        {
            RegistraitionCommand = new RelayCommand(o =>
            {
                ThisWindow.Close();
                new UserWindow().ShowDialog();
            });
            AutoriseCommand = new RelayCommand(o =>
            {
               ThisWindow.Close();
            });
        }
    }
}
