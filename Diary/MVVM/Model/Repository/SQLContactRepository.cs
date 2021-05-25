using System.Collections.Generic;
using System.Data.Entity;
using Diary.MVVM.Model.PrimaryModels;

namespace Diary.MVVM.Model.Repository
{
    public class SqlContactRepository : SqlRepository<Contact>
    {
        public SqlContactRepository(ApplicationContext db) : base(db)
        {
        }

        public override IEnumerable<Contact> List => dbset.AsNoTracking().Include(x => x.User).Include(x=>x.Events);
        public void RemoveContact(Contact contact)
        {
            dbset.Remove(contact);
        }
    }
}