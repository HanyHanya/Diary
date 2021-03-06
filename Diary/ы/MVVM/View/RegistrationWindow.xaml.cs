using Diary.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Diary
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public static RegistrationWindow Instance { get; internal set; }
        public RegistrationWindow()
        {
            //Uri IconUri = new Uri(@"D:\lab\sem4\ООП\курсовой\Ресурсы\Icon.png");
            //this.Icon = BitmapFrame.Create(IconUri);
            Instance = this;
            InitializeComponent();
            DataContext = new RegistrationViewModel(this);
        }
    }
}
