

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpManagement.Domain;
using EmpManagement.Domain.Models;

namespace EmpManagement.Repositories
{
    public class LeaveService : ILeaveRepositorys
    {
        private readonly KumaravelContext _context;

        public LeaveService(KumaravelContext context)
        {
            this._context = context;
        }
        public async Task<Domain.Models.LeaveDetails> ApplyLeaveAsync(Domain.Models.LeaveDetails leaveRequest)
        {
           var leave=await _context.LeaveDetails.AddAsync(leaveRequest);

            _context.SaveChanges();
            return leave.Entity;
        }

        public async Task<IEnumerable<LeaveDetails>> GetLeaveDetails(int MangerId)
        {
            var leave = await _context.LeaveDetails.ToListAsync();

            leave = leave.Where(x => x.ManagerId == MangerId).ToList();
            return leave;
        }




























       /* public  async Task<List<LeaveDetails>> GetLeavesAsync()
        {
            return await _context.LeaveDetails.ToListAsync();
           
        }*/
    }
}
