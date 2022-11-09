using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Student_hostel
{
    /// <summary>
    /// Interaction logic for StudentRegistry.xaml
    /// </summary>
    public partial class StudentRegistry : Window
    {
        StudentHostelContext db = null;
        string Picture = null;
        byte[] picturebytes;
        Students student = new Students();
        string email = null;
        string password = null;
        public StudentRegistry(string email, string password)
        {
            InitializeComponent();
            db = new StudentHostelContext();
            Loaded += StudentRegistry_Loaded;
            this.email = email;
            this.password = password;
        }

        private void StudentRegistry_Loaded(object sender, RoutedEventArgs e)
        {
            fillingcombo();
        }

        private void fillingcombo()
        {
            residence.ItemsSource = db.Residence.Select(o => o.ResidenceName).ToList();
            faculty.ItemsSource = db.Faculty.Select(o => o.FacultyName).ToList();
            gender.Items.Add("Male");
            gender.Items.Add("Female");
            gender.Items.Add("Other");
            gender.UpdateLayout();
            residence.UpdateLayout();
            faculty.UpdateLayout();
        }
        private void imgUser_MouseDown(object sender, MouseButtonEventArgs e)
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

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Students student = null;
            checkifnotfilled(student);
        }
        private void checkifnotfilled(Students student)
        {
            if (firstname.Text != "" && lastname.Text != "" && address.Text != "" && birthdate.Text != "" && residence.SelectedIndex != -1
                && roomnumber.SelectedIndex != -1 && faculty.SelectedIndex != -1 && group.SelectedIndex != -1 && phone.Text != ""
                && gender.SelectedIndex != -1)
            {
                try
                {
                    string fullname1 = firstname.Text + " " + lastname.Text;
                    int room1 = int.Parse(roomnumber.SelectedItem.ToString());
                    int room2 = db.Room.Where(o => o.Number == room1).Select(o => o.Id).First();
                    student = new Students()
                    {
                        Email = email,
                        Password = password,
                        FullName = fullname1,
                        Address = address.Text,
                        Phone = phone.Text,
                        Sex = gender.SelectedItem.ToString(),
                        FacultyId = db.Faculty.Where(o => o.FacultyName == faculty.SelectedItem.ToString()).Select(o => o.Id).First(),
                        GroupId = db.Group.Where(o => o.GroupName == group.SelectedItem.ToString()).Select(o => o.Id).First(),
                        RoomId = room2,
                        BirthDate = DateTime.Parse(birthdate.Text),
                        StudentsPhoto = picturebytes,
                        Faculty = db.Faculty.Where(o => o.FacultyName == faculty.SelectedItem.ToString()).First(),
                        Group = db.Group.Where(o => o.GroupName == group.SelectedItem.ToString()).First()
                        //Room = db.Room.Where(o => o.Id == room2).First()
                    };
                }
                catch (Exception o)
                {
                    if (o.Message == "String was not recognized as a valid DateTime.")
                    {
                        MessageBox.Show("You're Birthday is Invalid try writting\nmm/dd/yy");
                    }
                    else
                    {
                        MessageBox.Show(o.Message);
                    }
                }
                this.student = student;
                checkifoldenough(student.BirthDate.Value);
            }
            else
            {
                MessageBox.Show("Make sure you filled all the blanks!");
            }
        }
        private void checkifoldenough(DateTime date)
        {
            int check = DateTime.Now.Year - date.Year;
            if (check >= 18)
            {
                db.Students.Add(student);
                db.SaveChanges();
                MessageBox.Show("Registered Successfully!");
                Login form = new Login();
                form.Show();
                this.Close();
            }
            else if (check <= 17)
            {
                MessageBox.Show("Sense you're not 18 or older we need to register you're Parents!");
                RegisterParents form = new RegisterParents(student);
                form.Show();
                this.Close();
            }
        }
        private void residence_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (residence.SelectedIndex != -1)
            {
                roomnumber.Items.Clear();
                int id = db.Residence.Where(o => o.ResidenceName == residence.SelectedItem.ToString()).Select(o => o.Id).First();
                foreach (var item in db.Room)
                {
                    if (item.ResidenceId == id)
                    {
                        roomnumber.Items.Add(item.Number);
                    }
                }
                //var list = from a in db.Residence
                //           join b in db.Room on a.Id equals b.ResidenceId
                //           select new { Room = b.Number };
                //roomnumber.ItemsSource = list.ToList();
            }
        }

        private void faculty_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (faculty.SelectedIndex != -1)
            {
                group.Items.Clear();
                //MessageBox.Show(faculty.SelectedItem.ToString());
                int id = db.Faculty.Where(o => o.FacultyName == faculty.SelectedItem.ToString()).Select(o => o.Id).First();
                foreach (var item in db.Group)
                {
                    if (item.FacultyId == id)
                    {
                        group.Items.Add(item.GroupName);
                    }
                }
                //var list = from a in db.Group
                //           join b in db.Faculty on a.FacultyId equals b.Id
                //           select new { Name = a.GroupName };
                //group.ItemsSource = list.ToList();
            }
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
