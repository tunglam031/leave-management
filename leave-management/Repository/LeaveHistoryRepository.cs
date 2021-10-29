using leave_management.Contract;
using leave_management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Repository
{
    public class LeaveHistoryRepository : ILeaveHistoryRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public LeaveHistoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Create(LeaveHistory entity)
        {
            _dbContext.LeaveHistories.Add(entity);
            return Save();
        }

        public bool Delete(LeaveHistory entity)
        {
            _dbContext.LeaveHistories.Remove(entity);
            return Save();
        }

        public ICollection<LeaveHistory> FindAll()
        {
            return _dbContext.LeaveHistories.ToList();
        }

        public LeaveHistory FindById(int id)
        {
            return _dbContext.LeaveHistories.Find(id);
        }

        public bool isExists(int id)
        {
            var exists = _dbContext.LeaveHistories.Any(q => q.Id == id);
            return exists;
        }

        public bool Save()
        {
            return _dbContext.SaveChanges() > 0;
        }

        public bool Update(LeaveHistory entity)
        {
            _dbContext.LeaveHistories.Update(entity);
            return Save();
        }
    }
}
