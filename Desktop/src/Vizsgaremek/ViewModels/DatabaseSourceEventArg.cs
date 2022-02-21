using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vizsgaremek.ViewModels
{
    class DatabaseSourceEventArg : EventArgs
    {
        private string databaseSource;

        public DatabaseSourceEventArg(string databaseSource)
        {
            this.DatabaseSource = databaseSource;
        }

        public string DatabaseSource { get => databaseSource; set => databaseSource = value; }
    }
}
