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
                            User user = new User(Login, Password, Name);
                            uow.Users.Create(user);
                            uow.SaveChanges();
                            MainWindow mainWindow = new MainWindow()
                            {
                                DataContext = new MainViewModel(new MonthControlViewModel(user),user)
                            };
                            mainWindow.Show();
                            ThisWindow.Close();
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
                
            });
            AutoriseCommand = new RelayCommand(o =>
            {
                if (Login.Length != 0)//вылетает
                {
                    if (Password.Length != 0)
                    {
                        
                        var uow = UnitOfWorkSingleton.Instance;
                        User user = uow.Users.GetElement(Login);
                        if (user != null)//протащить юзера как-нибудь умнее
                        {
                            if (user.Password == Password)
                            {
                                MainWindow mainWindow = new MainWindow()
                                {
                                    DataContext = new MainViewModel(new MonthControlViewModel(user), user)
                                };
                                mainWindow.Show();// nullReferensExeption за шо
                                ThisWindow.Close();
                            }
                            else
                            {
                                MessageBox.Show("Вы все беспарольные!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Вы все дураки!");
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
                
            });
        }
    }
}
