using System;

namespace DAL.Interfaces
{
    public class RoleDAL : IDALKeyEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
