using System;

namespace BLL.Interfaces
{
    public class RoleEntity : IBLLKeyEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}