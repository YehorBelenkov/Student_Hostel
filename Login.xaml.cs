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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        StudentHostelContext db = null;
        public Login()
        {
            InitializeComponent();
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ConfirmIdentity form = new ConfirmIdentity();
            form.Show();
            this.Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            db = new StudentHostelContext();
            if (db.Students.Any(o => o.Email == txtUser.Text) == true)
            {
                //db.Students.Any(o => o.Password == passwordtxt.Password)
                if (db.Students.Where(o=>o.Email == txtUser.Text).Select(o=>o.Password == passwordtxt.Password).First() != true)
                {
                    MessageBox.Show("Incorect Password");
                }
                else
                {
                    Studentpage form = new Studentpage(txtUser.Text);
                    form.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("This User does not exist!");
            }
            
        }
    }
}
