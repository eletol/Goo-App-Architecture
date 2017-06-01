using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Models
{
    public abstract class LookupBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}