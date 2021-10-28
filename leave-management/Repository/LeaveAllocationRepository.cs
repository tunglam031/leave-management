using leave_management.Contract;
using leave_management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Repository
{
    public class LeaveAllocationRepository : ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public LeaveAllocationRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Create(LeaveAllocation entity)
        {
            _dbContext.LeaveAllocations.Add(entity);
            return Save();
        }

        public bool Delete(LeaveAllocation entity)
        {
            _dbContext.LeaveAllocations.Remove(entity);
            return Save();
        }

        public ICollection<LeaveAllocation> FindAll()
        {
            return _dbContext.LeaveAllocations.ToList();
        }

        public LeaveAllocation FindById(int id)
        {
            return _dbContext.LeaveAllocations.Find(id);
        }

        public bool Save()
        {
            return _dbContext.SaveChanges() > 0;
        }

        public bool Update(LeaveAllocation entity)
        {
            _dbContext.LeaveAllocations.Update(entity);
            return Save(); ;
        }
    }
}
