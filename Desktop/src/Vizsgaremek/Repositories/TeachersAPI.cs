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
        public List<Teacher> GetAll()
        {            
            switch (applicationStore.DbSource)
            {
                case DbSource.NONE:
                    teachers.Clear();
                    MakeTestData();
                    break;
                case DbSource.LOCALHOST:
                    break;
                case DbSource.DEVOPS:
                    break;
            }
            return teachers;
        }

        public Teacher Get(string id)
        {
            Teacher found = new Teacher();
            switch (applicationStore.DbSource)
            {
                case DbSource.NONE:
                    break;
                case DbSource.LOCALHOST:
                    break;
                case DbSource.DEVOPS:
                    break;
            }
            return found;
        }

        public void Insert(Teacher entity)
        {
            switch (applicationStore.DbSource)
            {
                case DbSource.NONE:
                    InsertTeacherToTestData(entity);
                    break;
                case DbSource.LOCALHOST:
                    break;
                case DbSource.DEVOPS:
                    break;
            }
        }

        public void Update(string id, Teacher entity)
        {
            switch (applicationStore.DbSource)
            {
                case DbSource.NONE:
                    break;
                case DbSource.LOCALHOST:
                    break;
                case DbSource.DEVOPS:
                    break;
            }
        }

        public void Delete(string id)
        {
            switch (applicationStore.DbSource)
            {
                case DbSource.NONE:
                    break;
                case DbSource.LOCALHOST:
                    break;
                case DbSource.DEVOPS:
                    break;
            }
        }
    }
}
