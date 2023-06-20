using MilitaryRegistrationInfoSystem.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Policy;
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
using System.Xml.Linq;
using static MilitaryRegistrationInfoSystem.ClassHelper.AppData;

namespace MilitaryRegistrationInfoSystem.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddWorkerWindow.xaml
    /// </summary>
    public partial class AddWorkerWindow : Window
    {
        bool isEdit = true;
        EF.Worker workerEdit = new Worker();

        public AddWorkerWindow()
        {
            isEdit = false;
            InitializeComponent();
        }

        public AddWorkerWindow(EF.Worker worker)
        {
            InitializeComponent();
            LNameTextBox.Text = worker.LName;
            FNameTextBox.Text = worker.FName;
            MNameTextBox.Text = worker.MName;
            SPassTextBox.Text = worker.S_Pass;
            NPassTextBox.Text = worker.N_Pass;
            PositionTextBox.Text = worker.Position;
            LoginTextBox.Text = worker.Login;
            PasswordTextBox.Text = worker.Password;
            IsAdminCheckBox.IsChecked = worker.IsAdmin;
            PhoneTextBox.Text = worker.Phone;
            DescrTextBox.Text = worker.Descr;

            workerEdit = worker;
            ClassHelper.AppData.context.SaveChanges();

        }

        private void LNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => (ch >= 'а' && ch <= 'я') || (ch >= 'А' && ch <= 'Я') || ch == 'ё' || ch == 'Ё' || (ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z')).ToArray()
                    );
            }
        }

        private void FNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => (ch >= 'а' && ch <= 'я') || (ch >= 'А' && ch <= 'Я') || ch == 'ё' || ch == 'Ё' || (ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z')).ToArray()
                    );
            }
        }

        private void MNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => (ch >= 'а' && ch <= 'я') || (ch >= 'А' && ch <= 'Я') || ch == 'ё' || ch == 'Ё' || (ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z')).ToArray()
                    );
            }
        }

        private void SPassTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            {
                if (sender is TextBox textBox)
                {
                    textBox.Text = new string
                        (
                             textBox.Text.Where(ch => (ch >= '0' && ch <= '9')).ToArray()
                        );
                }
            }
        }

        private void NPassTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            {
                if (sender is TextBox textBox)
                {
                    textBox.Text = new string
                        (
                             textBox.Text.Where(ch => (ch >= '0' && ch <= '9')).ToArray()
                        );
                }
            }
        }

        private void PositionTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => (ch >= 'а' && ch <= 'я') || (ch >= 'А' && ch <= 'Я') || ch == 'ё' || ch == 'Ё' || (ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z')).ToArray()
                    );
            }
        }

        private void LoginTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => (ch >= 'а' && ch <= 'я') || (ch >= 'А' && ch <= 'Я') || ch == 'ё' || ch == 'Ё' || (ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z') || (ch >= '0' && ch <= '9')).ToArray()
                    );
            }
        }

        private void PasswordTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => (ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z') || ch == '/' || ch == '.' || (ch >= '0' && ch <= '9')).ToArray()
                    );
            }
        }

        private void IsAdminCheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void PhoneTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => (ch >= '0' && ch <= '9') || ch >= ')' || ch >= '(').ToArray()
                    );
            }
        }

        private void DescrTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => (ch >= 'а' && ch <= 'я') || (ch >= 'А' && ch <= 'Я') || ch == 'ё' || ch == 'Ё' || (ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z') || (ch >= '0' && ch <= '9')).ToArray()
                    );
            }
        }
        private void bOk_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FNameTextBox.Text))
            {
                MessageBox.Show("Вы не ввели имя");
                return;
            }

            if (string.IsNullOrWhiteSpace(LNameTextBox.Text))
            {
                MessageBox.Show("Вы не ввели фамилию");
                return;
            }
            if (string.IsNullOrWhiteSpace(SPassTextBox.Text))
            {
                MessageBox.Show("Вы не ввели cерию паспорта");
                return;
            }
            if (string.IsNullOrWhiteSpace(NPassTextBox.Text))
            {
                MessageBox.Show("Вы не ввели номер паспорта");
                return;
            }
            if (string.IsNullOrWhiteSpace(PositionTextBox.Text))
            {
                MessageBox.Show("Вы не ввели должность");
                return;
            }
            if (string.IsNullOrWhiteSpace(LoginTextBox.Text))
            {
                MessageBox.Show("Вы не ввели логин");
                return;
            }
            if (string.IsNullOrWhiteSpace(PasswordTextBox.Text))
            {
                MessageBox.Show("Вы не ввели пароль");
                return;
            }
            var workerSPass = ClassHelper.AppData.context.Worker.Where(i => i.S_Pass == SPassTextBox.Text).ToList().FirstOrDefault();
            var workerNPass = ClassHelper.AppData.context.Worker.Where(i => i.N_Pass == NPassTextBox.Text).ToList().FirstOrDefault();
            var workerPhone = ClassHelper.AppData.context.Worker.Where(i => i.N_Pass == PhoneTextBox.Text).ToList().FirstOrDefault();

            if (isEdit == true)
            {

            }
            else
            {
                if (workerSPass != null)
                {
                    MessageBox.Show("Данный номер паспорта уже есть в системе ", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (workerNPass != null)
                {
                    MessageBox.Show("Данная серия паспорта уже есть в системе ", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (workerPhone != null)
                {
                    MessageBox.Show("Данный номер телефона уже есть в системе ", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            if (isEdit)
            {
                workerEdit.LName = LNameTextBox.Text;
                workerEdit.FName = FNameTextBox.Text;
                workerEdit.MName = MNameTextBox.Text;
                workerEdit.S_Pass = SPassTextBox.Text;
                workerEdit.N_Pass = NPassTextBox.Text;
                workerEdit.Position = PositionTextBox.Text;
                workerEdit.Login = LoginTextBox.Text;
                workerEdit.Password = PasswordTextBox.Text;
                workerEdit.IsAdmin = IsAdminCheckBox.IsChecked;
                workerEdit.Phone = PhoneTextBox.Text;
                workerEdit.Descr = DescrTextBox.Text;

                ClassHelper.AppData.context.SaveChanges();
                MessageBox.Show("Пользователь успешно изменен!");
                this.Close();
            }
            else
            //Добавление
            {
                Worker worker = new Worker();
                worker.LName = LNameTextBox.Text;
                worker.FName = FNameTextBox.Text;
                worker.MName = MNameTextBox.Text;
                worker.S_Pass = SPassTextBox.Text;
                worker.N_Pass = NPassTextBox.Text;
                worker.Position = PositionTextBox.Text;
                worker.Login = LoginTextBox.Text;
                worker.Password = PasswordTextBox.Text;
                worker.IsAdmin = IsAdminCheckBox.IsChecked;
                worker.Phone = PhoneTextBox.Text;
                worker.Descr = DescrTextBox.Text;

                ClassHelper.AppData.context.Worker.Add(worker);
                ClassHelper.AppData.context.SaveChanges();
                MessageBox.Show("Сотрудник успешно добавлен!");
                this.Close();
            };
            //MessageBox.Show("Сотрудник добавлен");
            //context.Worker.Add(worker);
            //context.SaveChanges();

            //this.Hide();
            //MainWindowForAdmin mainWindowForAdmin = new MainWindowForAdmin();
            //mainWindowForAdmin.ShowDialog();
            //this.Close();


        }
        private void bCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
