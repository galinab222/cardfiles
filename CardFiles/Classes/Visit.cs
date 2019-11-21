using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardFiles.Classes
{
    //Характеристика посещения
    //Первичный = 0,
    //повторный   1


    public class Visit
    {
        public int Id { get; set; }
        public Patient Patient { get; set; }
        public DateTime DateOfVisit { get; set; }
        public int KindOfVisit { get; set; }
        public string Diagnosis { get; set; }
        [NotMapped]
        public string PatientName
        {
            get
            {
                try
                { return Patient.Id.ToString() + " " + Patient.LastName + " " + Patient.FirstName + " " + Patient.FatherName; }
                catch
                { return ""; }
            }
        }


        public Visit() { }
        public Visit(int n) { Id = n; }         //  конструктор

        public Visit Clone()
        {
            Visit newVisit = new Visit();
            if (this != null)
            {
                newVisit.Id = this.Id;
                newVisit.Patient = this.Patient;
                newVisit.DateOfVisit = this.DateOfVisit;
                newVisit.KindOfVisit = this.KindOfVisit;
                newVisit.Diagnosis = this.Diagnosis;
            }

            return newVisit;
        }
    }
}
