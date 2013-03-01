using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mvc4Grid.Models.Entities;

namespace Mvc4Grid.Models
{
    public interface IRepository
    {
        IQueryable<Computer> Computers();
    }
}