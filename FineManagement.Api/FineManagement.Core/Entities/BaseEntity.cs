using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FineManagement.Core.Entities
{
    public abstract class BaseEntity<T> : IAuditable
    {
        public T Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }

    }
}
