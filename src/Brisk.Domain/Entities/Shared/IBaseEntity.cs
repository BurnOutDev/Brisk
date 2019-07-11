using System;

namespace Brisk.Domain.Entities.Shared
{
    public interface IBaseEntity
    {
        DateTime CreateDate { get; set; }
        int Id { get; set; }
        bool IsDeleted { get; set; }
    }
}