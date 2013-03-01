using System.Web.Mvc;
using Mvc4Grid.Models.Grid;
using Filter = Mvc4Grid.Models.Grid.Filter;

namespace Mvc4Grid.Models.Grid
{
    [ModelBinder(typeof(GridModelBinder))]
    public class GridSettings
    {
        public bool IsSearch { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public string SortColumn { get; set; }
        public string SortOrder { get; set; }

        public Filter Where { get; set; }
    }
}