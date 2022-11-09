using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
    /// Interaction logic for ConfirmIdentity.xaml
    /// </summary>
    public partial class ConfirmIdentity : Window
    {
        Random rand = new Random();
        public int num;
        public ConfirmIdentity()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            
            //if(int.Parse(password.Text) == this.password)
            //{

            //}
            if(int.Parse(code.Text) == num)
            {
                NewPassword form = new NewPassword(email.Text);
                form.Show();
                this.Close();
            }
            else { MessageBox.Show("Incorect Password!"); }
        }

        private void sendemail_Click(object sender, RoutedEventArgs e)
        {
            num = rand.Next(1000, 9999);
            var fromAddress = new MailAddress("robottester51@gmail.com", "Student Hostel");
            var toAddress = new MailAddress(email.Text, "Yehor");
            const string fromPassword = "iokkbczukalzztuv";
            const string subject = "Change Password";
            string body = $"Hello this is the message to reset you're password!\nHere is you're code: [{num}]";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20000
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}
