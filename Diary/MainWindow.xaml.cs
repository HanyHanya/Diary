using System;
using Diary.MVVM.ViewModel;
using System.Windows;
using Diary.MVVM.Model.PrimaryModels;
using Diary.MVVM.Model.UnitOfWork;
using System.Windows.Media.Imaging;

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
            Uri IconUri = new Uri(@"D:\lab\sem4\ООП\курсовой\Ресурсы\Icon.png");
            this.Icon = BitmapFrame.Create(IconUri);

            #region DbFill

            if (true)
            {
                
                /*var uow = UnitOfWorkSingleton.Instance;
                var user = new User("OrLove", "Catboy", "Орлов Артём");
                uow.Users.Create(user);
                uow.SaveChanges();
                var contact = new Contact(1, "Тумаш Станислав Уточкин", "+375-29-000-00-01", "Не кошкомальчик", user);
                uow.Contacts.Create(contact);
                uow.SaveChanges();
                uow.Tasks.Create(new Task(1,"Сделать бд кошкомальчиков", DateTime.Now,"Кошкомальчики лучшие", Status.Started,user));
                uow.Tasks.Create(new Task(2, "Построить кошкомальчиковую империю", DateTime.Now, null, Status.InProcess, user));
                uow.SaveChanges();
                uow.Events.Create(new Event(3, "Надеть кошкоушки", DateTime.Now, DateTime.Now, "Мягенькие",  Status.Finished, user, contact, RepeatMode.RepeatDaily, NotificationMode.NotifyHourBefore));
                uow.SaveChanges();*/
            }
            

            #endregion

        }
    }
}
