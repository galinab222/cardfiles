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
   public class ReportViewModel : INotifyPropertyChanged
    {

        public ObservableCollection<Report> ReportResult { get; set; }
     public ReportViewModel()

        {
            var dbContext = MainWindowModel.userContext;

            var result = MainWindowModel.userContext.Database
              .SqlQuery<Report>("dbo.CountVisits")
              .ToList();
            ReportResult = new ObservableCollection<Report>(result);
        }



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

