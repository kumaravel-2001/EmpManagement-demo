
using EmpManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace EmpManagement.Domain
{
    public class ApplyLeaveDbContext : DbContext {
        public ApplyLeaveDbContext(DbContextOptions<ApplyLeaveDbContext> options) : base(options)
        {
        }

            public DbSet<LeaveDetails> LeaveDetail { get; set; }

    }
    }

