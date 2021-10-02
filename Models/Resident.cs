using System;
using System.Collections.Generic;

#nullable disable

namespace ApartmentManagement.Models
{
    public partial class Resident
    {
        public Resident()
        {
            Units = new HashSet<Unit>();
        }

        public string ResId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public string CellNumber { get; set; }
        public DateTime YearMovedIn { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Unit> Units { get; set; }
    }
}
