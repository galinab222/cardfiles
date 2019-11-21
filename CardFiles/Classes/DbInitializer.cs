using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardFiles.Classes
{
    class DbInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<UserContext>
        {
            protected override void Seed(UserContext context)
            {   var patients = new List<Patient> 
            {
                // Здесь может быть начальный список
            };
                patients.ForEach(p => context.Patients.Add(p)); // Добавляем все элементы списка через контекст.
                context.SaveChanges(); // Сохраняем изменения.

                var visits = new List<Visit>
            {
                    // Здесь может быть начальный список
                };

                visits.ForEach(v => context.Visits.Add(v));
                context.SaveChanges();
            }
        }
    }

