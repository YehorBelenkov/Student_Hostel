using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_hostel
{
    class Violation
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public string information { get; set; }
        public virtual Students Student { get; set; }
        public int? ResidenceId { get; set; }
        public virtual Residence Residence { get; set; }
        public DateTime ViolationDate { get; set; }

    }
}
