using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vizsgaremek.Models
{
    public enum DbSource { NONE, LOCALHOST, DEVOPS }

    public class DatabaseSource
    {
        string name;
        string toolTip;
        DbSource dbSource;

        public string Name { get => name; set => name = value; }
        public string ToolTip { get => toolTip; set => toolTip = value; }

        public DbSource DbSource
        {
            get
            {
                if (name == "localhost")
                    return DbSource.LOCALHOST;
                else if (name == "devops")
                    return DbSource.DEVOPS;
                return DbSource.NONE;
            }
        }

        public DatabaseSource()
        { 
        }

        public DatabaseSource(string name, string tooltip)
        {
            this.name = name;
            this.toolTip = tooltip;
        }
    }
}
