using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_hostel
{
    class StudentHostelContext : DbContext
    {
        public StudentHostelContext() : base("StudentHostel1")
        {
            Database.SetInitializer<StudentHostelContext>(new MyInitalizer());
        }
        public DbSet<Course> Course { get; set; }
        public DbSet<Faculty> Faculty { get; set; }
        public DbSet<Furniture> Furniture { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<ParentsInfo> ParentsInfo { get; set; }
        public DbSet<Residence> Residence { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Violation> Violation { get; set; }
    }
    class MyInitalizer : DropCreateDatabaseIfModelChanges<StudentHostelContext>
    {
        protected override void Seed(StudentHostelContext db)
        {
            Furniture f = (new Furniture() { FurnitureName = "Couch", InventoryNumber = 100 });
            db.Furniture.Add(f);

            Room r = (new Room() { Number = 202 });
            r.Furnitures.Add(f);
            db.Room.Add(r);

            Residence s = (new Residence() { ResidenceName = "El Machico Hostel" });
            s.Rooms.Add(r);
            db.Residence.Add(s);

            f = (new Furniture() { FurnitureName = "Chair", InventoryNumber = 101 });
            db.Furniture.Add(f);

            r = (new Room() { Number = 203 });
            r.Furnitures.Add(f);
            db.Room.Add(r);

            s.Rooms.Add(r);
            db.Residence.Add(s);

            f = (new Furniture() { FurnitureName = "Table", InventoryNumber = 102 });
            db.Furniture.Add(f);

            r = (new Room() { Number = 204 });
            r.Furnitures.Add(f);
            db.Room.Add(r);

            s = (new Residence() { ResidenceName = "Einstein Hostel" });
            s.Rooms.Add(r);
            db.Residence.Add(s);

            f = (new Furniture() { FurnitureName = "Tv", InventoryNumber = 103 });
            db.Furniture.Add(f);

            r = (new Room() { Number = 205 });
            r.Furnitures.Add(f);
            db.Room.Add(r);

            s.Rooms.Add(r);
            db.Residence.Add(s);
            db.SaveChanges();

            Faculty faculty = new Faculty() { FacultyName = "H Quiters" };
            db.Faculty.Add(faculty);
            db.SaveChanges();

            faculty = new Faculty() { FacultyName = "W Letters" };
            db.Faculty.Add(faculty);
            db.SaveChanges();

            Course course = new Course() {CourseName="Gemoetry" };
            db.Course.Add(course);
            db.SaveChanges();

            course = new Course() {CourseName="Numerologic" };
            db.Course.Add(course);
            db.SaveChanges();

            Group group = new Group() { GroupName = "Yellow Stone", FacultyId = 1, CourseId = 1 };
            db.Group.Add(group);
            db.SaveChanges();

            group = new Group() { GroupName = "Red Stone", FacultyId = 2, CourseId = 2 };
            db.Group.Add(group);
            db.SaveChanges();
        }
    }
}
