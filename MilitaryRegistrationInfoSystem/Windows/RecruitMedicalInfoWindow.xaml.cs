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
        List<EF.Recruit> recruit = new List<EF.Recruit>();

        public RecruitMedicalInfoWindow()
        {
            InitializeComponent();
        }

        private void Filter()
        {
            recruit = context.Recruit.ToList();
            recruit = recruit.Where(e => e.LName.Contains(tbSearch.Text) || e.FName.Contains(tbSearch.Text) || e.MName.Contains(tbSearch.Text) || e.Phone.Contains(tbSearch.Text)).ToList();

            switch (cbSort.SelectedIndex)
            {
                case 0:
                    recruit = recruit.OrderBy(e => e.ID).ToList();
                    break;
                case 1:
                    recruit = recruit.OrderBy(e => e.LName).ToList();
                    break;
                case 2:
                    recruit = recruit.OrderBy(e => e.FName).ToList();
                    break;
                case 3:
                    recruit = recruit.OrderBy(e => e.MName).ToList();
                    break;
            }

            if (recruit.Count == 0)
            {
                MessageBox.Show("Записей нет");
            }
            AllPersonal.ItemsSource = recruit;
        }

        private void cbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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
            this.Hide();
            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            authorizationWindow.ShowDialog();
            this.Close();
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
