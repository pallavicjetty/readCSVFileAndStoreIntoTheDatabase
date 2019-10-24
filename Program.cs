using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace readCSVFileStoreInDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            var Data = File.ReadAllLines(@"..\..\excel\convertcsv.csv");
            Data = Data.Skip(1).ToArray();
            string[] PassengerId;
            string[] Survived, Pclass, Name, Sex, Age, SibSp, Parch, Ticket, Fare, Cabin, Embarked;
            //using (var db = new DbContextClass())
            //{
            //    var dataList = new modelClass();
                var dataList = from dataSet in Data
                           let data = dataSet.Split(';')
                           select new
                           {
                               PassengerId = data[0],
                               Survived = data[1],
                               Pclass = data[2],
                               Name = data[3],
                               Sex = data[4],
                               Age = data[5],
                               SibSp = data[6],
                               Parch = data[7],
                               Ticket = data[8],
                               Fare = data[9],
                               Cabin = data[10],
                               Embarked = data[11]
                           };
            //int i = dataList.Count();
            //for(var d=1;d<i;d++)
            ////foreach (var d in dataList)
            //{
            //    Console.WriteLine(PassengerId + "|" + d.Survived);
            //}
            using (var db = new DbContextClass())
            {
                
                foreach (var d in dataList)
                {
                    var da = new modelClass();
                    Console.WriteLine(d.PassengerId + "|" + d.Survived);
                    da.passengerid = Int16.Parse(d.PassengerId);
                    if (d.Survived == "")
                    {
                        da.survived = null;
                    }
                    else
                    {
                        da.survived = Int32.Parse(d.Survived);
                    }
                    if (d.Pclass == "")
                    {
                        da.pclass = null;
                    }
                    else
                    {
                        da.pclass = Int32.Parse(d.Pclass);
                    }
                    da.name = d.Name;
                    da.sex = d.Sex;
                    if (d.Age == "")
                    {
                        da.age = null;
                    }
                    else
                    {
                        da.age = float.Parse(d.Age);
                    }
                    if (d.SibSp == "")
                    {
                        da.sibsp = null;
                    }
                    else
                    {
                        da.sibsp = Int32.Parse(d.SibSp);
                    }
                    if (d.Parch == "")
                    {
                        da.parch = null;
                    }
                    else
                    {
                        da.parch = Int32.Parse(d.Parch);
                    }
                    da.ticket = d.Ticket;
                    if (d.Fare == "")
                    {
                        da.fare = null;
                    }
                    else
                    {
                        da.fare = float.Parse(d.Fare);
                    }
                    da.cabin = d.Cabin;
                    da.embarked = d.Embarked;
                    db.modelClasses.Add(da);
                    try
                    {
                        //db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.modelClasses ON");
                        db.SaveChanges();
                    }
                    catch(Exception ex)
                    {
                        throw ex;
                    }
                }
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }
    }
}
