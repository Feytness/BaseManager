using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseManagerUI.Models
{
    internal abstract class Command
    {
        public string Action { get; set; }
        public List<string> AltNames { get; set; }
        public string[] Arguments { get; set; }
        public string Description { get; set; }

        public Command() 
        { 
        }

        public abstract GeneralResponse Execute(string[] arguments);

        public abstract GeneralResponse Validate(string[] arguments);

        public string ShowExample() => string.Join(" ", Arguments);
    }
}
