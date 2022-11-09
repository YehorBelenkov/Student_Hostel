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
    /// Interaction logic for RegisterParents.xaml
    /// </summary>
    public partial class RegisterParents : Window
    {
        Students student;
        public RegisterParents(object o)
        {
            student = o as Students;
            InitializeComponent();

            kinship.Items.Add("True");
            kinship.Items.Add("False");
            kinship1.Items.Add("True");
            kinship1.Items.Add("False");
            stackpanel2.Visibility = Visibility.Hidden;
        }

        private void kinship_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (checkbox1.IsChecked == false)
            {
                if (firstname.Text != "" && lastname.Text != "" && address.Text != "" && workplace.Text != "" && kinship.SelectedIndex != -1)
                {
                    using (StudentHostelContext db = new StudentHostelContext())
                    {
                        bool n;
                        if (kinship.SelectedItem == "True")
                        {
                            n = true;
                        }
                        else
                        {
                            n = false;
                        }
                        db.Students.Add(student);
                        db.SaveChanges();
                        ParentsInfo parents = new ParentsInfo() { FullName = firstname.Text + " " + lastname.Text, Address = address.Text, KinshipStatus = n, Phone = phone.Text, WorkPlace = workplace.Text, Student = student };
                        db.ParentsInfo.Add(parents);
                        db.SaveChanges();
                        db.Students.Where(m => m.Id == student.Id).First().ParentsInfos.Add(parents); db.SaveChanges();
                    }
                    Login form = new Login();
                    form.Show();
                    this.Close();
                }
            }
            else
            {
                if (firstname.Text != "" && lastname.Text != "" && address.Text != "" && workplace.Text != "" && kinship.SelectedIndex != -1 &&
                    firstname1.Text != "" && lastname1.Text != "" && address1.Text != "" && workplace1.Text != "" && kinship1.SelectedIndex != -1)
                {
                    using (StudentHostelContext db = new StudentHostelContext())
                    {
                        bool n, n1;
                        if (kinship.SelectedItem == "True")
                        {
                            n = true;
                        }
                        else
                        {
                            n = false;
                        }
                        if (kinship1.SelectedItem == "True")
                        {
                            n1 = true;
                        }
                        else
                        {
                            n1 = false;
                        }

                        db.Students.Add(student);
                        db.SaveChanges();
                        ParentsInfo parents = new ParentsInfo() { FullName = firstname.Text + " " + lastname.Text, Address = address.Text, KinshipStatus = n, Phone = phone.Text, WorkPlace = workplace.Text, Student = student };
                        db.ParentsInfo.Add(parents);
                        db.SaveChanges();
                        db.Students.Where(m => m.Id == student.Id).First().ParentsInfos.Add(parents); db.SaveChanges();
                        student.ParentsInfos.Add(parents);
                        parents = new ParentsInfo() { FullName = firstname1.Text + " " + lastname1.Text, Address = address1.Text, KinshipStatus = n1, Phone = phone1.Text, WorkPlace = workplace1.Text, Student = student };
                        db.ParentsInfo.Add(parents);
                        db.SaveChanges();
                        db.Students.Where(m => m.Id == student.Id).First().ParentsInfos.Add(parents); db.SaveChanges();
                    }
                    Login form = new Login();
                    form.Show();
                    this.Close();
                }
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

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            stackpanel2.Visibility = Visibility.Visible;
        }

        private void checkbox1_Unchecked(object sender, RoutedEventArgs e)
        {
            stackpanel2.Visibility = Visibility.Hidden;
        }
    }
}
