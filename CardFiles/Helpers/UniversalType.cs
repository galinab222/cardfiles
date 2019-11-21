using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
namespace CardFiles.Classes
{
    [NotMapped]
   public class UniversalType
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public UniversalType(int n, string s) { Code = n; Name = s; }         //  конструктор

    }
}
