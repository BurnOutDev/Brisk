using System;

namespace Brisk.Domain.Entities.Shared
{
    public class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
