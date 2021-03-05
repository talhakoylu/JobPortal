using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class Company : EntityBase, IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; }
        public string Biography { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string CompanyMail { get; set; }
    }
}
