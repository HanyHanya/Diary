using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diary.MVVM.Model.Primary_Models;

namespace Diary.MVVM.Model
{
    class SQLEventRepository : IRepository<Event>
    {
        private ApplicationContext db;

        public SQLEventRepository(ApplicationContext db)
        {
            this.db = db;
        }
        public IEnumerable<Event> GetDataList()
        {
            return db.EVENT;
        }

        public Event GetElement(int ID)
        {
            return db.EVENT.Find(ID);
        }

        public void Create(Event item)
        {
            db.EVENT.Add(item);
        }

        public void Update(Event item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Event _event = db.EVENT.Find(id);
            if (_event != null)
            {
                db.EVENT.Remove(_event);
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
