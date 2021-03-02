using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.DTOs
{
    public class OperationClaimDto : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
