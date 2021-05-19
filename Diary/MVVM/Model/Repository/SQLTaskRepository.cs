using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.MVVM.Model
{
    class SQLTaskRepository : IRepository<TASK>
    {
        private ApplicationContext db;

        public SQLTaskRepository(ApplicationContext db)
        {
            this.db = db;
        }
        public IEnumerable<TASK> GetDataList()
        {
            return db.TASK;
        }

        public TASK GetElement(int ID)
        {
            return db.TASK.Find(ID);
        }

        public void Create(TASK item)
        {
            db.TASK.Add(item);
        }

        public void Update(TASK item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            TASK task = db.TASK.Find(id);
            if (task != null)
            {
                db.TASK.Remove(task);
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
