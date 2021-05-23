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
        private byte[] img;
        public byte[] Img
        {
            get { return img; }
            set { img = value; }
        }
        private User _authorisedauser;
        public User AuthorisedUser
        {
            get { return _authorisedauser; }
            set { _authorisedauser = value; OnPropertyChanged(); }
        }


        public RelayCommand UserCommand { get; set; }
        public Action Close { get; set; }

        public UserViewModel(User user)
        {
            AuthorisedUser = user;
            Name = AuthorisedUser.Name;
            Password = AuthorisedUser.Password;
            Login = AuthorisedUser.UserName;

            UserCommand = new RelayCommand(o =>
            {
                var uow = UnitOfWorkSingleton.Instance;
                AuthorisedUser.Name = Name;
                AuthorisedUser.Password = Password;
                AuthorisedUser.UserName = Login;
                uow.SaveChanges();
            });
        }
    }
}
