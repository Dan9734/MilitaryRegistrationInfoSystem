using MilitaryRegistrationInfoSystem.EF;
using System;
using System.Collections.Generic;
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
using MilitaryRegistrationInfoSystem.ClassHelper;
using static MilitaryRegistrationInfoSystem.ClassHelper.AppData;


namespace MilitaryRegistrationInfoSystem.Windows
{
    /// <summary>
    /// Логика взаимодействия для RecruitMedicalInfoWindow.xaml
    /// </summary>
    public partial class RecruitMedicalInfoWindow : Window
    {
        List<EF.MedicalConclusion> medicalConclusions = new List<EF.MedicalConclusion>();

        public RecruitMedicalInfoWindow()
        {
            InitializeComponent();
            AllPersonal.ItemsSource = context.MedicalConclusion.ToList();
            cbSort.ItemsSource = listForSort;
            cbSort.SelectedIndex = 0;
            Filter();
        }
        List<string> listForSort = new List<string>()
        {
            "По умолчанию",
            "По заключению терапевта",
            "По дате"
        };

        private void Filter()
        {
            medicalConclusions = context.MedicalConclusion.ToList();
            medicalConclusions = medicalConclusions.Where(e => e.DateOfMedicalExamination.ToString().Contains(tbSearch.Text) ||
            e.TherapistConclusion.Contains(tbSearch.Text)).ToList();

            switch (cbSort.SelectedIndex)
            {
                case 0:
                    medicalConclusions = medicalConclusions.OrderBy(e => e.ID).ToList();
                    break;
                case 2:
                    medicalConclusions = medicalConclusions.OrderBy(e => e.TherapistConclusion).ToList();
                    break;
                case 3:
                    medicalConclusions = medicalConclusions.OrderBy(e => e.DateOfMedicalExamination.ToString()).ToList();
                    break;
                default:
                    medicalConclusions = medicalConclusions.OrderBy(e => e.ID).ToList();
                    break;
            }

            if (medicalConclusions.Count == 0)
            {
                MessageBox.Show("Записей нет");
            }
            AllPersonal.ItemsSource = medicalConclusions;
        }

        private void cbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void tsbAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void tsbDelete_Click(object sender, RoutedEventArgs e)
        {

        }
        private void tsmiBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
            this.Close();
        }
        private void ChangeUser_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            Close();
            authorizationWindow.ShowDialog();
        }
        private void tsmiBook_Click(object sender, RoutedEventArgs e)
        {

        }
        private void tsbRefresh_Click(object sender, RoutedEventArgs e)
        {
            Filter();
        }
        private void tsmiExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void AllPersonal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
