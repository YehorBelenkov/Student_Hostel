using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Student_hostel
{
    /// <summary>
    /// Interaction logic for Deleting.xaml
    /// </summary>
    public partial class Deleting : Window
    {
        string selection = null;
        StudentHostelContext db = new StudentHostelContext();
        public Deleting(string selection)
        {
            InitializeComponent();

            this.selection = selection;
            gettingid();
        }
        public void gettingid()
        {
            if(selection == "Students")
            {
                label1.Content = "Student Id";
                combo1.ItemsSource = db.Students.Select(o => o.Id).ToList();
                datagrid1.ItemsSource = db.Students.ToList();
            }
            if (selection == "Parents")
            {
                label1.Content = "Parent Id";
                combo1.ItemsSource = db.ParentsInfo.Select(o => o.Id).ToList();
                datagrid1.ItemsSource = db.ParentsInfo.ToList();
            }
            if (selection == "Residence")
            {
                label1.Content = "Residence Id";
                combo1.ItemsSource = db.Residence.Select(o => o.Id).ToList();
                datagrid1.ItemsSource = db.Residence.ToList();
            }
            if (selection == "Room")
            {
                label1.Content = "Room Id";
                combo1.ItemsSource = db.Room.Select(o => o.Id).ToList();
                datagrid1.ItemsSource = db.Room.ToList();
            }
            if (selection == "Faculty")
            {
                label1.Content = "Faculty Id";
                combo1.ItemsSource = db.Faculty.Select(o => o.Id).ToList();
                datagrid1.ItemsSource = db.Faculty.ToList();
            }
            if (selection == "Groups")
            {
                label1.Content = "Group Id";
                combo1.ItemsSource = db.Group.Select(o => o.Id).ToList();
                datagrid1.ItemsSource = db.Group.ToList();
            }
            if (selection == "Course")
            {
                label1.Content = "Course Id";
                combo1.ItemsSource = db.Course.Select(o => o.Id).ToList();
                datagrid1.ItemsSource = db.Course.ToList();
            }
            if (selection == "Furniture")
            {
                label1.Content = "Furniture Id";
                combo1.ItemsSource = db.Furniture.Select(o => o.Id).ToList();
                datagrid1.ItemsSource = db.Furniture.ToList(); 
            }
            if (selection == "Violations")
            {
                label1.Content = "Violation Id";
                combo1.ItemsSource = db.Violation.Select(o => o.Id).ToList();
                datagrid1.ItemsSource = db.Violation.ToList();
            }
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Studentpage form = new Studentpage("lidiiabelenkova@gmail.com");
            form.Show();
            this.Close();
        }

        private void deleteinformation_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(combo1.SelectedItem.ToString());
            if (selection == "Students")
            {
                Students c = db.Students.Where(m => m.Id == id).First();
                ParentsInfo c1 = db.ParentsInfo.Where(o => o.StudentId == c.Id).First();
                List<Violation> c2 = db.Violation.Where(o => o.StudentId == c.Id).ToList();
                db.ParentsInfo.Remove(c1);
                foreach(var item in c2)
                {
                    db.Violation.Remove(item);
                }
                db.Students.Remove(c);
                db.SaveChanges();
            }
            if (selection == "Parents")
            {
                ParentsInfo c = db.ParentsInfo.Where(m => m.Id == id).First();
                db.ParentsInfo.Remove(c);
                db.SaveChanges();
            }
            if (selection == "Residence")
            {
                Residence c = db.Residence.Where(m => m.Id == id).First();
                try
                {
                    db.Residence.Remove(c);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    MessageBox.Show("Before Deleting Edit the Foreign Keys Conntected to Residence!");
                }
            }
            if (selection == "Room")
            {
                Room c = db.Room.Where(m => m.Id == id).First();
                try
                {
                    db.Room.Remove(c);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    MessageBox.Show("Before Deleting Edit the Foreign Keys Conntected to Room!");
                }
            }
            if (selection == "Faculty")
            {
               
                Faculty c = db.Faculty.Where(m => m.Id == id).First();
                try
                {
                    db.Faculty.Remove(c);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    MessageBox.Show("Before Deleting Edit the Foreign Keys Conntected to Faculty!");
                }
            }
            if (selection == "Groups")
            {
                Group c = db.Group.Where(m => m.Id == id).First();
                try
                {
                    db.Group.Remove(c);
                    db.SaveChanges();
                } 
                catch (Exception)
                {
                    MessageBox.Show("Before Deleting Edit the Foreign Keys Conntected to Group!");
                }
            }
            if (selection == "Course")
            {
                Course c = db.Course.Where(m => m.Id == id).First();
                try
                {
                    db.Course.Remove(c);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    MessageBox.Show("Before Deleting Edit the Foreign Keys Conntected to Course!");
                }
            }
            if (selection == "Furniture")
            {
                Furniture c = db.Furniture.Where(m => m.Id == id).First();
                try
                {
                    db.Furniture.Remove(c);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    MessageBox.Show("Before Deleting Edit the Foreign Keys Conntected to Furniture!");
                }
            }
            if (selection == "Violations")
            {
                Violation c = db.Violation.Where(m => m.Id == id).First();
                db.Violation.Remove(c);
                db.SaveChanges();
            }
            Deleting form = new Deleting(selection);
            form.Show();
            this.Close();
        }
    }
}
