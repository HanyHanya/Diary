using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = Diary.MVVM.Model.Primary_Models.Task;

namespace Diary.MVVM.Model
{
    class SQLTaskRepository : IRepository<Task>
    {
        private ApplicationContext db;

        public SQLTaskRepository(ApplicationContext db)
        {
            this.db = db;
        }
        public IEnumerable<Task> GetDataList()
        {
            return db.TASK;
        }

        public Task GetElement(int ID)
        {
            return db.TASK.Find(ID);
        }

        public void Create(Task item)
        {
            db.TASK.Add(item);
        }

        public void Update(Task item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Task task = db.TASK.Find(id);
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
