using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
    /// Interaction logic for Studentpage.xaml
    /// </summary>
    public partial class Studentpage : Window
    {
        private string email;
        StudentHostelContext db = null;
        TextBox olddecoration = null;
        string Picture;
        byte[] picturebytes = null;
        public Studentpage(string email)
        {
            InitializeComponent();
            this.email = email;
            db = new StudentHostelContext();

            SaveEditedinfo.Visibility = Visibility.Hidden;
            delaccount.Visibility = Visibility.Hidden;
            bool isadmin = db.Students.Where(o => o.Email == email).First().IsAdmin;
            if (isadmin) { ShowIfAdmin(); }
            else { ShowIfStudent(); }
        }
        private void ShowIfAdmin()
        {
            
            stackpanel1.Visibility = Visibility.Hidden;
            stackpanel2.Visibility = Visibility.Hidden;
            stackpanel3.Visibility = Visibility.Hidden;
            editbutton.Visibility = Visibility.Hidden;
            phonenumber.Visibility = Visibility.Hidden;
            gender.Visibility = Visibility.Hidden;
            SaveEditedinfo.Visibility = Visibility.Hidden;
            selectioncombo.Visibility = Visibility.Visible;
            selectioncombo.Items.Add("Students");
            selectioncombo.Items.Add("Parents");
            selectioncombo.Items.Add("Residence");
            selectioncombo.Items.Add("Room");
            selectioncombo.Items.Add("Faculty");
            selectioncombo.Items.Add("Groups");
            selectioncombo.Items.Add("Course");
            selectioncombo.Items.Add("Furniture");
            selectioncombo.Items.Add("Violations");
            information.Visibility = Visibility.Visible;
        }
        private void ShowIfStudent()
        {
            add.Visibility = Visibility.Hidden;
            updateinformation.Visibility = Visibility.Hidden;
            delete.Visibility = Visibility.Hidden;
            if (db.Students.Where(o => o.Email == email).Select(o => o.StudentsPhoto != null).First() == true)
            {
                using (MemoryStream mStream = new MemoryStream(db.Students.Where(o => o.Email == email).Select(o => o.StudentsPhoto).First()))
                {
                    ImageSource a = BitmapFrame.Create(mStream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                    //if error I have changed image.source and imgUser.fill places!
                    image.Source = null;
                    imgUser.Fill = new ImageBrush(a);
                }
            }
            //username.Text = db.Students.Where(o => o.Email == email).Select(o => o.FullName).First();
            //phonenumber.Text = db.Students.Where(o => o.Email == email).Select(o => o.Phone).First();
            //gender.Text = db.Students.Where(o => o.Email == email).Select(o => o.Sex).First();
            stackpanel3.Visibility = Visibility.Hidden;
            Students student = db.Students.Where(o => o.Email == email).First();
            username.Text = student.FullName;
            phonenumber.Text = student.Phone;
            gender.Text = student.Sex;
            address.Text = student.Address;
            facultyname.Text = db.Faculty.Where(o => o.Id == student.FacultyId).Select(o => o.FacultyName).First();
            //int groupid = db.Group.Where(o => o.Id == student.GroupId).Select(o => o.Id).First();
            groupname.Text = db.Group.Where(o => o.Id == student.GroupId).Select(o => o.GroupName).First();
            int countvio = db.Violation.Where(o => o.StudentId == student.Id).Count();
            violations.Text = $"{countvio}";
            if (violations.Text == "0")
            {
                seeviolations.Visibility = Visibility.Hidden;
            }
            //Room numberoom = db.Students.Where(o => o.Email == email).Select(o => o.Room).First();
            roomnumber.Text = $"{db.Room.Where(o => o.Id == student.RoomId).Select(o => o.Number).First()}";
            int roomid2 = int.Parse(roomnumber.Text.ToString());
            int? roomid3 = db.Room.Where(o => o.Number == roomid2).Select(o => o.ResidenceId).First();

            residence.Text = $"{db.Residence.Where(o => o.Id == roomid3).Select(o => o.ResidenceName).First()}";
            int resid = db.Residence.Where(o => o.ResidenceName == residence.Text).Select(o => o.Id).First();
            roomcombo.ItemsSource = db.Room.Where(o => o.ResidenceId == resid).ToList();
            roomcombo.SelectedItem = roomnumber.Text;

            int? roomid = db.Room.Where(o => o.Id == student.RoomId).Select(o => o.ResidenceId).First();
            residence.Text = db.Residence.Where(o => o.Id == roomid).Select(o => o.ResidenceName).First();
            try
            {
                List<ParentsInfo> parents = db.ParentsInfo.Where(o => o.StudentId == student.Id).ToList();
                if (parents.Count == 2)
                {
                    parentsname1.Text = parents[0].FullName;
                    parentsname2.Text = parents[1].FullName;
                }
                else if (parents.Count == 1)
                {
                    parentsname1.Text = parents[0].FullName;
                    parentsname2.Visibility = Visibility.Hidden;
                }
                else
                {
                    parentslabel.Visibility = Visibility.Hidden;
                    parentsname1.Visibility = Visibility.Hidden;
                    parentsname2.Visibility = Visibility.Hidden;
                }
            }
            catch (Exception o) { MessageBox.Show(o.Message); }


            List<string> parentsname = db.ParentsInfo.Where(o => o.Student.FullName == username.Text).Select(o => o.FullName).ToList();

            for (int i = 0; i < parentsname.Count; i++)
            {
                if (parentsname1 != null)
                {
                    if (parentsname2 == null)
                    {
                        parentsname2.Text = parentsname[i];
                    }
                }
                if (parentsname1 == null)
                {
                    parentsname1.Text = parentsname[i];
                }

            }
            //if (!parentsname.Any())
            //{
            //    if (parentsname[0] != null)
            //    {
            //        parentsname1.Visibility = Visibility.Visible; parentsname1.Text = parentsname[0];
            //        parentsname1.Text = parentsname[0];
            //    }

            //    if (parentsname[1] != null)
            //    {
            //        parentsname2.Visibility = Visibility.Visible;
            //        parentsname2.Text = parentsname[1];
            //    }
            //}
        }

        private void editbutton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            olddecoration = new TextBox();
            delaccount.Visibility = Visibility.Visible;
            olddecoration.TextDecorations.Add(username.TextDecorations);
            SaveEditedinfo.Visibility = Visibility.Visible;
            stackpanel3.Visibility = Visibility.Visible;
            editphoto.Visibility = Visibility.Visible;

            residencecombo.ItemsSource = db.Residence.Select(o => o.ResidenceName).ToList();
            residencecombo.SelectedItem = residence.Text;
            roomcombo.SelectedItem = roomnumber.Text;
            facultycombo.ItemsSource = db.Faculty.Select(o => o.FacultyName).ToList();
            facultycombo.SelectedItem = facultyname.Text;
            groupcombo.SelectedItem = groupname.Text;

            username.IsEnabled = true;
            phonenumber.IsEnabled = true;
            address.IsEnabled = true;

            username.TextDecorations.Add(TextDecorations.Underline);
            phonenumber.TextDecorations.Add(TextDecorations.Underline);
            address.TextDecorations.Add(TextDecorations.Underline);
        }

        private void SaveEditedinfo_Click(object sender, RoutedEventArgs e)
        {
            SaveEditedinfo.Visibility = Visibility.Hidden;
            delaccount.Visibility = Visibility.Hidden;
            editphoto.Visibility = Visibility.Hidden;
            Students student = db.Students.Where(o => o.Email == email).First();

            username.IsEnabled = false;
            phonenumber.IsEnabled = false;
            address.IsEnabled = false;
            username.TextDecorations = olddecoration.TextDecorations;
            phonenumber.TextDecorations = olddecoration.TextDecorations;
            address.TextDecorations = olddecoration.TextDecorations;

            residence.Text = residencecombo.SelectedItem.ToString();
            roomnumber.Text = roomcombo.SelectedItem.ToString();
            facultyname.Text = facultycombo.SelectedItem.ToString();
            groupname.Text = groupcombo.SelectedItem.ToString();

            db.Students.Where(m => m.Id == student.Id).First().FullName = username.Text;
            db.Students.Where(m => m.Id == student.Id).First().Phone = phonenumber.Text;
            db.Students.Where(m => m.Id == student.Id).First().Address = address.Text;
            int numberoom = int.Parse(roomnumber.Text);
            db.Students.Where(m => m.Id == student.Id).First().RoomId = db.Room.Where(o => o.Number == numberoom).Select(o => o.Id).First();
            db.Students.Where(m => m.Id == student.Id).First().FacultyId = db.Faculty.Where(o => o.FacultyName == facultyname.Text).Select(o => o.Id).First();
            db.Students.Where(m => m.Id == student.Id).First().GroupId = db.Group.Where(o => o.GroupName == groupname.Text).Select(o => o.Id).First();
            if (picturebytes != null)
            {
                db.Students.Where(m => m.Id == student.Id).First().StudentsPhoto = picturebytes;
            }
            db.SaveChanges();
            MessageBox.Show("Edit Completed!");
            stackpanel3.Visibility = Visibility.Hidden;
        }

        private void seeviolations_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (seeviolations.Text == "See Violations")
            {
                datagrid1.Visibility = Visibility.Visible;
                datagrid1.ItemsSource = null;
                datagrid1.ItemsSource = db.Students.Where(o => o.Email == email).Select(o => o.Violations).ToList();
                datagrid1.UpdateLayout();
                seeviolations.Text = "Close Violations";
                int id = db.Students.Where(o => o.Email == email).Select(o => o.Id).First();
                datagrid1.ItemsSource = db.Violation.Where(o => o.StudentId == id).ToList();
            }
            else
            {
                datagrid1.Visibility = Visibility.Hidden;
                seeviolations.Text = "See Violations";
            }
        }

        private void residencecombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (residencecombo.SelectedIndex != -1)
            {
                roomcombo.ItemsSource = null;
                int id = db.Residence.Where(o => o.ResidenceName == residencecombo.SelectedItem.ToString()).Select(o => o.Id).First();
                foreach (var item in db.Room)
                {
                    if (item.ResidenceId == id)
                    {
                        roomcombo.Items.Add(item.Number);
                    }
                }
            }
        }

        private void facultycombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (facultycombo.SelectedIndex != -1)
            {
                groupcombo.Items.Clear();
                //MessageBox.Show(faculty.SelectedItem.ToString());
                int id = db.Faculty.Where(o => o.FacultyName == facultycombo.SelectedItem.ToString()).Select(o => o.Id).First();
                foreach (var item in db.Group)
                {
                    if (item.FacultyId == id)
                    {
                        groupcombo.Items.Add(item.GroupName);
                    }
                }
            }
        }

        private void editphoto_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Graphics File|*.bmp; *.gif; *.jpg; *.png";
            ofd.FileName = "";
            if (ofd.ShowDialog() == true)
            {
                using (StudentHostelContext db = new StudentHostelContext())
                {
                    Picture = ofd.FileName;
                }
                System.Drawing.Image img = System.Drawing.Image.FromFile(Picture);
                int maxWidth = 300, maxHeight = 300;
                //we pick the width
                double ratioX = (double)maxWidth / img.Width;
                double ratioY = (double)maxHeight / img.Height;
                double ratio = Math.Min(ratioX, ratioY);
                int newWidth = (int)(img.Width * ratio);
                int newHeight = (int)(img.Height * ratio);
                System.Drawing.Image mi = new Bitmap(newWidth, newHeight);
                //the Picture is in the memory
                Graphics g = Graphics.FromImage(mi);
                g.DrawImage(img, 0, 0, newWidth, newHeight);
                MemoryStream ms = new MemoryStream();
                //поток для ввода|вывода байт из памяти
                mi.Save(ms, ImageFormat.Jpeg);
                ms.Flush();//выносим в поток все данные
                           //из буфера
                ms.Seek(0, SeekOrigin.Begin);
                BinaryReader br = new BinaryReader(ms);
                byte[] buf = br.ReadBytes((int)ms.Length);
                picturebytes = buf;
                using (MemoryStream mStream = new MemoryStream(buf))
                {
                    ImageSource a = BitmapFrame.Create(mStream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                    //if error I have changed image.source and imgUser.fill places!
                    image.Source = null;
                    imgUser.Fill = new ImageBrush(a);
                }
                imgUser.UpdateLayout();
            }
        }

        private void selectioncombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (selectioncombo.SelectedItem.ToString() == "Students")
            {
                information.ItemsSource = db.Students.ToList();
            }
            if (selectioncombo.SelectedItem.ToString() == "Parents")
            {
                information.ItemsSource = db.ParentsInfo.ToList();
            }
            if (selectioncombo.SelectedItem.ToString() == "Residence")
            {
                information.ItemsSource = db.Residence.ToList();
            }
            if (selectioncombo.SelectedItem.ToString() == "Room")
            {
                information.ItemsSource = db.Room.ToList();
            }
            if (selectioncombo.SelectedItem.ToString() == "Faculty")
            {
                information.ItemsSource = db.Faculty.ToList();
            }
            if (selectioncombo.SelectedItem.ToString() == "Groups")
            {
                information.ItemsSource = db.Group.ToList();
            }
            if (selectioncombo.SelectedItem.ToString() == "Course")
            {
                information.ItemsSource = db.Course.ToList();
            }
            if (selectioncombo.SelectedItem.ToString() == "Furniture")
            {
                information.ItemsSource = db.Furniture.ToList();
            }
            if (selectioncombo.SelectedItem.ToString() == "Violations")
            {
                information.ItemsSource = db.Violation.ToList();
            }
        }

        private void updateinformation_Click(object sender, RoutedEventArgs e)
        {
            if (selectioncombo.SelectedIndex != -1)
            {
                if (selectioncombo.SelectedItem.ToString() == "Violations")
                {
                    MessageBox.Show("Can't Edit Violations Only Delete!");
                }
                else
                {
                    Edit form = new Edit(selectioncombo.SelectedItem.ToString());
                    form.Show();
                }
            }
            else
            {
                MessageBox.Show("Select the table!");
            }
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (selectioncombo.SelectedIndex != -1)
            {
                Deleting form = new Deleting(selectioncombo.SelectedItem.ToString());
                form.Show();
            }
            else
            {
                MessageBox.Show("Select the table!");
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            if(selectioncombo.SelectedItem.ToString() != "Students" && selectioncombo.SelectedItem.ToString() != "Parents"
                && selectioncombo.SelectedItem.ToString() != "Violations")
            {
                if(selectioncombo.SelectedIndex != -1)
                {
                    AddToDb form = new AddToDb(selectioncombo.SelectedItem.ToString());
                    form.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Select the table!");
                }
            }
            else if(selectioncombo.SelectedItem.ToString() == "Students")
            {
                MessageBox.Show("Can't Add Student, Student Add's by the program himself!");
            }
            else if (selectioncombo.SelectedItem.ToString() == "Violations")
            {
                MessageBox.Show("Violations are added in the Edit Section of the Student!");
            }
            else if(selectioncombo.SelectedIndex == -1)
            {
                MessageBox.Show("Select the Table Before Adding");
            }
            else
            {
                MessageBox.Show("Can't Add Parents, Student Add's parents!");
            }
        }

        private void delaccount_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Students students = db.Students.Where(o => o.Email == email).First();
            ParentsInfo parents = db.ParentsInfo.Where(o => o.StudentId == students.Id).First();
            db.ParentsInfo.Remove(parents);
            db.Students.Remove(students);
            db.SaveChanges();
            MainWindow form = new MainWindow();
            form.Show();
            this.Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else { this.WindowState = WindowState.Maximized; }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
