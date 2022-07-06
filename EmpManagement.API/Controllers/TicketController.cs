using EmployeeManagementSystem.Repositories;
using EmpManagement.Domain.Models;
using EmpManagement.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EmpManagement.API.Controllers
{

    [ApiController]

    [Route("[controller]")]
    public class TicketController : Controller
    {

        private readonly ITicketRepositorys repo;
        public TicketController(ITicketRepositorys repo)
        {
            this.repo = repo;
        }

        [HttpGet("GetTicketDetails")]
        [ProducesResponseType(200)]
        //[Route("[controller]")]
        public async Task<ActionResult> GetTicketsAsync (int ManagerId)
        {

            var ticketList = await repo.GetTicketsAsync(ManagerId);

            return Ok(ticketList);
            
        }
        [HttpPost]
        [ProducesResponseType(200)]
        //[Route("[controller]/RaiseTicket")]
        public async Task<IActionResult> RaiseTicketAsync(RaiseTicket _ticket)
        {
            var ticket = await repo.RaiseTicketAsync(_ticket);

            return Ok(ticket);
        }
    }
}
