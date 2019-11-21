using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardFiles.Classes;

namespace CardFiles.Models
{
    class MainWindowModel
    {
        public static UserContext userContext;
        public MainWindowModel ()
            {
            userContext = new UserContext();
            }
    

        private RelayCommand patientsCommand;
        public RelayCommand PatientsCommand
        {
            get
            {
                return patientsCommand ??
                  (patientsCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          var model = new PatientsViewModel();
                          ShowerPatients.Show(model);
                      }
                      catch (Exception e)
                      {
                          System.Windows.MessageBox.Show(e.Message);
                      }
        
                  }));
            }

        }


        private RelayCommand visitsCommand;
        public RelayCommand VisitsCommand
        {
            get
            {
                return visitsCommand ??
                  (visitsCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          var model = new VisitsViewModel();
                          ShowerVisits.Show(model);
                      }
                      catch (Exception e)
                      {
                          System.Windows.MessageBox.Show(e.Message);
                      }
                  }));
            }

        }
        private RelayCommand reportCommand;
        public RelayCommand ReportCommand
        {
            get
            {
                return reportCommand ??
                  (reportCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          var model = new ReportViewModel();
                          ShowerReport.Show(model);
                      }
                      catch (Exception e)
                      {
                          System.Windows.MessageBox.Show(e.Message);
                      }
                  }));
            }

        }

    }
}
