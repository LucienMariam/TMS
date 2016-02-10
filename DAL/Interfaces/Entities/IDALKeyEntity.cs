using System;

namespace DAL.Interfaces
{
    public interface IDALKeyEntity: IDALEntity
    {
        Guid Id { get; set; }
    }
}
