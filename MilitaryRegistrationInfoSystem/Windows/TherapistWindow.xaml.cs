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
using MilitaryRegistrationInfoSystem.EF;


namespace MilitaryRegistrationInfoSystem.Windows
{
    /// <summary>
    /// Логика взаимодействия для TherapistWindow.xaml
    /// </summary>
    public partial class TherapistWindow : Window
    {
        List<EF.Recruit> recruit = new List<EF.Recruit>();

        public TherapistWindow()
        {
            InitializeComponent();
            AllPersonal.ItemsSource = context.Recruit.ToList();
            cbSort.ItemsSource = listForSort;
            cbSort.SelectedIndex = 0;
            Filter();
        }
        List<string> listForSort = new List<string>()
        {
            "По умолчанию",
            "По фамилии",
            "По имени",
            "По дате рождения"
        };

        private void Filter()
        {
            recruit = context.Recruit.ToList();
            recruit = recruit.Where(e => e.LName.Contains(tbSearch.Text) || e.FName.Contains(tbSearch.Text) || e.Phone.Contains(tbSearch.Text)).ToList();

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
                    recruit = recruit.OrderBy(e => e.DateBirth).ToList();
                    break;
                default:
                    recruit = recruit.OrderBy(e => e.ID).ToList();
                    break;
            }

            if (recruit.Count == 0)
            {
                MessageBox.Show("Записей нет");
            }
            AllPersonal.ItemsSource = recruit;
        }

        private void AllPersonal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AllPersonal_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                var recruitDel = AllPersonal.SelectedItem as EF.Recruit;
                var medicalConclusion = ClassHelper.AppData.context.MedicalConclusion.Where(i => i.IDRecruit == recruitDel.ID).FirstOrDefault();
                var resClick = MessageBox.Show($"Удалить мед заключение  {recruitDel.LName}", "Подтвержение", MessageBoxButton.YesNo, MessageBoxImage.Information);


                if (resClick == MessageBoxResult.Yes)
                {
                    EF.Recruit recruit = new EF.Recruit();
                    if (!(AllPersonal.SelectedItem is EF.Recruit))
                    {
                        MessageBox.Show("Запись не выбраны");
                        return;
                    }
                    recruit = AllPersonal.SelectedItem as EF.Recruit;

                    AppData.context.MedicalConclusion.Remove(medicalConclusion);
                    AppData.context.SaveChanges();
                }
            }
            Filter();
        }

        private void tsbDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LVEmployee_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EF.Recruit recruit = AllPersonal.SelectedItem as EF.Recruit;
            //AddRecruitWindow add = new AddRecruitWindow(recruit);
            //add.ShowDialog();
            AddRecruitMedicalInfoWindow addRecruitMedicalInfoWindow = new AddRecruitMedicalInfoWindow(recruit,1);
            addRecruitMedicalInfoWindow.ShowDialog();
        }

        private void tsmiExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {

        }
        private void DataUpdate()
        {
            //dbDataSetЗапрос_ПризывникTableAdapter.Fill(dbDataSet.Запрос_Призывник);
        }
        private void tsbAdd_Click(object sender, RoutedEventArgs e)
        {
            EF.Recruit recruit = AllPersonal.SelectedItem as EF.Recruit;
            AddRecruitMedicalInfoWindow form = new AddRecruitMedicalInfoWindow(recruit,1);
            form.ShowDialog();
            //var result = form.ShowDialog();
            //if (result != null && result == true)
            //{
            //    DataUpdate();
            //}
        }

        private void tsbEdit_Click(object sender, RoutedEventArgs e)
        {
            if (AllPersonal.SelectedItem is Recruit recruit)
            {
                this.Hide();
                AddRecruitMedicalInfoWindow addRecruitMedicalInfoWindow = new AddRecruitMedicalInfoWindow(recruit,1);
                addRecruitMedicalInfoWindow.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show($"Вы не выбрали пользователя", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void tsbRefresh_Click(object sender, RoutedEventArgs e)
        {

        }
        private void tsmiReportRecruitQuestionnaire_Click(object sender, RoutedEventArgs e)
        {

        }
        private void tsmiReportRecruitEduList_Click(object sender, RoutedEventArgs e)
        {

        }
        private void tsmiReportConsolidate_Click(object sender, RoutedEventArgs e)
        {

        }
        private void tsmiBook_Click(object sender, RoutedEventArgs e)
        {

        }
        private void tsmiUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }
    }
}