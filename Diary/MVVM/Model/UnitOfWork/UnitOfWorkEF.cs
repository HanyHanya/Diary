using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.MVVM.Model.UnitOfWork
{
    public class UnitOfWorkEF : IUnitOfWork
    {
        public ApplicationContext DbContext { get; }

        public IRepository<CONTACT> Contacts { get; }
        public IRepository<TASK> Tasks { get; }
        public IRepository<EVENT> Events { get; }

        public UnitOfWorkEF()
        {
            DbContext = new ApplicationContext();
            Contacts = new SQLContactRepository(DbContext);
            Tasks = new SQLTaskRepository(DbContext);
            Events = new SQLEventRepository(DbContext);

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
