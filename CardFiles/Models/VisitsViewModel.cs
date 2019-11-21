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
using System.Data;
namespace CardFiles.Models
{
   public class VisitsViewModel : INotifyPropertyChanged
    {
        private Visit selectedVisit;
        public DataView TypeOfVisitView { get; set; }
  //   public ObservableCollection<UniversalType> PatientsView { get; set; }
        private ObservableCollection<Patient> allPatients;
        public ObservableCollection <Visit> Visits { get; set; }
        public Visit SelectedVisit
        {
            get { return selectedVisit; }
            set
            {
                selectedVisit = value;
                OnPropertyChanged("SelectedVisit");
            }
        }
        public VisitsViewModel()
        {
            Visits = new ObservableCollection<Visit>();
            Visits = MainWindowModel.userContext.Visits.Local;
            MainWindowModel.userContext.Visits.OrderBy(p => p.Patient.LastName).Load();
            Visits = MainWindowModel.userContext.Visits.Local;

            //var typeoOfVisitTable = new DataTable();
            //typeoOfVisitTable.Columns.Add("Code", typeof(int));
            //typeoOfVisitTable.Columns.Add("Name", typeof(string));
            //typeoOfVisitTable.Rows.Add(0, "Первичный");
            //typeoOfVisitTable.Rows.Add(1, "Повторный");
            //TypeOfVisitView = typeoOfVisitTable.AsDataView();
            //OnPropertyChanged("TypeOfVisitView");

            //MainWindowModel.userContext.Patients.Load();
            //allPatients = (MainWindowModel.userContext.Patients.Local);

            //PatientsView = new ObservableCollection<UniversalType>
            //   ((from p in allPatients.OrderBy(x => x.LastName).OrderBy(x => x.FirstName).OrderBy(x => x.FatherName)
            //     select new UniversalType(p.Id, p.LastName + " " + p.FirstName + " " + p.FatherName)).ToList());

            //OnPropertyChanged("PatientsView");

        }
        public Visit createNewVisit()
        {
            int newId = 0;
            if (Visits.Count == 0)
            { newId = 1; }
            else
            {
                newId = Visits.Select(p => p.Id).Max() + 1;
            }
            return new Visit(newId);
  
         }

  
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      var newVisit = createNewVisit();
                 var     newVisitModel = new VisitRedaktorViewModel(newVisit);
                      ShowerVisitRedaktor.Show(newVisitModel);
                      Visits.Add(newVisit);
                      OnPropertyChanged("Visits");
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
                      if (this.SelectedVisit != null)
                      {
                         var x = Visits.Where(p => p.Id == SelectedVisit.Id).FirstOrDefault();
                          if (x != null)
                          {
                              Visit p =x.Clone();
                              var newVisitModel = new VisitRedaktorViewModel(p);
                              ShowerVisitRedaktor.Show(newVisitModel);
                              if (ShowerVisitRedaktor.acceptChanges == 1)
                              {
                                  this.SelectedVisit = p;
                                  int i = Visits.IndexOf(x);
                                  Visits.Remove(x);
                                  Visits.Insert(i, p);
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
                      if (this.SelectedVisit != null)
                      {
                          var x = Visits.Where(p => p.Id == SelectedVisit.Id).ToList();
                          if (x.Count != 0)
                          {
                              Visit p = x[0];
                   
                              Visits.Remove(selectedVisit);
                            
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

