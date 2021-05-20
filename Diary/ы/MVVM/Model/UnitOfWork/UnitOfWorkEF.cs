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
    public class UnitOfWorkEF : IUnitOfWork
    {
        public ApplicationContext DbContext { get; }

        public IRepository<Contact> Contacts { get; }
        public IRepository<Task> Tasks { get; }
        public IRepository<Event> Events { get; }
        public IRepository<User> Users { get; }

        public UnitOfWorkEF()
        {
            DbContext = new ApplicationContext();
            Contacts = new SqlContactRepository(DbContext);
            Tasks = new SqlTaskRepository(DbContext);
            Events = new SqlEventRepository(DbContext);
            Users = new SqlUserRepository(DbContext);
        }

        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
