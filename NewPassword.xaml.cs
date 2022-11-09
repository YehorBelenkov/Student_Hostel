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
    /// Interaction logic for NewPassword.xaml
    /// </summary>
    public partial class NewPassword : Window
    {
        string email = null;
        StudentHostelContext db = new StudentHostelContext();
        public NewPassword(string email)
        {
            InitializeComponent();
            this.email = email;
        }

       

        private void btnLogin_Click_1(object sender, RoutedEventArgs e)
        {
            if(confirmpas.Password == txtPass.Password)
            {
                db.Students.Where(o => o.Email == email).First().Password = txtPass.Password;
                db.SaveChanges();
                MainWindow form = new MainWindow();
                form.Show();
                this.Close();
            }
            else { MessageBox.Show("Passwords don't match!"); }
        }
    }
}
