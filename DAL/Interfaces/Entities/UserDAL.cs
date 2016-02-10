using System;

namespace DAL.Interfaces
{
    public class UserDAL : IDALKeyEntity
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}