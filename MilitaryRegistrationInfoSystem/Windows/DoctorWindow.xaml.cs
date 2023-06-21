using MilitaryRegistrationInfoSystem.Pages;
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
    /// <summary>
    /// Логика взаимодействия для DoctorWindow.xaml
    /// </summary>
    public partial class DoctorWindow : Window
    {
        public DoctorWindow(int IdRole)
        {
            InitializeComponent();
            if (IdRole == 2)
            {
                frame.Navigate(new SurgeonPage());
            }
            else if (IdRole == 3)
            {
                frame.Navigate(new NeurologistPage());
            }
            else if (IdRole == 4)
            {
                frame.Navigate(new PsychiatristPage());
            }
            else if (IdRole == 5)
            {
                frame.Navigate(new OptometristPage());
            }
            else if (IdRole == 6)
            {
                frame.Navigate(new OtolaryngologPage());
            }
            else if (IdRole == 7)
            {
                frame.Navigate(new DentistPage());
            }
        }
    }
}
