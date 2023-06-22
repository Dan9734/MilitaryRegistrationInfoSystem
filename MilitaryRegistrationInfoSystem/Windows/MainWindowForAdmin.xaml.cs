using MilitaryRegistrationInfoSystem.ClassHelper;
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
using static MilitaryRegistrationInfoSystem.ClassHelper.AppData;

namespace MilitaryRegistrationInfoSystem.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindowForAdmin.xaml
    /// </summary>
    public partial class MainWindowForAdmin : Window
    {
        List<EF.Worker> worker = new List<EF.Worker>();

        public MainWindowForAdmin()
        {
            InitializeComponent();
            AllPersonal.ItemsSource = context.Worker.ToList();
            cbSort.ItemsSource = listForSort;
            cbSort.SelectedIndex = 0;
            Filter();
        }
        List<string> listForSort = new List<string>()
        {
            "По умолчанию",
            "По фамилии",
            "По имени",
            "По должности"
        };
        private void Add()
        {
            AddWorkerWindow addWorkerWindow = new AddWorkerWindow();
            Hide();
            addWorkerWindow.ShowDialog();
            Show();
        }

        private void Filter()
        {
            worker = AppData.context.Worker.ToList();
            worker = worker.Where(e => e.LName.Contains(tbSearch.Text) || e.FName.Contains(tbSearch.Text) || e.Position.Contains(tbSearch.Text)).ToList();

            switch (cbSort.SelectedIndex)
            {
                case 0:
                    worker = worker.OrderBy(e => e.ID).ToList();
                    break;
                case 1:
                    worker = worker.OrderBy(e => e.LName).ToList();
                    break;
                case 2:
                    worker = worker.OrderBy(e => e.FName).ToList();
                    break;
                case 3:
                    worker = worker.OrderBy(e => e.Position).ToList();
                    break;
                default:
                    worker = worker.OrderBy(e => e.ID).ToList();
                    break;
            }

            if (worker.Count == 0)
            {
                MessageBox.Show("Записей нет");
            }
            AllPersonal.ItemsSource = worker;
        }

        private void AllPersonal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AllPersonal_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                var resClick = MessageBox.Show($"Удалить пользователя {(AllPersonal.SelectedItem as EF.Worker).LName}", "Подтвержение", MessageBoxButton.YesNo, MessageBoxImage.Information);


                if (resClick == MessageBoxResult.Yes)
                {
                    EF.Worker client = new EF.Worker();
                    if (!(AllPersonal.SelectedItem is EF.Worker))
                    {
                        MessageBox.Show("Пользователь не выбран");
                        return;
                    }
                    client = AllPersonal.SelectedItem as EF.Worker;

                    context.Worker.Remove(client);
                    context.SaveChanges();
                }
            }
            Filter();
        }
        private void tsbSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LVEmployee_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
         
        }
        private void tsmiChangeProfile_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            Close();
            authorizationWindow.ShowDialog();
        }
        private void tsmiExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
      
        private void tsbAdd_Click(object sender, RoutedEventArgs e)
        {
            Add();
            Filter();
        }
        private void tsbEdit_Click(object sender, RoutedEventArgs e)
        {
            if (AllPersonal.SelectedItem is Worker worker)
            {
                var resMAss = MessageBox.Show($"Вы хотите изменить пользователя {worker.LName}  {worker.FName}", "Предупреждение", MessageBoxButton.YesNo);
                if (resMAss == MessageBoxResult.Yes)
                {
                    this.Hide();
                    AddWorkerWindow clientWindow = new AddWorkerWindow();
                    ClassPD.IDWorker = worker.ID;
                    clientWindow.ShowDialog();
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
        }

        private void tsbDelete_Click(object sender, RoutedEventArgs e)
        {
                var resClick = MessageBox.Show($"Удалить пользователя {(AllPersonal.SelectedItem as EF.Worker).LName}", "Подтвержение", MessageBoxButton.YesNo, MessageBoxImage.Information);


                if (resClick == MessageBoxResult.Yes)
                {
                    EF.Worker client = new EF.Worker();
                    if (!(AllPersonal.SelectedItem is EF.Worker))
                    {
                        MessageBox.Show("Запись не выбраны");
                        return;
                    }
                    client = AllPersonal.SelectedItem as EF.Worker;

                    context.Worker.Remove(client);
                    context.SaveChanges();
               
            }
            Filter();
        }

        private void tsbRefresh_Click(object sender, RoutedEventArgs e)
        {
            Filter();
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

        private void cbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void AllPersonal_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EF.Worker worker = AllPersonal.SelectedItem as EF.Worker;
            AddWorkerWindow add = new AddWorkerWindow(worker);
            add.ShowDialog();
            Filter();
        }
    }
}