using BaseManager.Models;

namespace BaseManagerUI.Models
{
    internal class BuildingList : BaseObject
    {
        public string Name { get; set; }
        public List<Building> Buildings { get; set; }

        public BuildingList()
        {
            Buildings = new List<Building>();
        }
        public BuildingList(List<string> names)
        {
            Names = names;
        }

        public override string DisplayInfo()
        {
            string buildingInfo = $"{Name}: \r\n";

            if (Buildings != null)
            {
                foreach (Building b in Buildings)
                {
                    buildingInfo += $"ID: {b.Id}                Name: {b.Name} \r\n";
                    buildingInfo += $"Alt names:                {string.Join(',', b.AltNames)} \r\n";
                    buildingInfo += $"Resources Req to build:   \r\n";

                    if (b.ResourcesRequiredToBuild != null)
                        foreach (var item in b.ResourcesRequiredToBuild)
                        {
                            buildingInfo += $"{item.Name}               {item.Quantity} \r\n";
                        }
                    else
                        buildingInfo += "NONE \r\n";

                    buildingInfo += $"Resources Req to run:   \r\n";
                    if (b.ResourcesRequiredToRun != null)
                        foreach (var item in b.ResourcesRequiredToRun)
                        {
                            buildingInfo += $"{item.Name}               {item.Quantity} \r\n";
                        }
                    else
                        buildingInfo += "NONE \r\n";

                    buildingInfo += $"Resources gained:   \r\n";
                    if (b.ResourcesGained != null)
                        foreach (var item in b.ResourcesGained)
                        {
                            buildingInfo += $"{item.Name}               {item.Quantity} \r\n";
                        }
                    else
                        buildingInfo += "NONE \r\n";

                    buildingInfo += "\r\n";
                }
                buildingInfo += "================================== \r\n \r\n";
            }
            else
                buildingInfo += "NONE \r\n \r\n";

            return buildingInfo;
        }
    }
}
