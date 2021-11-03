using leave_management.Contract;
using leave_management.Data;
using Microsoft.EntityFrameworkCore;
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
        public async Task<bool> Create(LeaveType entity)
        {
            await _dbContext.LeaveTypes.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(LeaveType entity)
        {
             _dbContext.LeaveTypes.Remove(entity);
            return await Save();
              
        }

        public async Task<ICollection<LeaveType>> FindAll()
        {
            return await _dbContext.LeaveTypes.ToListAsync();
        }

        public async Task<LeaveType> FindById(int id)
        {
            return await _dbContext.LeaveTypes.FindAsync(id);
        }

        public async Task<ICollection<LeaveType>> GetEmployeeByLeaveType(int id)
        {
            return await _dbContext.LeaveTypes.Where(x => x.Id == id).ToListAsync();
        }

        public async Task<bool> isExists(int id)
        {
            var exists = await _dbContext.LeaveTypes.AnyAsync(q=>q.Id==id);
            return exists;
        }

        public async Task<bool> Save()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(LeaveType entity)
        {
            _dbContext.LeaveTypes.Update(entity);
            return await Save();
        }
    }
}
