using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using CardFiles.Classes;
using CardFiles.Views;
namespace CardFiles.Models
{
   public class PatientsViewModel : INotifyPropertyChanged
    {
        private Patient selectedPatient;
       public ObservableCollection <Patient> Patients { get; set; }
        public Patient SelectedPatient
        {
            get { return selectedPatient; }
            set
            {
                selectedPatient = value;
                OnPropertyChanged("SelectedPatient");
            }
        }
        public PatientsViewModel()
        {
            Patients = new ObservableCollection<Patient>();
            Patients = MainWindowModel.userContext.Patients.Local;
            MainWindowModel.userContext.Patients.OrderBy(p => p.LastName).Load();
            Patients = MainWindowModel.userContext.Patients.Local;
                 
        }
        public Patient createNewPatient()
        {
            int newId = 0;
            if (Patients.Count == 0)
            { newId = 1; }
            else
            {
                newId = Patients.Select(p => p.Id).Max() + 1;
            }

            return new Patient(newId);
          
          
         }

      


        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      var newPatient = createNewPatient();
                 var     newPatientModel = new PatientRedaktorViewModel(newPatient);
                      ShowerPatientRedaktor.Show(newPatientModel);
                      Patients.Add(newPatient);
                     }));

        
            }
        }
        public void Save()
        {
            MainWindowModel.userContext.SaveChanges();
        }
        public void UnDoChanges()
        {
            MainWindowModel.userContext = null;
            MainWindowModel.userContext= new  UserContext();
        }


        private RelayCommand redaktorCommand;
        public RelayCommand RedaktorCommand => redaktorCommand ??
                  (redaktorCommand = new RelayCommand(obj =>
                  {
                      if (this.SelectedPatient != null)
                      {
                         var x = Patients.Where(p => p.Id == SelectedPatient.Id).FirstOrDefault();
                          if (x != null)
                          {
                              Patient p =x.Clone();
                              var newPatientModel = new PatientRedaktorViewModel(p);
                              ShowerPatientRedaktor.Show(newPatientModel);
                              if (ShowerPatientRedaktor.acceptChanges == 1)
                              {
                                  this.SelectedPatient = p;
                                  int i = Patients.IndexOf(x);
                                  Patients.Remove(x);
                                  Patients.Insert(i, p);
                              }
                              else
                              {
                                  p = x;
                              }
                            
                          }

                      }
                  }));

        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand => deleteCommand ??
                  (deleteCommand = new RelayCommand(obj =>
                  {
                      if (this.SelectedPatient != null)
                      {
                          var x = Patients.Where(p => p.Id == SelectedPatient.Id).ToList();
                          if (x.Count != 0)
                          {
                              Patient p = x[0];
                   
                              Patients.Remove(selectedPatient);
                            
                          }
                      }
                  }));

        private RelayCommand closeCommand;
        public RelayCommand CloseCommand
        {
            get
            {
                return closeCommand ??
                  (closeCommand = new RelayCommand(obj =>
                  {
                  }));
            }

        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
  
    }



}

