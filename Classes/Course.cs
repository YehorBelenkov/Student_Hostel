using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_hostel
{
    class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public ICollection<Group> Groups { get; set; }
        public Course()
        {
            Groups = new List<Group>();
        }
    }
}
