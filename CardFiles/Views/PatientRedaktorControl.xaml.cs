using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CardFiles.Models;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using CardFiles.Views;

namespace CardFiles.Views
{
    /// <summary>
    /// Логика взаимодействия для Patientreadktorindow.xaml
    /// </summary>
    public partial class PatientRedaktorControl : UserControl
    {
        public PatientRedaktorControl()
        {
            InitializeComponent();
         ///   DataContext = PatientsViewModel.newPatientModel;
        }
    }
}
