using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc4Grid.Models.Entities
{
    public class Computer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string IP { get; set; }
        public string User { get; set; }

        public bool IsOnline { get; set; }
    }
}