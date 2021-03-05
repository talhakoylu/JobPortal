using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class Advertisement : EntityBase, IEntity
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
    }
}
