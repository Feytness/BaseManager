using BaseManager.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseManager.Models
{
    internal class Building
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public WorldItemType Type { get; set; }
        public string DisplayCharacter { get; set; }
        public List<string> AltNames { get; set; }
        public List<Resource> ResourcesRequiredToBuild { get; set; }
        public List<Resource> ResourcesRequiredToRun { get; set; }
        public List<Resource> ResourcesGained { get; set; }
    }
}
