using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_hostel
{
    class Room
    {
        public int Id { get; set; }
        [Index("UniqueInventoryNumber", IsUnique = true)]
        public int Number { get; set; }
        public int? ResidenceId { get; set; }
        public virtual Residence Residence { get; set; }
        public ICollection<Furniture> Furnitures { get; set; }
        public ICollection<Students> Students { get; set; }
        public Room()
        {
            Students = new List<Students>();
            Furnitures = new List<Furniture>();
        }
    }
}
