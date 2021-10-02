using System;
using System.Collections.Generic;

#nullable disable

namespace ApartmentManagement.Models
{
    public partial class Unit
    {
        public Unit()
        {
            UnitComplaints = new HashSet<UnitComplaint>();
        }

        public string UnitId { get; set; }
        public string SquareMeters { get; set; }
        public string ResId { get; set; }

        public virtual Resident Res { get; set; }
        public virtual ICollection<UnitComplaint> UnitComplaints { get; set; }
    }
}
