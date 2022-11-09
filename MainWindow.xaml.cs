using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
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
using System.Drawing;
using System.IO;
using System.Data;
using System.Drawing.Imaging;
using System.Net.Mail;
using System.Net;

namespace Student_hostel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection conn = new SqlConnection();
        string conn_str = ConfigurationManager.ConnectionStrings["StudentHostel1"].ConnectionString;
        StudentHostelContext db = null;
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                db = new StudentHostelContext();
                if (db.Students.Any(o => o.FullName == "Admin") != true)
                {
                    Students admin = new Students() { FullName = "Admin", IsAdmin = true, Email = "lidiiabelenkova@gmail.com", Password = "admin"/*, BirthDate=DateTime.Now */};
                    db.Students.Add(admin as Students);
                    db.SaveChanges();
                }
                //else
                //{
                //    bool isexists = db.Students.Any(o => o.FullName == "Admin");
                //    if (isexists == false)
                //    {
                //        Students admin = new Students() { FullName = "Admin", IsAdmin = true, Email = "lidiiabelenkova@gmail.com", Password = "admin"/*, BirthDate=DateTime.Now */};
                //        db.Students.Add(admin as Students);
                //        db.SaveChanges();
                //    }
                //}
            }
            catch (Exception o)
            {
                MessageBox.Show(o.Message);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else { this.WindowState = WindowState.Maximized; }

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (var item in db.Students)
                {
                    if (item.Email == txtUser.Text)
                    {
                        throw new Exception("This Email Exists!");

                    }
                }
                
                string email = txtUser.Text;
                string password;
                if (txtPass.Password == txtConfirmPass.Password)
                {
                    password = txtPass.Password;
                    StudentRegistry form = new StudentRegistry(email, password);
                    form.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Passwords Don't Match!");
                }
            }
            catch (Exception o)
            {
                MessageBox.Show(o.Message);
            }
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Login form = new Login();
            form.Show();
            this.Close();
        }
    }
}
