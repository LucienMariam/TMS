using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using DAL.Interfaces;
using ORM;

namespace DAL
{
    public class TaskUserRepository : BaseRepository<TaskUser, TaskUserDAL, TaskUserMapperDAL>, ITaskUserRepository
    {
        public TaskUserRepository(DbContext context) : base(context) { }

        public IEnumerable<TaskUserDAL> GetByUserId(Guid userId)
        {
            Func<TaskUser, TaskUserDAL> f = (obj) => _entityMapper.ToDAL(obj);
            return _context.Set<TaskUser>().AsNoTracking().Where(x => x.UserId == userId).Select(f);
        }

        public IEnumerable<TaskUserDAL> GetByTaskId(Guid taskId)
        {
            Func<TaskUser, TaskUserDAL> f = (obj) => _entityMapper.ToDAL(obj);
            return _context.Set<TaskUser>().AsNoTracking().Where(x => x.TaskId == taskId).Select(f);
        }

        public IEnumerable<TaskUserDAL> GetTaskByUser(string username)
        {
            Func<TaskUser, TaskUserDAL> f = (obj) => _entityMapper.ToDAL(obj);
            Guid userId = _context.Set<User>().AsNoTracking().Where(u => u.Login == username).Select(u => u.Id).FirstOrDefault();
            return _context.Set<TaskUser>().AsNoTracking().Where(x => x.UserId == userId).Select(f);
        }
        public TaskDAL GetTaskDAL(Guid taskId)
        {
            Task task = _context.Set<Task>().AsNoTracking().Where(x => x.Id == taskId).FirstOrDefault() ;
            return new TaskDAL()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description
            };
        }
        public TaskUserDAL CreateUserTask(Guid taskID, string userName)
        {
            Guid userId = _context.Set<User>().Where(u=>u.Login==userName).FirstOrDefault().Id;
            return new TaskUserDAL()
            {
                TaskId = taskID,
                UserId = userId,
                Progress = 0
            };
        }
    }
}
