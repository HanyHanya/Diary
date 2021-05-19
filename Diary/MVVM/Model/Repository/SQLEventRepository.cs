using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.MVVM.Model
{
    class SQLEventRepository : IRepository<EVENT>
    {
        private ApplicationContext db;

        public SQLEventRepository(ApplicationContext db)
        {
            this.db = db;
        }
        public IEnumerable<EVENT> GetDataList()
        {
            return db.EVENT;
        }

        public EVENT GetElement(int ID)
        {
            return db.EVENT.Find(ID);
        }

        public void Create(EVENT item)
        {
            db.EVENT.Add(item);
        }

        public void Update(EVENT item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            EVENT _event = db.EVENT.Find(id);
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
