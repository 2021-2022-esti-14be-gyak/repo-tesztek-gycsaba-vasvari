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
        }
    }
}