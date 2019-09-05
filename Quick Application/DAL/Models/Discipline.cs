using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public class Discipline : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
