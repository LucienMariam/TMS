using System;

namespace DAL.Interfaces
{
    public class TaskDAL : IDALKeyEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
