using Diary.MVVM.Model;
using Diary.MVVM.Model.UnitOfWork;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Diary
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow Instance { get; internal set; }
        public MainWindow()
        {
            InitializeComponent();
            Instance = this;
            DataContext = new MainViewModel(new MonthControlViewModel());

            #region DbFill // для заполнения тестовым наборов данных
            if (false)
            {

                var uow = UnitOfWorkSingleton.Instance;
                uow.Tasks.Create(new MVVM.Model.TASK() { ID = 1, NOTES = "Кокшомальчики лучшие", Status = Status.status1 });
                uow.SaveChanges();
            }
            
            #endregion
        }
    }
}
