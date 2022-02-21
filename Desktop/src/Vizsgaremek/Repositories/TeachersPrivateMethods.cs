using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vizsgaremek.Models;

namespace Vizsgaremek.Repositories
{
    public partial class Teachers
    {
        private void InsertTeacherToTestData(Teacher teacher)
        {
            if (IsTeacherCanInsert(teacher))
            {
                teachers.Add(teacher);
            }
        }

        bool IsTeacherCanInsert(Teacher teacher)
        {
            if (FindTeacherWithId(teacher.Id))
                return false;
            else
                return true;
        }

        private bool FindTeacherWithId(string id)
        {
            foreach (Teacher teacher in teachers)
            {
                if (teacher.Id.CompareTo(id) == 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
