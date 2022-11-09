using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_hostel
{
    class Furniture
    {
        public int Id { get; set; }
        public string FurnitureName { get; set; }
        [Index("UniqueInventoryNumber", IsUnique = true)] //making it Unique
        public int InventoryNumber { get; set; }
    }
}
