using MilitaryRegistrationInfoSystem.ClassHelper;
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

namespace MilitaryRegistrationInfoSystem.Windows
{
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            EF.Worker userAuth = ClassHelper.AppData.context.Worker.Where(i => i.Login == txbLogin.Text && i.Password == txbPassword.Text).ToList().FirstOrDefault();
            if (userAuth.IsAdmin == false)
                {
                MainWindow menu = new MainWindow();
                txbLogin.Clear();
                txbPassword.Clear();
                this.Close();
                menu.ShowDialog();
                
            }
            else if (userAuth.IsAdmin == true)
            {
                MainWindowForAdmin menu = new MainWindowForAdmin();
                txbLogin.Clear();
                txbPassword.Clear();
                this.Close();
                menu.ShowDialog();
            }
            if (userAuth.IDDoctor == 1)
            {
                TherapistWindow menu = new TherapistWindow();
                txbLogin.Clear();
                txbPassword.Clear();
                this.Close();
                menu.ShowDialog();
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль");
            }
        }
        
        private void Grid_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                var userAuth = AppData.context.Worker.Where(i => i.Login == txbLogin.Text && i.Password == txbPassword.Text).ToList().FirstOrDefault();
                if (userAuth != null)
                {
                    MainWindow menu = new MainWindow();
                    txbLogin.Clear();
                    txbPassword.Clear();
                    this.Close();
                    menu.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Неправильный логин или пароль");
                }
            }

        }
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}