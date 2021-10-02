using System;
using System.Collections.Generic;

#nullable disable

namespace ApartmentManagement.Models
{
    public partial class Complaint
    {
        public Complaint()
        {
            UnitComplaints = new HashSet<UnitComplaint>();
        }

        public string ComplaintId { get; set; }
        public string ComplaintDescription { get; set; }
        public DateTime ComplaintDate { get; set; }
        public string ComplaintTypeId { get; set; }
        public string Status { get; set; }
        public string LinkedUnit { get; set; }

        public virtual ComplaintType ComplaintType { get; set; }
        public virtual ICollection<UnitComplaint> UnitComplaints { get; set; }
    }
}
