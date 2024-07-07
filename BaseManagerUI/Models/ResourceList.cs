using BaseManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseManagerUI.Models
{
    internal class ResourceList : BaseObject
    {
        public List<Resource> Resources { get; set; }

        public ResourceList() 
        {
            Resources = new List<Resource>();
        }

        public ResourceList(List<string> names) 
        {
            Names = names;
            Resources = new List<Resource>();
        }

        public override string DisplayInfo()
        {
            string resourceInfo = string.Empty;

            foreach (var r in Resources)
            {
                resourceInfo += $"Resource          Qty \r\n";
                resourceInfo += $"{r.Name}          {r.Quantity} \r\n";
            }
            resourceInfo += "================================== \r\n \r\n";

            return resourceInfo;
        }
    }
}
