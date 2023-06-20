using MilitaryRegistrationInfoSystem.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
using static MilitaryRegistrationInfoSystem.ClassHelper.AppData;

namespace MilitaryRegistrationInfoSystem.Windows
{
    public partial class AddRecruitWindow : Window
    {
        bool isEdit = true;
        EF.Recruit recruitEdit = new Recruit();

        public AddRecruitWindow()
        {
            isEdit = false;
            InitializeComponent();
        }

        public AddRecruitWindow(EF.Recruit recruit)
        {
            InitializeComponent();
            LNameTextBox.Text = recruit.LName;
            FNameTextBox.Text = recruit.FName;
            MNameTextBox.Text = recruit.MName;
            DateBirthDatePicker.Text = recruit.DateBirth.ToString();
            WorkPlaceTextBox.Text = recruit.WorkPlace;
            RegistrationAddressTextBox.Text = recruit.RegistrationPlace;
            LivePlaceTextBox.Text = recruit.LivePlace;
            PhoneTextBox.Text = recruit.Phone;
            SPassTextBox.Text = recruit.S_Pass;
            NPassTextBox.Text = recruit.N_Pass;
            DateIssuePassportDatePicker.Text = recruit.DateIssuePassport.ToString();
            PassportIssuedTextBox.Text = recruit.PassportIssued;

            recruitEdit = recruit;
            ClassHelper.AppData.context.SaveChanges();

        }
            private void bCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void tsbEduDelete_Click(object sender, RoutedEventArgs e)
        {
            
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
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => (ch >= '0' && ch <= '9')).ToArray()
                    );
            }
        }

        private void NPassTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => (ch >= '0' && ch <= '9')).ToArray()
                    );
            }
        }

        private void DateIssueTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => (ch >= '0' && ch <= '9') || ch == '.' ).ToArray()
                    );
            }
        }

        private void PhoneTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void PassportIssuedTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

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
            var recruitSPass = ClassHelper.AppData.context.Recruit.Where(i => i.S_Pass == SPassTextBox.Text).ToList().FirstOrDefault();
            var recruitNPass = ClassHelper.AppData.context.Recruit.Where(i => i.N_Pass == NPassTextBox.Text).ToList().FirstOrDefault();
            var recruitPhone = ClassHelper.AppData.context.Recruit.Where(i => i.N_Pass == PhoneTextBox.Text).ToList().FirstOrDefault();

            if (isEdit == true)
            {

            }
            else
            {
                if (recruitSPass != null)
                {
                    MessageBox.Show("Данный номер паспорта уже есть в системе ", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (recruitNPass != null)
                {
                    MessageBox.Show("Данная серия паспорта уже есть в системе ", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (recruitPhone != null)
                {
                    MessageBox.Show("Данный номер телефона уже есть в системе ", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
                //Изменение
                if (isEdit)
                {
                    recruitEdit.LName = LNameTextBox.Text;
                    recruitEdit.FName = FNameTextBox.Text;
                    recruitEdit.MName = MNameTextBox.Text;
                    recruitEdit.DateBirth = Convert.ToDateTime(DateBirthDatePicker.Text);
                    recruitEdit.WorkPlace = WorkPlaceTextBox.Text;
                    recruitEdit.RegistrationPlace = RegistrationAddressTextBox.Text;
                    recruitEdit.LivePlace = LivePlaceTextBox.Text;
                    recruitEdit.Phone = PhoneTextBox.Text;
                    recruitEdit.S_Pass = SPassTextBox.Text;
                    recruitEdit.N_Pass = NPassTextBox.Text;
                    recruitEdit.DateIssuePassport = Convert.ToDateTime(DateIssuePassportDatePicker.Text);
                    recruitEdit.PassportIssued = PassportIssuedTextBox.Text;

                    ClassHelper.AppData.context.SaveChanges();
                    MessageBox.Show("Пользователь успешно изменен!");
                    this.Close();
                }
                else
                //Добавление
                {
                    Recruit recruit = new Recruit();
                    recruit.LName = LNameTextBox.Text;
                    recruit.FName = FNameTextBox.Text;
                    recruit.MName = MNameTextBox.Text;
                    recruit.DateBirth = Convert.ToDateTime(DateBirthDatePicker.Text);
                    recruit.WorkPlace = WorkPlaceTextBox.Text;
                    recruit.RegistrationPlace = RegistrationAddressTextBox.Text;
                    recruit.LivePlace = LivePlaceTextBox.Text;
                    recruit.Phone = PhoneTextBox.Text;
                    recruit.S_Pass = SPassTextBox.Text;
                    recruit.N_Pass = NPassTextBox.Text;
                    recruit.DateIssuePassport = Convert.ToDateTime(DateIssuePassportDatePicker.Text);
                    recruit.PassportIssued = PassportIssuedTextBox.Text;

                    ClassHelper.AppData.context.Recruit.Add(recruit);
                    ClassHelper.AppData.context.SaveChanges();
                    MessageBox.Show("Пользователь успешно добавлен!");
                    this.Close();
                };
        }
    }
}

