using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpManagement.Repositories;
using EmpManagement.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using EmpManagement.Domain.Models;

namespace EmpManagement.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LeaveController : Controller


    {
        private readonly ILeaveRepositorys repo;

        public LeaveController(ILeaveRepositorys repo)
        {
            
            this.repo = repo;
        }


       
      
      
       /* [HttpGet("Getsample")]
        [ProducesResponseType(200)]
        
        public IActionResult Getsample(string parm1)
        {
            return Ok(parm1);
        }*/
        [HttpPost]
        [ProducesResponseType(200)]
        //[Route("[controller]/ApplyLeave")]
        public async Task<IActionResult> SaveLeaveDetails(LeaveDetails leaves)
           {
            var leave=await repo.ApplyLeaveAsync(leaves);

            return Ok(leave);
        }

        [HttpGet("GetLeaveDetails")]
        [ProducesResponseType(200)]
        //[Route("[controller]")]
        public async Task<IActionResult> GetLeaveDetails(int ManagerId)
       {
           var leavedetails = await repo.GetLeaveDetails(ManagerId);

            return Ok(leavedetails);
        }
    }
}
