using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_hostel
{
    class Students
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public bool IsAdmin { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        //[Required]
        public string Phone { get; set; }
        public string Sex { get; set; }
        public DateTime? BirthDate { get; set; }
        public List<ParentsInfo> ParentsInfos { get; set; }
        public int? RoomId { get; set; }
        public virtual Room Room { get; set; }
        public int? FacultyId { get; set; }
        public virtual Faculty Faculty { get; set; }
        public int? GroupId { get; set; }
        public virtual Group Group { get; set; }
        public byte[] StudentsPhoto { get; set; }
        public List<Violation> Violations { get; set; }

        public Students()
        {
            Violations = new List<Violation>();
            ParentsInfos = new List<ParentsInfo>();
        }
    }
}
