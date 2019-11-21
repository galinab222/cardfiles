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
   public class PatientRedaktorViewModel : INotifyPropertyChanged
    {
        private Patient redaktorPatient;
        private Patient oldPatient;
        public DataView GenderView { get; set; }

     

        public PatientRedaktorViewModel(Patient patient)
        {
            redaktorPatient = patient;
            oldPatient = patient.Clone();
            var gTable= new DataTable();
           gTable.Columns.Add("Code", typeof(int));
           gTable.Columns.Add("Name", typeof(string));
            gTable.Rows.Add(0,"Женcкий");
            gTable.Rows.Add(1,"Мужской");
            GenderView = gTable.AsDataView();
            OnPropertyChanged("GenderView");

            //       }
        }


        public PatientRedaktorViewModel()
        {
            var gTable = new DataTable();
            gTable.Columns.Add("Code", typeof(int));
            gTable.Columns.Add("Name", typeof(string));
            gTable.Rows.Add(0, "Женщина");
            gTable.Rows.Add(1, "Мужчина");
            GenderView = gTable.AsDataView();
            //       }
        }


        public string FirstName
        {
            get { return redaktorPatient.FirstName; }
            set
            {
                if (value != redaktorPatient.FirstName)
                {
                    redaktorPatient.FirstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
        }


        public string LastName
        {
            get { return redaktorPatient.LastName; }
            set
            {
                if (value != redaktorPatient.LastName)
                {
                    redaktorPatient.LastName = value;
                    OnPropertyChanged("LastName");
                }
            }
        }


        public string FatherName
        {
            get { return redaktorPatient.FatherName; }
            set
            {
                if (value != redaktorPatient.FatherName)
                {
                    redaktorPatient.FatherName = value;
                    OnPropertyChanged("FatherName");
                }
            }
        }
        public int Id
        {
            get { return redaktorPatient.Id; }
         
        }

        public DateTime DateOfBirth
        {
            get { return redaktorPatient.DateOfBirth; }
            set
            {
                if (value != redaktorPatient.DateOfBirth)
                {
                    redaktorPatient.DateOfBirth = value;
                    OnPropertyChanged("DateOfBirth");
                }
            }
        }

        public string Address
        {
            get { return redaktorPatient.Address; }
            set
            {
                if (value != redaktorPatient.Address)
                {
                    redaktorPatient.Address = value;
                    OnPropertyChanged("Address");
                }
            }
        }
        public int Gender
        {
            get { return redaktorPatient.Gender; }
            set
            {
                if (value != redaktorPatient.Gender)
                {
                    redaktorPatient.Gender = value;
                    OnPropertyChanged("Gender");
                }
            }
        }
        public string PhoneNumber
        {
            get { return redaktorPatient.PhoneNumber; }
            set
            {
                if (value != redaktorPatient.PhoneNumber)
                {
                    redaktorPatient.PhoneNumber = value;
                    OnPropertyChanged("PhoneNumber");
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

