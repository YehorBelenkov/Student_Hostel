using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_hostel
{
    class Group
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public int? FacultyId { get; set; }
        public virtual Faculty Faculty { get; set; }
        public List<Students> Students { get; set; }
        public int? CourseId { get; set; }
        public virtual Course Course { get; set; }
        public Group()
        {
            Students = new List<Students>();
        }
    }
}
