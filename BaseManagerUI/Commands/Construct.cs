using BaseManagerUI.Managers;
using BaseManagerUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseManagerUI.Commands
{
    internal class Construct : Command
    {
        public Construct() : base()
        {
            Action = nameof(Construct);
            Arguments = new[] { Action, "<ConstructionName>", "<Position>" };
            Description = "Place a building/item on the selected space";
            AltNames = new List<string>()
            {
                "C",
                "CON"
            };
        }

        public override GeneralResponse Execute(string[] arguments)
        {
            var item = BuildingManager.Building_GetOnName(arguments[1]);
            if (item.DisplayCharacter == null)
                return new GeneralResponse(false, "Construction does not exist");

            var pos = MapManager.GetCoordinates(arguments[2]);
            if(pos.Length != 2)
                return new GeneralResponse(false, "Invalid coordinates");

            var addBuildingtoGame = BuildingManager.AddActiveBuilding(item);
            if (addBuildingtoGame.IsSuccessful)
                MapManager.AddItem(item, pos);
            else
                return addBuildingtoGame;

            return new GeneralResponse(true, $"{item.Name} successfully built");
        }

        public override GeneralResponse Validate(string[] arguments)
        {
            if(arguments.Length != Arguments.Length || arguments.Any(x => x == string.Empty))
                return new(false, $"Not all arguments were supplied, please run command like this \r\n {ShowExample()}" );
            if (!MapManager.CheckIfSpaceAvailable(arguments[2]))
                return new(false, $"Unfortunately, the space you selected, {arguments[2]}, is already occupied");

            return new(true);
        }
    }
}
