using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_hostel
{
    class Faculty
    {
        public int Id { get; set; }
        public string FacultyName { get; set; }
        public ICollection<Students> Students { get; set; }
        public ICollection<Group> Groups { get; set; }
        public Faculty()
        {
            Students = new List<Students>();
            Groups = new List<Group>();
        }
    }
}
