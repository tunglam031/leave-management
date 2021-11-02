using leave_management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Contract
{
    public interface ILeaveAllocationRepository : IRepositoryBase<LeaveAllocation>
    {
        bool CheckAllocation(int leavetypeId, string employeeid);
        ICollection<LeaveAllocation> GetLeaveAllocationsByEmployee(string employeeid);
        LeaveAllocation GetLeaveAllocationsByEmployeeAndType(string employeeid, int leaveTypeId);
    }
}
