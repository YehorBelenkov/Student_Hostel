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
    /// Interaction logic for Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        string selection = null;
        StudentHostelContext db = new StudentHostelContext();
        public Edit(string selection)
        {
            InitializeComponent();

            this.selection = selection;
            decoration();
        }
        public void decoration()
        {
            textbox2.TextDecorations.Add(TextDecorations.Underline);
            textbox3.TextDecorations.Add(TextDecorations.Underline);
            textbox4.TextDecorations.Add(TextDecorations.Underline);
            textbox5.TextDecorations.Add(TextDecorations.Underline);

            labeldecoration();
        }
        public void labeldecoration()
        {
            if (selection == "Students")
            {
                labelv.Visibility = Visibility.Visible;
                violationpage.Visibility = Visibility.Visible;
                datagrid1.ItemsSource = db.Students.ToList();
                label1.Content = "Student Id";
                label2.Content = "Residence";
                label3.Content = "Room Number";
                label4.Content = "Faculty";
                label5.Content = "Group";
                updateinformation.Content = "EDIT | ADD";
                combo1.ItemsSource = db.Students.Select(o => o.Id).ToList();
            }
            if (selection == "Parents")
            {
                label5.Visibility = Visibility.Hidden;
                combo2.Visibility = Visibility.Hidden;
                combo3.Visibility = Visibility.Hidden;
                combo4.Visibility = Visibility.Hidden;
                combo5.Visibility = Visibility.Hidden;
                textbox5.Visibility = Visibility.Hidden;

                datagrid1.ItemsSource = db.ParentsInfo.ToList();
                label1.Content = "Parent Id";
                combo1.ItemsSource = db.ParentsInfo.Select(o => o.Id).ToList();
                label2.Content = "Phone";
                label3.Content = "Address";
                label4.Content = "Work Place";
            }
            if (selection == "Residence")
            {
                label3.Visibility = Visibility.Hidden;
                label4.Visibility = Visibility.Hidden;
                label5.Visibility = Visibility.Hidden;
                combo2.Visibility = Visibility.Hidden;
                combo3.Visibility = Visibility.Hidden;
                combo4.Visibility = Visibility.Hidden;
                combo5.Visibility = Visibility.Hidden;
                textbox3.Visibility = Visibility.Hidden;
                textbox4.Visibility = Visibility.Hidden;
                textbox5.Visibility = Visibility.Hidden;

                datagrid1.ItemsSource = db.Residence.ToList();
                label1.Content = "Residence Id";
                combo1.ItemsSource = db.Residence.Select(o => o.Id).ToList();
                label2.Content = "Residence Name";
            }
            if (selection == "Room")
            {
                label3.Visibility = Visibility.Hidden;
                label4.Visibility = Visibility.Hidden;
                label5.Visibility = Visibility.Hidden;
                combo3.Visibility = Visibility.Hidden;
                combo4.Visibility = Visibility.Hidden;
                combo5.Visibility = Visibility.Hidden;
                textbox3.Visibility = Visibility.Hidden;
                textbox4.Visibility = Visibility.Hidden;
                textbox5.Visibility = Visibility.Hidden;

                datagrid1.ItemsSource = db.Room.ToList();
                label1.Content = "Room Id";
                combo1.ItemsSource = db.Room.Select(o => o.Id).ToList();
                label2.Content = "In What Residence Located";
            }
            if (selection == "Faculty")
            {
                label3.Visibility = Visibility.Hidden;
                label4.Visibility = Visibility.Hidden;
                label5.Visibility = Visibility.Hidden;
                combo2.Visibility = Visibility.Hidden;
                combo3.Visibility = Visibility.Hidden;
                combo4.Visibility = Visibility.Hidden;
                combo5.Visibility = Visibility.Hidden;
                textbox3.Visibility = Visibility.Hidden;
                textbox4.Visibility = Visibility.Hidden;
                textbox5.Visibility = Visibility.Hidden;

                datagrid1.ItemsSource = db.Faculty.ToList();
                label1.Content = "Faculty Id";
                combo1.ItemsSource = db.Faculty.Select(o => o.Id).ToList();
                label2.Content = "Faculty Name";
            }
            if (selection == "Groups")
            {
                label4.Visibility = Visibility.Hidden;
                label5.Visibility = Visibility.Hidden;
                combo4.Visibility = Visibility.Hidden;
                combo5.Visibility = Visibility.Hidden;
                textbox5.Visibility = Visibility.Hidden;

                datagrid1.ItemsSource = db.Group.ToList();
                combo1.ItemsSource = db.Group.Select(o => o.Id).ToList();
                label1.Content = "Group Id";
                label2.Content = "Faculty Located";
                label3.Content = "Course";
            }
            if (selection == "Course")
            {
                label3.Visibility = Visibility.Hidden;
                label4.Visibility = Visibility.Hidden;
                label5.Visibility = Visibility.Hidden;
                combo2.Visibility = Visibility.Hidden;
                combo3.Visibility = Visibility.Hidden;
                combo4.Visibility = Visibility.Hidden;
                combo5.Visibility = Visibility.Hidden;
                textbox3.Visibility = Visibility.Hidden;
                textbox4.Visibility = Visibility.Hidden;
                textbox5.Visibility = Visibility.Hidden;

                datagrid1.ItemsSource = db.Course.ToList();
                combo1.ItemsSource = db.Course.Select(o => o.Id).ToList();
                label1.Content = "Course Id";
                label2.Content = "Course Name";
            }
            if (selection == "Furniture")
            {
                label4.Visibility = Visibility.Hidden;
                label5.Visibility = Visibility.Hidden;
                combo2.Visibility = Visibility.Hidden;
                combo3.Visibility = Visibility.Hidden;
                combo4.Visibility = Visibility.Hidden;
                combo5.Visibility = Visibility.Hidden;
                textbox4.Visibility = Visibility.Hidden;
                textbox5.Visibility = Visibility.Hidden;

                datagrid1.ItemsSource = db.Furniture.ToList();
                combo1.ItemsSource = db.Furniture.Select(o => o.Id).ToList();
                label1.Content = "Furniture Id";
                label2.Content = "Furniture Name";
                label3.Content = "Furniture Inventory Number";
            }
        }
        private void updateinformation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (selection == "Students")
                {
                    int id = int.Parse(combo1.SelectedItem.ToString());
                    if (violationpage.Text != "")
                    {
                        Violation violation = new Violation()
                        {
                            StudentId = id,
                            information = violationpage.Text,
                            ResidenceId = db.Residence.Where(o => o.ResidenceName == combo2.SelectedItem.ToString()).Select(o => o.Id).First(),
                            ViolationDate = DateTime.Now
                        };
                        db.Violation.Add(violation);
                        db.SaveChanges();
                    }
                    int roomnumber = int.Parse(combo3.SelectedItem.ToString());
                    db.Students.Where(m => m.Id == id).First().RoomId = db.Room.Where(o => o.Number == roomnumber).Select(o => o.Id).First(); db.SaveChanges();
                    db.Students.Where(o => o.Id == id).First().FacultyId = db.Faculty.Where(o => o.FacultyName == combo4.SelectedItem.ToString()).Select(o => o.Id).First();
                    db.SaveChanges();
                    db.Students.Where(o => o.Id == id).First().GroupId = db.Group.Where(o => o.GroupName == combo5.SelectedItem.ToString()).Select(o => o.Id).First();
                    db.SaveChanges();
                }
                if (selection == "Parents")
                {
                    int id = int.Parse(combo1.SelectedItem.ToString());
                    db.ParentsInfo.Where(o => o.Id == id).First().Phone = textbox2.Text;
                    db.ParentsInfo.Where(o => o.Id == id).First().Address = textbox3.Text;
                    db.ParentsInfo.Where(o => o.Id == id).First().WorkPlace = textbox4.Text;
                    db.SaveChanges();
                }
                if (selection == "Residence")
                {
                    int id = int.Parse(combo1.SelectedItem.ToString());
                    db.Residence.Where(o => o.Id == id).First().ResidenceName = textbox2.Text;
                    db.SaveChanges();
                }
                if (selection == "Room")
                {
                    int id = int.Parse(combo1.SelectedItem.ToString());
                    int? resid = db.Residence.Where(o => o.ResidenceName == combo2.SelectedItem.ToString()).Select(o => o.Id).First();
                    db.Room.Where(o => o.Id == id).First().ResidenceId = resid;
                    db.SaveChanges();
                }
                if (selection == "Faculty")
                {
                    int id = int.Parse(combo1.SelectedItem.ToString());
                    db.Faculty.Where(o => o.Id == id).First().FacultyName = textbox2.Text;
                    db.SaveChanges();
                }
                if (selection == "Groups")
                {
                    int id = int.Parse(combo1.SelectedItem.ToString());
                    db.Group.Where(o => o.Id == id).First().FacultyId = db.Faculty
                        .Where(o => o.FacultyName == combo2.SelectedItem.ToString()).Select(o => o.Id).First();
                    db.SaveChanges();
                    db.Group.Where(o => o.Id == id).First().CourseId = db.Course
                        .Where(o => o.CourseName == combo3.SelectedItem.ToString()).Select(o => o.Id).First();
                    db.SaveChanges();
                }
                if (selection == "Course")
                {
                    int id = int.Parse(combo1.SelectedItem.ToString());
                    db.Course.Where(o => o.Id == id).First().CourseName = textbox2.Text;
                    db.SaveChanges();
                }
                if (selection == "Furniture")
                {
                    bool checkingfuriture = false;
                    foreach (var item in db.Furniture)
                    {
                        if (item.InventoryNumber == int.Parse(textbox3.Text))
                        {
                            checkingfuriture = true;
                        }
                    }
                    if(checkingfuriture != true)
                    {
                        int id = int.Parse(combo1.SelectedItem.ToString());
                        db.Furniture.Where(o => o.Id == id).First().FurnitureName = textbox2.Text;
                        db.SaveChanges();

                        db.Furniture.Where(o => o.Id == id).First().InventoryNumber = int.Parse(textbox3.Text);
                        db.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Can't Add a Furniture with same Inventory Number!");
                    }
                }
                Edit form = new Edit(selection);
                form.Show();
                this.Close();
            }
            catch (Exception o)
            {
                MessageBox.Show("Fill all the information");
            }
        }

        private void combo1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (selection == "Students")
            {
                combo2.ItemsSource = db.Residence.Select(o => o.ResidenceName).ToList();
                int studid = int.Parse(combo1.SelectedItem.ToString());
                int? roomid1 = db.Students.Where(o => o.Id == studid).Select(o => o.RoomId).First();
                int? resid = db.Room.Where(o => o.Id == roomid1).Select(o => o.ResidenceId).First();
                combo2.SelectedItem = db.Residence.Where(o => o.Id == resid).Select(o => o.ResidenceName).First();
                if (combo2.SelectedIndex != -1)
                {
                    combo3.Items.Clear();
                    int id = db.Residence.Where(o => o.ResidenceName == combo2.SelectedItem.ToString()).Select(o => o.Id).First();
                    foreach (var item in db.Room)
                    {
                        if (item.ResidenceId == id)
                        {
                            combo3.Items.Add(item.Number);
                        }
                    }
                    combo3.SelectedItem = db.Room.Where(o => o.ResidenceId == resid).Select(o => o.Number).First();

                    combo4.ItemsSource = db.Faculty.Select(o => o.FacultyName).ToList();
                    int? facid = db.Students.Where(o => o.Id == studid).Select(o => o.FacultyId).First();
                    combo4.SelectedItem = db.Faculty.Where(o => o.Id == facid).Select(o => o.FacultyName).First();
                }
            }
            if (selection == "Parents")
            {
                int parentid = int.Parse(combo1.SelectedItem.ToString());
                textbox2.Text = db.ParentsInfo.Where(o => o.Id == parentid).Select(o => o.Phone).First();
                textbox3.Text = db.ParentsInfo.Where(o => o.Id == parentid).Select(o => o.Address).First();
                textbox4.Text = db.ParentsInfo.Where(o => o.Id == parentid).Select(o => o.WorkPlace).First();
            }
            if(selection == "Residence")
            {
                int id = int.Parse(combo1.SelectedItem.ToString());
                textbox2.Text = db.Residence.Where(o => o.Id == id).Select(o => o.ResidenceName).First();
            }
            if (selection == "Room")
            {
                combo2.ItemsSource = db.Residence.Select(o => o.ResidenceName).ToList();
                int roomid = int.Parse(combo1.SelectedItem.ToString());
                int? idres = db.Room.Where(o => o.Id == roomid).Select(o => o.ResidenceId).First();
                combo2.SelectedItem = db.Residence.Where(o => o.Id == idres).Select(o => o.ResidenceName).First();
            }
            if (selection == "Faculty")
            {
                int facid = int.Parse(combo1.SelectedItem.ToString());
                textbox2.Text = db.Faculty.Where(o => o.Id == facid).Select(o => o.FacultyName).First();
            }
            if (selection == "Groups")
            {
                int groupid = int.Parse(combo1.SelectedItem.ToString());
                int? facid = db.Group.Where(o => o.Id == groupid).Select(o => o.FacultyId).First();
                int? courseid = db.Group.Where(o => o.Id == groupid).Select(o => o.CourseId).First();
                combo2.ItemsSource = db.Faculty.Select(o => o.FacultyName).ToList();
                combo2.SelectedItem = db.Faculty.Where(o => o.Id == facid).Select(o => o.FacultyName).First();
                combo3.ItemsSource = db.Course.Select(o => o.CourseName).ToList();
                combo3.SelectedItem = db.Course.Where(o => o.Id == courseid).Select(o => o.CourseName).First();
            }
            if (selection == "Course")
            {
                int courseid = int.Parse(combo1.SelectedItem.ToString());
                textbox2.Text = db.Course.Where(o => o.Id == courseid).Select(o => o.CourseName).First();
            }
            if (selection == "Furniture")
            {
                int furnitureid = int.Parse(combo1.SelectedItem.ToString());
                textbox2.Text = db.Furniture.Where(o => o.Id == furnitureid).Select(o => o.FurnitureName).First();
                textbox3.Text = $"{db.Furniture.Where(o => o.Id == furnitureid).Select(o => o.InventoryNumber).First()}";
            }
        }

        private void combo4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (selection == "Students")
            {
                if (combo4.SelectedIndex != -1)
                {
                    combo5.Items.Clear();
                    int id = db.Faculty.Where(o => o.FacultyName == combo4.SelectedItem.ToString()).Select(o => o.Id).First();
                    foreach (var item in db.Group)
                    {
                        if (item.FacultyId == id)
                        {
                            combo5.Items.Add(item.GroupName);
                        }
                    }
                    combo5.SelectedItem = db.Group.Where(o => o.FacultyId == id).Select(o => o.GroupName).First();
                }
            }
        }

        private void combo2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(selection == "Student")
            {
                if (combo2.SelectedIndex != -1)
                {
                    int studid = int.Parse(combo1.SelectedItem.ToString());
                    int? roomid1 = db.Students.Where(o => o.Id == studid).Select(o => o.RoomId).First();
                    int? resid = db.Room.Where(o => o.Id == roomid1).Select(o => o.ResidenceId).First();
                    combo3.Items.Clear();
                    int id = db.Residence.Where(o => o.ResidenceName == combo2.SelectedItem.ToString()).Select(o => o.Id).First();
                    foreach (var item in db.Room)
                    {
                        if (item.ResidenceId == id)
                        {
                            combo3.Items.Add(item.Number);
                        }
                    }
                    combo3.SelectedItem = db.Room.Where(o => o.ResidenceId == resid).Select(o => o.Number).First();

                    combo4.ItemsSource = db.Faculty.Select(o => o.FacultyName).ToList();
                    int? facid = db.Students.Where(o => o.Id == studid).Select(o => o.FacultyId).First();
                    combo4.SelectedItem = db.Faculty.Where(o => o.Id == facid).Select(o => o.FacultyName).First();
                }
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Studentpage form = new Studentpage("lidiiabelenkova@gmail.com");
            form.Show();
            this.Close();
        }
    }
}
