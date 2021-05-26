using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using Diary.MVVM.Model.PrimaryModels;

namespace Diary.MVVM.Model.Repository
{
    public class SqlUserRepository : SqlRepository<User>
    {
        public SqlUserRepository(ApplicationContext db) : base(db)
        {
        }

        public override IEnumerable<User> List
        {
            get
            {
                var set= dbset.AsNoTracking().Include(x => x.Tasks).Include(x => x.Contacts).ToList();
                foreach (var user in set)
                {
                    user.Events = new List<Event>();
                    foreach (var task in user.Tasks)
                    {
                        if (task is Event userEvent)
                        {
                            user.Events.Add(userEvent);
                        }
                    }
                    foreach (var userEvent in user.Events)
                    {
                        user.Tasks.Remove(userEvent);
                    }
                }

                return set;
            }
        }
    }
}