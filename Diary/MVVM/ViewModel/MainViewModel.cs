using Diary.Core;
using Diary.MVVM.Model.PrimaryModels;
using Diary.MVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand MonthViewCommand { get; set; }
        public RelayCommand YearViewCommand { get; set; }
        public RelayCommand AddTaskCommand { get; set; }
        public RelayCommand AddEventCommand { get; set; }
        public RelayCommand AddContactCommand { get; set; }
        public RelayCommand RegistrationCommand { get; set; }
        public RelayCommand SettingsCommand { get; set; }

        public MonthControlViewModel MonthVM { get; set; }
        public YearControlViewModel YearVM { get; set; }
        public SettingsControlViewModel SettVM { get; set; }

        private string username;
        public string UserName
        {
            get { return username; }
            set { username = value; }
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


        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel(MonthControlViewModel MonthVM, User authorisedUser)
        {
            MonthVM = new MonthControlViewModel(authorisedUser);
            YearVM = new YearControlViewModel();
            CurrentView = MonthVM;
            
            AuthorisedUser = authorisedUser;
            UserName = AuthorisedUser.Name;
            Img = AuthorisedUser.Img;

            MonthViewCommand = new RelayCommand(o =>
            {
                CurrentView = MonthVM;
            });
            YearViewCommand = new RelayCommand(o =>
            {
                CurrentView = YearVM;
            });
            AddTaskCommand = new RelayCommand(o =>
            {
                AddTaskWindow taskWin = new AddTaskWindow()
                {
                    DataContext = new AddTaskViewModel(_authorisedauser)
                };
                taskWin.ShowDialog();
            });
            AddEventCommand = new RelayCommand(o =>
            {
                AddEventWindow taskWin = new AddEventWindow()
                {
                    DataContext = new AddEventViewModel(_authorisedauser)
                };
                taskWin.ShowDialog();
            });
            AddContactCommand = new RelayCommand(o =>
            {
                AddContactWindow taskWin = new AddContactWindow()
                {
                    DataContext = new AddContactViewModel(_authorisedauser)
                };
                taskWin.ShowDialog();
            });
            RegistrationCommand = new RelayCommand(o =>
            {
                UserWindow taskWin = new UserWindow()
                {
                    DataContext = new UserViewModel(AuthorisedUser)
                };
                taskWin.ShowDialog();
                UserName = null;
                UserName = AuthorisedUser.Name;
            });
        }
    }
}
