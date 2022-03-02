using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIP.Entities.Enums;

namespace SumanthInPaylocity.Models
{
    public class DependentVM : PersonVM
    {
        public List<SelectListItem> TypeList { get; set; }
       
    }
}