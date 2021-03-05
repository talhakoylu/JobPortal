using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class CurriculumVitae : EntityBase, IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string FilePath { get; set; }
    }
}
