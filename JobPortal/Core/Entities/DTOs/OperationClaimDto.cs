using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;

namespace Core.Entities.DTOs
{
    public class OperationClaimDto : EntityBase, IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
