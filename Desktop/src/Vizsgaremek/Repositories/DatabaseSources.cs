using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vizsgaremek.Models;

namespace Vizsgaremek.Repositories
{
    class DatabaseSources
    {
        private List<DatabaseSource> databaseSourcesItems;
        private DatabaseSource storedSelectedSource;

        public DatabaseSource StoredSelectedSource { get => storedSelectedSource; set => storedSelectedSource = value; }

        public DatabaseSources()
        {
            StoredSelectedSource = new DatabaseSource()
            {
                Name = Properties.Settings.Default.storedDataSource,
                ToolTip = Properties.Settings.Default.storedDataSource,
            };

            if (StoredSelectedSource.Name == "test")
            {
                databaseSourcesItems = new List<DatabaseSource>();
                databaseSourcesItems.Add(new DatabaseSource()
                {
                    Name = "test",
                    ToolTip = "test"
                });
                databaseSourcesItems.Add(new DatabaseSource()
                {
                    Name = "localhost",
                    ToolTip = "localhost"
                });
                databaseSourcesItems.Add(new DatabaseSource()
                {
                    Name = "devops",
                    ToolTip = "devops.vasvari.hu"
                });

            }
            else
            {
                databaseSourcesItems = new List<DatabaseSource>();
                ApplicationConfigurations appConfigRepo = new ApplicationConfigurations();
                Dictionary<string, string> allPossibleDatabaseSources = new Dictionary<string, string>();
                allPossibleDatabaseSources = appConfigRepo.DatabaseSources;
                foreach (KeyValuePair<string, string> possibleDatabaseSource in allPossibleDatabaseSources)
                {
                    DatabaseSource item = new DatabaseSource()
                    {
                        Name = possibleDatabaseSource.Key,
                        ToolTip = possibleDatabaseSource.Value
                    };
                    databaseSourcesItems.Add(item);
                }
            }
        }

        public List<DatabaseSource> GetAllDatabaseSources()
        {
            return databaseSourcesItems;
        }
    }

}

