using BaseManager.Models;
using BaseManagerUI.Models.Enums;
using BaseManagerUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace BaseManagerUI.Managers
{
    internal static class ResourceManager
    {
        private static ResourceList _resources;

        internal static ResourceList GetCurrentResources() => _resources;

        internal static void Initialize()
        {
            _resources = new ResourceList(new() { "Resources", "Resource", "R", "Res" });
            _resources.Resources = new List<Resource>()
            {
                new Resource(ResourceType.Wood, 100),
                new Resource(ResourceType.Iron, 10),
                new Resource(ResourceType.Oxygen, 100)
            };
        }

        internal static List<GeneralResponse> ManageResources()
        {
            var responses = new List<GeneralResponse>();
            var activeBuildings = BuildingManager.GetBuildings_Active();

            if (activeBuildings == null)
                responses.Add(new GeneralResponse(false));
            if (activeBuildings.Buildings == null)
                responses.Add(new GeneralResponse(false));
            if (responses.Count > 0)
                return responses;

            // Retrieve "free" resources
            var buildingsWithFreeResources = activeBuildings.Buildings.Where(x => x.ResourcesRequiredToRun == null).ToList();
            foreach (var building in buildingsWithFreeResources)
            {
                building.ResourcesGained.ForEach(res => _resources.Resources.FirstOrDefault(x => x.Name == res.Name).Quantity += res.Quantity);
            }

            // Retreive resources that require resources to get
            var buildingsWithReqResources = activeBuildings.Buildings.Where(x => x.ResourcesRequiredToRun != null).ToList();
            foreach (var building in buildingsWithReqResources)
            {
                var hasRequiredResources = true;
                foreach (var reqRes in building.ResourcesRequiredToRun)
                {
                    var localRes = _resources.Resources.Where(x => x.Name == reqRes.Name).FirstOrDefault();
                    if (localRes.Quantity < reqRes.Quantity)
                    {
                        responses.Add(new GeneralResponse(false, $"{building.Name} nr {building.Id} requires {reqRes.Quantity} {reqRes.Name} to be able to produce resources"));
                        hasRequiredResources = false;
                        break;
                    }
                }
                if (hasRequiredResources)
                {
                    building.ResourcesGained.ForEach(res => _resources.Resources.Where(x => x.Name == res.Name).FirstOrDefault().Quantity += res.Quantity);
                }
            }

            return responses;
        }
    }
}
