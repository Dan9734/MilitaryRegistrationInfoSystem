using MilitaryRegistrationInfoSystem.EF;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MilitaryRegistrationInfoSystem.Windows
{
    /// <summary>
    /// Логика взаимодействия для SummonsWindow.xaml
    /// </summary>
    public partial class SummonsWindow : Window
    {
        List<EF.Summons> summons = new List<EF.Summons>();

        public SummonsWindow()
        {
            InitializeComponent();
            AllPersonal.ItemsSource = ClassHelper.AppData.context.Summons.ToList();
            cbSort.ItemsSource = listForSort;
            cbSort.SelectedIndex = 0;
            Filter();
        }
        List<string> listForSort = new List<string>()
        {
            "По умолчанию",
            "По адресу",
            "По причине",
            "По дате"
        };

        private void Filter()
        {
            summons = ClassHelper.AppData.context.Summons.ToList();
            summons = summons.Where(e => e.MailingAddres.Contains(tbSearch.Text) || e.ReasonForVisiting.Contains(tbSearch.Text)).ToList();

            switch (cbSort.SelectedIndex)
            {
                case 0:
                    summons = summons.OrderBy(e => e.ID).ToList();
                    break;
                case 1:
                    summons = summons.OrderBy(e => e.MailingAddres).ToList();
                    break;
                case 2:
                    summons = summons.OrderBy(e => e.ReasonForVisiting).ToList();
                    break;
                case 3:
                    summons = summons.OrderBy(e => e.DateVisiting.ToString()).ToList();
                    break;
                default:
                    summons = summons.OrderBy(e => e.ID).ToList();
                    break;
            }

            if (summons.Count == 0)
            {
                MessageBox.Show("Записей нет");
            }
            AllPersonal.ItemsSource = summons;
        }

        private void AllPersonal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void tsmiChangeProfile_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            authorizationWindow.ShowDialog();
            this.Show();
        }
        private void tsbDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void tsmiExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void DataUpdate()
        {
            //dbDataSetЗапрос_ПризывникTableAdapter.Fill(dbDataSet.Запрос_Призывник);
        }
        private void tsbAdd_Click(object sender, RoutedEventArgs e)
        {
            AddSummonsWindow add = new AddSummonsWindow();
            add.ShowDialog();
            Filter();
        }

        private void LVEmployee_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EF.Summons summons = AllPersonal.SelectedItem as EF.Summons;
            AddSummonsWindow add = new AddSummonsWindow(summons);
            add.ShowDialog();
            Filter();
        }
        private void tsbEdit_Click(object sender, RoutedEventArgs e)
        {

            if (AllPersonal.SelectedItem is Summons summons)
            {
                var resMAss = MessageBox.Show($"Вы хотите изменить повестку номер {summons.ID}?", "Предупреждение", MessageBoxButton.YesNo);
                if (resMAss == MessageBoxResult.Yes)
                {
                    this.Hide();
                    AddSummonsWindow addSummonsWindow = new AddSummonsWindow(summons);
                    addSummonsWindow.Show();
                    this.Close();
                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show($"Вы не выбрали пользователя", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Filter();
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

