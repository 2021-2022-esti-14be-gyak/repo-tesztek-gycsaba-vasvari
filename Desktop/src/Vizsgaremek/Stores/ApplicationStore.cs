using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vizsgaremek.Models;

namespace Vizsgaremek.Stores
{
    public class ApplicationStore
    {
        private DbSource dbSource;
        private string language;    // A futó program nyelve

        public ApplicationStore()
        {
            this.DbSource = DbSource.NONE;
            this.language = "hu-HU";
        }

        public ApplicationStore(DbSource dbSource, string language)
        {
            this.DbSource = dbSource;
            this.Language = language;
        }

        public DbSource DbSource { get => dbSource; set => dbSource = value; }
        public string Language { get => language; set => language = value; }
    }
}
