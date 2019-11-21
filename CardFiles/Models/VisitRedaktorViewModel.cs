using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Collections;
using CardFiles.Classes;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Data;
namespace CardFiles.Models
{
   public class VisitRedaktorViewModel : INotifyPropertyChanged
    {
        private Visit redaktorVisit;
        private Visit oldVisit;
        public DataView TypeOfVisitView { get; set; }
       // private ObservableCollection<UniversalType> patientsView;
        public ObservableCollection<UniversalType> PatientsView { get; set; }
        private  ObservableCollection<Patient> allPatients;

        public VisitRedaktorViewModel(Visit Visit)
        {
            redaktorVisit = Visit;
            oldVisit = Visit.Clone();
            var typeoOfVisitTable= new DataTable();
            typeoOfVisitTable.Columns.Add("Code", typeof(int));
            typeoOfVisitTable.Columns.Add("Name", typeof(string));
            typeoOfVisitTable.Rows.Add(0,"Первичный");
            typeoOfVisitTable.Rows.Add(1,"Повторный");
           TypeOfVisitView = typeoOfVisitTable.AsDataView();
            OnPropertyChanged("TypeOfVisitView");

            MainWindowModel.userContext.Patients.Load();
             allPatients = (MainWindowModel.userContext.Patients.Local);

             PatientsView = new ObservableCollection<UniversalType>
                ( (from p in allPatients.OrderBy(x => x.LastName).OrderBy(x => x.FirstName).OrderBy(x => x.FatherName)
                                select new UniversalType( p.Id, p.LastName + " " + p.FirstName + " " + p.FatherName )).ToList());
     
            OnPropertyChanged("PatientsView");

            //       }
        } 


        public VisitRedaktorViewModel()
        {
            var typeoOfVisitTable = new DataTable();
            typeoOfVisitTable.Columns.Add("Code", typeof(int));
            typeoOfVisitTable.Columns.Add("Name", typeof(string));
            typeoOfVisitTable.Rows.Add(0, "Первичный");
            typeoOfVisitTable.Rows.Add(1, "Повторный");
            TypeOfVisitView = typeoOfVisitTable.AsDataView();
            OnPropertyChanged("TypeOfVisitView");
            var PatientsView = new ObservableCollection<UniversalType>
             ((from p in allPatients.OrderBy(x => x.LastName).OrderBy(x => x.FirstName).OrderBy(x => x.FatherName)
               select new UniversalType(p.Id, p.LastName + " " + p.FirstName + " " + p.FatherName)).ToList());
            OnPropertyChanged("PatientsView");
            //       }
        }


        public string Name
        {
            get { return redaktorVisit.Patient.LastName +" " + redaktorVisit.Patient.FirstName +" " +  redaktorVisit.Patient.FatherName; }
           
        }



        public int PatientId
        {
            get {
               int Id = 0;
                if (redaktorVisit != null)
                {
                    {
                        if (redaktorVisit.Patient != null)
                        { Id = redaktorVisit.Patient.Id; }
                    }
                }
                return Id;
            }
            set
            {

             
                //if (value != redaktorVisit.Patient.Id )
                //{
                   try
                    {
                   //    patientId = value;
                        redaktorVisit.Patient = allPatients.Where(p => p.Id == value).FirstOrDefault();
                     }
                    catch
                    { System.Windows.MessageBox.Show("Не найден пациент"); }
                    
                    OnPropertyChanged("PatientId");
                }
          //  }

        }


        public int Id
        {
            get { return redaktorVisit.Id; }
         
        }

        public DateTime DateOfVisit
        {
            get { return redaktorVisit.DateOfVisit; }
            set
            {
                if (value != redaktorVisit.DateOfVisit)
                {
                    redaktorVisit.DateOfVisit = value;
                    OnPropertyChanged("DateOfVisit");
                }
            }
        }


        public int KindOfVisit
        {
            get { return redaktorVisit.KindOfVisit; }
            set
            {
                if (value != redaktorVisit.KindOfVisit)
                {
                    redaktorVisit.KindOfVisit = value;
                    OnPropertyChanged("KindOfVisit");
                }
            }
        }
     
       
       
        public string Diagnosis
        {
            get { return redaktorVisit.Diagnosis; }
            set
            {
                if (value != redaktorVisit.Diagnosis)
                {
                    redaktorVisit.Diagnosis = value;
                    OnPropertyChanged("Diagnosis");
                }
            }
        }
        

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }



}

