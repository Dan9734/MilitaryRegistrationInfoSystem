﻿using MilitaryRegistrationInfoSystem.Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MilitaryRegistrationInfoSystem.ClassHelper;
using static MilitaryRegistrationInfoSystem.ClassHelper.AppData;
using MilitaryRegistrationInfoSystem.EF;

namespace MilitaryRegistrationInfoSystem
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<EF.Recruit> recruit = new List<EF.Recruit>();

        public MainWindow()
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
                var resClick = MessageBox.Show($"Удалить пользователя {(AllPersonal.SelectedItem as EF.Recruit).LName}", "Подтвержение", MessageBoxButton.YesNo, MessageBoxImage.Information);


                if (resClick == MessageBoxResult.Yes)
                {
                    EF.Recruit recruit = new EF.Recruit();
                    if (!(AllPersonal.SelectedItem is EF.Recruit))
                    {
                        MessageBox.Show("Запись не выбраны");
                        return;
                    }
                    recruit = AllPersonal.SelectedItem as EF.Recruit;

                    AppData.context.Recruit.Remove(recruit);
                    AppData.context.SaveChanges();
                }
            }
            Filter();
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
            AddRecruitWindow form = new AddRecruitWindow();
            var result = form.ShowDialog();
            if (result != null && result == true)
            {
                DataUpdate();
            }
            Filter();
        }

        private void LVEmployee_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EF.Recruit recruit = AllPersonal.SelectedItem as EF.Recruit;
            AddRecruitWindow add = new AddRecruitWindow(recruit);
            add.ShowDialog();
            Filter();
        }
        private void tsbEdit_Click(object sender, RoutedEventArgs e)
        {
            
                if (AllPersonal.SelectedItem is Recruit recruit)
                {
                    var resMAss = MessageBox.Show($"Вы хотите изменить пользователя {recruit.LName}  {recruit.FName}", "Предупреждение", MessageBoxButton.YesNo);
                    if (resMAss == MessageBoxResult.Yes)
                    {
                        this.Hide();
                        AddRecruitWindow addRecruitWindow = new AddRecruitWindow(recruit);
                        ClassPD.IDRecruit = recruit.ID;
                        addRecruitWindow.ShowDialog();
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
        private void tsmiChangeProfile_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            Close();
            authorizationWindow.ShowDialog();
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

        private void tsmiSummons_Click(object sender, RoutedEventArgs e)
        {
                SummonsWindow summonsWindow = new SummonsWindow();
                summonsWindow.ShowDialog();
            
               
        }

        private void tsmiMed_Click(object sender, RoutedEventArgs e)
        {
            RecruitMedicalInfoWindow recruitMedical = new RecruitMedicalInfoWindow();
            Hide();
            recruitMedical.ShowDialog();
            Show();
        }
    }
}
