using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Page: IEntity
    {
        public int PageId { get; set; }
        public string PageName { get; set; }
        public string PageHtml { get; set; }
    }
}
