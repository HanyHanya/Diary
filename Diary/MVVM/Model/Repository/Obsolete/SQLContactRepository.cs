using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diary.MVVM.Model.Primary_Models;

namespace Diary.MVVM.Model
{
    class SQLContactRepository : IRepository<Contact>
    {
        private ApplicationContext db;

        public SQLContactRepository(ApplicationContext db)
        {
            this.db = db;
        }
        public IEnumerable<Contact> GetDataList()
        {
            return db.CONTACT;
        }

        public Contact GetElement(int ID)
        {
            return db.CONTACT.Find(ID);
        }

        public void Create(Contact item)
        {
            db.CONTACT.Add(item);
        }

        public void Update(Contact item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Contact contact = db.CONTACT.Find(id);
            if (contact != null)
            {
                db.CONTACT.Remove(contact);
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

