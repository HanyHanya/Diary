using System;
using System.Collections.Generic;
using System.Linq;
using Diary.MVVM.ViewModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Diary.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для AddContactWindow.xaml
    /// </summary>
    public partial class AddContactWindow : Window
    {
        public static AddContactWindow Instance { get; internal set; }
        public AddContactWindow()
        {
            InitializeComponent();
            Instance = this;
            DataContext = new AddContactViewModel(this);
        }
    }
}
