using leave_management.Contract;
using leave_management.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Repository
{
    public class LeaveRequestRepository : ILeaveRequestRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public LeaveRequestRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Create(LeaveRequest entity)
        {
            _dbContext.LeaveRequests.Add(entity);
            return Save();
        }

        public bool Delete(LeaveRequest entity)
        {
            _dbContext.LeaveRequests.Remove(entity);
            return Save();
        }

        public ICollection<LeaveRequest> FindAll()
        {
            return _dbContext.LeaveRequests.ToList();
        }

        public LeaveRequest FindById(int id)
        {
            return _dbContext.LeaveRequests.Include(q => q.RequestingEmployee)
                .Include(q => q.ApprovedBy)
                .Include(q => q.LeaveType).FirstOrDefault(q=>q.Id==id);
        }

        public ICollection<LeaveRequest> GetLeaveRequestsByEmployee(string employeeid)
        {
            var leaveRequests = FindAll()
                .Where(q => q.RequestingEmployeeId == employeeid)
                .ToList();
            return leaveRequests;
        }

        public bool isExists(int id)
        {
            var exists = _dbContext.LeaveRequests.Any(q => q.Id == id);
            return exists;
        }

        public bool Save()
        {
            return _dbContext.SaveChanges() > 0;
        }

        public bool Update(LeaveRequest entity)
        {
            _dbContext.LeaveRequests.Update(entity);
            return Save();
        }
    }
}
