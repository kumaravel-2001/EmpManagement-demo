using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EmpManagement.Domain.Models
{
    public partial class Employees
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int DepartmentId { get; set; }
        public DateTime DateOfJoining { get; set; }
        public int ManagerId { get; set; }
        public string AppUserId { get; set; }
    }
}
