
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpManagement.Domain;
using EmpManagement.Domain.Models;
using System.Collections.Generic;

namespace EmpManagement.Repositories
{
    public interface ILeaveRepositorys
    {

        Task<LeaveDetails> ApplyLeaveAsync(LeaveDetails leaveRequest);
        //Task<List<LeaveDetails>> GetLeavesAsync();

       Task<IEnumerable<LeaveDetails>> GetLeaveDetails(int MangerId);


    }
}
