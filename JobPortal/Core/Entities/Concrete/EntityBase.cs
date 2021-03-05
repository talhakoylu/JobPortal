using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public abstract class EntityBase
    {
        public virtual DateTime CreatedDate { get; set; } = DateTime.Now;
        public virtual DateTime UpdatedDate { get; set; } = DateTime.Now;
        public virtual bool Status { get; set; }
    }
}
