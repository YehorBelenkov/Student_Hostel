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
    /// Interaction logic for AddToDb.xaml
    /// </summary>
    public partial class AddToDb : Window
    {
        string selection = null;
        StudentHostelContext db = new StudentHostelContext();
        public AddToDb(string selection)
        {
            InitializeComponent();

            this.selection = selection;
            decoration();
        }

        public void decoration()
        {
            textbox1.TextDecorations.Add(TextDecorations.Underline);
            textbox2.TextDecorations.Add(TextDecorations.Underline);
            textbox3.TextDecorations.Add(TextDecorations.Underline);
            textbox4.TextDecorations.Add(TextDecorations.Underline);
            textbox5.TextDecorations.Add(TextDecorations.Underline);

            labeldecoration();
        }
        public void labeldecoration()
        {
            if (selection == "Residence")
            {
                label2.Visibility = Visibility.Hidden;
                label3.Visibility = Visibility.Hidden;
                label4.Visibility = Visibility.Hidden;
                label5.Visibility = Visibility.Hidden;
                combo1.Visibility = Visibility.Hidden;
                combo2.Visibility = Visibility.Hidden;
                combo3.Visibility = Visibility.Hidden;
                combo4.Visibility = Visibility.Hidden;
                combo5.Visibility = Visibility.Hidden;
                textbox2.Visibility = Visibility.Hidden;
                textbox3.Visibility = Visibility.Hidden;
                textbox4.Visibility = Visibility.Hidden;
                textbox5.Visibility = Visibility.Hidden;

                datagrid1.ItemsSource = db.Residence.ToList();
                label1.Content = "Residence Name";
                textbox1.Text = "Name";
            }
            if (selection == "Room")
            {
                label3.Visibility = Visibility.Hidden;
                label4.Visibility = Visibility.Hidden;
                label5.Visibility = Visibility.Hidden;
                combo1.Visibility = Visibility.Hidden;
                combo3.Visibility = Visibility.Hidden;
                combo4.Visibility = Visibility.Hidden;
                combo5.Visibility = Visibility.Hidden;
                textbox3.Visibility = Visibility.Hidden;
                textbox4.Visibility = Visibility.Hidden;
                textbox5.Visibility = Visibility.Hidden;

                datagrid1.ItemsSource = db.Room.ToList();
                label1.Content = "Room Number";
                textbox1.Text = "0000";
                label2.Content = "Residence";
                combo2.ItemsSource = db.Residence.Select(o => o.ResidenceName).ToList();
            }
            if (selection == "Faculty")
            {
                label2.Visibility = Visibility.Hidden;
                label3.Visibility = Visibility.Hidden;
                label4.Visibility = Visibility.Hidden;
                label5.Visibility = Visibility.Hidden;
                combo1.Visibility = Visibility.Hidden;
                combo2.Visibility = Visibility.Hidden;
                combo3.Visibility = Visibility.Hidden;
                combo4.Visibility = Visibility.Hidden;
                combo5.Visibility = Visibility.Hidden;
                textbox2.Visibility = Visibility.Hidden;
                textbox3.Visibility = Visibility.Hidden;
                textbox4.Visibility = Visibility.Hidden;
                textbox5.Visibility = Visibility.Hidden;

                datagrid1.ItemsSource = db.Faculty.ToList();
                label1.Content = "Faculty Name";
                textbox1.Text = "Name";
            }
            if (selection == "Groups")
            {
                
                label4.Visibility = Visibility.Hidden;
                label5.Visibility = Visibility.Hidden;
                combo1.Visibility = Visibility.Hidden;
                combo4.Visibility = Visibility.Hidden;
                combo5.Visibility = Visibility.Hidden;
                textbox4.Visibility = Visibility.Hidden;
                textbox5.Visibility = Visibility.Hidden;

                datagrid1.ItemsSource = db.Group.ToList();

                label1.Content = "Group Name";
                textbox1.Text = "Name";
                label2.Content = "Faculty";
                combo2.ItemsSource = db.Faculty.Select(o => o.FacultyName).ToList();
                label3.Content = "Course";
                combo3.ItemsSource = db.Course.Select(o => o.CourseName).ToList();
            }
            if (selection == "Course")
            {
                label2.Visibility = Visibility.Hidden;
                label3.Visibility = Visibility.Hidden;
                label4.Visibility = Visibility.Hidden;
                label5.Visibility = Visibility.Hidden;
                combo1.Visibility = Visibility.Hidden;
                combo2.Visibility = Visibility.Hidden;
                combo3.Visibility = Visibility.Hidden;
                combo4.Visibility = Visibility.Hidden;
                combo5.Visibility = Visibility.Hidden;
                textbox2.Visibility = Visibility.Hidden;
                textbox3.Visibility = Visibility.Hidden;
                textbox4.Visibility = Visibility.Hidden;
                textbox5.Visibility = Visibility.Hidden;

                datagrid1.ItemsSource = db.Course.ToList();
                label1.Content = "Course Name";
                textbox1.Text = "Name";
            }
            if (selection == "Furniture")
            {
                label3.Visibility = Visibility.Hidden;
                label4.Visibility = Visibility.Hidden;
                label5.Visibility = Visibility.Hidden;
                combo1.Visibility = Visibility.Hidden;
                combo2.Visibility = Visibility.Hidden;
                combo3.Visibility = Visibility.Hidden;
                combo4.Visibility = Visibility.Hidden;
                combo5.Visibility = Visibility.Hidden;
                textbox3.Visibility = Visibility.Hidden;
                textbox4.Visibility = Visibility.Hidden;
                textbox5.Visibility = Visibility.Hidden;

                datagrid1.ItemsSource = db.Furniture.ToList();
                label1.Content = "Furniture Name";
                textbox1.Text = "Name";
                label2.Content = "Furniture Inventory Number";
                textbox2.Text = "0000";
            }
        }
        private void additem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (selection == "Residence")
                {
                    bool checkin = false;
                    foreach (var item in db.Residence)
                    {
                        if (item.ResidenceName == textbox1.Text)
                        {
                            checkin = true;
                        }
                    }
                    if (checkin != true)
                    {
                        Residence res = new Residence() { ResidenceName = textbox1.Text };
                        db.Residence.Add(res);
                        db.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Can't Have Residence with same names!");
                    }
                }
                if (selection == "Room")
                {
                    bool checkin = false;
                    int num = int.Parse(textbox1.Text);
                    int resid1 = db.Residence.Where(o => o.ResidenceName == combo2.SelectedItem.ToString()).Select(o => o.Id).First();
                    foreach (var item in db.Room)
                    {
                        if (item.ResidenceId == resid1)
                        {
                            if (item.Number == num)
                            {
                                checkin = true;
                            }
                        }
                    }
                    if (checkin != true)
                    {
                        int roomnumber = int.Parse(textbox1.Text);
                        int resid = db.Residence.Where(o => o.ResidenceName == combo2.SelectedItem.ToString()).Select(o => o.Id).First();
                        Room room = new Room()
                        {
                            Number = roomnumber,
                            ResidenceId = resid
                        };
                        db.Room.Add(room);
                        db.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Can't Have Rooms with same Numbers!");
                    }
                }
                if (selection == "Faculty")
                {
                    bool checkin = false;
                    foreach (var item in db.Faculty)
                    {
                        if (item.FacultyName == textbox1.Text)
                        {
                            checkin = true;
                        }
                    }
                    if (checkin != true)
                    {
                        Faculty faculty = new Faculty() { FacultyName = textbox1.Text };
                        db.Faculty.Add(faculty);
                        db.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Can't have same Faculty Names!");
                    }
                }
                if (selection == "Groups")
                {
                    bool checkin = false;
                    int facid = db.Faculty.Where(o => o.FacultyName == combo2.SelectedItem.ToString()).Select(o => o.Id).First();
                    foreach (var item in db.Group)
                    {
                        if (item.FacultyId == facid)
                        {
                            if (item.GroupName == textbox1.Text)
                            {
                                checkin = true;
                            }
                        }
                    }
                    if (checkin != true)
                    {
                        Group group = new Group()
                        {
                            GroupName = textbox1.Text,
                            FacultyId = db.Faculty
                            .Where(o => o.FacultyName == combo2.SelectedItem.ToString()).Select(o => o.Id).First(),
                            CourseId = db.Course
                            .Where(o => o.CourseName == combo3.SelectedItem.ToString()).Select(o => o.Id).First()
                        };
                        db.Group.Add(group);
                        db.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Can't Add Existing Name of Groupbox");
                    }
                }
                if (selection == "Course")
                {
                    bool checkin = false;
                    foreach (var item in db.Course)
                    {
                        if (item.CourseName == textbox1.Text)
                        {
                            checkin = true;
                        }
                    }
                    if (checkin != true)
                    {
                        Course course = new Course() { CourseName = textbox1.Text };
                        db.Course.Add(course);
                        db.SaveChanges();
                    }
                    else { MessageBox.Show("This Course Already Exists!"); }
                }
                if (selection == "Furniture")
                {
                    bool checkin = false;
                    foreach (var item in db.Furniture)
                    {
                        if (item.InventoryNumber == int.Parse(textbox2.Text))
                        {
                            checkin = true;
                        }
                        if (item.FurnitureName == textbox1.Text)
                        {
                            checkin = true;
                        }
                    }
                    if (checkin != true)
                    {
                        Furniture furniture = new Furniture()
                        {
                            FurnitureName = textbox1.Text,
                            InventoryNumber = int.Parse(textbox2.Text)
                        };
                        db.Furniture.Add(furniture);
                        db.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Can't Add a Furniture with same Inventory Number Or Name!");
                    }
                }
                AddToDb form = new AddToDb(selection);
                form.Show();
                this.Close();
            }
            catch (Exception o)
            {
                MessageBox.Show("This Room Number Exists!");
            }
        }

        private void combo1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void combo4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void combo2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Studentpage form = new Studentpage("lidiiabelenkova@gmail.com");
            form.Show();
            this.Close();
        }
    }
}
