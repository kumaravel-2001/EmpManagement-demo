using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EmpManagement.Domain.Models
{
    public partial class RaiseTicket
    {
        public int TicketId { get; set; }
        public int EmployeeId { get; set; }
        public int ManagerId { get; set; }
        public string QueryRelatedTo { get; set; }
        public DateTime? QueryDate { get; set; }
        public string Responses { get; set; }
    }
}
