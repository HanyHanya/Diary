using Diary.Core;
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

        public MainViewModel(MonthControlViewModel MonthVM)
        {
            MonthVM = new MonthControlViewModel();
            YearVM = new YearControlViewModel();
            SettVM = new SettingsControlViewModel();
            CurrentView = MonthVM;

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
