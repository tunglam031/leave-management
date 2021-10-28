using leave_management.Contract;
using leave_management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Repository
{
    public class LeaveTypeRepository : ILeaveTypeRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public LeaveTypeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Create(LeaveType entity)
        {
            _dbContext.LeaveTypes.Add(entity);
            return Save();
        }

        public bool Delete(LeaveType entity)
        {
            _dbContext.LeaveTypes.Remove(entity);
            return Save();
        }

        public ICollection<LeaveType> FindAll()
        {
            return _dbContext.LeaveTypes.ToList();
        }

        public LeaveType FindById(int id)
        {
            return _dbContext.LeaveTypes.Find(id);
        }

        public ICollection<LeaveType> GetEmployeeByLeaveType(int id)
        {
            return _dbContext.LeaveTypes.Where(x => x.Id == id).ToList();
        }

        public bool Save()
        {
            return _dbContext.SaveChanges() > 0;
        }

        public bool Update(LeaveType entity)
        {
            _dbContext.LeaveTypes.Update(entity);
            return Save();
        }
    }
}
