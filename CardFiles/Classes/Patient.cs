using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardFiles.Classes
{

    //Пол 
    //       Женский= 0,
    //     Мужской = 1



    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public int Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

       
        public Patient() { }
        public Patient(int n) { Id = n; }         //  конструктор

        public Patient Clone()
        {
          Patient newPatient = new Patient();
            if(this!=null)
            {
                newPatient.Id = this.Id;
                newPatient.FirstName = this.FirstName;
                newPatient.LastName = this.LastName;
                newPatient.FatherName = this.FatherName;
                newPatient.Gender = this.Gender;
                newPatient.Address = this.Address;
                newPatient.DateOfBirth = this.DateOfBirth;
                newPatient.PhoneNumber = this.PhoneNumber;

            }

          return newPatient;
         }

    }
}