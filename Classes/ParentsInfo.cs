using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_hostel
{
    class ParentsInfo
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public bool KinshipStatus { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string WorkPlace { get; set; }
        public int? StudentId { get; set; }
        public virtual Students Student { get; set; }
    }
}
