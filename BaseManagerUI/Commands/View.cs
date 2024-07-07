using BaseManagerUI.Managers;
using BaseManagerUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseManagerUI.Commands
{
    internal class View : Command
    {
        public View() : base()
        {
            Action = nameof(View);
            Arguments = new[] { Action, "<Collection>" };
            Description = "View details on workers/buildings/resources";
            AltNames = new List<string>()
            {
                "V"
            };
        }

        public override GeneralResponse Execute(string[] arguments)
        {
            GeneralResponse response = new GeneralResponse(true);

            List<BaseObject> list = new List<BaseObject>()
            {
                BuildingManager.GetBuildings_Active(),
                BuildingManager.GetBuildings_All(),
            };

            var viewList = arguments[1].ToUpper() == "ALL" ? list : list.Where(x => x.Names.Contains(arguments[1], StringComparer.OrdinalIgnoreCase)).ToList();
            viewList.ForEach(x => response.Message += x.DisplayInfo());

            return response;
        }

        public override GeneralResponse Validate(string[] arguments)
        {
            if (arguments.Length <= 1 || arguments.Any(x => x == string.Empty))
                return new(false, $"Not all arguments were supplied, please run command like this \r\n {ShowExample()}");
            
            return new(true);
        }
    }
}
