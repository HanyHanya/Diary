using Diary.Core;
using Diary.MVVM.Model;
using Diary.MVVM.Model.PrimaryModels;
using Diary.MVVM.Model.Repository;
using Diary.MVVM.Model.UnitOfWork;
using Diary.MVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Diary.MVVM.ViewModel
{
    class RegistrationViewModel : ObservableObject
    {
        static ApplicationContext db = new ApplicationContext();

        private string login;

        public string Login
        {
            get { return login; }
            set { login = value; OnPropertyChanged(); }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged(); }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }


        public RelayCommand RegistraitionCommand { get; set; }
        public RelayCommand AutoriseCommand { get; set; }

        public RegistrationViewModel(RegistrationWindow ThisWindow)
        {
            RegistraitionCommand = new RelayCommand(o =>
            {
                if (Login.Length != 0 )
                {
                    if (Password.Length!=0)
                    {
                        if(Name.Length != 0)
                        {
                            var uow = UnitOfWorkSingleton.Instance;
                            uow.Users.Create(new User(Login, Password, Name));
                            uow.SaveChanges();
                        }
                        else
                        {
                            MessageBox.Show("Введите имя!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Введите пароль");
                    }
                }
                else
                {
                    MessageBox.Show("Введите имя пользователя!");
                }
                

                new MainWindow().ShowDialog();
                new UserWindow().ShowDialog();
                ThisWindow.Close();
            });
            AutoriseCommand = new RelayCommand(o =>
            {
                if (Login.Length != 0)
                {
                    if (Password.Length != 0)
                    {
                        
                        var uow = UnitOfWorkSingleton.Instance;
                        if (uow.Users.Get);
                    }
                    else
                    {
                        MessageBox.Show("Введите пароль");
                    }
                }
                else
                {
                    MessageBox.Show("Введите имя пользователя!");
                }
                new MainWindow().ShowDialog();
                ThisWindow.Close();
            });
        }
    }
}
