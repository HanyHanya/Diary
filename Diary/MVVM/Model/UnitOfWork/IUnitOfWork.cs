using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.MVVM.Model.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<CONTACT> Contacts { get; }
        IRepository<TASK> Tasks { get; }
        IRepository<EVENT> Events { get; }

        void SaveChanges();
    }
}
