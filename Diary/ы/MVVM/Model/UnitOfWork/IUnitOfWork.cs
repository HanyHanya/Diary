using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diary.MVVM.Model.PrimaryModels;
using Diary.MVVM.Model.Repository;
using Task = Diary.MVVM.Model.PrimaryModels.Task;

namespace Diary.MVVM.Model.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<Contact> Contacts { get; }
        IRepository<Task> Tasks { get; }
        IRepository<Event> Events { get; }
        IRepository<User> Users { get; }

        void SaveChanges();
    }
}
