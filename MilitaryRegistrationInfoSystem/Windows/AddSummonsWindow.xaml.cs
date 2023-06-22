using MilitaryRegistrationInfoSystem.EF;
using System;
using System.Linq;
using System.Windows;

namespace MilitaryRegistrationInfoSystem.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddSummonsWindow.xaml
    /// </summary>
    public partial class AddSummonsWindow : Window
    {
        bool isEdit = false;
        EF.Summons summonsEdit = new Summons();
        Recruit recruit1 = new Recruit();
        public AddSummonsWindow()
        {
            InitializeComponent();
        }
        public AddSummonsWindow(EF.Summons summons)
        {
            InitializeComponent();
            var recruit = ClassHelper.AppData.context.Recruit.Where(i => i.ID == summons.IDRecruit).FirstOrDefault();
            if (recruit != null)
            {
                recruit1 = recruit;
                var summons1 = ClassHelper.AppData.context.Summons.Where(i => i.IDRecruit == recruit.ID).FirstOrDefault();
                if (summons1 != null)
                {
                    summonsEdit = summons;
                    isEdit = true;
                    tbAddress.Text = summons.MailingAddres;
                    tbReason.Text = summons.ReasonForVisiting;
                }
            }
            LNameTextBox.Text = recruit.LName;
            FNameTextBox.Text = recruit.FName;
            MNameTextBox.Text = recruit.MName;
        }

        private void bOk_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbAddress.Text))
            {
                MessageBox.Show("Вы не ввели Адресс");
                return;
            }
            // var workerSPass = ClassHelper.AppData.context.MedicalConclusion.Where(i => i.TherapistConclusion == ConclusionTextBox.Text).ToList().FirstOrDefault();

            if (isEdit == true)
            {
                try
                {
                    var time = Convert.ToDateTime(DateDatePicker.Text);

                    summonsEdit.DateVisiting = time;

                }
                catch
                {
                    var time = DateTime.Now;
                    summonsEdit.DateVisiting = time;
                }
                summonsEdit.IDRecruit = recruit1.ID;
                summonsEdit.MailingAddres = tbAddress.Text;
                summonsEdit.ReasonForVisiting = tbReason.Text;
                ClassHelper.AppData.context.SaveChanges();
                MessageBox.Show("Пользователь успешно изменен!");
                this.Close();

            }
            else
            {
                Summons summons = new Summons();
                var recruit = ClassHelper.AppData.context.Recruit.Where(i => i.LName == LNameTextBox.Text && i.FName == FNameTextBox.Text && i.MName == MNameTextBox.Text).FirstOrDefault();
                summons.IDRecruit = recruit.ID;
                try
                {
                    summons.DateVisiting = Convert.ToDateTime(DateDatePicker.Text);
                }
                catch
                {
                    summons.DateVisiting = DateTime.Now;
                }
                summons.MailingAddres = tbAddress.Text;
                summons.ReasonForVisiting = tbReason.Text;
                //summons.IDVoenkomat = 1;

                ClassHelper.AppData.context.Summons.Add(summons);
                ClassHelper.AppData.context.SaveChanges();
                MessageBox.Show("ПОвестка успешно добавлена!");
                this.Close();

            }
        }
        private void bCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
