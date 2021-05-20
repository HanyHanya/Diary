using Diary.Core;
using Diary.MVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Diary.MVVM.ViewModel
{
    class SettingsControlViewModel : ObservableObject
    {
        public RelayCommand RusLangCommand { get; set; }
        public RelayCommand EngLangCommand { get; set; }
        public RelayCommand PinkColorCommand { get; set; }
        public RelayCommand RedColorCommand { get; set; }
        public RelayCommand BlueColorCommand { get; set; }
        public RelayCommand GreenColorCommand { get; set; }
        public RelayCommand YellowColorCommand { get; set; }

        public SettingsControlViewModel()
        {
            RusLangCommand = new RelayCommand(o =>
            {
                MainWindow.Instance.Resources.Clear();
                AddContactWindow.Instance.Resources.Clear();
                AddEventWindow.Instance.Resources.Clear();
                AddTaskWindow.Instance.Resources.Clear();
                UserWindow.Instance.Resources.Clear();
                RegistrationWindow.Instance.Resources.Clear();
                ContactListWindow.Instance.Resources.Clear();

                MainWindow.Instance.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/Themes/Language/Lang_RUS.xaml") };
                AddContactWindow.Instance.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/Themes/Language/Lang_RUS.xaml") };
                AddEventWindow.Instance.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/Themes/Language/Lang_RUS.xaml") };
                AddTaskWindow.Instance.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/Themes/Language/Lang_RUS.xaml") };
                UserWindow.Instance.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/Themes/Language/Lang_RUS.xaml") };
                RegistrationWindow.Instance.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/Themes/Language/Lang_RUS.xaml") };
                ContactListWindow.Instance.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/Themes/Language/Lang_RUS.xaml") };
            });
            EngLangCommand = new RelayCommand(o =>
            {
                MainWindow.Instance.Resources.Clear();
                //AddContactWindow.Instance.Resources.Clear();
                //AddEventWindow.Instance.Resources.Clear();
                //AddTaskWindow.Instance.Resources.Clear();
                //UserWindow.Instance.Resources.Clear();
                //RegistrationWindow.Instance.Resources.Clear();
                //ContactListWindow.Instance.Resources.Clear();

                //AddContactWindow.Instance.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/Themes/Language/lang_ENG.xaml") };
                //AddEventWindow.Instance.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/Themes/Language/lang_ENG.xaml") };
                //AddTaskWindow.Instance.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/Themes/Language/lang_ENG.xaml") };
                //UserWindow.Instance.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/Themes/Language/lang_ENG.xaml") };
                //RegistrationWindow.Instance.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/Themes/Language/lang_ENG.xaml") };
                //ContactListWindow.Instance.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/Themes/Language/lang_ENG.xaml") };
                MainWindow.Instance.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/Themes/Language/lang_ENG.xaml") };
            });

            PinkColorCommand = new RelayCommand(o =>
            {
                MainWindow.Instance.Resources.Clear();
                AddContactWindow.Instance.Resources.Clear();
                AddEventWindow.Instance.Resources.Clear();
                AddTaskWindow.Instance.Resources.Clear();
                UserWindow.Instance.Resources.Clear();
                RegistrationWindow.Instance.Resources.Clear();
                ContactListWindow.Instance.Resources.Clear();

                AddContactWindow.Instance.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Pink.xaml") };
                AddEventWindow.Instance.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Pink.xaml") };
                AddTaskWindow.Instance.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Pink.xaml") };
                UserWindow.Instance.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Pink.xaml") };
                RegistrationWindow.Instance.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Pink.xaml") };
                ContactListWindow.Instance.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Pink.xaml") };
                MainWindow.Instance.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Pink.xaml") };
            });
            BlueColorCommand = new RelayCommand(o =>
            {
                MainWindow.Instance.Resources.Clear();
                //AddContactWindow.Instance.Resources.Clear();
                //AddEventWindow.Instance.Resources.Clear();
                //AddTaskWindow.Instance.Resources.Clear();
                //UserWindow.Instance.Resources.Clear();
                //RegistrationWindow.Instance.Resources.Clear();
                //ContactListWindow.Instance.Resources.Clear();

                //AddContactWindow.Instance.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Blue.xaml") };
                //AddEventWindow.Instance.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Blue.xaml") };
                //AddTaskWindow.Instance.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Blue.xaml") };
                //UserWindow.Instance.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Blue.xaml") };
                //RegistrationWindow.Instance.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Blue.xaml") };
                //ContactListWindow.Instance.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Blue.xaml") };
                MainWindow.Instance.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Blue.xaml") };
            });
        }
    }
}
