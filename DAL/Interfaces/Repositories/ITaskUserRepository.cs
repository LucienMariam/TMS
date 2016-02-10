using System;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface ITaskUserRepository : IRepository<TaskUserDAL>
    {
        IEnumerable<TaskUserDAL> GetByUserId(Guid userId);
        IEnumerable<TaskUserDAL> GetByTaskId(Guid taskId);
        IEnumerable<TaskUserDAL> GetTaskByUser(string userName);
        TaskDAL GetTaskDAL(Guid taskId);
        TaskUserDAL CreateUserTask(Guid taskID, string userName);
    }
}
