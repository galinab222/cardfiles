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

    [NotMapped]
    public class Report
    {
        public int amountOfVisits { get; set; }
        public string FIO { get; set; }
        public int yearOfVisit { get; set; }
        public int monthOfVisit { get; set; }
        public string Diagnosis { get; set; }

    }
}
 

