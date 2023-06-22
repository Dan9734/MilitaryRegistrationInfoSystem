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
        bool isEdit = false;
        EF.MedicalConclusion medicalConclusionEdit = new MedicalConclusion();
        EF.Recruit recruit1 = new Recruit();
        int idRole = 0;

        //public AddRecruitMedicalInfoWindow()
        //{
        //    isEdit = false;
        //    InitializeComponent();
        //}

        public AddRecruitMedicalInfoWindow(EF.Recruit recruit,int IdRole)
        {
            InitializeComponent();
            var isHaveMedical = ClassHelper.AppData.context.MedicalConclusion.Where(i => i.IDRecruit == recruit.ID).FirstOrDefault();
            recruit1 = recruit;
            idRole = IdRole;
            if (isHaveMedical != null)
            {
                
                medicalConclusionEdit = ClassHelper.AppData.context.MedicalConclusion.Where(i => i.IDRecruit == recruit.ID).FirstOrDefault();
                isEdit = true;
            }
            if (idRole == 1)
            {
                ConclusionTextBox.Text = medicalConclusionEdit.TherapistConclusion;
            }
            else if (this.idRole == 2)
            {
                ConclusionTextBox.Text = medicalConclusionEdit.SurgeonConclusion;
            }
            else if (this.idRole == 3)
            {
                ConclusionTextBox.Text = medicalConclusionEdit.NeurologistConclusion;
            }
            else if (this.idRole == 4)
            {
                ConclusionTextBox.Text = medicalConclusionEdit.PsychiatristConclusion;
            }
            else if (this.idRole == 5)
            {
                ConclusionTextBox.Text = medicalConclusionEdit.OptometristConclusion;
            }
            else if (this.idRole == 6)
            {
                ConclusionTextBox.Text = medicalConclusionEdit.OtolaryngologistConclusion;
            }
            else if (this.idRole == 7)
            {
                ConclusionTextBox.Text = medicalConclusionEdit.DentistConclusion;
            }
            LNameTextBox.Text = recruit.LName;
            FNameTextBox.Text = recruit.FName;
            MNameTextBox.Text = recruit.MName;
            DateDatePicker.Text = DateTime.Now.ToShortDateString();
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
                try
                {
                    var time = Convert.ToDateTime(DateDatePicker.Text);

                    medicalConclusionEdit.DateOfMedicalExamination = time;

                }
                catch
                {
                    var time = medicalConclusionEdit.DateOfMedicalExamination;
                    medicalConclusionEdit.DateOfMedicalExamination = medicalConclusionEdit.DateOfMedicalExamination;
                }
                medicalConclusionEdit.IDRecruit = recruit1.ID;
                if (idRole == 1)
                {
                    medicalConclusionEdit.TherapistConclusion = ConclusionTextBox.Text;
                }
                else if (idRole == 2)
                {
                    medicalConclusionEdit.SurgeonConclusion = ConclusionTextBox.Text;
                }
                else if (idRole == 3)
                {
                    medicalConclusionEdit.NeurologistConclusion = ConclusionTextBox.Text;
                }
                else if (idRole == 4)
                {
                    medicalConclusionEdit.PsychiatristConclusion = ConclusionTextBox.Text;
                }
                else if (idRole == 5)
                {
                    medicalConclusionEdit.OptometristConclusion = ConclusionTextBox.Text;
                }
                else if (idRole == 6)
                {
                    medicalConclusionEdit.OtolaryngologistConclusion = ConclusionTextBox.Text;
                }
                else if (idRole == 7)
                {
                    medicalConclusionEdit.DentistConclusion = ConclusionTextBox.Text;
                }
                ClassHelper.AppData.context.SaveChanges();
                MessageBox.Show("Пользователь успешно изменен!");
                this.Close();

            }
            else
            {
                if (idRole == 1)
                {
                    MedicalConclusion medicalConclusion = new MedicalConclusion();
                    try
                    {
                        medicalConclusion.DateOfMedicalExamination = Convert.ToDateTime(DateDatePicker.Text);
                    }
                    catch
                    {
                        medicalConclusion.DateOfMedicalExamination = DateTime.Now;
                    }
                    medicalConclusion.TherapistConclusion = ConclusionTextBox.Text;
                    medicalConclusion.IDRecruit = recruit1.ID;
                    ClassHelper.AppData.context.MedicalConclusion.Add(medicalConclusion);
                    ClassHelper.AppData.context.SaveChanges();
                    MessageBox.Show("Пользователь успешно добавлен!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Данный человек не пришел к терапевту");
                }
               
            }
        }
        private void bCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
