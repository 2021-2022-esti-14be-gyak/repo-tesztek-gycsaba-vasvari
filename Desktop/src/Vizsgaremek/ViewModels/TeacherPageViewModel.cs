using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vizsgaremek.Repositories;
using System.Collections.ObjectModel;
using Vizsgaremek.Models;
using Vizsgaremek.Stores;

namespace Vizsgaremek.ViewModels
{
    public class TeacherPageViewModel
    { 
        private Teachers teachersRepo;        
        private ObservableCollection<Teacher> displayedTeachers;
        private ApplicationStore applicationStore;

        public TeacherPageViewModel(ApplicationStore applicationStore)
        {
            this.applicationStore = applicationStore;
            teachersRepo = new Teachers(applicationStore);
            displayedTeachers = new ObservableCollection<Teacher>(teachersRepo.AllTeachers);
        }

        public ObservableCollection<Teacher> DisplayedTeachers
        {
            get
            {
                return displayedTeachers;
            }
        }

        public void Update()
        {
            displayedTeachers.Clear();
            displayedTeachers=new ObservableCollection<Teacher>(teachersRepo.AllTeachers);
        }
    }
}
