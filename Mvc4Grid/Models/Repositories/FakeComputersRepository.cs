using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Mvc4Grid.Models.Entities;

namespace Mvc4Grid.Models.Repositories
{
    public class FakeComputersRepository:IRepository
    {
        #region IRepository<Computer> Members

        public IQueryable<Computer> Computers()
        {
            //For NHibernate with Linq:
            // var query = Session.Linq<Computer>().AsQueryable();

            return new List<Computer>()
            {
                new Computer { ID=1, Name = "Computer1", IP = "192.168.1.1", User = "User1", IsOnline = true },
                new Computer { ID=2, Name = "Computer2", IP = "192.168.1.2", User = "User2", IsOnline = true },
                new Computer { ID=3, Name = "Computer3", IP = "192.168.1.3", User = "User3", IsOnline = false },
                new Computer { ID=4, Name = "Computer4", IP = "192.168.1.4", User = "User4", IsOnline = true }
            }.AsQueryable();
        }

        #endregion
    }
}