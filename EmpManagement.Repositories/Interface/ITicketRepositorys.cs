using EmpManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Repositories
{
   public interface ITicketRepositorys
    {
        Task<IEnumerable<RaiseTicket>> GetTicketsAsync(int MangerId);

        Task<RaiseTicket> RaiseTicketAsync(RaiseTicket _ticket);

    }
}
