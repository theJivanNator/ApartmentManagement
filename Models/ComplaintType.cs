using System;
using System.Collections.Generic;

#nullable disable

namespace ApartmentManagement.Models
{
    public partial class ComplaintType
    {
        public ComplaintType()
        {
            Complaints = new HashSet<Complaint>();
        }

        public string ComplaintTypeId { get; set; }
        public string TypeDescription { get; set; }

        public virtual ICollection<Complaint> Complaints { get; set; }
    }
}
