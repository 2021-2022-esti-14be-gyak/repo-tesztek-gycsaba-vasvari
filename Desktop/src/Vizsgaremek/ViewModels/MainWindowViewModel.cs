using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vizsgaremek.ViewModels.BaseClass;

namespace Vizsgaremek.ViewModels
{
    class MainWindowViewModel : ViewModelBaseClass
    {
        private string selectedSource;

        public string SelectedSource
        {
            get
            {
                selectedSource = Properties.Settings.Default.storedDataSource;
                return selectedSource;
            }
            set
            {
                selectedSource = value;
                OnPropertyChanged("SelectedSource");
            }
        }

        private string selectedLanguage;
        
        public string SelectedLanguage
        {
            get
            {
                return selectedLanguage;
            }

            set
            {
                selectedLanguage = value;
                OnPropertyChanged();
            }
        }

        

    }
}
