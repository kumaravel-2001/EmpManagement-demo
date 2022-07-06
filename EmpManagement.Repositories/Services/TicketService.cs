using EmployeeManagementSystem.Repositories;
using EmpManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpManagement.Domain;

namespace EmpManagement.Repositories
{
    public class TicketService : ITicketRepositorys
    {
        
        private readonly KumaravelContext _context;

        public TicketService(KumaravelContext context)
        {
           
            this._context = context;
        }
       /* public async Task<List<RaiseTicket>> GetTicketsAsync(int ManagerId)
        {
            var ticketList = await context.RaiseTicket.ToListAsync();

            return ticketList;
            
        }*/
       /* public async Task<IEnumerable<RaiseTicket>> GetTicketsAsync(int MangerId)
        {
            var ticketList = await _context.RaiseTicket.ToListAsync();


            return ticketList;
        }*/

        public  async Task<Domain.Models.RaiseTicket> RaiseTicketAsync(Domain.Models.RaiseTicket _ticket)
        {
            var ticket = await _context.RaiseTicket.AddAsync(_ticket);

            _context.SaveChanges();


            return ticket.Entity;
             
            
        }

        
        public async Task<IEnumerable<RaiseTicket>> GetTicketsAsync(int MangerId)
        {
            var leave = await _context.RaiseTicket.ToListAsync();
            leave = leave.Where(x => x.ManagerId == MangerId).ToList();

            return leave;
            //throw new NotImplementedException();
        }
    }
}
