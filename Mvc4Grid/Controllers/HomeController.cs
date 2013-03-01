using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc4Grid.Models;
using Mvc4Grid.Models.Entities;
using Mvc4Grid.Models.Grid;
using Mvc4Grid.Models.Helpers;

namespace Mvc4Grid.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        private IRepository _repository;

        public HomeController(IRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "jqGrid and ASP.NET MVC";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult GetData(GridSettings grid)
        {

            var query = _repository.Computers();

            //filtring
            if (grid.IsSearch)
            {
                //And
                if (grid.Where.groupOp == "AND")
                    foreach (var rule in grid.Where.rules)
                        query = query.Where<Computer>(
                            rule.field, rule.data,
                            (WhereOperation)StringEnum.Parse(typeof(WhereOperation), rule.op));
                else
                {
                    //Or
                    var temp = (new List<Computer>()).AsQueryable();
                    foreach (var rule in grid.Where.rules)
                    {
                        var t = query.Where<Computer>(
                        rule.field, rule.data,
                        (WhereOperation)StringEnum.Parse(typeof(WhereOperation), rule.op));
                        temp = temp.Concat<Computer>(t);
                    }
                    //remove repeating records
                    query = temp.Distinct<Computer>();
                }
            }

            //sorting
            query = query.OrderBy<Computer>(grid.SortColumn,
                grid.SortOrder);

            //count
            var count = query.Count();

            //paging
            var data = query.Skip((grid.PageIndex - 1) * grid.PageSize).Take(grid.PageSize).ToArray();

            //converting in grid format
            var result = new
            {
                total = (int)Math.Ceiling((double)count / grid.PageSize),
                page = grid.PageIndex,
                records = count,
                rows = (from host in data
                        select new
                        {
                            IsOnline = host.IsOnline.ToString(),
                            Name = host.Name,
                            IP = host.IP,
                            User = host.User,
                        }).ToArray()
            };

            //convert to JSON and return to client
            return Json(result, JsonRequestBehavior.AllowGet);

        }
    }
}
