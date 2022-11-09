using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_hostel
{
    class Residence
    {
        public int Id { get; set; }
        public string ResidenceName { get; set; }

        public List<Room> Rooms { get; set; }
        public Residence()
        {
            Rooms = new List<Room>();
        }
    }
}
