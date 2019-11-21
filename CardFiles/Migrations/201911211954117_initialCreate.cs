namespace CardFiles.Migrations
{   
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
              "dbo.Patients",
              c => new
              {
                  Id = c.Int(nullable: false, identity: true),
                  FirstName = c.String(),
                  LastName = c.String(),
                  FatherName = c.String(),
                  Gender = c.Int(nullable: false),
                  DateOfBirth = c.DateTime(nullable: false),
                  Address = c.String(),
                  PhoneNumber = c.String(),
              })
              .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Visits",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    DateOfVisit = c.DateTime(nullable: false),
                    KindOfVisit = c.Int(nullable: false),
                    Diagnosis = c.String(),
                    Patient_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.Patient_Id)
                .Index(t => t.Patient_Id);

            CreateStoredProcedure("dbo.CountVisits", "select count(*) as amountOfVisits, b.LastName+' ' + b.FirstName + ' ' + b.FatherName as FIO , year(a.DateOfVisit) as yearOfVisit, month (a.DateOfVisit) as monthOfVisit, a.Diagnosis " +
            " from dbo.Visits a left  join dbo.Patients b on a.Patient_Id = b.Id " +
            " group by b.LastName + ' ' + b.FirstName + ' ' + b.FatherName, year(a.DateOfVisit), month(a.DateOfVisit),a.Diagnosis order by FIO", null) ;

        }



        public override void Down()
        {
            DropForeignKey("dbo.CountVisits", "Patient_Id", "dbo.Patients");
            DropIndex("dbo.Visits", new[] { "Patient_Id" });
            DropTable("dbo.Visits");
            DropTable("dbo.Patients");
            DropStoredProcedure("dbo.CountAmountOfVisits");
            DropStoredProcedure("dbo.CountAmountOfVisits");
        }
    }
}
