using Diary.Core;
using Diary.MVVM.Model;
using Diary.MVVM.Model.PrimaryModels;
using Diary.MVVM.Model.UnitOfWork;
using Diary.MVVM.View;
using Microsoft.Win32;
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
        public RelayCommand AddImgCommand { get; set; }
        public Action Close { get; set; }

        public UserViewModel(User user, MainViewModel MainVM = null)
        {
            AuthorisedUser = user;
            Name = AuthorisedUser.Name;
            Password = AuthorisedUser.Password;
            Login = AuthorisedUser.UserName;
            Img = AuthorisedUser.Img;

            UserCommand = new RelayCommand(o =>
            {
                var uow = UnitOfWorkSingleton.Instance;
                AuthorisedUser.Name = Name;
                AuthorisedUser.Password = Password;
                AuthorisedUser.UserName = Login;
                AuthorisedUser.Img = Img;
                uow.SaveChanges();
                MainVM.UserName = AuthorisedUser.Name;
                MainVM.Img = AuthorisedUser.Img;
            });
            AddImgCommand = new RelayCommand(o =>
           {
               OpenFileDialog openDialog = new OpenFileDialog();
               openDialog.Filter = "Image files (*.png;*.jpeg; *.jpg)|*.png;*.jpeg; *.jpg";
               openDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
               if (openDialog.ShowDialog() == true)
               {
                   //Img = openDialog.FileName;
               }
           });
        }
    }
}
