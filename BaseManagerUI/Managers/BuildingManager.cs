using BaseManager.Models;
using BaseManagerUI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BaseManagerUI.Managers
{
    internal static class BuildingManager
    {
        private static int _buildingIDCounter = 0;
        private static BuildingList _activeBuildings;
        private static BuildingList _buildingList;

        public static Building Building_GetOnName(string name)
        {
            if (_buildingList == null || _buildingList.Buildings == null)
                return new Building();

            return _buildingList.Buildings.Where(x => x.Name == name.ToUpper()).FirstOrDefault() ??
                _buildingList.Buildings.Where(x => x.AltNames.Contains(name.ToUpper())).FirstOrDefault() ??
                new Building();
        }

        public static BuildingList GetBuildings_Active() => _activeBuildings;
        public static BuildingList GetBuildings_All() => _buildingList;

        internal static void Initialize()
        {
            var settings = new JsonSerializerSettings
            {
                Converters = new[] { new StringEnumConverter() }
            };

            var jsonText = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "\\Resources\\Resource_Buildings.json");
            _buildingList = JsonConvert.DeserializeObject<BuildingList>(jsonText, settings);
            _buildingList.Names = new() { "AllBuildings", "AB", "Buildings" };
            _buildingList.Name = "All Buildings";

            _activeBuildings = new BuildingList(new() { "ConstructedBuildings", "CB", "Buildings" });
            _activeBuildings.Name = "Constructed Buildings";
        }

        internal static GeneralResponse AddActiveBuilding(Building building)
        {
            var playerResources = ResourceManager.GetCurrentResources();
            if (building.ResourcesRequiredToBuild.Any())
            {
                foreach (var reqRes in building.ResourcesRequiredToBuild)
                {
                    var localRes = playerResources.Resources.Where(x => x.Name == reqRes.Name).FirstOrDefault();
                    if (localRes.Quantity < reqRes.Quantity)
                        return new GeneralResponse(false, $"Insufficient resources, you require at least {reqRes.Quantity} {reqRes.Name} to build {building.Name}");
                }
            }

            building.Id = _buildingIDCounter++;
            _activeBuildings.Buildings.Add(building);

            return new GeneralResponse(true);
        }

        internal static void RemoveActiveBuilding(Building building)
        {
            _activeBuildings.Buildings.Remove(building);
        }
    }
}
