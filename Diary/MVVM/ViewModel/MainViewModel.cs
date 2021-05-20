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

        public MainViewModel(MonthControlViewModel MonthVM, User authorisedUser = null)
        {
            MonthVM = new MonthControlViewModel();
            YearVM = new YearControlViewModel();
            SettVM = new SettingsControlViewModel();
            CurrentView = MonthVM;

            AuthorisedUser = authorisedUser;

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
                new AddTaskWindow().ShowDialog();
            });
            AddEventCommand = new RelayCommand(o =>
            {
                new AddEventWindow().ShowDialog();
            });
            AddContactCommand = new RelayCommand(o =>
            {
                new AddContactWindow().ShowDialog();
            });
            RegistrationCommand = new RelayCommand(o =>
            {
                new RegistrationWindow().ShowDialog();
            });
            SettingsCommand = new RelayCommand(o =>
            {
                CurrentView = SettVM;
            });
        }
    }
}
