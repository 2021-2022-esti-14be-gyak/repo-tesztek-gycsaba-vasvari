using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vizsgaremek.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vizsgaremek.Stores;
using Vizsgaremek.Models;

namespace Vizsgaremek.Repositories.Tests
{
    [TestClass()]
    public class TeachersTests
    {
        [TestMethod()]
        public void GetAllTestTestData()
        {
            ApplicationStore applicationStore = new ApplicationStore();
            // A teszt adatokat fogjuk tesztelni
            applicationStore.DbSource = DbSource.NONE;

            //Példányosítottuk a teachers repót tesztadatokkal
            Teachers teachers = new Teachers(applicationStore);


            // Példányosítás után a repo-ban a lista létezik-e
            Assert.IsNotNull(teachers.AllTeachers, "A tanár lista nincs példányosítva!");

            // A teszt adatok hat tanárt példányosítanak, ellenőrizzük, hogy megvannak-e
            int expected = 6;
            int actaul = teachers.GetAll().Count;

            // A teszt megvizsgálja, hogy megvan-e mind a hat
            Assert.AreEqual(expected, actaul, "A teszt adatok nem készülnek el megfelelő számban!");

        }

        [TestMethod()]
        public void IsertTestTestData()
        {
            // A repot-beállítjuk teszt adatokkal
            ApplicationStore applicationStore = new ApplicationStore();
            applicationStore.DbSource = DbSource.NONE;
            Teachers teachers = new Teachers(applicationStore);

            // Példányosítás után a repo-ban a lista létezik-e
            Assert.IsNotNull(teachers.AllTeachers, "A tanár lista nincs példányosítva!");

            // Egy tanár akit lehet insertálni
            Teacher newCanInsertTeacher = new Teacher()
            {
                Id = "20101111111",
                FirstName = "Új",
                LastName = "Tanár",
                Password = "jelszó",
                Meal = true,
                Emploeyment = EmploymentValue.DONEONCOMMISSION,
            };
            // Egy tanár akit nem lehet insertálni
            Teacher newNotCanInsertTeacher = new Teacher()
            {
                Id = "10101111111",
                FirstName = "Nem Felvehető",
                LastName = "Tanár",
                Password = "jelszó",
                Meal = true,
                Emploeyment = EmploymentValue.DONEONCOMMISSION,
            };
            // Felvehető tanár felvétele a repository
            try
            {
                teachers.Insert(newCanInsertTeacher);
            }
            catch (Exception e)
            {
                Assert.Fail("Fevehető tanár esetén, az Insert kivételt dob.\n" + e.Message);
            }
            // Felvehető tanár esetén a tanárok száma egyel kell nőjön
            int canInsertTeacherExpected = 7;
            int canInsertTeacherActaul = teachers.AllTeachers.Count();
            Assert.AreEqual(canInsertTeacherExpected, canInsertTeacherActaul, "Felvehető tanár felvétele esetén nem növekszik a tanárok száma a repoban!");
            // Felvehető tanár megtalálható-e a listában
            Teacher insertedTeacherExpected = newCanInsertTeacher;
            Teacher insertedTeacherActaul = teachers.AllTeachers.Find(teacher => teacher == newCanInsertTeacher);
            Assert.AreEqual(insertedTeacherExpected, insertedTeacherActaul, "A felvehető tanár, nem lett felvéve,  nincs a listában");

            //Nem felvehető tanár felvétele
            try
            {
                teachers.Insert(newNotCanInsertTeacher);
            }
            catch (Exception e)
            {
                Assert.Fail("Nem felvehető tanár esetén, az Insert kivételt dob.\n" + e.Message);
            }
            // Az ismétlődő id-val csak egy tanár lehet, nem lehet kettő
            int numberOfTeacherWithIdExptected = 1;
            int numberOfTeacherWithIdActual= teachers.AllTeachers.FindAll(teacher => teacher.Id == newCanInsertTeacher.Id).Count;
            Assert.AreEqual(numberOfTeacherWithIdExptected, numberOfTeacherWithIdActual, "Egy Id-ből több is van a listába amikor olyan tanár veszük fel, akinek az ID-je már szerepel a listába");
        }
    }
}
