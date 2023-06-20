using MilitaryRegistrationInfoSystem.EF;
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
    public partial class AddRecruitMedicalInfoWindow : Window
    {
        bool isEdit = true;
        EF.MedicalConclusion medicalConclusionEdit = new MedicalConclusion();

        public AddRecruitMedicalInfoWindow()
        {
            isEdit = false;
            InitializeComponent();
        }

        public AddRecruitMedicalInfoWindow(EF.MedicalConclusion medicalConclusion)
        {
            InitializeComponent();
            DateDatePicker.Text = medicalConclusion.DateOfMedicalExamination.ToString();
            ConclusionTextBox.Text = medicalConclusion.TherapistConclusion;

            medicalConclusionEdit = medicalConclusion;
            ClassHelper.AppData.context.SaveChanges();

        }

        private void bOk_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ConclusionTextBox.Text))
            {
                MessageBox.Show("Вы не ввели заключение");
                return;
            }     
            var workerSPass = ClassHelper.AppData.context.MedicalConclusion.Where(i => i.TherapistConclusion == ConclusionTextBox.Text).ToList().FirstOrDefault();

            if (isEdit == true)
            {

            }

            if (isEdit)
            {
                medicalConclusionEdit.DateOfMedicalExamination = Convert.ToDateTime(DateDatePicker.Text);
                medicalConclusionEdit.TherapistConclusion = ConclusionTextBox.Text;    

                ClassHelper.AppData.context.SaveChanges();
                MessageBox.Show("Пользователь успешно изменен!");
                this.Close();
            }
            else
            //Добавление
            {
                MedicalConclusion medicalConclusion = new MedicalConclusion();
                medicalConclusion.DateOfMedicalExamination = Convert.ToDateTime(DateDatePicker.Text);
                medicalConclusion.TherapistConclusion = ConclusionTextBox.Text;

                ClassHelper.AppData.context.MedicalConclusion.Add(medicalConclusion);
                ClassHelper.AppData.context.SaveChanges();
                MessageBox.Show("Медицинская комиссия успешно добавлена!");
                this.Close();
            };
        }
        private void bCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
