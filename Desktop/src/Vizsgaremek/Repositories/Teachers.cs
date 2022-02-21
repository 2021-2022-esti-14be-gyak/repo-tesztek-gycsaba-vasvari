using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vizsgaremek.Models;
using Vizsgaremek.Stores;
using Vizsgaremek.Repositories.Interface;

namespace Vizsgaremek.Repositories
{
    public partial class Teachers : IRepositoryAPIStringId<Teacher>
    {
        private List<Teacher> teachers;

        public List<Teacher> AllTeachers
        {
            get
            {
                Update();
                return teachers;
            }
        }

        private ApplicationStore applicationStore;
        public Teachers(ApplicationStore applicationStore)
        {
            this.applicationStore = applicationStore;
            switch(applicationStore.DbSource)
            {
                case DbSource.NONE:
                    break;
                case DbSource.LOCALHOST:
                    break;
                case DbSource.DEVOPS:
                    break;
            }

            teachers = new List<Teacher>();
            teachers = GetAll();
        }

        public void MakeTestData()
        {
            teachers.Add(new Teacher("10101111111", "Számoló", "Szonja", "123456", true, EmploymentValue.LECTURER));
            teachers.Add(new Teacher("10101111112", "Buktató", "Béla", "123456", false, EmploymentValue.INDENTUREDLABOURER));
            teachers.Add(new Teacher("10101111113", "Aritmetika", "Antal", "123456", false, EmploymentValue.DONEONCOMMISSION));
            teachers.Add(new Teacher("10101111114", "Arany", "András", "123456", false, EmploymentValue.DONEONCOMMISSION));
            teachers.Add(new Teacher("10101111115", "Sportoló", "Jenő", "123456", false, EmploymentValue.DONEONCOMMISSION));
            teachers.Add(new Teacher("10101111116", "Visszanéző", "Viola", "123456", false, EmploymentValue.DONEONCOMMISSION));
        }

        public void Update()
        {
            if (applicationStore.DbSource == DbSource.NONE)
            {
                if (!FindTeacherWithId("10101111111"))
                    teachers = GetAll();
            }
            else
            {
                teachers = GetAll();
            }
        }
    }
}
