using Diary.Core;
using Diary.MVVM.Model;
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
    class UserViewModel : ObservableObject, ICloseWindows
    {
        private string login;
        public string Login
        {
            get { return login; }
            set { login = value; OnPropertyChanged("Login"); }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged("Password"); }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }

        public RelayCommand UserCommand { get; set; }
        public Action Close { get; set; }
        void CloseWindow()
        {
            Close?.Invoke();
        }

        public UserViewModel(User user)
        {
            UserCommand = new RelayCommand(o =>
            {
                var uow = UnitOfWorkSingleton.Instance;
                Name = user.Name;
                Password = user.Password;
                Login = user.UserName;
                //uow.SaveChanges();
                CloseWindow();
            });
        }
    }
}
