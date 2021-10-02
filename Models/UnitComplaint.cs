using System;
using System.Collections.Generic;

#nullable disable

namespace ApartmentManagement.Models
{
    public partial class UnitComplaint
    {
        public string UnitComplaintsId { get; set; }
        public string ComplaintId { get; set; }
        public string UnitId { get; set; }

        public virtual Complaint Complaint { get; set; }
        public virtual Unit Unit { get; set; }
    }
}
