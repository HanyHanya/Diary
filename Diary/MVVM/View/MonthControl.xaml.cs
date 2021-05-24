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
using Diary.MVVM.Model.PrimaryModels;
using Diary.MVVM.ViewModel;

namespace Diary.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для MonthControl.xaml
    /// </summary>
    public partial class MonthControl : UserControl
    {
        public MonthControl()
        {
            InitializeComponent();
        }

        private void scrl_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scroll = (ScrollViewer)sender;
            scroll.ScrollToVerticalOffset(scroll.VerticalOffset - e.Delta / 7);
            e.Handled = true;
        }
    }
}
